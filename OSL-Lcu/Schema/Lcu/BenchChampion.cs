using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class BenchChampion
    {
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("isPriority")]
        public bool IsPriority { get; set; }
    }
}
