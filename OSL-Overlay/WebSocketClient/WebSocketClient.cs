using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Overlay.WebSocketClient.Handlers;
using OSL_Utils;
using OSL_Utils.WebSocket;
using System.Net.WebSockets;
using System.Text;

namespace OSL_Overlay.WebSocketClient
{
    /// <summary>
    /// WebSocket client with automatic reconnection, authentication, 
    /// and pluggable message handlers for real-time communication.
    /// </summary>
    /// <remarks>
    /// Features:
    /// <list type="bullet">
    /// <item>Automatic reconnection with exponential backoff.</item>
    /// <item>Authentication on connect via token.</item>
    /// <item>Support for message handlers based on type.</item>
    /// <item>Graceful disposal of resources.</item>
    /// </list>
    /// </remarks>
    public class WebSocketClient : IAsyncDisposable
    {
        private ClientWebSocket _webSocket;
        private readonly CancellationTokenSource _cts = new();
        private readonly Uri _serverUri;
        private readonly IEnumerable<IMessageHandler> _handlers;
        private readonly WebSocketConfig _config;

        private static readonly Logger _logger = new("WebSocketClient");

        /// <summary>
        /// Raised when a raw JSON message is received.
        /// </summary>
        public event Func<string, Task>? OnMessageReceived;

        /// <summary>
        /// Creates a new WebSocket client with configuration and handlers.
        /// </summary>
        public WebSocketClient(IOptions<WebSocketConfig> config, IEnumerable<IMessageHandler> handlers)
        {
            _config = config.Value;
            _serverUri = new Uri($"ws://{_config.Ip}:{_config.Port}/");
            _handlers = handlers;
            _webSocket = new ClientWebSocket();
        }

        /// <summary>
        /// Starts the connection process. 
        /// If already connected or connecting, this call is ignored.
        /// </summary>
        public async Task ConnectAsync()
        {
            if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting)
            {
                _logger.Log(LoggingLevel.INFO, nameof(ConnectAsync), "⚡ Already connected or connecting");
                return;
            }

            _ = Task.Run(EnsureConnectedAsync); // run in background
        }

        /// <summary>
        /// Sends an object as JSON to the server.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if not connected.</exception>
        public async Task SendAsync(object message)
        {
            if (_webSocket.State != WebSocketState.Open)
                throw new InvalidOperationException("WebSocket is not connected.");

            var payload = JsonConvert.SerializeObject(message);
            var buffer = Encoding.UTF8.GetBytes(payload);

            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, _cts.Token);

            _logger.Log(LoggingLevel.DEBUG, nameof(SendAsync), $"📤 Sent: {payload}");
        }

        /// <summary>
        /// Main receive loop: reads messages, invokes event, and dispatches to handlers.
        /// </summary>
        private async Task ReceiveLoopAsync()
        {
            var buffer = new byte[1024 * 1024];

            try
            {
                while (_webSocket.State == WebSocketState.Open && !_cts.IsCancellationRequested)
                {
                    var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), _cts.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(ReceiveLoopAsync), "⚠️ Server closed connection");
                        break;
                    }

                    var messageJson = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    _logger.Log(LoggingLevel.DEBUG, nameof(ReceiveLoopAsync), $"📩 Received: {messageJson}");

                    if (OnMessageReceived != null)
                        await OnMessageReceived.Invoke(messageJson);

                    // Deserialize and dispatch
                    var wrapper = JsonConvert.DeserializeObject<WebSocketMessage>(messageJson);
                    if (wrapper != null && !string.IsNullOrEmpty(wrapper.Type))
                    {
                        var handler = _handlers.FirstOrDefault(h => h.Type == wrapper.Type);
                        if (handler != null)
                            await handler.HandleAsync(wrapper.Data);
                        else
                            _logger.Log(LoggingLevel.WARN, nameof(ReceiveLoopAsync), $"⚠️ No handler for type={wrapper.Type}");
                    }
                    else
                    {
                        _logger.Log(LoggingLevel.ERROR, nameof(ReceiveLoopAsync), "❌ Invalid message wrapper");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.INFO, nameof(ReceiveLoopAsync), "🛑 Receive loop cancelled");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(ReceiveLoopAsync), $"❌ Error: {ex.Message}");
            }

            await EnsureConnectedAsync();
        }

        /// <summary>
        /// Ensures connection to the server, with retry and authentication.
        /// </summary>
        public async Task EnsureConnectedAsync()
        {
            int delay = 2000; // start at 2s

            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    _webSocket.Dispose();
                    _webSocket = new ClientWebSocket();

                    _logger.Log(LoggingLevel.INFO, nameof(EnsureConnectedAsync), $"🔌 Connecting to {_serverUri} ...");

                    await _webSocket.ConnectAsync(_serverUri, _cts.Token);

                    if (_webSocket.State == WebSocketState.Open)
                    {
                        _logger.Log(LoggingLevel.INFO, nameof(EnsureConnectedAsync), $"✅ Connected to {_serverUri}");

                        // Send auth payload
                        await SendAsync(BuildPayload("auth", _config.Token));
                        _logger.Log(LoggingLevel.INFO, nameof(EnsureConnectedAsync), "🔑 Auth message sent");

                        _ = Task.Run(ReceiveLoopAsync);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(EnsureConnectedAsync), $"⚠️ Server not up yet: {ex.Message}");
                }

                _logger.Log(LoggingLevel.WARN, nameof(EnsureConnectedAsync), $"⏳ Retrying in {delay / 1000}s ...");
                await Task.Delay(delay, _cts.Token);

                delay = Math.Min(delay * 2, 30000); // exponential backoff max 30s
            }
        }

        /// <summary>
        /// Cleanly closes the connection and disposes of resources.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            try
            {
                if (_webSocket.State == WebSocketState.Open)
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disposed", _cts.Token);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.WARN, nameof(DisposeAsync), $"⚠️ Error while closing: {ex.Message}");
            }
            finally
            {
                _cts.Cancel();
                _cts.Dispose();
                _webSocket.Dispose();
            }

            _logger.Log(LoggingLevel.INFO, nameof(DisposeAsync), "🛑 Client disposed");
        }

        /// <summary>
        /// Creates a standard WebSocket payload with type and data.
        /// </summary>
        private static object BuildPayload(string type, object data) =>
            new { type, data = JToken.FromObject(data) };
    }
}
