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

        /// <inheritdoc />
        public string Type => "endGameTimeline";

        private readonly EndGameState _state;

        public EndGameTimelineHandler(EndGameState state)
        {
            _state = state;
        }

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<TimelineDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame timeline management");
            //if (data != null)
            //    _state.SetTimeline(data);
            return Task.CompletedTask;
        }
    }
}
