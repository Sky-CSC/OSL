using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    public class UpdateDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("publish")]
        public bool Publish { get; set; }
        /// <summary>
        /// Legal values: riotclient, riotstatus, game 
        /// </summary>
        [JsonProperty("publish_locations")]
        public List<string> PublishLocations { get; set; }
        [JsonProperty("translations")]
        public List<ContentDto> Translations { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
