using OSL_Lcu;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Server.Phases
{
    /// <summary>
    /// Retrieves and syncs the champion selection phase from the League Client to a WebSocket server.
    /// </summary>
    /// <param name="lcuEndpoints">Endpoint</param>
    /// <param name="wsServer">Socket server</param>
    public class ChampSelect(LcuEndpoints lcuEndpoints, WebSocketServer.WebSocketServer wsServer)
    {
        private static readonly Logger _logger = new("ChampSelect");

        private readonly LcuEndpoints _lcuEndpoints = lcuEndpoints;
        private readonly WebSocketServer.WebSocketServer _wsServer = wsServer;

        /// <summary>
        /// Updates the WebSocket server with the current champion selection details from the League Client.
        /// </summary>
        public async Task SyncChampSelectAsync()
        {
            try
            {
                // Retrieve champion selection details from the League Client
                var gameflowPhase = await _lcuEndpoints.GetChampSelectAsync();
                if (gameflowPhase == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "SyncChampSelectAsync()", "❌ Failed to retrieve champ select.");
                    return;
                }
                _logger.Log(LoggingLevel.INFO, "SyncChampSelectAsync()", $"📊 Champ Select : {gameflowPhase}");
                // Send champ select details to the WebSocket server
                gameflowPhase = GameName(gameflowPhase);
                await _wsServer.SetChampSelectAsync(gameflowPhase);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "SyncChampSelectAsync()", $"❌ {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves the game names of players in the champion selection phase and updates the ChampSelectSession object accordingly.
        /// </summary>
        /// <param name="gameflowPhase"></param>
        /// <returns></returns>
        public ChampSelectSession GameName(ChampSelectSession gameflowPhase)
        {
            gameflowPhase.MyTeam = CheckTeamsSummonerNames(gameflowPhase.MyTeam);
            gameflowPhase.TheirTeam = CheckTeamsSummonerNames(gameflowPhase.TheirTeam);
            return gameflowPhase;
        }

        /// <summary>
        /// Checks the summoner names of players in a team and updates their GameName property if it is null or empty.
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<ChampSelectPlayerSelection> CheckTeamsSummonerNames(List<ChampSelectPlayerSelection> team)
        {
            foreach (var player in team)
            {
                if (!String.IsNullOrEmpty(player.GameName))
                {
                    continue;
                }
                var summoner = _lcuEndpoints.GetSummonerByIdAsync(player.SummonerId).Result;
                if (summoner != null)
                {
                    player.GameName = summoner.GameName;
                }
            }
            return team;
        }
    }
}
