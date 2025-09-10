using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class ChampSelectBannedChampions
    {
        [JsonProperty("myTeamBans")]
        public List<int> MyTeamBans { get; set; }

        [JsonProperty("theirTeamBans")]
        public List<int> TheirTeamBans { get; set; }

        [JsonProperty("numBans")]
        public int NumBans { get; set; }
    }
}
