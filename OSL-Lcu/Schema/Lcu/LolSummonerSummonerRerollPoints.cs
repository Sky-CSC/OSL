

using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    public class LolSummonerSummonerRerollPoints
    {
        [JsonProperty("pointsToReroll")]
        public UInt32 PointsToReroll { get; set; }

        [JsonProperty("currentPoints")]
        public UInt32 CurrentPoints { get; set; }

        [JsonProperty("numberOfRolls")]
        public UInt32 NumberOfRolls { get; set; }

        [JsonProperty("maxRolls")]
        public UInt32 MaxRolls { get; set; }

        [JsonProperty("pointsCostToRoll")]
        public UInt32 PointsCostToRoll { get; set; }
    }
}
