using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Provides methods to interact with the Spectator V5 API of Riot Games Developer Portal.
    /// </summary>
    /// <remarks>This class allows you to retrieve current game information for a given summoner ID.</remarks>
    /// <param name="config">Information for connect to API</param>
    public class SpectatorV5
    {
        /// <summary>
        /// Represents the information associated with this instance.
        /// </summary>
        /// <remarks>This field is read-only and is intended to store metadata or configuration details
        /// relevant to the containing class. It cannot be modified after initialization.</remarks>
        private readonly RiotGameDeveloperPortalConfig _config;

        public SpectatorV5(RiotGameDeveloperPortalConfig config)
        {
            _config = config.Clone();
            // Routing is the regio not the continent
            _config.Routing = _config.Region;
        }

        /// <summary>
        /// Retrieves current game information for a given summoner ID.
        /// </summary>
        /// <remarks>This method sends a request to the Spectator V5 API endpoint to fetch details about the current game <see cref="CurrentGameInfo"/> associated with the specified summoner ID."</remarks>
        /// <param name="encryptedPuuid">The encrypted PUUID (Player Universal Unique Identifier) of the account to retrieve.</param>
        /// <returns>An instance of <see cref="CurrentGameInfo"/> containing details about the current game. If no data is found, an empty <see cref="CurrentGameInfo"/> object is returned.</returns>
        public CurrentGameInfo? BySummoner(string encryptedPuuid)
        {
            string? data = Request(_config, $"/lol/spectator/v5/active-games/by-summoner/{encryptedPuuid}");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<CurrentGameInfo>(data);
        }
    }
}
