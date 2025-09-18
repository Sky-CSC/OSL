using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class ChampSelectPlayerSelection
    {
        [JsonProperty("cellId")]
        public long CellId { get; set; }

        [JsonProperty("championId")]
        public Int64 ChampionId { get; set; }

        [JsonProperty("selectedSkinId")]
        public int SelectedSkinId { get; set; }

        [JsonProperty("wardSkinId")]
        public long WardSkinId { get; set; }

        [JsonProperty("spell1Id")]
        public UInt64 Spell1Id { get; set; }

        [JsonProperty("spell2Id")]
        public UInt64 Spell2Id { get; set; }

        [JsonProperty("team")]
        public int Team { get; set; }

        [JsonProperty("assignedPosition")]
        public string AssignedPosition { get; set; }

        [JsonProperty("championPickIntent")]
        public int ChampionPickIntent { get; set; }

        [JsonProperty("playerType")]
        public string PlayerType { get; set; }

        [JsonProperty("summonerId")]
        public Int64 SummonerId { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("tagLine")]
        public string TagLine { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("isHumanoid")]
        public bool IsHumanoid { get; set; }

        [JsonProperty("nameVisibilityType")]
        public string NameVisibilityType { get; set; }

        [JsonProperty("playerAlias")]
        public string PlayerAlias { get; set; }

        [JsonProperty("obfuscatedSummonerId")]
        public int ObfuscatedSummonerId { get; set; }

        [JsonProperty("obfuscatedPuuid")]
        public string ObfuscatedPuuid { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("pickMode")]
        public int PickMode { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }
}
