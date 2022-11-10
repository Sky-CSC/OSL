using OSL_Client.RiotApp.API.Replay;
using OSL_Client.RiotApp.DataProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OSL_Client.RiotApp.API.LCU.GameFlowPhase;

namespace OSL_Client.RiotApp.API.LCU
{
    public class LcuApi
    {
        private static OSLLogger _logger = new OSLLogger("LcuApi");
        public static void GameFlowPhaseCheck(string gameFlowPhase)
        {
            //Error, impossible to recive corect information of LCUAPI
            if (gameFlowPhase == null)
            {
                _logger.log(LoggingLevel.ERROR, "GameFlowPhaseCheck()", "GameFlowPhase is null");
            }

            //There are no specific things going on, BUT it is possible that it is a finished part that we want to look at
            else if (gameFlowPhase.Equals(None))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {None}");
                //Check if a game is running
                if (ReplayApi.GameEndButReplay() != null)
                {
                    _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", "Game found");
                    //If the game is finish and we want to watch it, no champ select display but, champ pick and ban display
                    InGameProcess.InGame();
                }
                else
                {
                    _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", "No game found");
                }
            }

            else if (gameFlowPhase.Equals(Lobby))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {Lobby}");
            }
            else if (gameFlowPhase.Equals(Matchmaking))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {Matchmaking}");
            }
            else if (gameFlowPhase.Equals(CheckedIntoTournament))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {CheckedIntoTournament}");
            }
            else if (gameFlowPhase.Equals(ReadyCheck))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {ReadyCheck}");
            }

            //We are in Champion Selection
            else if (gameFlowPhase.Equals(ChampSelect))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {ChampSelect}");
                ChampSelectProcess.InChampSelect();
            }

            else if (gameFlowPhase.Equals(GameStart))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {GameStart}");
            }
            else if (gameFlowPhase.Equals(FailedToLaunch))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {FailedToLaunch}");
            }

            //We are in Game
            else if (gameFlowPhase.Equals(InProgress))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {InProgress}");
                InGameProcess.InGame();
            }

            else if (gameFlowPhase.Equals(Reconnect))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {Reconnect}");
            }
            else if (gameFlowPhase.Equals(WaitingForStats))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {WaitingForStats}");
            }
            else if (gameFlowPhase.Equals(PreEndOfGame))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {PreEndOfGame}");
            }
            else if (gameFlowPhase.Equals(EndOfGame))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {EndOfGame}");
            }
            else if (gameFlowPhase.Equals(TerminatedInError))
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase is {TerminatedInError}");
            }
            else
            {
                _logger.log(LoggingLevel.INFO, "GameFlowPhaseCheck()", $"GameFlowPhase not exist");
            }
        }
    }

    public class GameFlowPhaseStatus
    {
        //public Int64 IdGame { get; set; }
        public string? Phase { get; set; }
        public string? Status { get; set; }
        public string? Date { get; set; }
    }

    public class UrlRequest
    {
        public static readonly string riotclientappname = "/riotclient/app-name"; //Application name without file extension
        public static readonly string lolgameflowv1session = "/lol-gameflow/v1/session"; //
        public static readonly string lolgameflowv1gameflowphase = "/lol-gameflow/v1/gameflow-phase"; //
        public static readonly string lolsummonerv1summoners = "/lol-summoner/v1/summoners/"; // 


        //lol-champ-select
        public static readonly string lolchampselectv1gridchampions = "/lol-champ-select/v1/grid-champions/"; //
        public static readonly string lolchampselectv1session = "/lol-champ-select/v1/session"; //
        public static readonly string lolsummonerv1summonersid = "/lol-summoner/v1/summoners/"; //
        public static readonly string lolchampselectv1bannablechampionids = "/lol-champ-select/v1/bannable-champion-ids"; //All champ possible to ban
        public static readonly string lolchampselectv1currentchampion = "/lol-champ-select/v1/current-champion"; //No info

        //lol-champ-select-legacy
        public static readonly string lolchampselectlegacyv1session = "/lol-champ-select-legacy/v1/session";
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
