using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class MucJwtDto
    {
        [JsonProperty("jwt")]
        public string Jwt { get; set; }

        [JsonProperty("channelClaim")]
        public string ChannelClaim { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("targetRegion")]
        public string TargetRegion { get; set; }
    }
}
