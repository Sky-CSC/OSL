using OSL_RGDP.Schema.Riot;
using OSL_Server.Services;
using OSL_Utils;

namespace OSL_Server.WebSocket.Handlers
{
    public class SpectatorCurentGameInfoByRiotId : IMessageHandler
    {
        private static readonly Logger _logger = new("SpectatorCurentGameInfoByRiotId");


        private readonly IServiceProvider _serviceProvider;

        public SpectatorCurentGameInfoByRiotId(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public string Type => "spectatorCurentGameInfoByRiotId";

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
                var json = data.Split("#");
                string gameName = json[0];
                string tagLine = json[1];
                _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🌍 Rune received: puiid :{json}");

                // Get data from OSL_RGDP
                AccountDto? accountDto = leagueClient.rgdp.Account.ByRiotId(gameName, tagLine);
                if (accountDto == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "HandleAsync()", "⚠️ Account dto data is null");
                    return;
                }
                CurrentGameInfo? curentGame = leagueClient.rgdp.Spectator.BySummoner(accountDto.Puuid);
                if (curentGame == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "HandleAsync()", "⚠️ Curent game data is null");
                    return;
                }
                CurrentGameInfo response = curentGame;
                await server.BroadcastAsync("spectatorCurentGameInfoByRiotId", response);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "HandleAsync()", $"❌ Error: {ex.Message}");
            }
        }
    }
}
