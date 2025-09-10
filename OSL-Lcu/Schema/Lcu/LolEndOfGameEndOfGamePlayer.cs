using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolEndOfGameEndOfGamePlayer
    {
        [JsonProperty("stats")]
        public object Stats { get; set; }

        [JsonProperty("items")]
        public List<int> Items { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("riotIdGameName")]
        public string RiotIdGameName { get; set; }

        [JsonProperty("riotIdTagLine")]
        public string RiotIdTagLine { get; set; }

        [JsonProperty("botPlayer")]
        public bool BotPlayer { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("gameId")]
        public int GameId { get; set; }

        [JsonProperty("leaver")]
        public bool Leaver { get; set; }

        [JsonProperty("leaves")]
        public int Leaves { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }

        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("summonerId")]
        public int SummonerId { get; set; }

        [JsonProperty("selectedPosition")]
        public string SelectedPosition { get; set; }

        [JsonProperty("detectedTeamPosition")]
        public string DetectedTeamPosition { get; set; }

        [JsonProperty("skinSplashPath")]
        public string SkinSplashPath { get; set; }

        [JsonProperty("skinTilePath")]
        public string SkinTilePath { get; set; }

        [JsonProperty("skinEmblemPaths")]
        public List<string> SkinEmblemPaths { get; set; }

        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        [JsonProperty("championSquarePortraitPath")]
        public string ChampionSquarePortraitPath { get; set; }

        [JsonProperty("isLocalPlayer")]
        public bool IsLocalPlayer { get; set; }
    }
}
