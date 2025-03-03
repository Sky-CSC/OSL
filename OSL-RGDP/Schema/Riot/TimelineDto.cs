using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a timeline data transfer object.
    /// </summary>
    public struct TimelineDto
    {
        /// <summary>
        /// Match metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public MetadataTimeLineDto Metadata { get; set; }
        /// <summary>
        /// Match info.
        /// </summary>
        [JsonProperty("info")]
        public InfoTimeLineDto Info { get; set; }
    }
}
