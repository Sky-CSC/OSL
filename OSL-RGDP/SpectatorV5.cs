using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Game information see by a spectator
    /// </summary>
    /// <param name="info"></param>
    public class SpectatorV5(Info info)
    {
        /// <summary>
        /// Information for make request to Riot Game Developer Portal
        /// </summary>
        private readonly Info _info = info;

        /// <summary>
        /// Get the current game information for the given summoner ID.
        /// </summary>
        /// <param name="encryptedPuuid">Encrypted puuid</param>
        /// <returns><see cref="CurrentGameInfo"/> info</returns>
        public CurrentGameInfo BySummoner(string encryptedPuuid)
        {
            string? data = Request(_info, $"/lol/spectator/v5/active-games/by-summoner/{encryptedPuuid}");
            if (data == null)
            {
                return new CurrentGameInfo();
            }
            return JsonConvert.DeserializeObject<CurrentGameInfo>(data);
        }
    }
}
