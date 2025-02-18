using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents a summoner spell in the game.  Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct SummonerSpell
    {
        /// <summary>
        /// The unique identifier of the summoner spell.
        /// </summary>
        [JsonProperty("id")]
        public uint Id { get; set; }
        /// <summary>
        /// The name of the summoner spell.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The path to the summoner spell's icon.
        /// </summary>
        [JsonProperty("iconPath")]
        public string IconPath { get; set; }
    }
}
