using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents an events timeline data transfer object.
    /// </summary>
    public struct EventsTimeLineDto
    {
        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        /// <summary>
        /// The real timestamp of the event.
        /// </summary>
        [JsonProperty("realTimestamp")]
        public long RealTimestamp { get; set; }
        /// <summary>
        /// The type of the event.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
