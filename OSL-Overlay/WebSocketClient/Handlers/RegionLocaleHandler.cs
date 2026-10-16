using Newtonsoft.Json.Linq;
using OSL_CDragon;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handles the "regionLocale" message: the language of the League client decides which region of the assets is used.
    /// </summary>
    public class RegionLocaleHandler(CDragon cdragon) : IMessageHandler
    {
        private static readonly Logger _logger = new("RegionLocaleHandler");

        /// <inheritdoc />
        public string Type => "regionLocale";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<LolPublishingContentPubHubConfig>();
            string? locale = data?.AppContext?.AppLocale;
            if (string.IsNullOrWhiteSpace(locale))
                locale = data?.AppContext?.PublishingLocale;
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Region locale received : '{locale}' (current assets region : {cdragon.Region})");
            // Returns immediately: the new catalogs are read in the background by AssetUpdateService.
            cdragon.SetRegion(locale);
            return Task.CompletedTask;
        }
    }
}
