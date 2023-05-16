using Newtonsoft.Json;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Sockets;

namespace OSL_Web.Configuration.Socket
{
    public class SocketConfig
    {
        private static Logger _logger = new("SocketConfig");
        /// <summary>
        /// Configuration of server socker port
        /// </summary>
        public static void LoadJsonConfig()
        {
            string filePath = "./" + "Configuration" + "/" +"Socket" + "/" + "socket.json";
            dynamic configHost = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
            try
            {
                AsyncServer.port = configHost.port;
                _logger.log(LoggingLevel.INFO, "LoadConfigServerSocket()", $"Config host load Port : {AsyncServer.port}");
            }
            catch (Exception e)
            {
                //Create file
                _logger.log(LoggingLevel.ERROR, "LoadConfigServerSocket()", e.Message);
            }
        }
    }
}
