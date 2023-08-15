using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_Common.System.FileManager;

namespace OSL_Client.Configuration
{
    /// <summary>
    /// Gestion of configuration fo client
    /// </summary>
    public class Config
    {
        private static Logger _logger = new("Config");

        public static string? serverSocketIp;
        public static int serverSocketPort;
        public static string? leagueClientProcess;
        public static string? leagueClientFullFilePath;
        public static string? leagueClientPath;
        public static string? leagueClientLockFilePath;
        public static int leagueClientLockFileProcessId;
        public static int leagueClientLockFilePort;
        public static string? leagueClientLockFilePassword;
        public static string? riotLogin;
        public static int riotPort;
        public static string? leagueClientApiLocalHost;
        public static string? leagueClientApiPassword;
        public static int leagueClientLiveEventsPort;

        public static string localIpHttp = "127.0.0.1";
        public static string localIpHttps = "https://127.0.0.1";

        /// <summary>
        /// Load config
        /// </summary>
        public static void LoadConfig()
        {
            LoadConfigServerSocket();
            LoadConfigRiot();
        }

        /// <summary>
        /// Load config server socket
        /// </summary>
        public static void LoadConfigServerSocket()
        {
            try
            {
                string filePath = "./" + "Configuration" + "/" + "server-socket.json";
                dynamic jsonContent = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
                serverSocketIp = jsonContent.ip;
                serverSocketPort = jsonContent.port;
                _logger.log(LoggingLevel.INFO, "LoadConfigServerSocket()", $"Config host load Ip : {serverSocketIp} Port : {serverSocketPort}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigServerSocket()", e.Message);
            }
        }

        /// <summary>
        /// load config riot
        /// </summary>
        public static void LoadConfigRiot()
        {
            try
            {
                string filePath = "./" + "Configuration" + "/" + "riot.json";
                dynamic jsonContent = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
                leagueClientLiveEventsPort = jsonContent.leagueClientLiveEventsPort;
                leagueClientProcess = jsonContent.leagueClientProcess;
                riotLogin = jsonContent.riotLogin;
                riotPort = jsonContent.riotPort;
                _logger.log(LoggingLevel.INFO, "LoadConfigRiot()", $"Config riot load leagueClientLiveEventsPort : {leagueClientLiveEventsPort}, leagueClientProcess : {leagueClientProcess},  riotLogin : {riotLogin} riotPort : {riotPort}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigRiot()", e.Message);
            }
        }
    }
}
