using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// This object contains ban information.
    /// </summary>
    internal struct BanDto
    {
        /// <summary>
        /// The ID of the banned champion.
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        /// <summary>
        /// The turn during which the champion was banned.
        /// </summary>
        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }
    }
}
