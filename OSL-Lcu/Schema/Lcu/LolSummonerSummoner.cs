using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    public class LolSummonerSummoner
    {
        [JsonProperty("summonerId")]
        public ulong SummonerId { get; set; }

        [JsonProperty("accountId")]
        public ulong AccountId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("summonerLevel")]
        public UInt32 SummonerLevel { get; set; }

        [JsonProperty("xpSinceLastLevel")]
        public ulong XpSinceLastLevel { get; set; }

        [JsonProperty("xpUntilNextLevel")]
        public ulong XpUntilNextLevel { get; set; }

        [JsonProperty("percentCompleteForNextLevel")]
        public UInt32 PercentCompleteForNextLevel { get; set; }

        [JsonProperty("rerollPoints")]
        public LolSummonerSummonerRerollPoints RerollPoints { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("nameChangeFlag")]
        public bool NameChangeFlag { get; set; }

        [JsonProperty("unnamed")]
        public bool Unnamed { get; set; }

        [JsonProperty("privacy")]
        public LolSummonerProfilePrivacySetting Privacy { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }
    }
}
