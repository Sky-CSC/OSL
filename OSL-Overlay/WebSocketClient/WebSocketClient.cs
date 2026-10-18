using Newtonsoft.Json;
using OSL_Overlay.WebSocketClient.Handlers;
using OSL_Utils;
using OSL_Utils.WebSocket;
using System.Buffers;
using System.Net.WebSockets;
using System.Text;

namespace OSL_Overlay.WebSocketClient
{
    /// <summary>
    /// Represents the connection state of the WebSocket client. It indicates whether the client is disconnected, connecting, connected, authenticating, authenticated, or reconnecting.
    /// </summary>
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Authenticating,
        Authenticated,
        Reconnecting
    }

    /// <summary>
    /// WebSocket client of the overlay: it connects to OSL-Server, dispatches the received messages to the handlers and reconnects
    /// by itself (waiting 2 s, then up to 30 s, again 2 s after a connection that worked).
    /// <para>
    /// One single background loop owns the connection. <see cref="RestartAsync"/> stops that loop, waits for it to be over, then starts a new one:
    /// two loops never run at the same time.
    /// </para>
    /// </summary>
    public sealed class WebSocketClient : IAsyncDisposable
    {
        private static readonly Logger _logger = new("WebSocketClient");

        /// <summary>Largest message accepted from the server (the timeline of a match can weigh several MB).</summary>
        private const int MaxMessageBytes = 64 * 1024 * 1024;

        private readonly Dictionary<string, IMessageHandler> _handlers = new(StringComparer.Ordinal);
        private readonly SemaphoreSlim _lifecycleLock = new(1, 1);
        private readonly SemaphoreSlim _sendLock = new(1, 1);

        private CancellationTokenSource? _runSource;
        private Task? _runTask;
        private volatile ClientWebSocket? _socket;

        /// <summary>True once the current attempt has connected (even if it ended with an error afterwards). Only the loop touches it.</summary>
        private bool _attemptConnected;

        /// <summary>Wait before the first reconnection attempt, doubled after each failure.</summary>
        internal TimeSpan ReconnectInitialDelay { get; set; } = TimeSpan.FromSeconds(2);

        /// <summary>Longest wait between two reconnection attempts.</summary>
        internal TimeSpan ReconnectMaxDelay { get; set; } = TimeSpan.FromSeconds(30);

        public ConnectionState State { get; private set; } = ConnectionState.Disconnected;
        public WebSocketConfig Config { get; private set; }
        public event Func<string, Task>? RawMessageReceived;
        public event Action? OnChange;
        public readonly string ConfigFilePath;
        public void NotifyStateChanged() => OnChange?.Invoke();

        private Uri ServerUri => new($"ws://{Config.Ip}:{Config.Port}/");

        /// <summary>
        /// Initializes a new instance of the WebSocketClient class with the specified message handlers. It loads the WebSocket configuration
        /// from the "WebSocketClient" directory. The configuration is used to establish a connection to the WebSocket server.
        /// </summary>
        public WebSocketClient(IEnumerable<IMessageHandler> handlers)
        {
            ConfigFilePath = OSL_Utils.Path.Combine(".", "WebSocketClient", "WebSocketServerConfig.json");
            Config = WebSocketConfigService.Load(ConfigFilePath);

            foreach (IMessageHandler handler in handlers)
            {
                if (!_handlers.TryAdd(handler.Type, handler))
                    _logger.Log(LoggingLevel.WARN, nameof(WebSocketClient), $"⚠️ Several handlers for '{handler.Type}', only the first one is used");
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // Lifecycle
        // ---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Starts the connection loop in the background and returns immediately. Does nothing if it is already running.
        /// </summary>
        public async Task ConnectAsync()
        {
            await _lifecycleLock.WaitAsync().ConfigureAwait(false);
            try
            {
                if (_runTask is { IsCompleted: false })
                    return;

                StartLoop();
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        /// <summary>
        /// Stops the connection, waits for the loop to be over, then connects again with the current configuration.
        /// </summary>
        public async Task RestartAsync()
        {
            await _lifecycleLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopLoopAsync().ConfigureAwait(false);
                StartLoop();
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        /// <summary>
        /// Updates the WebSocket configuration and restarts the connection with the new settings.
        /// </summary>
        public async Task UpdateSocketConfig(WebSocketConfig config)
        {
            Config = config.Clone();
            WebSocketConfigService.SaveSocketConfig(Config, ConfigFilePath);
            await RestartAsync().ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            await _lifecycleLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopLoopAsync().ConfigureAwait(false);
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        private void StartLoop()
        {
            var source = new CancellationTokenSource();
            _runSource = source;
            _runTask = Task.Run(() => RunAsync(source.Token));
        }

        /// <summary>Cancels the loop and waits until it is really over (the socket is closed and the state is final).</summary>
        private async Task StopLoopAsync()
        {
            CancellationTokenSource? source = _runSource;
            Task? task = _runTask;
            _runSource = null;
            _runTask = null;

            if (source is null || task is null)
            {
                SetState(ConnectionState.Disconnected);
                return;
            }

            await source.CancelAsync().ConfigureAwait(false);
            try
            {
                // Breaks a pending receive at once instead of waiting for the close handshake.
                _socket?.Abort();
            }
            catch (ObjectDisposedException)
            {
            }

            Task finished = await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(5))).ConfigureAwait(false);
            if (finished != task)
                _logger.Log(LoggingLevel.WARN, nameof(StopLoopAsync), "⚠️ The connection loop did not stop in time");

            source.Dispose();
            SetState(ConnectionState.Disconnected);
        }

        // ---------------------------------------------------------------------------------------------------------
        // Connection loop
        // ---------------------------------------------------------------------------------------------------------

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            TimeSpan delay = ReconnectInitialDelay;

            while (!cancellationToken.IsCancellationRequested)
            {
                _attemptConnected = false;
                try
                {
                    await ConnectAndReceiveAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(RunAsync), $"⚠️ Connection to {ServerUri} failed : {ex.GetBaseException().Message}");
                }

                if (cancellationToken.IsCancellationRequested)
                    break;

                // A connection that worked (even if it ended abruptly) gives the retry delay back its initial value.
                if (_attemptConnected)
                    delay = ReconnectInitialDelay;

                SetState(ConnectionState.Reconnecting);
                TimeSpan wait = delay + TimeSpan.FromMilliseconds(Random.Shared.NextDouble() * delay.TotalMilliseconds / 4);
                _logger.Log(LoggingLevel.INFO, nameof(RunAsync), $"🔄 Reconnecting in {wait.TotalSeconds:0.#} s");

                try
                {
                    await Task.Delay(wait, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }

                delay = TimeSpan.FromMilliseconds(Math.Min(delay.TotalMilliseconds * 2, ReconnectMaxDelay.TotalMilliseconds));
            }

            SetState(ConnectionState.Disconnected);
        }

        private async Task ConnectAndReceiveAsync(CancellationToken cancellationToken)
        {
            using var socket = new ClientWebSocket();
            socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);

            // The token goes in the handshake: the server refuses a wrong token before accepting the connection.
            string? token = Config.Token?.FirstOrDefault();
            if (!string.IsNullOrEmpty(token))
                socket.Options.SetRequestHeader("Authorization", $"Bearer {token}");

            SetState(ConnectionState.Connecting);
            _logger.Log(LoggingLevel.INFO, nameof(ConnectAndReceiveAsync), $"🔌 Connecting to {ServerUri}");

            using (var connectTimeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                connectTimeout.CancelAfter(TimeSpan.FromSeconds(10));
                await socket.ConnectAsync(ServerUri, connectTimeout.Token).ConfigureAwait(false);
            }

            _socket = socket;
            _attemptConnected = true;
            try
            {
                SetState(ConnectionState.Connected);
                _logger.Log(LoggingLevel.INFO, nameof(ConnectAndReceiveAsync), "✅ Connected");

                if (!string.IsNullOrEmpty(token))
                {
                    // The server already knows the token (handshake). This message is only for servers that wait for it, and is ignored by the others.
                    SetState(ConnectionState.Authenticating);
                    await SendAsync(MessageTypes.Auth, token, cancellationToken).ConfigureAwait(false);
                }

                await ReceiveLoopAsync(socket, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _socket = null;
                await CloseQuietlyAsync(socket).ConfigureAwait(false);
            }
        }

        private async Task ReceiveLoopAsync(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            while (socket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
            {
                string? text = await ReadTextMessageAsync(socket, cancellationToken).ConfigureAwait(false);
                if (text is null)
                {
                    _logger.Log(LoggingLevel.INFO, nameof(ReceiveLoopAsync), "🔌 Connection closed by the server");
                    return;
                }

                if (Logger.LogLevel >= LoggingLevel.DEBUG)
                    _logger.Log(LoggingLevel.DEBUG, nameof(ReceiveLoopAsync), $"📩 Received: {text}");

                await RaiseRawMessageReceivedAsync(text).ConfigureAwait(false);
                await ProcessMessageAsync(text).ConfigureAwait(false);
            }
        }

        private async Task ProcessMessageAsync(string text)
        {
            WebSocketMessage? message;
            try
            {
                message = JsonConvert.DeserializeObject<WebSocketMessage>(text);
            }
            catch (JsonException ex)
            {
                _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⚠️ Invalid message : {ex.Message}");
                return;
            }

            if (message?.Type is null)
                return;

            if (message.Type == MessageTypes.AuthOk)
            {
                SetState(ConnectionState.Authenticated);
                _logger.Log(LoggingLevel.INFO, nameof(ProcessMessageAsync), "🔐 Authenticated");
                return;
            }

            if (!_handlers.TryGetValue(message.Type, out IMessageHandler? handler))
            {
                _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⚠️ No handler for message type '{message.Type}'");
                return;
            }

            try
            {
                if (message.Data is null)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⚠️ Message '{message.Type}' without data");
                    return;
                }

                await handler.HandleAsync(message.Data).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(ProcessMessageAsync), $"❌ Handler '{message.Type}' failed : {ex}");
            }
        }

        private async Task RaiseRawMessageReceivedAsync(string text)
        {
            Func<string, Task>? subscribers = RawMessageReceived;
            if (subscribers is null)
                return;

            foreach (Func<string, Task> subscriber in subscribers.GetInvocationList().Cast<Func<string, Task>>())
            {
                try
                {
                    await subscriber(text).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(RaiseRawMessageReceivedAsync), $"❌ A RawMessageReceived handler failed : {ex.Message}");
                }
            }
        }

        private static async Task<string?> ReadTextMessageAsync(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(16 * 1024);
            try
            {
                var message = new ArrayBufferWriter<byte>(4096);
                ValueWebSocketReceiveResult result;
                do
                {
                    result = await socket.ReceiveAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                        return null;

                    if (message.WrittenCount + result.Count > MaxMessageBytes)
                        throw new InvalidDataException($"Message larger than {MaxMessageBytes / (1024 * 1024)} MB");

                    message.Write(buffer.AsSpan(0, result.Count));
                }
                while (!result.EndOfMessage);

                return Encoding.UTF8.GetString(message.WrittenSpan);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        private static async Task CloseQuietlyAsync(ClientWebSocket socket)
        {
            if (socket.State is not (WebSocketState.Open or WebSocketState.CloseReceived))
                return;

            try
            {
                using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", timeout.Token).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
            {
                // The connection is already gone.
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // Sending
        // ---------------------------------------------------------------------------------------------------------

        private sealed class Envelope
        {
            [JsonProperty("type")]
            public string Type { get; init; } = string.Empty;

            [JsonProperty("data")]
            public object? Data { get; init; }
        }

        /// <summary>
        /// Sends a message to the server. Does nothing (with a warning) when the client is not connected.
        /// Calls are serialised: a socket does not accept two sends at the same time.
        /// </summary>
        public async Task SendAsync(string type, object? data, CancellationToken? cancellationToken = null)
        {
            ClientWebSocket? socket = _socket;
            if (socket is not { State: WebSocketState.Open })
            {
                _logger.Log(LoggingLevel.WARN, nameof(SendAsync), "⚠️ WebSocket is not connected.");
                return;
            }

            CancellationToken token = cancellationToken ?? _runSource?.Token ?? CancellationToken.None;
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Envelope { Type = type, Data = data }));

            try
            {
                await _sendLock.WaitAsync(token).ConfigureAwait(false);
                try
                {
                    await socket.SendAsync(bytes.AsMemory(), WebSocketMessageType.Text, true, token).ConfigureAwait(false);
                }
                finally
                {
                    _sendLock.Release();
                }

                _logger.Log(LoggingLevel.INFO, nameof(SendAsync), $"📤 Sent message '{type}'");
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.WARN, nameof(SendAsync), "⚠️ Send cancelled");
            }
            catch (Exception ex) when (ex is WebSocketException or ObjectDisposedException or InvalidOperationException)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(SendAsync), $"❌ WebSocket send error: {ex.Message}");
            }
        }

        private void SetState(ConnectionState state)
        {
            if (State == state)
                return;

            State = state;
            NotifyStateChanged();
        }
    }
}
