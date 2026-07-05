using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolEndOfGameEndOfGameTeamBoost
    {
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("skinUnlockMode")]
        public string SkinUnlockMode { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("ipReward")]
        public long IpReward { get; set; }

        [JsonProperty("ipRewardForPurchaser")]
        public long IpRewardForPurchaser { get; set; }

        [JsonProperty("availableSkins")]
        public List<long> AvailableSkins { get; set; }

        [JsonProperty("unlocked")]
        public bool Unlocked { get; set; }
    }
}
