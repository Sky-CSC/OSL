using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class TeambuilderDirectTypesChampSelectTimer
    {
        [JsonProperty("adjustedTimeLeftInPhase")]
        public long AdjustedTimeLeftInPhase { get; set; }

        [JsonProperty("totalTimeInPhase")]
        public long TotalTimeInPhase { get; set; }

        [JsonProperty("phase")]
        public string Phase { get; set; }

        [JsonProperty("isInfinite")]
        public bool IsInfinite { get; set; }

        [JsonProperty("internalNowInEpochMs")]
        public int InternalNowInEpochMs { get; set; }
    }
}
