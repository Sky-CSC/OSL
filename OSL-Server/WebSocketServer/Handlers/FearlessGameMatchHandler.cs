using Newtonsoft.Json;
using OSL_RGDP.Schema.Riot;
using OSL_RGDP.WebSocketResponse;
using OSL_Server.Services;
using OSL_Utils;

namespace OSL_Server.WebSocket.Handlers
{
    /// <summary>
    /// Example handler for the "skynet" message type.
    /// </summary>
    /// <remarks>
    /// When a client sends a message of type <c>skynet</c>, 
    /// this handler responds with a broadcast to all clients.
    /// </remarks>
    public class FearlessGameMatchHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("FearlessGameMatchHandler");


        private readonly IServiceProvider _serviceProvider;

        public FearlessGameMatchHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "fearlessGameMatch";

        /// <inheritdoc />
        public async Task HandleAsync(WebSocketServer server, System.Net.WebSockets.WebSocket client, object? rawData)
        {
            var leagueClient = _serviceProvider.GetRequiredService<LeagueClient>();

            try
            {
                var data = rawData?.ToString();
                if (data == null)
                {
                    _logger.Log(LoggingLevel.WARN, "HandleAsync()", "⚠️ Received null data");
                    return;
                }
                var json = JsonConvert.DeserializeObject<FearlessMatchId>(data);
                if (json == null)
                {
                    _logger.Log(LoggingLevel.WARN, "HandleAsync()", "⚠️ Deserialized data is null");
                    return;
                }
                _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🌍 Fearless received: Match id :{json.MatchId}, Index {json.Index}");

                // TODO : get data from OSL_RGDP
                MatchDto? match = leagueClient.rgdp.Match.Match(json.MatchId);
                if (match == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "HandleAsync()", "⚠️ Match data is null");
                    return;
                }
                FearlessMatchDto response = new(json.Index, match);
                await server.BroadcastAsync("fearlessGameMatch", response);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "HandleAsync()", $"❌ Error: {ex.Message}");
            }
        }
    }
}
