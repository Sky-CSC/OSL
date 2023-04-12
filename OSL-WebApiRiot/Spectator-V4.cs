namespace OSL_WebApiRiot.WebApiRiot
{
    public class Spectator_V4
    {
        private static string httpsUrl = "https://";
        private static string region = "euw1";
        private static string pathUrlApiRiot = ".api.riotgames.com";

        public static string BySummoner(string encryptedSummonerId)
        {
            return $"{httpsUrl}{region}{pathUrlApiRiot}/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}";
        }
    }
}
