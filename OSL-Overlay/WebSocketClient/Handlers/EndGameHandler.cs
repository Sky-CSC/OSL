using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for "endGame" messages
    /// </summary>
    public class EndGameHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("EndGameHandler");

        /// <inheritdoc />
        public string Type => "endGame";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<LolEndOfGameEndOfGameStats>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame management");
            // TODO: Mangement of endGame data as needed
            return Task.CompletedTask;
        }
    }
}
