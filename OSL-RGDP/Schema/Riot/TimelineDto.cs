using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a timeline data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class TimelineDto
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
