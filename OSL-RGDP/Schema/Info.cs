using OSL_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_RGDP.Schema
{
    /// <summary>
    /// Represents the information needed to make a request to the Riot Games Data Dragon API.
    /// </summary>
    public class Info
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
        /// Initializes a new instance of the <see cref="Info"/> struct.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="region"></param>
        public Info(string apiKey, string region)
        {
            ApiKey = apiKey;
            Region = region;
            Continent = SetContinent();
            Routing = Region;
            Https = "https://";
            Domain = ".api.riotgames.com";
            _logger.Log(LoggingLevel.INFO, "Info()", $"Region: {Region}, Continent: {Continent}");
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
