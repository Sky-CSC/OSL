using Newtonsoft.Json;

namespace OSL_Utils.WebSocket
{
    public static class WebSocketConfigService
    {
        private static readonly Logger _logger = new("WebSocketConfigService");

        public static WebSocketConfig Load(string configPath)
        {
            WebSocketConfig Config = new();
            if (!File.Exist(configPath))
            {
                return Config;
            }

            try
            {
                var json = File.Read(configPath);
                Config = JsonConvert.DeserializeObject<WebSocketConfig>(json) ?? new WebSocketConfig();
                Config.Token = [.. Config.Token.Distinct()];
                _logger.Log(LoggingLevel.DEBUG, nameof(Load), $"Configuration loaded successfully: {configPath}");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Load), $"Failed to load configuration: {ex}");
            }

            return Config;
        }

        /// <summary>
        /// Saves the WebSocket configuration to file.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="configPath"></param>
        public static void SaveSocketConfig(WebSocketConfig config, string configPath)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.Write(configPath, json);
        }
    }
}
