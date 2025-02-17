using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// CDragon's representation of a champion. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct Champion
    {
        /// <summary>
        /// The ID of the champion.
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
        /// The title of the champion.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// The short biography of the champion.
        /// </summary>
        [JsonProperty("shortBio")]
        public string ShortBio { get; set; }
        /// <summary>
        /// The square portrait path of the champion.
        /// </summary>
        [JsonProperty("squarePortraitPath")]
        public string SquarePortraitPath { get; set; }
        /// <summary>
        /// The splash path of the champion.
        /// </summary>
        [JsonProperty("stingerSfxPath")]
        public string StingerSfxPath { get; set; }
        /// <summary>
        /// The choose voice path of the champion.
        /// </summary>
        [JsonProperty("chooseVoPath")]
        public string ChooseVoPath { get; set; }
        /// <summary>
        /// The ban voice path of the champion.
        /// </summary>
        [JsonProperty("banVoPath")]
        public string BanVoPath { get; set; }
        /// <summary>
        /// The list of roles of the champion.
        /// </summary>
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
        /// <summary>
        /// The list of skins of the champion.
        /// </summary>
        [JsonProperty("skins")]
        public List<Skin> Skins { get; set; }
    }
}
