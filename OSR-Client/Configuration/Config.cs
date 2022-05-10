using Newtonsoft.Json;
using OSR_Client.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSR_Client.Configuration
{
    public class Config
    {
        private static OSRLogger _logger = new OSRLogger("Config");

        public static string ip = "localhost";
        public static int port = 456789;
        public static string LeagueClientProcess = "LeagueClient";
        public static string LeagueClientFullFilePath = "";
        public static string LeagueClientFilePath = "";
        
        /// <summary>
        /// Loads the config from the config file.
        /// </summary>
        public static void LoadConfigHost()
        {

            string filePath = "./" + "Config" + "/" + "configHost.json";
            dynamic configHost = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
            try
            {
                ip = configHost.ip;
                port = configHost.port;
                _logger.log(LoggingLevel.INFO, "LoadConfigHost()", "Config host load");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigHost()", e.Message);
            }
        }
    }
}
