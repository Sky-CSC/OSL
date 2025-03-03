using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents an objectives data transfer object.
    /// </summary>
    public struct ObjectivesDto
    {
        /// <summary>
        /// The Baron Nashor objective.
        /// </summary>
        [JsonProperty("baron")]
        public ObjectiveDto Baron { get; set; }
        /// <summary>
        /// The champion objective.
        /// </summary>
        [JsonProperty("champion")]
        public ObjectiveDto Champion { get; set; }
        /// <summary>
        /// The dragon objective.
        /// </summary>
        [JsonProperty("dragon")]
        public ObjectiveDto Dragon { get; set; }
        /// <summary>
        /// The horde objective.
        /// </summary>
        [JsonProperty("horde")]
        public ObjectiveDto Horde { get; set; }
        /// <summary>
        /// The inhibitor objective.
        /// </summary>
        [JsonProperty("inhibitor")]
        public ObjectiveDto Inhibitor { get; set; }
        /// <summary>
        /// The Rift Herald objective.
        /// </summary>
        [JsonProperty("riftHerald")]
        public ObjectiveDto RiftHerald { get; set; }
        /// <summary>
        /// The tower objective.
        /// </summary>
        [JsonProperty("tower")]
        public ObjectiveDto Tower { get; set; }
    }
}
