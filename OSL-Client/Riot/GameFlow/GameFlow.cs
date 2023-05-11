using OSL_Client.Configuration;
using OSL_Client.Riot.GameFlow.Phase;
using OSL_Common.System.Logging;
using OSL_LcuApi;
using OSL_ReplayApi;

namespace OSL_Client.Riot.GameFlow
{
    /// <summary>
    /// Gestion of game flow
    /// </summary>
    public class GameFlow
    {
        private static Logger _logger = new("GameFlow");

        /// <summary>
        /// Check phase of league client
        /// </summary>
        /// <returns></returns>
        public static string PhaseRequest()
        {
            return LcuApi.Request(LcuApi.Url.lolgameflowv1gameflowphase, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword); //Request game client api
        }

        /// <summary>
        /// Send data to specific phase
        /// </summary>
        /// <param name="gameFlowPhase"></param>
        public static void Phase(string gameFlowPhase)
        {
            if (gameFlowPhase == null)
            {
                _logger.log(LoggingLevel.ERROR, "GameFlowPhase()", "GameFlowPhase is null");
            }

            switch (gameFlowPhase)
            {
                case "\"None\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is None");
                    //Check if a game is running
                    if (ReplayApi.Request(ReplayApi.Url.replaygame, Config.riotPort) != null)
                    {
                        _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", "Game found");
                        //If the game is finish and we want to watch it, no champ select display but, champ pick and ban display
                        InGame.Progress();
                    }
                    else
                    {
                        _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", "No game found");
                    }
                    break;

                case "\"Lobby\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is Lobby");
                    break;

                case "\"Matchmaking\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is Matchmaking");
                    break;

                case "\"CheckedIntoTournament\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is CheckedIntoTournament");
                    break;

                case "\"ReadyCheck\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is ReadyCheck");
                    break;

                //We are in Champion Selection
                case "\"ChampSelect\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is ChampSelect");
                    ChampSelect.Progress();
                    break;

                case "\"GameStart\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is GameStart");
                    break;

                case "\"FailedToLaunch\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is FailedToLaunch");
                    break;

                //We are in Game
                case "\"InProgress\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is InProgress");
                    InGame.Progress();
                    break;

                case "\"Reconnect\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is Reconnect");
                    break;

                case "\"WaitingForStats\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is WaitingForStats");
                    break;

                case "\"PreEndOfGame\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is PreEndOfGame");
                    break;

                case "\"EndOfGame\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is EndOfGame");
                    EndGame.Progress();
                    break;

                case "\"TerminatedInError\"":
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase is TerminatedInError");
                    break;

                default:
                    _logger.log(LoggingLevel.INFO, "GameFlowPhase()", $"GameFlowPhase not exist");
                    break;
            }
        }

        /// <summary>
        /// Information for send information of status of phase to server
        /// </summary>
        public class PhaseStatus
        {
            //public Int64 IdGame { get; set; }
            public string? Phase { get; set; }
            public string? Status { get; set; }
            public string? Date { get; set; }
        }
    }
}
