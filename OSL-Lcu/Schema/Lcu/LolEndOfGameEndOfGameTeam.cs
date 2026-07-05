using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolEndOfGameEndOfGameTeam
    {
        [JsonProperty("stats")]
        public object Stats { get; set; }

        [JsonProperty("players")]
        public List<LolEndOfGameEndOfGamePlayer> Players { get; set; }

        [JsonProperty("memberStatusString")]
        public string MemberStatusString { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("fullId")]
        public string FullId { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("isBottomTeam")]
        public bool IsBottomTeam { get; set; }

        [JsonProperty("isPlayerTeam")]
        public bool IsPlayerTeam { get; set; }

        [JsonProperty("isWinningTeam")]
        public bool IsWinningTeam { get; set; }
    }
}
