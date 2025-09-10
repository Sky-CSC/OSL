using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a damage stats data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class DamageStatsDto
    {
        /// <summary>
        /// The magic damage done.
        /// </summary>
        [JsonProperty("magicDamageDone")]
        public int MagicDamageDone { get; set; }
        /// <summary>
        /// The magic damage done to champions.
        /// </summary>
        [JsonProperty("magicDamageDoneToChampions")]
        public int MagicDamageDoneToChampions { get; set; }
        /// <summary>
        /// The magic damage taken.
        /// </summary>
        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }
        /// <summary>
        /// The physical damage done.
        /// </summary>
        [JsonProperty("physicalDamageDone")]
        public int PhysicalDamageDone { get; set; }
        /// <summary>
        /// The physical damage done to champions.
        /// </summary>
        [JsonProperty("physicalDamageDoneToChampions")]
        public int PhysicalDamageDoneToChampions { get; set; }
        /// <summary>
        /// The physical damage taken.
        /// </summary>
        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }
        /// <summary>
        /// The total damage done.
        /// </summary>
        [JsonProperty("totalDamageDone")]
        public int TotalDamageDone { get; set; }
        /// <summary>
        /// The total damage done to champions.
        /// </summary>
        [JsonProperty("totalDamageDoneToChampions")]
        public int TotalDamageDoneToChampions { get; set; }
        /// <summary>
        /// The total damage taken.
        /// </summary>
        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }
        /// <summary>
        /// The true damage done.
        /// </summary>
        [JsonProperty("trueDamageDone")]
        public int TrueDamageDone { get; set; }
        /// <summary>
        /// The true damage done to champions.
        /// </summary>
        [JsonProperty("trueDamageDoneToChampions")]
        public int TrueDamageDoneToChampions { get; set; }
        /// <summary>
        /// The true damage taken.
        /// </summary>
        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }
    }
}
