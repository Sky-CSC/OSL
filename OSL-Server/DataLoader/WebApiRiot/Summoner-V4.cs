namespace OSL_Server.DataLoader.WebApiRiot
{
    public class Summoner_V4
    {
        private static string httpsUrl = "https://";
        private static string region = "euw1";
        private static string pathUrlApiRiot = ".api.riotgames.com";

        public static string ByAccount(string encryptedAccountId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-account/{encryptedAccountId}";
        }
        public static string ByName(string summonerName)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-name/{summonerName}";
        }
        public static string ByPuuid(string encryptedPUUID)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/by-puuid/{encryptedPUUID}";
        }
        public static string BySummonerId(string encryptedSummonerId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/summoner/v4/summoners/{encryptedSummonerId}";
        }
    }

    public class SummonerDTO
    {
        public string AccountId { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Puuid { get; set; }
        public long SummonerLevel { get; set; }
    }
}
