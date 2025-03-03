using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a match data transfer object.
    /// </summary>
    public struct MatchDto
    {
        /// <summary>
        /// Match metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public MetadataDto Metadata { get; set; }
        /// <summary>
        /// Match info.
        /// </summary>
        [JsonProperty("info")]
        public InfoDto Info { get; set; }
    }
}
