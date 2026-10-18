using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_RGDP.Schema.Riot;
using OSL_Server.WebSocketServer.Handlers;
using OSL_Utils;
using OSL_Utils.WebSocket;
using System.Buffers;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;

namespace OSL_Server.WebSocketServer
{
    /// <summary>
    /// State of the WebSocket server.
    /// </summary>
    public enum WebSocketServerState
    {
        Stopped,
        Starting,
        Running,
        Restarting,
        Stopping,
        /// <summary>The server could not start (port already used, invalid address...). See <see cref="WebSocketServer.LastError"/>.</summary>
        Faulted
    }

    /// <summary>
    /// WebSocket server used by the OSL-Overlay applications.
    /// <para>
    /// It runs in its own Kestrel instance, on the Ip/Port of its configuration: the administration UI can stay on
    /// loopback while the WebSocket port is open on the network. It is an <see cref="IHostedService"/>: it starts and stops with the
    /// application, and a failure to start (port busy...) is reported in <see cref="State"/> instead of crashing the application.
    /// </para>
    /// <para>
    /// Every message to a client goes through a bounded queue sent by a dedicated loop: a slow client never blocks the others
    /// (nor the code that publishes the state of the League client).
    /// </para>
    /// </summary>
    public class WebSocketServer : IHostedService
    {
        private static readonly Logger _logger = new("WebSocketServer");

        /// <summary>Largest message accepted from an authenticated client.</summary>
        private const int MaxMessageBytes = 1024 * 1024;

        /// <summary>Largest message accepted from a client that has not authenticated yet (only a token is expected).</summary>
        private const int MaxUnauthenticatedMessageBytes = 4 * 1024;

        /// <summary>State messages replayed, in this order, to a client when it authenticates.</summary>
        private static readonly string[] ReplayOrder =
        [
            MessageTypes.RegionLocale,
            MessageTypes.GameFlowPhase,
            MessageTypes.ChampSelect,
            MessageTypes.EndGame,
            MessageTypes.EndGameMatch,
            MessageTypes.EndGameTimeline,
        ];

        private readonly Dictionary<string, IMessageHandler> _handlers = new(StringComparer.Ordinal);
        private readonly ConcurrentDictionary<Guid, ClientConnection> _connections = new();
        private readonly SemaphoreSlim _lifecycleLock = new(1, 1);

        /// <summary>
        /// Guards the last known state and the broadcasts together: a client that connects gets the state and then the
        /// following changes in order, never an old state after a newer one.
        /// </summary>
        private readonly object _stateLock = new();
        private readonly Dictionary<string, byte[]> _lastMessages = new(StringComparer.Ordinal);
        private string? _champSelectFingerprint;

        private RunningHost? _host;

        private sealed record RunningHost(WebApplication App, CancellationTokenSource Cts);

        /// <summary>Wait for a client that does not authenticate before closing its connection.</summary>
        internal TimeSpan AuthTimeout { get; set; } = TimeSpan.FromSeconds(10);

        /// <summary>Interval of the WebSocket ping frames that detect dead connections.</summary>
        internal TimeSpan KeepAliveInterval { get; set; } = TimeSpan.FromSeconds(20);

        public WebSocketConfig Config { get; private set; }
        public readonly string ConfigFilePath;
        public event Action? OnChange;
        public IReadOnlyList<WebSocketClientInfo> Clients => [.. _connections.Values.Select(c => c.Info).OrderBy(info => info.ConnectedAt)];
        public WebSocketServerState State { get; private set; } = WebSocketServerState.Stopped;

        /// <summary>Why the server could not start (when <see cref="State"/> is <see cref="WebSocketServerState.Faulted"/>).</summary>
        public string? LastError { get; private set; }

        public void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// Creates a new WebSocket server with configuration and handlers.
        /// </summary>
        public WebSocketServer(IEnumerable<IMessageHandler> handlers)
        {
            ConfigFilePath = OSL_Utils.Path.Combine(".", "WebSocketServer", "WebSocketServerConfig.json");
            Config = WebSocketConfigService.Load(ConfigFilePath);

            foreach (IMessageHandler handler in handlers)
            {
                if (!_handlers.TryAdd(handler.Type, handler))
                    _logger.Log(LoggingLevel.WARN, nameof(WebSocketServer), $"⚠️ Several handlers for '{handler.Type}', only the first one is used");
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // Lifecycle
        // ---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Starts listening. Returns once the server is started (or failed to: see <see cref="State"/>); it never throws
        /// for a startup problem so that the rest of the application keeps running.
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _lifecycleLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (_host is null)
                    await StartHostAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _lifecycleLock.WaitAsync(CancellationToken.None).ConfigureAwait(false);
            try
            {
                await StopHostAsync(updateState: true).ConfigureAwait(false);
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        /// <summary>
        /// Stops the server (clients are disconnected, they reconnect by themselves) and starts it again with the current configuration.
        /// </summary>
        public async Task RestartAsync()
        {
            await _lifecycleLock.WaitAsync().ConfigureAwait(false);
            try
            {
                SetState(WebSocketServerState.Restarting);
                await StopHostAsync(updateState: false).ConfigureAwait(false);
                await StartHostAsync(CancellationToken.None).ConfigureAwait(false);
            }
            finally
            {
                _lifecycleLock.Release();
            }
        }

        /// <summary>
        /// Updates the WebSocket server configuration and restarts the server to apply changes.
        /// </summary>
        public async Task UpdateSocketConfig(WebSocketConfig config)
        {
            Config = config.Clone();
            WebSocketConfigService.SaveSocketConfig(Config, ConfigFilePath);
            await RestartAsync().ConfigureAwait(false);
        }

        private async Task StartHostAsync(CancellationToken cancellationToken)
        {
            SetState(WebSocketServerState.Starting);
            LastError = null;

            var stopSource = new CancellationTokenSource();
            WebApplication? app = null;
            try
            {
                WebSocketConfig config = Config;
                app = BuildHost(config, stopSource.Token);
                await app.StartAsync(cancellationToken).ConfigureAwait(false);

                _host = new RunningHost(app, stopSource);
                SetState(WebSocketServerState.Running);
                _logger.Log(LoggingLevel.INFO, nameof(StartHostAsync), $"✅ WebSocket server listening on ws://{config.Ip}:{config.Port}/");
            }
            catch (Exception ex) when (!cancellationToken.IsCancellationRequested)
            {
                LastError = ex.GetBaseException().Message;
                _logger.Log(LoggingLevel.ERROR, nameof(StartHostAsync), $"❌ WebSocket server could not start on {Config.Ip}:{Config.Port} : {LastError}");

                stopSource.Dispose();
                if (app is not null)
                    await app.DisposeAsync().ConfigureAwait(false);

                SetState(WebSocketServerState.Faulted);
            }
        }

        private async Task StopHostAsync(bool updateState)
        {
            RunningHost? host = _host;
            _host = null;
            if (host is null)
            {
                if (updateState && State != WebSocketServerState.Faulted)
                    SetState(WebSocketServerState.Stopped);
                return;
            }

            if (updateState)
                SetState(WebSocketServerState.Stopping);

            // Ends every connection loop: sockets are closed properly by the loops themselves.
            await host.Cts.CancelAsync().ConfigureAwait(false);

            using (var waitConnections = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
            {
                while (!_connections.IsEmpty && !waitConnections.IsCancellationRequested)
                    await Task.Delay(25).ConfigureAwait(false);
            }

            using (var stopTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
            {
                try
                {
                    await host.App.StopAsync(stopTimeout.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(StopHostAsync), "⚠️ WebSocket server took too long to stop");
                }
            }

            await host.App.DisposeAsync().ConfigureAwait(false);
            host.Cts.Dispose();

            if (updateState)
                SetState(WebSocketServerState.Stopped);
        }

        /// <summary>
        /// Builds a dedicated, minimal Kestrel host (it does not read the configuration of the main application, so it never
        /// takes the ports of the administration UI).
        /// </summary>
        private WebApplication BuildHost(WebSocketConfig config, CancellationToken stopToken)
        {
            WebApplicationBuilder builder = WebApplication.CreateEmptyBuilder(new WebApplicationOptions());
            builder.Services.AddLogging();
            builder.WebHost.UseKestrelCore();
            builder.WebHost.ConfigureKestrel(options =>
            {
                string address = (config.Ip ?? string.Empty).Trim();
                if (address.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                    options.ListenLocalhost(config.Port);
                else if (address is "" or "*" or "+" or "0.0.0.0")
                    options.ListenAnyIP(config.Port);
                else if (IPAddress.TryParse(address, out IPAddress? ipAddress))
                    options.Listen(ipAddress, config.Port);
                else
                    options.Listen(Dns.GetHostAddresses(address).First(), config.Port);
            });

            WebApplication app = builder.Build();
            app.UseWebSockets(new WebSocketOptions { KeepAliveInterval = KeepAliveInterval });
            app.Run(context => HandleRequestAsync(context, stopToken));
            return app;
        }

        // ---------------------------------------------------------------------------------------------------------
        // Connections
        // ---------------------------------------------------------------------------------------------------------

        private async Task HandleRequestAsync(HttpContext context, CancellationToken stopToken)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            // A token in the handshake (Authorization: Bearer ...) is checked BEFORE the connection is accepted:
            // a wrong token never gets a WebSocket. Older clients authenticate with their first message instead.
            bool authenticated = false;
            string? presented = GetBearerToken(context.Request);
            if (presented is not null)
            {
                if (!IsTokenValid(presented))
                {
                    _logger.Log(LoggingLevel.WARN, nameof(HandleRequestAsync), $"⛔ Connection from {context.Connection.RemoteIpAddress} refused: invalid token");
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
                authenticated = true;
            }

            using WebSocket socket = await context.WebSockets.AcceptWebSocketAsync().ConfigureAwait(false);
            await RunConnectionAsync(socket, context.Connection.RemoteIpAddress?.ToString(), authenticated, context.RequestAborted, stopToken).ConfigureAwait(false);
        }

        private async Task RunConnectionAsync(WebSocket socket, string? remoteAddress, bool authenticatedAtHandshake, CancellationToken requestAborted, CancellationToken stopToken)
        {
            var connection = new ClientConnection(socket, remoteAddress);
            _connections[connection.Info.Id] = connection;
            _logger.Log(LoggingLevel.INFO, nameof(RunConnectionAsync), $"🔌 Client connected: {connection.Info.Id} ({remoteAddress})");
            NotifyStateChanged();

            using var linked = CancellationTokenSource.CreateLinkedTokenSource(requestAborted, stopToken);
            CancellationToken cancellationToken = linked.Token;

            Task sendLoop = connection.RunSendLoopAsync(cancellationToken);
            Task watchdog = authenticatedAtHandshake ? Task.CompletedTask : WatchAuthenticationAsync(connection, linked, cancellationToken);
            // If writing fails, the whole connection ends.
            _ = sendLoop.ContinueWith(_ => CancelQuietly(linked), TaskScheduler.Default);

            try
            {
                if (authenticatedAtHandshake)
                    Authenticate(connection);

                await ReceiveLoopAsync(connection, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Server stopping or client gone.
            }
            catch (WebSocketException ex)
            {
                _logger.Log(LoggingLevel.DEBUG, nameof(RunConnectionAsync), $"Client {connection.Info.Id} connection lost : {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(RunConnectionAsync), $"❌ Client {connection.Info.Id} error : {ex}");
            }
            finally
            {
                // The send loop must be over before closing: only one send at a time is allowed on a socket.
                connection.CompleteOutbound();
                CancelQuietly(linked);
                await sendLoop.ConfigureAwait(false);
                await watchdog.ConfigureAwait(false);

                await CloseSocketAsync(connection).ConfigureAwait(false);

                _connections.TryRemove(connection.Info.Id, out _);
                connection.RefreshState();
                _logger.Log(LoggingLevel.INFO, nameof(RunConnectionAsync), $"🔌 Client disconnected: {connection.Info.Id}");
                NotifyStateChanged();
            }
        }

        private async Task ReceiveLoopAsync(ClientConnection connection, CancellationToken cancellationToken)
        {
            WebSocket socket = connection.Socket;

            while (socket.State == WebSocketState.Open)
            {
                bool authenticated = connection.Info.Authenticated;

                string? text;
                try
                {
                    text = await ReadTextMessageAsync(socket, authenticated ? MaxMessageBytes : MaxUnauthenticatedMessageBytes, cancellationToken).ConfigureAwait(false);
                }
                catch (MessageTooBigException)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(ReceiveLoopAsync), $"⛔ Client {connection.Info.Id} sent a message that is too big");
                    Close(connection, WebSocketCloseStatus.MessageTooBig, "Message too big");
                    return;
                }

                if (text is null)
                    return; // The client closed the connection.

                connection.Info.LastActivity = DateTime.UtcNow;
                if (!await ProcessMessageAsync(connection, text).ConfigureAwait(false))
                    return;
            }
        }

        /// <summary>
        /// Closes a connection that does not authenticate in time. The close frame is sent while the receive loop is waiting:
        /// cancelling a pending receive would abort the socket without any close frame.
        /// </summary>
        private async Task WatchAuthenticationAsync(ClientConnection connection, CancellationTokenSource connectionSource, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(AuthTimeout, cancellationToken).ConfigureAwait(false);
                if (connection.Socket.State != WebSocketState.Open || !connection.TryMarkTimedOut())
                    return;

                _logger.Log(LoggingLevel.WARN, nameof(WatchAuthenticationAsync), $"⏱️ Client {connection.Info.Id} did not authenticate in time");
                await connection.Socket.CloseOutputAsync(WebSocketCloseStatus.PolicyViolation, "Authentication timeout", cancellationToken).ConfigureAwait(false);

                // The client has 2 seconds to answer the close frame, then the connection is dropped.
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken).ConfigureAwait(false);
                CancelQuietly(connectionSource);
            }
            catch (Exception ex) when (ex is OperationCanceledException or WebSocketException or ObjectDisposedException)
            {
                // Connection already over.
            }
        }

        /// <returns>False when the connection must end.</returns>
        private async Task<bool> ProcessMessageAsync(ClientConnection connection, string text)
        {
            if (Logger.LogLevel >= LoggingLevel.DEBUG)
                _logger.Log(LoggingLevel.DEBUG, nameof(ProcessMessageAsync), $"📩 Received from {connection.Info.Id}: {text}");

            WebSocketMessage? message;
            try
            {
                message = JsonConvert.DeserializeObject<WebSocketMessage>(text);
            }
            catch (JsonException ex)
            {
                _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⚠️ Invalid message from {connection.Info.Id} : {ex.Message}");
                if (connection.Info.Authenticated)
                    return true;

                Close(connection, WebSocketCloseStatus.PolicyViolation, "Invalid message");
                return false;
            }

            if (!connection.Info.Authenticated)
            {
                string? token = message?.Type == MessageTypes.Auth ? message.Data?.ToString() : null;
                if (IsTokenValid(token))
                {
                    Authenticate(connection);
                    return true;
                }

                _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⛔ Client {connection.Info.Id} failed to authenticate");
                Close(connection, WebSocketCloseStatus.PolicyViolation, "Authentication failed");
                return false;
            }

            if (message?.Type is null)
                return true;

            // Clients that also send their token in a message (kept for servers that only read the message) are already authenticated here.
            if (message.Type == MessageTypes.Auth)
                return true;

            if (!_handlers.TryGetValue(message.Type, out IMessageHandler? handler))
            {
                _logger.Log(LoggingLevel.WARN, nameof(ProcessMessageAsync), $"⚠️ No handler for message type '{message.Type}'");
                return true;
            }

            try
            {
                await handler.HandleAsync(this, connection.Socket, message.Data).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(ProcessMessageAsync), $"❌ Handler '{message.Type}' failed : {ex}");
            }

            return true;
        }

        /// <summary>
        /// Marks the client as authenticated, then sends it "auth_ok" and the last known state. Done while holding the state lock,
        /// so no broadcast can slip between the replayed messages.
        /// </summary>
        private void Authenticate(ClientConnection connection)
        {
            lock (_stateLock)
            {
                if (!connection.TryMarkAuthenticated())
                    return;

                connection.RefreshState();

                connection.TryEnqueue(Serialize(MessageTypes.AuthOk, "Welcome!"));
                foreach (string type in ReplayOrder)
                {
                    if (_lastMessages.TryGetValue(type, out byte[]? payload))
                        connection.TryEnqueue(payload);
                }
            }

            _logger.Log(LoggingLevel.INFO, nameof(Authenticate), $"✅ Client authenticated: {connection.Info.Id}");
            NotifyStateChanged();
        }

        private static void Close(ClientConnection connection, WebSocketCloseStatus status, string description)
        {
            connection.CloseStatus = status;
            connection.CloseDescription = description;
        }

        private static async Task CloseSocketAsync(ClientConnection connection)
        {
            WebSocket socket = connection.Socket;
            if (socket.State is not (WebSocketState.Open or WebSocketState.CloseReceived))
                return;

            try
            {
                using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                await socket.CloseAsync(
                    connection.CloseStatus ?? WebSocketCloseStatus.NormalClosure,
                    connection.CloseDescription ?? "Closing",
                    timeout.Token).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is WebSocketException or OperationCanceledException or ObjectDisposedException)
            {
                // The client is already gone.
            }
        }

        private static async Task<string?> ReadTextMessageAsync(WebSocket socket, int maxBytes, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(8192);
            try
            {
                var message = new ArrayBufferWriter<byte>(1024);
                ValueWebSocketReceiveResult result;
                do
                {
                    result = await socket.ReceiveAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                        return null;

                    if (message.WrittenCount + result.Count > maxBytes)
                        throw new MessageTooBigException();

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

        private sealed class MessageTooBigException : Exception;

        private static void CancelQuietly(CancellationTokenSource source)
        {
            try
            {
                source.Cancel();
            }
            catch (ObjectDisposedException)
            {
            }
        }

        // ---------------------------------------------------------------------------------------------------------
        // Authentication
        // ---------------------------------------------------------------------------------------------------------

        private static string? GetBearerToken(HttpRequest request)
        {
            string? header = request.Headers.Authorization.FirstOrDefault();
            const string prefix = "Bearer ";
            if (header is null || !header.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return null;

            return header[prefix.Length..].Trim();
        }

        /// <summary>Compares the token with every configured one in constant time.</summary>
        private bool IsTokenValid(string? presented)
        {
            if (string.IsNullOrEmpty(presented))
                return false;

            byte[] candidate = Encoding.UTF8.GetBytes(presented);
            bool valid = false;
            foreach (string token in Config.Token)
                valid |= CryptographicOperations.FixedTimeEquals(candidate, Encoding.UTF8.GetBytes(token));

            return valid;
        }

        // ---------------------------------------------------------------------------------------------------------
        // Sending
        // ---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Sends a message to one client (queued, returns immediately).
        /// </summary>
        public Task SendToClientAsync<T>(System.Net.WebSockets.WebSocket socket, string type, T data)
        {
            ClientConnection? connection = _connections.Values.FirstOrDefault(c => ReferenceEquals(c.Socket, socket));
            if (connection is null || !connection.Info.Authenticated)
            {
                _logger.Log(LoggingLevel.WARN, nameof(SendToClientAsync), $"⚠️ Message '{type}' not sent: client unknown or not authenticated");
                return Task.CompletedTask;
            }

            connection.TryEnqueue(Serialize(type, data));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Sends a message to every authenticated client (queued, returns immediately). The message is serialised once.
        /// </summary>
        public Task BroadcastAsync<T>(string type, T data)
        {
            byte[] payload = Serialize(type, data);
            lock (_stateLock)
            {
                Publish(payload);
            }
            return Task.CompletedTask;
        }

        /// <summary>Must be called while holding the state lock.</summary>
        private void Publish(byte[] payload)
        {
            foreach (ClientConnection connection in _connections.Values)
            {
                if (connection.Info.Authenticated)
                    connection.TryEnqueue(payload);
            }
        }

        /// <summary>
        /// Stores the state (replayed to the clients that connect later) and sends it to the connected ones.
        /// </summary>
        private Task SetStateAsync(string type, object? data)
        {
            lock (_stateLock)
            {
                byte[] payload = Serialize(type, data);
                if (data is null)
                    _lastMessages.Remove(type);
                else
                    _lastMessages[type] = payload;

                Publish(payload);
            }
            return Task.CompletedTask;
        }

        public Task SetRegionLocaleAsync(LolPublishingContentPubHubConfig data) => SetStateAsync(MessageTypes.RegionLocale, data);

        public Task SetGameFlowPhaseAsync(LolGameflowGameflowPhase? data) => SetStateAsync(MessageTypes.GameFlowPhase, data);

        /// <summary>
        /// The session is only sent when it really changed (the timer values, different at each poll, are ignored).
        /// </summary>
        public Task SetChampSelectAsync(ChampSelectSession? data)
        {
            string? fingerprint = data is null ? null : ChampSelectFingerprint.Compute(data);

            lock (_stateLock)
            {
                if (fingerprint == _champSelectFingerprint)
                    return Task.CompletedTask;

                _champSelectFingerprint = fingerprint;
            }
            return SetStateAsync(MessageTypes.ChampSelect, data);
        }

        public Task SetEndGameAsync(LolEndOfGameEndOfGameStats? data) => SetStateAsync(MessageTypes.EndGame, data);

        public Task SetEndGameMatchAsync(MatchDto? data) => SetStateAsync(MessageTypes.EndGameMatch, data);

        public Task SetEndGameTimelineAsync(TimelineDto? data) => SetStateAsync(MessageTypes.EndGameTimeline, data);

        private sealed class Envelope<T>
        {
            [JsonProperty("type")]
            public string Type { get; init; } = string.Empty;

            [JsonProperty("data")]
            public T? Data { get; init; }
        }

        /// <summary>Standard payload {"type": ..., "data": ...}, serialised once.</summary>
        private static byte[] Serialize<T>(string type, T? data) =>
            Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Envelope<T> { Type = type, Data = data }));

        private void SetState(WebSocketServerState state)
        {
            if (State == state)
                return;

            State = state;
            NotifyStateChanged();
        }
    }
}
