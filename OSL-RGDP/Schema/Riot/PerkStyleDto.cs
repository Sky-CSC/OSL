using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a perk style data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class PerkStyleDto
    {
        /// <summary>
        /// The description of the perk style.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// The selections of the perk style.
        /// </summary>
        [JsonProperty("selections")]
        public List<PerkStyleSelectionDto> Selections { get; set; }
        /// <summary>
        /// The style of the perk.
        /// </summary>
        [JsonProperty("style")]
        public int Style { get; set; }
    }
}
