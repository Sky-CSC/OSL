using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Account information
    /// </summary>
    public class AccountV1
    {
        /// <summary>
        /// Information for make request to Riot Game Developer Portal
        /// </summary>
        private readonly Info _info;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">Information for download information</param>
        public AccountV1(Info info)
        {
            _info = info;
            // Routing is the continent not the region
            _info.Routing = _info.Continent;
        }

        /// <summary>
        /// Get information of summoner by encrypted PUUID
        /// </summary>
        /// <param name="encryptedPUUID">Encrypted puuid</param>
        /// <returns><see cref="AccountDto"/> info</returns>
        public AccountDto ByPuuid(string encryptedPUUID)
        {
            string? data = Request(_info, $"/riot/account/v1/accounts/by-puuid/{encryptedPUUID}");
            if (data == null)
            {
                return new AccountDto();
            }
            return JsonConvert.DeserializeObject<AccountDto>(data); 
        }

        /// <summary>
        /// Get information of summoner by riot id
        /// </summary>
        /// <param name="gameName">Game name</param>
        /// <param name="tagLine">Tag</param>
        /// <returns><see cref="AccountDto"/> info</returns>
        public AccountDto ByRiotId(string gameName, string tagLine)
        {
            string? data = Request(_info, $"/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}");
            if (data == null)
            {
                return new AccountDto();
            }
            return JsonConvert.DeserializeObject<AccountDto>(data);
        }
    }
}
