using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents an events timeline data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class EventsTimeLineDto
    {
        /// <summary>
        /// The timestamp of the event.
        /// </summary>
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        /// <summary>
        /// The real timestamp of the event.
        /// </summary>
        //[JsonProperty("realTimestamp")]
        //public long RealTimestamp { get; set; }
        /// <summary>
        /// The type of the event.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("monsterType")]
        public string MonsterType { get; set; }
        [JsonProperty("monsterSubType")]
        public string MonsterSubType { get; set; }

        [JsonProperty("killerTeamId")]
        public int KillerTeamId { get; set; }

    }
}
