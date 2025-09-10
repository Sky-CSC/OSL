using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a metadata timeline data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class MetadataTimeLineDto
    {
        /// <summary>
        /// Match data version.
        /// </summary>
        [JsonProperty("dataVersion")]
        public string DataVersion { get; set; }
        /// <summary>
        /// Match id.
        /// </summary>
        [JsonProperty("matchId")]
        public string MatchId { get; set; }
        /// <summary>
        /// A list of participant PUUIDs.
        /// </summary>
        [JsonProperty("participants")]
        public List<string> Participants { get; set; }
    }
}
