using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSR_Client.RiotApp.API.LCU
{
    public class LcuApi
    {
        private static OSRLogger _logger = new OSRLogger("LcuApi");
        public static void GameFlowPhaseCheck(string gameFlowPhase)
        {
            if (gameFlowPhase.Equals(GameFlowPhase.None))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.None}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.Lobby))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.Lobby}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.Matchmaking))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.Matchmaking}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.CheckedIntoTournament))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.CheckedIntoTournament}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.ReadyCheck))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.ReadyCheck}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.ChampSelect))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.ChampSelect}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.GameStart))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.GameStart}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.FailedToLaunch))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.FailedToLaunch}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.InProgress))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.InProgress}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.Reconnect))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.Reconnect}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.WaitingForStats))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.WaitingForStats}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.PreEndOfGame))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.PreEndOfGame}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.EndOfGame))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.EndOfGame}");
            }
            else if (gameFlowPhase.Equals(GameFlowPhase.TerminatedInError))
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase is {GameFlowPhase.TerminatedInError}");
            }
            else
            {
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", $"GameFlowPhase not exist");
            }
        }
    }
    public class UrlRequest
    {
        public static readonly string riotclientappname = "/riotclient/app-name"; //Application name without file extension
        public static readonly string lolgameflowv1session = "/lol-gameflow/v1/session"; //
        public static readonly string lolgameflowv1gameflowphase = "/lol-gameflow/v1/gameflow-phase"; //
        public static readonly string lolchampselectv1session = "/lol-champ-select/v1/session"; //
        public static readonly string lolsummonerv1summoners = "/lol-summoner/v1/summoners/"; // 
        public static readonly string lolchampselectv1gridchampions = "/lol-champ-select/v1/grid-champions/"; //
        
    }
    public class GameFlowPhase
    {
        public static readonly string None = "\"None\"";
        public static readonly string Lobby = "\"Lobby\"";
        public static readonly string Matchmaking = "\"Matchmaking\"";
        public static readonly string CheckedIntoTournament = "\"CheckedIntoTournament\"";
        public static readonly string ReadyCheck = "\"ReadyCheck\"";
        public static readonly string ChampSelect = "\"ChampSelect\"";
        public static readonly string GameStart = "\"GameStart\"";
        public static readonly string FailedToLaunch = "\"FailedToLaunch\"";
        public static readonly string InProgress = "\"InProgress\"";
        public static readonly string Reconnect = "\"Reconnect\"";
        public static readonly string WaitingForStats = "\"WaitingForStats\"";
        public static readonly string PreEndOfGame = "\"PreEndOfGame\"";
        public static readonly string EndOfGame = "\"EndOfGame\"";
        public static readonly string TerminatedInError = "\"TerminatedInError\"";
    }
}
