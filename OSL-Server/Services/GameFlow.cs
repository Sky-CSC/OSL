using OSL_Lcu;
using OSL_Lcu.Schema.Lcu;
using OSL_Server.Phases;
using OSL_Server.WebSocketServer;
using OSL_Utils;

namespace OSL_Server.Services
{
    /// <summary>
    /// Retrieves and syncs the game flow phase from the League Client to a WebSocket server.
    /// </summary>
    /// <param name="lcuEndpoints"></param>
    /// <param name="wsServer"></param>
    public class GameFlow(LcuEndpoints lcuEndpoints, WebSocketServer.WebSocketServer wsServer)
    {
        private static readonly Logger _logger = new("GameFlow");

        private readonly LcuEndpoints _lcuEndpoints = lcuEndpoints;
        private readonly WebSocketServer.WebSocketServer _wsServer = wsServer;
        private LolGameflowGameflowPhase? _phase;
        private bool _samePhase = false;

        /// <summary>
        /// Updates the WebSocket server with the current game flow phase from the League Client.
        /// </summary>
        public async Task<LolGameflowGameflowPhase?> SyncGameflowPhaseAsync()
        {
            try
            {
                // Retrieve the current game flow phase from the League Client
                var gameflowPhase = await _lcuEndpoints.GetGameflowPhaseAsync();
                if (gameflowPhase == null)
                {
                    _logger.Log(LoggingLevel.ERROR, "SyncGameflowPhaseAsync()", "❌ Failed to retrieve game flow phase.");
                    return null;
                }
                _logger.Log(LoggingLevel.INFO, "SyncGameflowPhaseAsync()", $"📊 Gameflow Phase: {gameflowPhase}");
                // Send the game flow phase to the WebSocket server
                await _wsServer.SetGameFlowPhaseAsync(gameflowPhase);
                return gameflowPhase;
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "SyncGameflowPhaseAsync()", $"❌ {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Manages actions based on the current game flow phase.
        /// </summary>
        /// <param name="phase">Phase in progress</param>
        /// <param name="champSelect">Champ select class</param>
        /// <param name="endGame">End game class</param>
        public void InPhase(LolGameflowGameflowPhase? phase, ChampSelect champSelect, EndGame endGame)
        {
            // Check if the phase has changed
            if (_phase != phase)
            {
                _phase = phase;
                _samePhase = false;
            }
            else
            {
                _samePhase = true;
            }

            _logger.Log(LoggingLevel.INFO, "InPhase()", $"📊 In phase: {phase}");
            switch (phase)
            {
                case LolGameflowGameflowPhase.ChampSelect:
                    // Handle Champ Select data
                    champSelect.SyncChampSelectAsync().GetAwaiter().GetResult();
                    break;
                case LolGameflowGameflowPhase.InProgress:
                    // Handle In Progress data
                    break;
                case LolGameflowGameflowPhase.EndOfGame:
                    // Handle End Game data
                    if (!_samePhase)
                        endGame.SyncEndGameAsync().GetAwaiter().GetResult();
                    break;
                default:
                    _logger.Log(LoggingLevel.WARN, "InPhase()", $"⚠️ Unknown phase: {phase}");
                    break;
            }
        }
    }
}
