using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a participant frame data transfer object.
    /// </summary>
    internal struct ParticipantFrameDto
    {
        /// <summary>
        /// The champion stats.
        /// </summary>
        [JsonProperty("championStats")]
        public ChampionStatsDto ChampionStats { get; set; }
        /// <summary>
        /// The current gold.
        /// </summary>
        [JsonProperty("currentGold")]
        public int CurrentGold { get; set; }
        /// <summary>
        /// The damage stats.
        /// </summary>
        [JsonProperty("damageStats")]
        public DamageStatsDto DamageStats { get; set; }
        /// <summary>
        /// The gold per second.
        /// </summary>
        [JsonProperty("goldPerSecond")]
        public int GoldPerSecond { get; set; }
        /// <summary>
        /// The jungle minions killed.
        /// </summary>
        [JsonProperty("jungleMinionsKilled")]
        public int JungleMinionsKilled { get; set; }
        /// <summary>
        /// The level.
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
        /// <summary>
        /// The minions killed.
        /// </summary>
        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }
        /// <summary>
        /// The participant id.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
        /// <summary>
        /// The position.
        /// </summary>
        [JsonProperty("position")]
        public PositionDto Position { get; set; }
        /// <summary>
        /// The time enemy spent controlled.
        /// </summary>
        [JsonProperty("timeEnemySpentControlled")]
        public int TimeEnemySpentControlled { get; set; }
        /// <summary>
        /// The total gold.
        /// </summary>
        [JsonProperty("totalGold")]
        public int TotalGold { get; set; }
        /// <summary>
        /// The xp.
        /// </summary>
        [JsonProperty("xp")]
        public int Xp { get; set; }
    }
}
