using Newtonsoft.Json.Linq;
using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;
using OSL_Overlay.GameFlow.Fearless;
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

        private readonly IServiceProvider _serviceProvider;

        public EndGameMatchHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "endGameMatch";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var endGameState = _serviceProvider.GetRequiredService<EndGameState>();

            var data = jsonData.ToObject<MatchDto>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 EndGame match management");
            if (data != null)
                endGameState.SetMatch(data);

            return Task.CompletedTask;
        }
    }
}
