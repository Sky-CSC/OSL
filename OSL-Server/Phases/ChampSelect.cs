using OSL_Lcu;
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
        private static readonly Logger _logger = new("GameFlow");

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
                await _wsServer.SetChampSelectAsync(gameflowPhase);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "SyncChampSelectAsync()", $"❌ {ex.Message}");
            }
        }
    }
}
