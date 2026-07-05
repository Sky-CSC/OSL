using OSL_Lcu;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Server.Services
{
    public class RegionLocale(LcuEndpoints lcuEndpoints, WebSocketServer.WebSocketServer wsServer)
    {
        private static readonly Logger _logger = new("RegionLocaleService");
        private readonly LcuEndpoints _lcuEndpoints = lcuEndpoints;
        private readonly WebSocketServer.WebSocketServer _wsServer = wsServer;

        /// <summary>
        /// Updates the region locale and sends it to the WebSocket server.
        /// </summary>
        /// <returns></returns>
        public async Task<LolPublishingContentPubHubConfig> SyncRegionLocaleAsync()
        {
            try
            {
                var regionLocale = await _lcuEndpoints.GetRegionLocaleAsync();
                if (regionLocale == null)
                {
                    _logger.Log(LoggingLevel.WARN, "SyncRegionLocaleAsync()", "⚠️ No RegionLocale received.");
                    return null;
                }
                _logger.Log(LoggingLevel.INFO, "SyncRegionLocaleAsync()", $"🌍 RegionLocale: {regionLocale}");
                await _wsServer.SetRegionLocaleAsync(regionLocale);
                return regionLocale;
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "SyncRegionLocaleAsync()", $"❌ {ex.Message}");
                return null;
            }
        }
    }
}
