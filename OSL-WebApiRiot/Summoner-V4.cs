namespace OSL_WebApiRiot.WebApiRiot
{
    /// <summary>
    /// Get information of a summoner
    /// </summary>
    public class Summoner_V4
    {
        private static string httpsUrl = "https://";
        private static string region = "euw1";
        private static string pathUrlApiRiot = ".api.riotgames.com";

        /// <summary>
        /// Get information of summoner by encrypted Account Id
        /// </summary>
        /// <param name="encryptedAccountId"></param>
        /// <returns></returns>
        public static string ByAccount(string encryptedAccountId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-account/{encryptedAccountId}";
        }
        /// <summary>
        /// Get information of summoner by summoner Name
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        public static string ByName(string summonerName)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-name/{summonerName}";
        }
        /// <summary>
        /// Get information of summoner by encrypted PUUID
        /// </summary>
        /// <param name="encryptedPUUID"></param>
        /// <returns></returns>
        public static string ByPuuid(string encryptedPUUID)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
        }
        /// <summary>
        /// Get information of summoner by encrypted Summoner Id
        /// </summary>
        /// <param name="encryptedSummonerId"></param>
        /// <returns></returns>
        public static string BySummonerId(string encryptedSummonerId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/{encryptedSummonerId}";
        }
    }
}
