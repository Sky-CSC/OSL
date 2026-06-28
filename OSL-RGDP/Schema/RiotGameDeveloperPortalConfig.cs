using OSL_Utils;

namespace OSL_RGDP.Schema
{
    /// <summary>
    /// Riot Games Developer Portal configuration class
    /// </summary>
    /// <remarks>This class is used to store the configuration for the Riot Games Developer Portal API.</remarks>
    public class RiotGameDeveloperPortalConfig
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly Logger _logger = new("Info");

        /// <summary>
        /// The API key to use for the request.
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// The region (euw1, euw2, ...).
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// The continent (europe, asie, ...).
        /// </summary>
        public string Continent { get; set; }
        /// <summary>
        /// Region or continent, depend of requests.
        /// </summary>
        public string Routing { get; set; }
        /// <summary>
        /// The https protocol.
        /// </summary>
        public string Https { get; set; }
        /// <summary>
        /// The domain name.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RiotGameDeveloperPortalConfig"/> struct.
        /// </summary>
        /// <param name="apiKey">Api key from Riot Games Developer Portal</param>
        /// <param name="region">Region (euw1, euw2, ...)</param>
        public RiotGameDeveloperPortalConfig(string apiKey, string region)
        {
            ApiKey = apiKey;
            Region = region;
            Continent = SetContinent();
            Routing = region;
            Https = "https://";
            Domain = ".api.riotgames.com";
            _logger.Log(LoggingLevel.INFO, nameof(RiotGameDeveloperPortalConfig), $"Region: {Region}, Continent: {Continent}");
        }

        /// <summary>
        /// Set the continent based on the region.
        /// </summary>
        /// <returns>Continent</returns>
        private string SetContinent()
        {
            if (Region.Equals("na1") || Region.Equals("br1") || Region.Equals("la1") || Region.Equals("la2"))
            {
                return "americas";
            }
            else if (Region.Equals("kr") || Region.Equals("jp1"))
            {
                return "asia";
            }
            else if (Region.Equals("eun1") || Region.Equals("euw1") || Region.Equals("tr1") || Region.Equals("ru"))
            {
                return "europe";
            }
            else if (Region.Equals("oc1") || Region.Equals("ph2") || Region.Equals("sg2") || Region.Equals("th2") || Region.Equals("tw2") || Region.Equals("vn2"))
            {
                return "sea";
            }
            return "europe";
        }
    }
}
