using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Provides methods to retrieve account information from the Riot Games Developer Portal.
    /// </summary>
    /// <remarks>This class allows users to fetch account details using either an encrypted PUUID or a Riot
    /// ID. It requires an instance of <see cref="RiotGameDeveloperPortalConfig"/> to configure the request parameters, including routing
    /// information.</remarks>
    public class AccountV1
    {
        /// <summary>
        /// Represents the information associated with this instance.
        /// </summary>
        /// <remarks>This field is read-only and is intended to store metadata or configuration details
        /// relevant to the containing class. It cannot be modified after initialization.</remarks>
        private readonly RiotGameDeveloperPortalConfig _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountV1"/> class with the specified account information.
        /// </summary>
        /// <remarks>The <paramref name="config"/> parameter must not be null. The <see
        /// cref="RiotGameDeveloperPortalConfig.Routing"/> property is automatically set to the value of <see cref="RiotGameDeveloperPortalConfig.Continent"/> during
        /// initialization.</remarks>
        /// <param name="config">The account information used to initialize the instance. The <see cref="RiotGameDeveloperPortalConfig.Routing"/> property will be set
        /// to the value of <see cref="RiotGameDeveloperPortalConfig.Continent"/>.</param>
        public AccountV1(RiotGameDeveloperPortalConfig config)
        {
            _config = config.Clone();
            // Routing is the continent not the region
            _config.Routing = _config.Continent;
        }

        /// <summary>
        /// Retrieves account information based on the provided encrypted PUUID.
        /// </summary>
        /// <param name="encryptedPUUID">The encrypted PUUID (Player Universal Unique Identifier) of the account to retrieve.</param>
        /// <returns>An <see cref="AccountDto"/> object containing the account details. Returns an empty <see cref="AccountDto"/>
        /// if no account information is found.</returns>
        public AccountDto? ByPuuid(string encryptedPUUID)
        {
            string? data = Request(_config, $"/riot/account/v1/accounts/by-puuid/{encryptedPUUID}");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AccountDto>(data); 
        }

        /// <summary>
        /// Retrieves account information based on the specified Riot ID.
        /// </summary>
        /// <param name="gameName">The game name portion of the Riot ID. This value cannot be null or empty.</param>
        /// <param name="tagLine">The tag line portion of the Riot ID. This value cannot be null or empty.</param>
        /// <returns>An <see cref="AccountDto"/> object containing the account details associated with the specified Riot ID. If
        /// no account is found, returns an empty <see cref="AccountDto"/>.</returns>
        public AccountDto? ByRiotId(string gameName, string tagLine)
        {
            string? data = Request(_config, $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AccountDto>(data);
        }
    }
}
