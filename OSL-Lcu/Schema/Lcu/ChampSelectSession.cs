using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class ChampSelectSession
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("gameId")]
        public int GameId { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        [JsonProperty("timer")]
        public ChampSelectTimer Timer { get; set; }

        [JsonProperty("chatDetails")]
        public ChampSelectChatRoomDetails ChatDetails { get; set; }

        [JsonProperty("myTeam")]
        public List<ChampSelectPlayerSelection> MyTeam { get; set; }

        [JsonProperty("theirTeam")]
        public List<ChampSelectPlayerSelection> TheirTeam { get; set; }

        [JsonProperty("trades")]
        public List<ChampSelectSwapContract> Trades { get; set; }

        [JsonProperty("pickOrderSwaps")]
        public List<ChampSelectSwapContract> PickOrderSwaps { get; set; }

        [JsonProperty("positionSwaps")]
        public List<ChampSelectSwapContract> PositionSwaps { get; set; }

        [JsonProperty("actions")]
        public List<object> Actions { get; set; }

        [JsonProperty("bans")]
        public ChampSelectBannedChampions Bans { get; set; }

        [JsonProperty("localPlayerCellId")]
        public long LocalPlayerCellId { get; set; }

        [JsonProperty("isSpectating")]
        public bool IsSpectating { get; set; }

        [JsonProperty("allowSkinSelection")]
        public bool AllowSkinSelection { get; set; }

        [JsonProperty("allowSubsetChampionPicks")]
        public bool AllowSubsetChampionPicks { get; set; }

        [JsonProperty("allowDuplicatePicks")]
        public bool AllowDuplicatePicks { get; set; }

        [JsonProperty("allowBattleBoost")]
        public bool AllowBattleBoost { get; set; }

        [JsonProperty("boostableSkinCount")]
        public int BoostableSkinCount { get; set; }

        [JsonProperty("allowRerolling")]
        public bool AllowRerolling { get; set; }

        [JsonProperty("rerollsRemaining")]
        public int RerollsRemaining { get; set; }

        [JsonProperty("allowLockedEvents")]
        public bool AllowLockedEvents { get; set; }

        [JsonProperty("lockedEventIndex")]
        public int LockedEventIndex { get; set; }

        [JsonProperty("benchEnabled")]
        public bool BenchEnabled { get; set; }

        [JsonProperty("benchChampions")]
        public List<BenchChampion> BenchChampions { get; set; }

        [JsonProperty("counter")]
        public long Counter { get; set; }

        [JsonProperty("skipChampionSelect")]
        public bool SkipChampionSelect { get; set; }

        [JsonProperty("hasSimultaneousBans")]
        public bool HasSimultaneousBans { get; set; }

        [JsonProperty("hasSimultaneousPicks")]
        public bool HasSimultaneousPicks { get; set; }

        [JsonProperty("showQuitButton")]
        public bool ShowQuitButton { get; set; }

        [JsonProperty("isLegacyChampSelect")]
        public bool IsLegacyChampSelect { get; set; }

        [JsonProperty("isCustomGame")]
        public bool IsCustomGame { get; set; }
    }
}
