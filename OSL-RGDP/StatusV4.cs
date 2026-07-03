using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    public class StatusV4
    {
        /// <summary>
        /// Represents the information associated with this instance.
        /// </summary>
        /// <remarks>This field is read-only and is intended to store metadata or configuration details
        /// relevant to the containing class. It cannot be modified after initialization.</remarks>
        private readonly RiotGameDeveloperPortalConfig _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusV4"/> class with the specified configuration.
        /// </summary>
        /// <remarks>The <paramref name="config"/> parameter must not be null. The <see
        /// cref="RiotGameDeveloperPortalConfig.Routing"/> property is automatically set to the value of <see cref="RiotGameDeveloperPortalConfig.Region"/> during
        /// initialization.</remarks>
        /// <param name="config">The configuration used to initialize the instance. The <see cref="RiotGameDeveloperPortalConfig.Routing"/> property will be set
        /// to the value of <see cref="RiotGameDeveloperPortalConfig.Region"/>.</param>
        public StatusV4(RiotGameDeveloperPortalConfig config)
        {
            _config = config.Clone();
            // Routing is the regio not the continent
            _config.Routing = _config.Region;
        }

        public PlatformDataDto? GetStatus()
        {
            string? data = Request(_config, "/lol/status/v4/platform-data");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<PlatformDataDto>(data);
        }
    }
}
