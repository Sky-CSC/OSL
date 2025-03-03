using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a match metadata data transfer object.
    /// </summary>
    public struct MetadataDto
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
