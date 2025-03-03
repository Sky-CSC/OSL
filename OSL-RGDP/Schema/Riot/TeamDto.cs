using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a team data transfer object.
    /// </summary>
    public struct TeamDto
    {
        /// <summary>
        /// The bans of the team.
        /// </summary>
        [JsonProperty("bans")]
        public List<BanDto> Bans { get; set; }
        /// <summary>
        /// The objectives of the team.
        /// </summary>
        [JsonProperty("objectives")]
        public ObjectivesDto Objectives { get; set; }
        /// <summary>
        /// The ID of the team.
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        /// <summary>
        /// Whether the team won.
        /// </summary>
        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
