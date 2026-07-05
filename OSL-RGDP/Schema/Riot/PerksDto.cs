
using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a perks data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class PerksDto
    {
        /// <summary>
        /// The stats perks selected.
        /// </summary>
        [JsonProperty("statPerks")]
        public PerkStatsDto StatPerks { get; set; }
        /// <summary>
        /// The styles selected.
        /// </summary>
        [JsonProperty("styles")]
        public List<PerkStyleDto> Styles { get; set; }
    }
}
