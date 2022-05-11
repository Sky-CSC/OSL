using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OSR_Client.Configuration;

namespace OSR_Client.RiotApp.API
{
    internal class ApiRequest
    {
        private static OSRLogger _logger = new OSRLogger("ApiRequest");

        public static string RequestGameClientAPI(string nameRequest)
        {
            SSL.BypassSSL();
            string httpsLocalHost = Config.localIpHttps + ":" + Config.lockFilePort + nameRequest;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
                request.Headers["Accept"] = "application/json";
                request.Headers["Host"] = Config.GameClientApiLocalHost;
                request.Headers["Authorization"] = Config.GameClientApiPassword;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", "Request to " + httpsLocalHost + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientAPI", "Request to " + httpsLocalHost + " failed, " + e.Message);
                return null;
            }
            //_logger.log(LoggingLevel.ERROR, "RequestGameClientAPI", "Request to " + httpsLocalHost + " failed");
            //return null;
        }
    }
    class SSL
    {
        public static void BypassSSL()
        {
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
        }
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

    public class LcuApi
    {
        public static readonly string riotclientappname = "/riotclient/app-name"; //Application name without file extension
        public static readonly string lolgameflowv1session = "/lol-gameflow/v1/session"; //
        public static readonly string lolgameflowv1gameflowphase = "/lol-gameflow/v1/gameflow-phase"; //
        public static readonly string lolchampselectv1session = "/lol-champ-select/v1/session"; //
        public static readonly string lolsummonerv1summoners = "/lol-summoner/v1/summoners/"; // 
        public static readonly string lolchampselectv1gridchampions = "/lol-champ-select/v1/grid-champions/"; //
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
