using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    public class ContentDto
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
