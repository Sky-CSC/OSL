using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_RGDP.Schema.Riot;
using OSL_Server.WebSocket.Handlers;
using OSL_Utils;
using OSL_Utils.WebSocket;
using System.Collections.Concurrent;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace OSL_Server.WebSocket
{
    /// <summary>
    /// Lightweight WebSocket server with authentication, 
    /// message dispatching, and stateful broadcasting.
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

        private readonly ConcurrentDictionary<Guid, System.Net.WebSockets.WebSocket> _clients = new();
        private readonly ConcurrentDictionary<Guid, bool> _authenticated = new();
        private readonly IEnumerable<IMessageHandler> _handlers;
        private readonly WebSocketConfig _config;

        // 🔹 Last known values to replay on reconnect
        private LolPublishingContentPubHubConfig? _regionLocale;
        private LolGameflowGameflowPhase? _gameFlowPhase;
        private ChampSelectSession? _champSelect;
        private LolEndOfGameEndOfGameStats? _endGame;
        private MatchDto? _endGameMatch;
        private TimelineDto? _endGameTimeline;

        /// <summary>
        /// Creates a new WebSocket server with configuration and handlers.
        /// </summary>
        public WebSocketServer(IOptions<WebSocketConfig> config, IEnumerable<IMessageHandler> handlers)
        {
            _config = config.Value;
            _handlers = handlers;
        }

        /// <summary>
        /// Starts the WebSocket server and listens for incoming connections.
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add($"http://{_config.Ip}:{_config.Port}/");
            httpListener.Start();

            _logger.Log(LoggingLevel.INFO, nameof(StartAsync), $"🚀 WebSocket Server started on ws://{_config.Ip}:{_config.Port}/");

            while (!cancellationToken.IsCancellationRequested)
            {
                var context = await httpListener.GetContextAsync();

                if (!context.Request.IsWebSocketRequest)
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                    continue;
                }

                var wsContext = await context.AcceptWebSocketAsync(null);
                var clientId = Guid.NewGuid();

                _clients[clientId] = wsContext.WebSocket;
                _authenticated[clientId] = false;

                _logger.Log(LoggingLevel.INFO, nameof(StartAsync), $"✅ Client connected : {clientId}");

                _ = HandleClientAsync(clientId, wsContext.WebSocket);
            }
        }

        /// <summary>
        /// Handles lifecycle of a client connection (recv loop + auth).
        /// </summary>
        private async Task HandleClientAsync(Guid clientId, System.Net.WebSockets.WebSocket webSocket)
        {
            var buffer = new byte[1024 * 1024];

            while (webSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Bye", CancellationToken.None);
                        _clients.TryRemove(clientId, out _);
                        _authenticated.TryRemove(clientId, out _);
                        _logger.Log(LoggingLevel.INFO, nameof(HandleClientAsync), $"❌ Client disconnected : {clientId}");
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var payload = JsonConvert.DeserializeObject<WebSocketMessage>(message);
                    if (payload == null) continue;

                    if (!_authenticated[clientId])
                    {
                        await HandleAuthenticationAsync(clientId, webSocket, payload);
                    }
                    else
                    {
                        var handler = _handlers.FirstOrDefault(h => h.Type == payload.Type);
                        if (handler != null)
                            await handler.HandleAsync(this, webSocket, payload.Data);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(HandleClientAsync), $"❌ Error client {clientId}: {ex.Message}");
                    _clients.TryRemove(clientId, out _);
                    _authenticated.TryRemove(clientId, out _);
                    break;
                }
            }
        }

        /// <summary>
        /// Authenticates a client by verifying token in the first message.
        /// </summary>
        private async Task HandleAuthenticationAsync(Guid clientId, System.Net.WebSockets.WebSocket webSocket, WebSocketMessage payload)
        {
            if (payload.Type == "auth" && payload.Data?.ToString() == _config.Token)
            {
                _authenticated[clientId] = true;
                await SendToClientAsync(webSocket, "auth_ok", "Bienvenue !");
                _logger.Log(LoggingLevel.INFO, nameof(HandleAuthenticationAsync), $"🔓 Client {clientId} authenticated");

                // Replay last known game state
                if (_regionLocale != null) await SendToClientAsync(webSocket, "regionLocale", _regionLocale);
                if (_gameFlowPhase != null) await SendToClientAsync(webSocket, "gameFlowPhase", _gameFlowPhase);
                if (_champSelect != null) await SendToClientAsync(webSocket, "champSelect", _champSelect);
                if (_endGame != null) await SendToClientAsync(webSocket, "endGame", _endGame);
                if (_endGameMatch != null) await SendToClientAsync(webSocket, "endGameMatch", _endGameMatch);
                if (_endGameTimeline != null) await SendToClientAsync(webSocket, "endGameTimeline", _endGameTimeline);
            }
            else
            {
                _logger.Log(LoggingLevel.WARN, nameof(HandleAuthenticationAsync), $"❌ Client {clientId} refused (bad token)");
                await webSocket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "Auth failed", CancellationToken.None);
                _clients.TryRemove(clientId, out _);
                _authenticated.TryRemove(clientId, out _);
            }
        }

        /// <summary>
        /// Sends a message to a single client.
        /// </summary>
        public async Task SendToClientAsync<T>(System.Net.WebSockets.WebSocket client, string type, T data)
        {
            var payload = JsonConvert.SerializeObject(BuildPayload(type, data));
            var bytes = Encoding.UTF8.GetBytes(payload);

            if (client.State == WebSocketState.Open)
                await client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        /// Broadcasts a message to all authenticated clients.
        /// </summary>
        public async Task BroadcastAsync<T>(string type, T data)
        {
            var payload = JsonConvert.SerializeObject(BuildPayload(type, data));
            var bytes = Encoding.UTF8.GetBytes(payload);

            foreach (var (id, client) in _clients)
            {
                if (_authenticated.TryGetValue(id, out var isAuth) && isAuth && client.State == WebSocketState.Open)
                {
                    await client.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        // 🔹 State setters (store + broadcast)

        /// <summary>Updates region/locale and broadcasts it.</summary>
        public async Task SetRegionLocaleAsync(LolPublishingContentPubHubConfig data)
        {
            _regionLocale = data;
            await BroadcastAsync("regionLocale", data);
        }

        /// <summary>Updates gameflow phase and broadcasts it.</summary>
        public async Task SetGameFlowPhaseAsync(LolGameflowGameflowPhase? data)
        {
            _gameFlowPhase = data;
            await BroadcastAsync("gameFlowPhase", data);
        }

        /// <summary>Updates champ select state and broadcasts it.</summary>
        public async Task SetChampSelectAsync(ChampSelectSession? data)
        {
            _champSelect = data;
            await BroadcastAsync("champSelect", data);
        }

        /// <summary>Updates endgame stats and broadcasts them.</summary>
        public async Task SetEndGameAsync(LolEndOfGameEndOfGameStats? data)
        {
            _endGame = data;
            await BroadcastAsync("endGame", data);
        }

        /// <summary>Updates endgame match data and broadcasts it.</summary>
        public async Task SetEndGameMatchAsync(MatchDto? data)
        {
            _endGameMatch = data;
            await BroadcastAsync("endGameMatch", data);
        }

        /// <summary>Updates endgame timeline and broadcasts it.</summary>
        public async Task SetEndGameTimelineAsync(TimelineDto? data)
        {
            _endGameTimeline = data;
            await BroadcastAsync("endGameTimeline", data);
        }

        /// <summary>
        /// Creates a standard WebSocket payload with type and data.
        /// </summary>
        private static object BuildPayload(string type, object data) =>
            new { type, data = JToken.FromObject(data) };
    }
}
