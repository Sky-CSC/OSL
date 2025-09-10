using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class ChampSelectChatRoomDetails
    {
        [JsonProperty("multiUserChatId")]
        public string MultiUserChatId { get; set; }

        [JsonProperty("multiUserChatPassword")]
        public string MultiUserChatPassword { get; set; }

        [JsonProperty("mucJwtDto")]
        public MucJwtDto MucJwtDto { get; set; }
    }
}
