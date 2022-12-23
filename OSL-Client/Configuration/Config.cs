using Newtonsoft.Json;
using OSL_Client.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Configuration
{
    public class Config
    {
        private static OSLLogger _logger = new OSLLogger("Config");

        //public static string serverIPSocket = "localhost";
        public static string serverIPSocket = "127.0.0.1";
        public static int serverPortSocket = 45678;
        public static string leagueClientProcess = "LeagueClient";
        public static string leagueClientFullFilePath = "";
        public static string leagueClientPath = "";
        public static string lockFilePath = "";
        public static int lockFileProcessId;
        public static int lockFilePort;
        public static string lockFilePassword = "";
        public static string localIpHttps = "https://127.0.0.1";
        public static string localIpHttp = "127.0.0.1";
        public static string loginRiot = "riot";
        public static string portRiot = "2999";
        public static string GameClientApiLocalHost = "";
        public static string GameClientApiPassword = "";
        //public static string LiveEventsAPIIP = "127.0.0.1";
        public static int LiveEventsAPIPort = 34243;

        /// <summary>
        /// Loads the config from the config file.
        /// </summary>
        public static void LoadConfigServerSocket()
        {
            string filePath = "./" + "Config" + "/" + "configServerSocket.json";
            dynamic configHost = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
            try
            {
                serverIPSocket = configHost.ip;
                serverPortSocket = configHost.port;
                _logger.log(LoggingLevel.INFO, "LoadConfigServerSocket()", "Config host load");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigServerSocket()", e.Message);
            }
        }

        public static bool SetHostPassGameClientApi()
        {
            try
            {
                GameClientApiLocalHost = Config.localIpHttp + ":" + Config.lockFilePort;
                GameClientApiPassword = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Config.loginRiot}:{Config.lockFilePassword}"));
                _logger.log(LoggingLevel.INFO, "HostPassGameClientApi()", "Host and password game client api set");
                return true;
            }
            catch
            {
                _logger.log(LoggingLevel.ERROR, "HostPassGameClientApi()", "Error host and password to game client api");
                return false;
            }
        }
    }
}
