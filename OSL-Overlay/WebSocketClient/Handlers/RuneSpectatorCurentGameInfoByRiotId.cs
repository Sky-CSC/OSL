using Newtonsoft.Json.Linq;
using OSL_Overlay.GameFlow.Rune;
using OSL_RGDP.Schema.Riot;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "endGameMatch" message type.
    /// </summary>
    public class RuneSpectatorCurentGameInfoByRiotId : IMessageHandler
    {
        private static readonly Logger _logger = new("RuneSpectatorCurentGameInfoByRiotId");

        private readonly IServiceProvider _serviceProvider;

        public RuneSpectatorCurentGameInfoByRiotId(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "spectatorCurentGameInfoByRiotId";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var runeState = _serviceProvider.GetRequiredService<RuneState>();

            var data = jsonData.ToObject<CurrentGameInfo>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Runes match management");
            if (data != null)
                runeState.SetRunesSpectatorCurentGameInfo(data);

            return Task.CompletedTask;
        }
    }
}
