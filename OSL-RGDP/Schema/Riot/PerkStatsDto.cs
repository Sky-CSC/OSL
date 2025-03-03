using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a perk stats data transfer object.
    /// </summary>
    internal struct PerkStatsDto
    {
        /// <summary>
        /// The defense stat.
        /// </summary>
        [JsonProperty("defense")]
        public int Defense { get; set; }
        /// <summary>
        /// The flex stat.
        /// </summary>
        [JsonProperty("flex")]
        public int Flex { get; set; }
        /// <summary>
        /// The offense stat.
        /// </summary>
        [JsonProperty("offense")]
        public int Offense { get; set; }
    }
}
