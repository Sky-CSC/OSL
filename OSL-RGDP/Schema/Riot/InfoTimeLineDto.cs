using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a info timeline data transfer object.
    /// </summary>
    public struct InfoTimeLineDto
    {
        /// <summary>
        /// Indicates if the game ended in termination.
        /// </summary>
        [JsonProperty("endOfGameResult")]
        public string EndOfGameResult { get; set; }
        /// <summary>
        /// The frame interval of the game.
        /// </summary>
        [JsonProperty("frameInterval")]
        public long FrameInterval { get; set; }
        /// <summary>
        /// The game id.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }
        /// <summary>
        /// The participants of the game.
        /// </summary>
        [JsonProperty("participants")]
        public List<ParticipantTimeLineDto> Participants { get; set; }
        /// <summary>
        /// The frames of the game.
        /// </summary>
        [JsonProperty("frames")]
        public List<FramesTimeLineDto> Frames { get; set; }
    }
}
