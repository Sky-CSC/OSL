using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;
using OSL_Overlay.GameFlow.ChampSelect;

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

        private readonly ChampSelectState _state;

        public ChampSelectHandler(ChampSelectState state)
        {
            _state = state;
        }

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<ChampSelectSession>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Champ Select management");
            // TODO : Process the ChampSelectSession data as needed
            _state.ManageSession(data!);

            return Task.CompletedTask;
        }
    }
}
