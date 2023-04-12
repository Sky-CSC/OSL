

using OSL_Common.System.Logging;
using OSL_Common.System.SSLCertificate;
using System.Net;


namespace OSL_LcuApi
{
    public class LcuApi
    {

        private static Logger _logger = new("LcuApi");

        public static string Request(string nameRequest, int leagueClientLockFilePort, string leagueClientApiLocalHost, string leagueClientApiPassword)
        {
            SSL.BypassSSL();
            string httpsLocalHost = "https://127.0.0.1" + ":" + leagueClientLockFilePort + nameRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
                request.Headers["Accept"] = "application/json";
                request.Headers["Host"] = leagueClientApiLocalHost;
                request.Headers["Authorization"] = leagueClientApiPassword;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "Request()", "Request to " + httpsLocalHost + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Request()", "Request to " + httpsLocalHost + " failed, " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// List of url for local LCU riot api
        /// </summary>
        public class Url
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
        
            //lol-end-game
            public static readonly string lolendofgamev1eogstatsblock = "/lol-end-of-game/v1/eog-stats-block"; //End of game stats
        
        }

        /// <summary>
        /// List of phase of LCU API
        /// </summary>
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
}
