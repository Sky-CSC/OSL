using OSL_Lcu;
using OSL_RGDP;
using OSL_Utils;

namespace OSL_Server.Phases
{
    /// <summary>
    /// Retrieves and syncs the end game phase from the League Client to a WebSocket server.
    /// </summary>
    /// <param name="lcuEndpoints">Endpoint</param>
    /// <param name="wsServer">Web socket server</param>
    /// <param name="rgdp">Riot Game Develeloper Portal</param>
    public class EndGame(LcuEndpoints lcuEndpoints, WebSocketServer.WebSocketServer wsServer, RiotGameDeveloperPortal rgdp)
    {
        private static readonly Logger _logger = new("GameFlow");

        private readonly LcuEndpoints _lcuEndpoints = lcuEndpoints;
        private readonly WebSocketServer.WebSocketServer _wsServer = wsServer;
        private readonly RiotGameDeveloperPortal _rgdp = rgdp;

        /// <summary>
        /// Updates the WebSocket server with the current end game details from the League Client and RGDP.
        /// </summary>
        public async Task SyncEndGameAsync()
        {
            try
            {
                // Retrieve end game details from the League Client
                var endGame = await _lcuEndpoints.GetEndGameAsync();
                if (endGame == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "SyncEndGameAsync()", "❌ Failed to retrieve end game data.");
                    return;
                }
                _logger.Log(LoggingLevel.INFO, "SyncEndGameAsync()", $"📊 End game : {endGame}");
                // Send end game details to the WebSocket server
                await _wsServer.SetEndGameAsync(endGame);
                
                Int64 gameId = endGame.GameId;
                // Retrieve match details from RGDP using the game ID
                var match = _rgdp.Match.Match(gameId);
                if (match == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "SyncEndGameAsync()", "❌ Failed to retrieve match data from RGDP.");
                    return;
                }
                _logger.Log(LoggingLevel.INFO, "SyncEndGameAsync()", $"📊 Match data from RGDP: {match}");
                // Send match details to the WebSocket server
                await _wsServer.SetEndGameMatchAsync(match);

                // Retrieve timeline details from RGDP using the game ID
                var timeline = _rgdp.Match.Timeline(gameId);
                if (timeline == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "SyncEndGameAsync()", "❌ Failed to retrieve timeline data from RGDP.");
                    return;
                }
                _logger.Log(LoggingLevel.INFO, "SyncEndGameAsync()", $"📊 Timeline data from RGDP: {timeline}");
                // Send timeline details to the WebSocket server
                await _wsServer.SetEndGameTimelineAsync(timeline);

            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "SyncEndGameAsync()", $"❌ {ex.Message}");
            }
        }
    }
}
