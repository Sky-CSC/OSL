using OSL_RGDP.Schema.Riot;
using OSL_Server.Services;
using OSL_Utils;

namespace OSL_Server.WebSocketServer.Handlers
{
    /// <summary>
    /// Example handler for the "endGameTimeline" message type.
    /// </summary>
    /// <remarks>
    /// When a client sends a message of type <c>skynet</c>, 
    /// this handler responds with a broadcast to all clients.
    /// </remarks>
    public class EndGameTimelineHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("EndGameTimelineHandler");


        private readonly IServiceProvider _serviceProvider;

        public EndGameTimelineHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "endGameTimeline";

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
                var json = Convert.ToInt64(data);
                _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🌍 End Game received: Timeline id :{json}");

                // Get data from OSL_RGDP
                TimelineDto? timeline = leagueClient.rgdp.Match.Timeline(json);
                if (timeline == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "HandleAsync()", "⚠️ Timeline data is null");
                    return;
                }
                TimelineDto response = timeline;
                await server.BroadcastAsync("endGameTimeline", response);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "HandleAsync()", $"❌ Error: {ex.Message}");
            }
        }
    }
}
