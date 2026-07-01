using Newtonsoft.Json;
using static MudBlazor.CategoryTypes;

namespace OSL_RGDP.Schema.Riot
{
    public class PlatformDataDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("locales")]
        public List<string> Locales { get; set; }

        [JsonProperty("maintenances")]
        public List<StatusDto> Maintenances { get; set; }
        [JsonProperty("incidents")]
        public List<StatusDto> Incidents { get; set; }
    }
}
