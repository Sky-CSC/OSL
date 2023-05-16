namespace OSL_WebApiRiot.WebApiRiot
{
    /// <summary>
    /// Get information from match in progress
    /// </summary>
    public class Spectator_V4
    {
        private static string httpsUrl = "https://";
        private static string region = "euw1";
        private static string pathUrlApiRiot = ".api.riotgames.com";

        /// <summary>
        /// Get match information by encrypted Summoner Id
        /// </summary>
        /// <param name="encryptedSummonerId"></param>
        /// <returns></returns>
        public static string BySummoner(string encryptedSummonerId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}";
        }
    }
}
