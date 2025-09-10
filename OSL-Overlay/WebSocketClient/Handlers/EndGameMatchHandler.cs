using Newtonsoft.Json.Linq;
using OSL_RGDP.Schema.Riot;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "endGameMatch" message type.
    /// </summary>
    public class EndGameMatchHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("EndGameMatchHandler");

        /// <inheritdoc />
        public string Type => "endGameMatch";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<MatchDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame match management");
            // TODO: Process the MatchDto data as needed
            return Task.CompletedTask;
        }
    }
}
