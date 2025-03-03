using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents the perks/runes assigned to a player.
    /// </summary>
    public struct Perks
    {
        /// <summary>
        /// IDs of the perks/runes assigned.
        /// </summary>
        [JsonProperty("perkIds")]
        public List<long> PerkIds { get; set; }
        /// <summary>
        /// Primary runes path
        /// </summary>
        [JsonProperty("perkStyle")]
        public long PerkStyle { get; set; }
        /// <summary>
        /// Secondary runes path
        /// </summary>
        [JsonProperty("perkSubStyle")]
        public long PerkSubStyle { get; set; }
    }
}
