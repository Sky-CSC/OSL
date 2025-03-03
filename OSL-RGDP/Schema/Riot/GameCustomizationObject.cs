using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a game customization object.
    /// </summary>
    public struct GameCustomizationObject
    {
        /// <summary>
        /// Category identifier for Game Customization
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }
        /// <summary>
        /// Game Customization content
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
