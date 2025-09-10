using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents an objective data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class ObjectiveDto
    {
        /// <summary>
        /// Flag indicating whether the team scored the first objective.
        /// </summary>
        [JsonProperty("first")]
        public bool First { get; set; }
        /// <summary>
        /// The number of kills.
        /// </summary>
        [JsonProperty("kills")]
        public int Kills { get; set; }
    }
}
