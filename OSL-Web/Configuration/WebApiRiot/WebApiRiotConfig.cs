using Newtonsoft.Json;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_WebApiRiot.WebApiRiot;

namespace OSL_Web.Configuration.WebApiRiot
{
    public class WebApiRiotConfig
    {
        private static Logger _logger = new("WebApiRiotConfig");
        public static void LoadJsonConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/WebApiRiot/web-api-riot.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            OSL_WebApiRiot.WebApiRiot.WebApiRiot.apiKey = jsonContent.apiKey;
            _logger.log(LoggingLevel.INFO, "LoadWebRiotApiKey()", $"Api key loaded");
        }
    }
}
