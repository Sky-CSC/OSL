using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    public class ChampSelectAction
    {
        [JsonProperty("id")]
        public Int64 Id { get; set; }
        [JsonProperty("actorCellId")]
        public Int64 ActorCellId { get; set; }
        [JsonProperty("championId")]
        public Int32 ChampionId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("completed")]
        public bool Completed { get; set; }
        [JsonProperty("isAllyAction")]
        public bool IsAllyAction { get; set; }
        [JsonProperty("isInProgress")]
        public bool IsInProgress { get; set; }
        [JsonProperty("pickTurn")]
        public Int32 PickTurn { get; set; }
        [JsonProperty("duration")]
        public Int64 Duration { get; set; }
    }
}
