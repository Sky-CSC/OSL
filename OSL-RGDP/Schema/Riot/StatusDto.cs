using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    public class StatusDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The maintenance status of the status update. (Legal values: scheduled, in_progress, complete)
        /// </summary>
        [JsonProperty("maintenance_status")]
        public string Status { get; set; }
        /// <summary>
        /// The severity of the incident. (Legal values: info, warning, critical)
        /// </summary>
        [JsonProperty("incident_severity")]
        public string Severity { get; set; }
        [JsonProperty("titles")]
        public List<ContentDto> Titles { get; set; }
        [JsonProperty("updates")]
        public List<UpdateDto> Updates { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("archive_at")]
        public string ArchiveAt { get; set; }
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        /// <summary>
        /// The platforms affected by the status update. (Legal values: windows, macos, android, ios, ps4, xbone, switch)
        /// </summary>
        [JsonProperty("platforms")]
        public List<string> Platforms { get; set; }

    }
}
