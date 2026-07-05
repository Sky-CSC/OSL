using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolPublishingContentPubHubConfig
    {
        [JsonProperty("edge")]
        public LolPublishingContentPubHubConfigEdge Edge { get; set; }

        [JsonProperty("appContext")]
        public LolPublishingContentPubHubConfigAppContext AppContext { get; set; }
    }
}
