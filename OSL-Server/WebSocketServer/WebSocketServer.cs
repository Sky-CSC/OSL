using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_RGDP.Schema.Riot;
using OSL_Server.WebSocketServer.Handlers;
using OSL_Utils;
using OSL_Utils.WebSocket;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace OSL_Server.WebSocketServer
{

    public enum WebSocketServerState
    {
        Stopped,
        Starting,
        Running,
        Restarting,
        Stopping
    }

    /// <summary>
    /// A WebSocket server that handles client connections, authentication, and message broadcasting.
    /// </summary>
    /// <remarks>
    /// Features:
    /// <list type="bullet">
    /// <item>Authentication with token.</item>
    /// <item>Support for typed message handlers.</item>
    /// <item>Stores last known game state and replays it on client reconnect.</item>
    /// <item>Broadcast to all authenticated clients.</item>
    /// </list>
    /// </remarks>
    public class WebSocketServer
    {
        private static readonly Logger _logger = new("WebSocketServer");

        private static readonly TimeSpan AuthTimeout = TimeSpan.FromSeconds(10);

        private readonly ConcurrentDictionary<Guid, WebSocketClientInfo> _clients = new();
        private readonly IEnumerable<IMessageHandler> _handlers;

        private (HttpListener Listener, CancellationTokenSource Cts)? _currentServer;
        private readonly SemaphoreSlim _serverLifecycleLock = new(1, 1);

        public WebSocketConfig Config { get; private set; }
        public readonly string ConfigFilePath;
        public event Action? OnChange;
        public IReadOnlyList<WebSocketClientInfo> Clients => [.. _clients.Values.OrderBy(x => x.ConnectedAt)];
        public WebSocketServerState State { get; private set; } = WebSocketServerState.Stopped;
        public void NotifyStateChanged() => OnChange?.Invoke();


        // Last known values to replay on reconnect
        private LolPublishingContentPubHubConfig? _regionLocale;
        private LolGameflowGameflowPhase? _gameFlowPhase;
        private ChampSelectSession? _champSelect;
        private LolEndOfGameEndOfGameStats? _endGame;
        private MatchDto? _endGameMatch;
        private TimelineDto? _endGameTimeline;

        /// <summary>
        /// Creates a new WebSocket server with configuration and handlers.
        /// </summary>
        public WebSocketServer(IEnumerable<IMessageHandler> handlers)
        {
            ConfigFilePath = OSL_Utils.Path.Combine(".", "WebSocketServer", "WebSocketServerConfig.json");
            Config = WebSocketConfigService.Load(ConfigFilePath);
            _handlers = handlers;
        }

        /// <summary>
        /// Starts the WebSocket server and listens for incoming connections.
        /// This method is intended to be called once (e.g. from a BackgroundService).
        /// Use RestartAsync() to apply configuration changes at runtime.
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            SetState(WebSocketServerState.Starting);

            var internalCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            var listener = new HttpListener();
            listener.Prefixes.Add($"http://{Config.Ip}:{Config.Port}/");

            await _serverLifecycleLock.WaitAsync(cancellationToken);

            try
            {
                // Arrête proprement l'instance précédente avant d'en démarrer une nouvelle.
                await StopCurrentServerAsync();

                listener.Start();
                _currentServer = (listener, internalCts);

                SetState(WebSocketServerState.Running);
            }
            finally
            {
                _serverLifecycleLock.Release();
            }

            _logger.Log(LoggingLevel.INFO, nameof(StartAsync), $"🚀 WebSocket Server started on ws://{Config.Ip}:{Config.Port}/");

            try
            {
                while (!internalCts.Token.IsCancellationRequested)
                {
                    HttpListenerContext context;
                    try
                    {
                        context = await listener.GetContextAsync().WaitAsync(internalCts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (HttpListenerException)
                    {
                        break;
                    }

                    if (!context.Request.IsWebSocketRequest)
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                        continue;
                    }

                    WebSocketContext wsContext;
                    try
                    {
                        wsContext = await context.AcceptWebSocketAsync(null);
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(StartAsync), $"❌ Failed to accept websocket: {ex.Message}");
                        continue;
                    }

                    var clientId = Guid.NewGuid();
                    _clients[clientId] = new WebSocketClientInfo
                    {
                        Id = clientId,
                        ConnectedAt = DateTime.UtcNow,
                        LastActivity = DateTime.UtcNow,
                        IpAddress = context.Request.RemoteEndPoint?.Address.ToString(),
                        Authenticated = false,
                        State = wsContext.WebSocket.State,
                        Socket = wsContext.WebSocket
                    };

                    NotifyStateChanged();
                    _logger.Log(LoggingLevel.INFO, nameof(StartAsync), $"✅ Client connected: {clientId}");

                    _ = HandleClientAsync(clientId, wsContext.WebSocket, internalCts.Token);
                }
            }
            finally
            {
                listener.Stop();
                listener.Close();
                internalCts.Dispose();
                _logger.Log(LoggingLevel.INFO, nameof(StartAsync), "🛑 WebSocket Server stopped");
                SetState(WebSocketServerState.Stopped);
            }
        }

        /// <summary>
        /// Stops the current WebSocket server instance and cleans up resources.
        /// </summary>
        /// <returns></returns>
        private async Task StopCurrentServerAsync()
        {
            SetState(WebSocketServerState.Stopping);

            if (_currentServer is not { } current)
                return;

            _logger.Log(LoggingLevel.INFO, nameof(StopCurrentServerAsync), "⏹ Stopping current server instance...");

            await current.Cts.CancelAsync();

            try
            {
                current.Listener.Stop();
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.WARN, nameof(StopCurrentServerAsync), $"Listener.Stop() failed: {ex.Message}");
            }

            var deadline = DateTime.UtcNow.AddSeconds(5);
            while (!_clients.IsEmpty && DateTime.UtcNow < deadline)
                await Task.Delay(50);

            current.Cts.Dispose();
            _currentServer = null;
            SetState(WebSocketServerState.Stopped);
        }

        /// <summary>
        /// Handles lifecycle of a client connection (recv loop + auth).
        /// </summary>
        private async Task HandleClientAsync(Guid clientId, System.Net.WebSockets.WebSocket webSocket, CancellationToken cancellationToken)
        {
            var buffer = System.Buffers.ArrayPool<byte>.Shared.Rent(1024 * 64);

            try
            {
                using var authCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                authCts.CancelAfter(AuthTimeout);

                while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    using var ms = new MemoryStream();
                    WebSocketReceiveResult result;

                    var activeToken = _clients.TryGetValue(clientId, out var ci) && ci.Authenticated
                        ? cancellationToken
                        : authCts.Token;

                    do
                    {
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), activeToken);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
                            return;
                        }

                        await ms.WriteAsync(buffer.AsMemory(0, result.Count), activeToken);
                    }
                    while (!result.EndOfMessage);

                    var message = Encoding.UTF8.GetString(ms.ToArray());

                    if (_clients.TryGetValue(clientId, out var client))
                    {
                        client.LastActivity = DateTime.UtcNow;
                        client.State = webSocket.State;
                    }

                    NotifyStateChanged();

                    _logger.Log(LoggingLevel.DEBUG, nameof(HandleClientAsync), $"📩 Received from {clientId}: {message}");

                    WebSocketMessage? payload;
                    try
                    {
                        payload = JsonConvert.DeserializeObject<WebSocketMessage>(message);
                    }
                    catch (JsonException ex)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(HandleClientAsync), $"❌ Invalid JSON from {clientId}: {ex.Message}");
                        continue;
                    }

                    if (payload == null)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(HandleClientAsync), $"❌ Null payload from {clientId}");
                        continue;
                    }

                    if (!_clients.TryGetValue(clientId, out var clientInfo))
                        break;

                    if (!clientInfo.Authenticated)
                    {
                        await HandleAuthenticationAsync(clientId, webSocket, payload, cancellationToken);
                    }
                    else
                    {
                        var handler = _handlers.FirstOrDefault(h => h.Type == payload.Type);
                        if (handler != null)
                        {
                            try
                            {
                                await handler.HandleAsync(this, webSocket, payload.Data);
                            }
                            catch (Exception ex)
                            {
                                _logger.Log(LoggingLevel.ERROR, nameof(HandleClientAsync), $"Handler '{handler.Type}' failed: {ex}");
                            }
                        }
                        else
                        {
                            _logger.Log(LoggingLevel.WARN, nameof(HandleClientAsync), $"⚠️ No handler for type '{payload.Type}' from {clientId}");
                        }
                    }
                }
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
                _logger.Log(LoggingLevel.WARN, nameof(HandleClientAsync), $"⏰ Auth timeout for client {clientId}");
                try {
                    await webSocket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "Auth timeout", CancellationToken.None);
                }
                catch { /* ignore */ }
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.INFO, nameof(HandleClientAsync), $"🛑 Client {clientId} cancelled");
            }
            catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
            {
                _logger.Log(LoggingLevel.INFO, nameof(HandleClientAsync), $"🔌 Client {clientId} disconnected abruptly");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(HandleClientAsync), $"❌ Error for client {clientId}: {ex.Message}");
            }
            finally
            {
                System.Buffers.ArrayPool<byte>.Shared.Return(buffer);

                try
                {
                    if (webSocket.State == WebSocketState.Open)
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disconnected", CancellationToken.None);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(HandleClientAsync), $"CloseAsync failed for {clientId}: {ex.Message}");
                }

                webSocket.Dispose();
                _clients.TryRemove(clientId, out _);
                NotifyStateChanged();
                _logger.Log(LoggingLevel.INFO, nameof(HandleClientAsync), $"🧹 Client cleaned: {clientId}");
            }
        }

        /// <summary>
        /// Authenticates a client by verifying token in the first message.
        /// </summary>
        private async Task HandleAuthenticationAsync(Guid clientId, System.Net.WebSockets.WebSocket webSocket, WebSocketMessage payload, CancellationToken cancellationToken)
        {
            var token = payload.Data?.ToString();

            if (payload.Type == "auth" && !string.IsNullOrWhiteSpace(token) && Config.Token.Contains(token))
            {
                if (_clients.TryGetValue(clientId, out var client))
                {
                    client.Authenticated = true;
                    client.LastActivity = DateTime.UtcNow;
                }

                NotifyStateChanged();
                await SendToClientAsync(webSocket, "auth_ok", "Welcome!");
                _logger.Log(LoggingLevel.INFO, nameof(HandleAuthenticationAsync), $"🔓 Client {clientId} authenticated");

                if (_regionLocale != null) await SendToClientAsync(webSocket, "regionLocale", _regionLocale);
                if (_gameFlowPhase != null) await SendToClientAsync(webSocket, "gameFlowPhase", _gameFlowPhase);
                if (_champSelect != null) await SendToClientAsync(webSocket, "champSelect", _champSelect);
                if (_endGame != null) await SendToClientAsync(webSocket, "endGame", _endGame);
                if (_endGameMatch != null) await SendToClientAsync(webSocket, "endGameMatch", _endGameMatch);
                if (_endGameTimeline != null) await SendToClientAsync(webSocket, "endGameTimeline", _endGameTimeline);
            }
            else
            {
                _logger.Log(LoggingLevel.WARN, nameof(HandleAuthenticationAsync), $"❌ Client {clientId} refused (bad token or wrong message type)");
                await webSocket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "Auth failed", CancellationToken.None);
                _clients.TryRemove(clientId, out _);
                NotifyStateChanged();
            }
        }

        /// <summary>
        /// Sends a message to a single client.
        /// </summary>
        public async Task SendToClientAsync<T>(System.Net.WebSockets.WebSocket socket, string type, T data)
        {
            var clientEntry = _clients.Values.FirstOrDefault(c => c.Socket == socket);

            if (socket.State != WebSocketState.Open)
                return;

            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(BuildPayload(type, data)));

            if (clientEntry != null)
            {
                await clientEntry.SendLock.WaitAsync();
                try
                {
                    if (socket.State != WebSocketState.Open)
                        return;

                    await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                catch (WebSocketException ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(SendToClientAsync), $"⚠️ Send failed: {ex.Message}");
                }
                catch (ObjectDisposedException)
                {
                    _logger.Log(LoggingLevel.DEBUG, nameof(SendToClientAsync), "Socket already disposed");
                }
                finally
                {
                    clientEntry.SendLock.Release();
                }
            }
            else
            {
                try
                {
                    await socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(SendToClientAsync), $"⚠️ Send (no lock) failed: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Broadcasts a message to all authenticated clients.
        /// </summary>
        public async Task BroadcastAsync<T>(string type, T data)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(BuildPayload(type, data)));
            var disconnectedClients = new ConcurrentBag<Guid>();

            var tasks = _clients
                .Where(x => x.Value.Authenticated && x.Value.Socket.State == WebSocketState.Open)
                .Select(async kvp =>
                {
                    await kvp.Value.SendLock.WaitAsync();
                    try
                    {
                        await kvp.Value.Socket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                        kvp.Value.LastActivity = DateTime.UtcNow;
                    }
                    catch (WebSocketException ex)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(BroadcastAsync), $"Broadcast failed for {kvp.Key}: {ex.Message}");
                        disconnectedClients.Add(kvp.Key);
                    }
                    catch (ObjectDisposedException)
                    {
                        disconnectedClients.Add(kvp.Key);
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(LoggingLevel.ERROR, nameof(BroadcastAsync), $"Unexpected error for {kvp.Key}: {ex}");
                        disconnectedClients.Add(kvp.Key);
                    }
                    finally
                    {
                        kvp.Value.SendLock.Release();
                    }
                });

            await Task.WhenAll(tasks);

            foreach (var clientId in disconnectedClients)
                _clients.TryRemove(clientId, out _);

            if (!disconnectedClients.IsEmpty)
                NotifyStateChanged();
        }

        /// <summary>
        /// Restarts the WebSocket server, closing all current connections and starting fresh.
        /// Called after a configuration change.
        /// </summary>
        /// <returns></returns>
        public async Task RestartAsync()
        {
            _logger.Log(LoggingLevel.INFO, nameof(RestartAsync), "🔄 Restarting WebSocket server...");
            SetState(WebSocketServerState.Restarting);

            await _serverLifecycleLock.WaitAsync();
            try
            {
                await StopCurrentServerAsync();
            }
            finally
            {
                _serverLifecycleLock.Release();
            }

            _ = Task.Run(() => StartAsync(CancellationToken.None));
        }

        /// <summary>
        /// Updates region/locale and broadcasts it.
        /// </summary>
        public async Task SetRegionLocaleAsync(LolPublishingContentPubHubConfig data)
        {
            _regionLocale = data;
            await BroadcastAsync("regionLocale", data);
        }

        /// <summary>
        /// Updates gameflow phase and broadcasts it.
        /// </summary>
        public async Task SetGameFlowPhaseAsync(LolGameflowGameflowPhase? data)
        {
            _gameFlowPhase = data;
            await BroadcastAsync("gameFlowPhase", data);
        }

        /// <summary>
        /// Updates champ select state and broadcasts it.
        /// </summary>
        public async Task SetChampSelectAsync(ChampSelectSession? data)
        {
            if (_champSelect != data)
            {
                _champSelect = data;
                await BroadcastAsync("champSelect", data);
            }
        }

        /// <summary>
        /// Updates endgame stats and broadcasts them.
        /// </summary>
        public async Task SetEndGameAsync(LolEndOfGameEndOfGameStats? data)
        {
            _endGame = data;
            await BroadcastAsync("endGame", data);
        }

        /// <summary>
        /// Updates endgame match data and broadcasts it.
        /// </summary>
        public async Task SetEndGameMatchAsync(MatchDto? data)
        {
            _endGameMatch = data;
            await BroadcastAsync("endGameMatch", data);
        }

        /// <summary>
        /// Updates endgame timeline and broadcasts it.
        /// </summary>
        public async Task SetEndGameTimelineAsync(TimelineDto? data)
        {
            _endGameTimeline = data;
            await BroadcastAsync("endGameTimeline", data);
        }

        /// <summary>
        /// Updates the WebSocket server configuration and restarts the server to apply changes.
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSocketConfig(WebSocketConfig config)
        {
            Config = config.Clone();
            WebSocketConfigService.SaveSocketConfig(Config, ConfigFilePath);
            await RestartAsync();
        }

        /// <summary>
        /// Creates a standard WebSocket payload with type and data.
        /// </summary>
        private static object BuildPayload(string type, object? data)
        {
            return new
            {
                type,
                data = data == null ? JValue.CreateNull() : JToken.FromObject(data)
            };
        }

        private void SetState(WebSocketServerState state)
        {
            if (State == state)
                return;

            State = state;
            NotifyStateChanged();
        }
    }
}
