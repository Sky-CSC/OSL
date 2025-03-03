using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a banned champion in a game.
    /// </summary>
    public struct BannedChampion
    {
        /// <summary>
        /// The turn during which the champion was banned.
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
        /// <summary>
        /// The ID of the banned champion.
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }
        /// <summary>
        /// The ID of the team that banned the champion.
        /// </summary>
        [JsonProperty("teamId")]
        public long TeamId { get; set; }
    }
}
