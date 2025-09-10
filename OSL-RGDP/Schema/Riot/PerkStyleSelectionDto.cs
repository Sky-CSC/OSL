using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a perk style selection data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class PerkStyleSelectionDto
    {
        /// <summary>
        /// The perk.
        /// </summary>
        [JsonProperty("perk")]
        public int Perk { get; set; }
        /// <summary>
        /// The first variable.
        /// </summary>
        [JsonProperty("var1")]
        public int Var1 { get; set; }
        /// <summary>
        /// The second variable.
        /// </summary>
        [JsonProperty("var2")]
        public int Var2 { get; set; }
        /// <summary>
        /// The third variable.
        /// </summary>
        [JsonProperty("var3")]
        public int Var3 { get; set; }
    }
}
