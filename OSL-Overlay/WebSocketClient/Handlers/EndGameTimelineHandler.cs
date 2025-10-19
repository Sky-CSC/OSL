using Newtonsoft.Json.Linq;
using OSL_Overlay.GameFlow.EndGame;
using OSL_RGDP.Schema.Riot;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "endGameTimeline" message type.
    /// </summary>
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
        public Task HandleAsync(JToken jsonData)
        {
            var endGameState = _serviceProvider.GetRequiredService<EndGameState>();

            var data = jsonData.ToObject<TimelineDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame timeline management");
            if (data != null)
                endGameState.SetTimeline(data);
            return Task.CompletedTask;
        }
    }
}
