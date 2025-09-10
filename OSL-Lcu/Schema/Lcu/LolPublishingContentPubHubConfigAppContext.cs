using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolPublishingContentPubHubConfigAppContext
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("userRegion")]
        public string UserRegion { get; set; }

        [JsonProperty("deviceCategory")]
        public string DeviceCategory { get; set; }

        [JsonProperty("deviceOperatingSystem")]
        public string DeviceOperatingSystem { get; set; }

        [JsonProperty("deviceOperatingSystemVersion")]
        public string DeviceOperatingSystemVersion { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("appLocale")]
        public string AppLocale { get; set; }

        [JsonProperty("appLanguage")]
        public string AppLanguage { get; set; }

        [JsonProperty("publishingLocale")]
        public string PublishingLocale { get; set; }

        [JsonProperty("appSessionId")]
        public string AppSessionId { get; set; }
    }
}
