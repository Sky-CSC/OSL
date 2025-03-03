using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a participant timeline data transfer object.
    /// </summary>
    internal struct ParticipantTimeLineDto
    {
        /// <summary>
        /// The participant id.
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
        /// <summary>
        /// The participant unique identifier.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
    }
}
