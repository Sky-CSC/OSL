using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents a champion summary. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct ChampionSummary
    {
        /// <summary>
        /// The unique identifier of the champion.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the champion.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The alias of the champion.
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }
        /// <summary>
        /// The path to the champion's square portrait.
        /// </summary>
        [JsonProperty("squarePortraitPath")]
        public string SquarePortraitPath { get; set; }
        /// <summary>
        /// The list of roles that the champion can play.
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }
}
