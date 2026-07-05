using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Handler for the "regionLocale" message type.
    /// </summary>
    public class RegionLocaleHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("RegionLocaleHandler");

        /// <inheritdoc />
        public string Type => "regionLocale";

        /// <inheritdoc />
        public Task HandleAsync(JToken jsonData)
        {
            var data = jsonData.ToObject<LolPublishingContentPubHubConfig>();
            _logger.Log(LoggingLevel.INFO, "HandleAsync()", $"🎯 Region Locale management");
            // TODO : Process the LolPublishingContentPubHubConfig data as needed
            return Task.CompletedTask;
        }
    }
}
