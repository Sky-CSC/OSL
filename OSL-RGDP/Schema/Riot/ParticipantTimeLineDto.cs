using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a participant timeline data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class ParticipantTimeLineDto
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
