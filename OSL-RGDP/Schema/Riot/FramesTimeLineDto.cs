using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a frames timeline data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class FramesTimeLineDto
    {
        /// <summary>
        /// The events of the game.
        /// </summary>
        [JsonProperty("events")]
        public List<EventsTimeLineDto> Events { get; set; }
        /// <summary>
        /// The participant frames of the game.
        /// </summary>
        [JsonProperty("participantFrames")]
        public ParticipantFramesDto ParticipantFrames { get; set; }
        /// <summary>
        /// The timestamp of the game.
        /// </summary>
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }
}
