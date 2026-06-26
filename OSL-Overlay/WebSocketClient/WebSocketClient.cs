using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Represents a WebSocket client that connects to a WebSocket server, handles messages, and manages connection state. It supports sending and receiving messages, authentication, and automatic reconnection. The client uses a configuration file to determine the server address and authentication token.
    /// </summary>
    public class WebSocketClient : IAsyncDisposable
    {
        private static readonly Logger _logger = new("WebSocketClient");

        private ClientWebSocket? _webSocket;

        private CancellationTokenSource _shutdown = new();

        private readonly SemaphoreSlim _connectLock = new(1, 1);

        private readonly IEnumerable<IMessageHandler> _handlers;
        private Uri ServerUri => new($"ws://{Config.Ip}:{Config.Port}/");

        public ConnectionState State { get; private set; } = ConnectionState.Disconnected;
        public WebSocketConfig Config { get; private set; }
        public event Func<string, Task>? RawMessageReceived;
        public event Action? OnChange;
        public readonly string ConfigFilePath;
        public void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// Initializes a new instance of the WebSocketClient class with the specified message handlers. It loads the WebSocket configuration from a JSON file located in the "WebSocketClient" directory relative to the application's base directory. The configuration is used to establish a connection to the WebSocket server.
        /// </summary>
        /// <param name="handlers"></param>
        public WebSocketClient(IEnumerable<IMessageHandler> handlers)
        {
            ConfigFilePath = OSL_Utils.Path.Combine(".", "WebSocketClient", "WebSocketServerConfig.json");
            Config = WebSocketConfigService.Load(ConfigFilePath);
            _handlers = handlers;
        }

        /// <summary>
        /// Initiates the connection to the WebSocket server in a background task. It calls EnsureConnectedAsync() to establish the connection and handle any exceptions that may occur during the process. This method returns immediately, allowing the connection process to run asynchronously without blocking the calling thread.
        /// </summary>
        /// <returns></returns>
        public Task ConnectAsync()
        {
            _ = Task.Run(async () =>
            {
                try
                {
                    await ConnectLoopAsync(_shutdown.Token);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(ConnectAsync), $"❌ Background connection error: {ex.Message}");
                }
            });

            return Task.CompletedTask;
        }

        /// <summary>
        /// Continuously attempts to connect to the WebSocket server until a successful connection is established or a shutdown is requested. It uses a semaphore to ensure that only one connection attempt is active at a time. If the connection fails, it retries with exponential backoff, logging the status of each attempt. Once connected, it authenticates (if a token is provided) and starts receiving messages. If the connection is lost, it transitions to the reconnecting state and continues attempting to reconnect.
        /// </summary>
        /// <param name="shutdownToken"></param>
        /// <returns></returns>
        private async Task ConnectLoopAsync(CancellationToken shutdownToken)
        {
            if (!await _connectLock.WaitAsync(0, shutdownToken))
            {
                _logger.Log(LoggingLevel.DEBUG, nameof(ConnectLoopAsync), "Connection loop already running, skipping.");
                return;
            }

            try
            {
                var delay = 2_000;

                while (!shutdownToken.IsCancellationRequested)
                {
                    try
                    {
                        SetState(ConnectionState.Connecting);

                        DisposeSocket();
                        _webSocket = new ClientWebSocket();

                        _logger.Log(LoggingLevel.INFO, nameof(ConnectLoopAsync), $"🔌 Connecting to {ServerUri} ...");
                        await _webSocket.ConnectAsync(ServerUri, shutdownToken);

                        SetState(ConnectionState.Connected);
                        _logger.Log(LoggingLevel.INFO, nameof(ConnectLoopAsync), $"✅ Connected to {ServerUri}");

                        await AuthenticateAsync(shutdownToken);

                        await ReceiveLoopAsync(shutdownToken);

                        if (!shutdownToken.IsCancellationRequested)
                        {
                            SetState(ConnectionState.Reconnecting);
                            _logger.Log(LoggingLevel.INFO, nameof(ConnectLoopAsync), "🔁 Connection lost, reconnecting...");
                        }
                    }
                    catch (OperationCanceledException) when (shutdownToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        SetState(ConnectionState.Reconnecting);
                        _logger.Log(LoggingLevel.WARN, nameof(ConnectLoopAsync), $"⚠️ Connection failed: {ex.Message}. Retry in {delay / 1000}s...");
                    }

                    if (shutdownToken.IsCancellationRequested)
                        break;

                    var jitter = Random.Shared.Next(500, 2_000);
                    try
                    {
                        await Task.Delay(delay + jitter, shutdownToken);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    delay = Math.Min(delay * 2, 30_000);
                }
            }
            finally
            {
                _connectLock.Release();
                SetState(ConnectionState.Disconnected);
                _logger.Log(LoggingLevel.INFO, nameof(ConnectLoopAsync), "🛑 Connect loop exited");
            }
        }

        private async Task AuthenticateAsync(CancellationToken cancellationToken)
        {
            var token = Config.Token?.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.Log(LoggingLevel.WARN, nameof(AuthenticateAsync), "⚠️ No authentication token configured");
                return;
            }

            SetState(ConnectionState.Authenticating);
            await SendAsync("auth", token, cancellationToken);
            _logger.Log(LoggingLevel.INFO, nameof(AuthenticateAsync), "🔑 Auth message sent, waiting for server confirmation...");
        }

        /// <summary>
        /// Continuously receives messages from the WebSocket connection. It reads messages in a loop until the connection is closed, an error occurs, or a cancellation is requested. For each received message, it logs the message, raises the RawMessageReceived event, and dispatches the message to the appropriate handler. If the server closes the connection or an error occurs, it exits the loop and allows for reconnection attempts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
        {
            var buffer = ArrayPool<byte>.Shared.Rent(64 * 1024);

            try
            {
                while (!cancellationToken.IsCancellationRequested && _webSocket?.State == WebSocketState.Open)
                {
                    var messageJson = await ReceiveMessageAsync(buffer, cancellationToken);

                    if (messageJson == null)
                    {
                        _logger.Log(LoggingLevel.INFO, nameof(ReceiveLoopAsync), "🔌 Server closed the connection");
                        break;
                    }

                    _logger.Log(LoggingLevel.DEBUG, nameof(ReceiveLoopAsync), $"📩 Received: {messageJson}");

                    await RaiseMessageReceivedAsync(messageJson);
                    await DispatchMessageAsync(messageJson);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.Log(LoggingLevel.INFO, nameof(ReceiveLoopAsync), "🛑 Receive loop cancelled");
            }
            catch (WebSocketException ex)
            {
                _logger.Log(LoggingLevel.INFO, nameof(ReceiveLoopAsync), $"🔌 WebSocket error: {ex.WebSocketErrorCode} - {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(ReceiveLoopAsync), $"❌ Unexpected error: {ex}");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Receives a complete message from the WebSocket connection. It reads data into the provided buffer until the end of the message is reached. If the server closes the connection or an error occurs, it returns null. The received message is returned as a UTF-8 encoded string.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<string?> ReceiveMessageAsync(byte[] buffer, CancellationToken cancellationToken)
        {
            var socket = _webSocket;
            if (socket == null)
                return null;

            using var stream = new MemoryStream();

            while (true)
            {
                WebSocketReceiveResult result;
                try
                {
                    result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
                }
                catch (WebSocketException ex)
                {
                    _logger.Log(LoggingLevel.INFO, nameof(ReceiveMessageAsync), $"🔌 Receive error: {ex.WebSocketErrorCode}");
                    return null;
                }

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    try
                    {
                        await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Acknowledged", CancellationToken.None);
                    }
                    catch { /* ignore : socket possibely already close */ }
                    return null;
                }

                await stream.WriteAsync(buffer.AsMemory(0, result.Count), cancellationToken);

                if (result.EndOfMessage)
                    break;
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Sends a message to the WebSocket server with the specified type and data. The message is serialized to JSON before sending. If the WebSocket is not connected, it logs a warning and returns without sending. Any exceptions during the send operation are caught and logged.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SendAsync(string type, object? data, CancellationToken? cancellationToken = null)
        {
            var token = cancellationToken ?? _shutdown.Token;

            if (_webSocket?.State != WebSocketState.Open)
            {
                _logger.Log(LoggingLevel.WARN, nameof(SendAsync), "⚠️ WebSocket is not connected.");
                return;
            }

            var payload = JsonConvert.SerializeObject(BuildPayload(type, data));
            var bytes = Encoding.UTF8.GetBytes(payload);

            try
            {
                await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, token);
                _logger.Log(LoggingLevel.INFO, nameof(SendAsync), $"📤 Sent: {payload}");
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.WARN, nameof(SendAsync), "⚠️ Send cancelled");
            }
            catch (WebSocketException ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(SendAsync), $"❌ WebSocket send error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(SendAsync), $"❌ Unexpected send error: {ex.Message}");
            }
        }

        /// <summary>
        /// Dispatches the received message to the appropriate handler based on its type. If no handler is found for the message type, a warning is logged. If the handler throws an exception, it is caught and logged as an error.
        /// </summary>
        /// <param name="messageJson"></param>
        /// <returns></returns>
        private async Task DispatchMessageAsync(string messageJson)
        {
            WebSocketMessage? message;
            try
            {
                message = JsonConvert.DeserializeObject<WebSocketMessage>(messageJson);
            }
            catch (JsonException ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(DispatchMessageAsync), $"❌ JSON parse error: {ex.Message}");
                return;
            }

            if (message == null || string.IsNullOrWhiteSpace(message.Type))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(DispatchMessageAsync), "❌ Invalid message (null or no type)");
                return;
            }

            if (message.Type == "auth_ok")
            {
                SetState(ConnectionState.Authenticated);
                _logger.Log(LoggingLevel.INFO, nameof(DispatchMessageAsync), "🔓 Authenticated by server");
                return;
            }

            var handler = _handlers.FirstOrDefault(h => h.Type == message.Type);
            if (handler == null)
            {
                _logger.Log(LoggingLevel.WARN, nameof(DispatchMessageAsync), $"⚠️ No handler for type='{message.Type}'");
                return;
            }

            try
            {
                if (message.Data is JToken data)
                {
                    await handler.HandleAsync(data);
                }
                else
                {
                    _logger.Log(LoggingLevel.WARN, nameof(DispatchMessageAsync), $"⚠️ Data is not a JToken for type='{message.Type}'");
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(DispatchMessageAsync), $"❌ Handler '{handler.GetType().Name}' failed: {ex}");
            }
        }

        /// <summary>
        /// Raises the RawMessageReceived event with the received message JSON. If there are no subscribers to the event, it simply returns. If an exception occurs while invoking the event, it is caught and logged as an error.
        /// </summary>
        /// <param name="messageJson"></param>
        /// <returns></returns>
        private async Task RaiseMessageReceivedAsync(string messageJson)
        {
            if (RawMessageReceived == null)
                return;
            try
            {
                await RawMessageReceived.Invoke(messageJson);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(RaiseMessageReceivedAsync), $"❌ RawMessageReceived handler failed: {ex}");
            }
        }

        /// <summary>
        /// Gracefully restarts the WebSocket client by cancelling any ongoing operations, closing the current socket, and starting a new connection loop. This method is useful when the configuration has changed (e.g., IP, port, token) and a fresh connection is needed. It logs the restart process and handles any exceptions that may occur during the restart.
        /// </summary>
        /// <returns></returns>
        public async Task RestartAsync()
        {
            _logger.Log(LoggingLevel.INFO, nameof(RestartAsync), "🔄 Restarting WebSocket client...");

            await _shutdown.CancelAsync();
            _shutdown.Dispose();

            DisposeSocket();

            SetState(ConnectionState.Disconnected);

            _shutdown = new CancellationTokenSource();

            _logger.Log(LoggingLevel.INFO, nameof(RestartAsync), $"🔌 Reconnecting to {ServerUri}...");
            _ = Task.Run(async () =>
            {
                try
                {
                    await ConnectLoopAsync(_shutdown.Token);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(RestartAsync), $"❌ Restart error: {ex.Message}");
                }
            });
        }

        /// <summary>
        /// Updates the WebSocket configuration and restarts the connection. This method is typically called when the configuration file changes, allowing the client to reconnect with the new settings.
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSocketConfig(WebSocketConfig config)
        {
            Config = config.Clone();
            WebSocketConfigService.SaveSocketConfig(Config, ConfigFilePath);
            await RestartAsync();
        }

        /// <summary>
        /// Sets the connection state and notifies subscribers if it has changed.
        /// </summary>
        /// <param name="state"></param>
        private void SetState(ConnectionState state)
        {
            if (State == state)
                return;

            State = state;
            NotifyStateChanged();
        }

        /// <summary>
        /// Disposes of the current WebSocket instance if it exists. This method is called before creating a new WebSocket connection to ensure that any existing connection is properly cleaned up. It logs any exceptions that occur during disposal and sets the WebSocket reference to null.
        /// </summary>
        private void DisposeSocket()
        {
            try
            {
                _webSocket?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.WARN, nameof(DisposeSocket), $"⚠️ Error disposing socket: {ex.Message}");
            }
            _webSocket = null;
        }

        /// <summary>
        /// Builds a payload object with the specified type and data. The data is converted to a JToken for JSON serialization. If the data is null, it creates a JValue representing null. This method is used to prepare messages for sending over the WebSocket connection.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static object BuildPayload(string type, object? data)
        {
            return new
            {
                type,
                data = data == null ? JValue.CreateNull() : JToken.FromObject(data)
            };
        }

        /// <summary>
        /// Asynchronously disposes of the WebSocket client, closing the connection and releasing resources. It cancels any ongoing operations, closes the WebSocket if it is open, and disposes of the semaphore and cancellation token source. This method should be called when the client is no longer needed to ensure proper cleanup.
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            SetState(ConnectionState.Disconnected);

            await _shutdown.CancelAsync();

            if (_webSocket?.State == WebSocketState.Open)
            {
                try
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disposed", CancellationToken.None);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(DisposeAsync), $"⚠️ Close on dispose failed: {ex.Message}");
                }
            }

            _webSocket?.Dispose();
            _connectLock.Dispose();
            _shutdown.Dispose();

            GC.SuppressFinalize(this);
            _logger.Log(LoggingLevel.INFO, nameof(DisposeAsync), "🛑 WebSocketClient disposed");
        }
    }
}
