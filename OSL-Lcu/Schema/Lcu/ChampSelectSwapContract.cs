using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class ChampSelectSwapContract
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cellId")]
        public long CellId { get; set; }

        [JsonProperty("state")]
        public ChampSelectSwapState State { get; set; }
    }
}
