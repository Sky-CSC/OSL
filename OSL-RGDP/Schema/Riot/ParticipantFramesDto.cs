using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a participant frames data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class ParticipantFramesDto
    {
        /// <summary>
        /// Key value mapping for each participant 
        /// </summary>
        [JsonProperty("1")]
        public ParticipantFrameDto Participant1 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("2")]
        public ParticipantFrameDto Participant2 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("3")]
        public ParticipantFrameDto Participant3 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("4")]
        public ParticipantFrameDto Participant4 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("5")]
        public ParticipantFrameDto Participant5 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("6")]
        public ParticipantFrameDto Participant6 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("7")]
        public ParticipantFrameDto Participant7 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("8")]
        public ParticipantFrameDto Participant8 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("9")]
        public ParticipantFrameDto Participant9 { get; set; }
        /// <summary>
        /// Key value mapping for each participant
        /// </summary>
        [JsonProperty("10")]
        public ParticipantFrameDto Participant10 { get; set; }
    }
}
