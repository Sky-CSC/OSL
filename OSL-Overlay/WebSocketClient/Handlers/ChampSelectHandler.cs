using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "regionLocale" message type.
    /// </summary>
    public class ChampSelectHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("ChampSelectHandler");

        /// <inheritdoc />
        public string Type => "champSelect";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<ChampSelectSession>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Champ Select management");
            // TODO : Process the ChampSelectSession data as needed
            return Task.CompletedTask;
        }
    }
}
