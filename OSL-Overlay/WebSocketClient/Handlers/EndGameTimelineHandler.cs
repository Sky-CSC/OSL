using Newtonsoft.Json.Linq;
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

        /// <inheritdoc />
        public string Type => "endGameTimeline";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<TimelineDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame timeline management");
            // TODO: Process the TimelineDto data as needed
            return Task.CompletedTask;
        }
    }
}
