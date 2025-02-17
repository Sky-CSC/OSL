using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents a skin of a champion. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct Skin
    {
        /// <summary>
        /// The unique identifier of the skin.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The content identifier of the skin.
        /// </summary>
        [JsonProperty("contentId")]
        public string ContentId { get; set; }
        /// <summary>
        /// If the skin are the base or not.
        /// </summary>
        [JsonProperty("isBase")]
        public bool IsBase { get; set; }
        /// <summary>
        /// The name of the skin.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The splash path of the skin.
        /// </summary>
        [JsonProperty("splashPath")]
        public string SplashPath { get; set; }
        /// <summary>
        /// The uncentered splash path of the skin.
        /// </summary>
        [JsonProperty("uncenteredSplashPath")]
        public string UncenteredSplashPath { get; set; }
        /// <summary>
        /// The tile path of the skin.
        /// </summary>
        [JsonProperty("tilePath")]
        public string TilePath { get; set; }
        /// <summary>
        /// The load screen path of the skin.
        /// </summary>
        [JsonProperty("loadScreenPath")]
        public string LoadScreenPath { get; set; }
        /// <summary>
        /// The chroma path of the skin.
        /// </summary>
        [JsonProperty("chromaPath")]
        public string ChromaPath { get; set; }
        /// <summary>
        /// The list of chromas of the skin.
        /// </summary>
        [JsonProperty("chromas")]
        public List<Chroma> Chromas { get; set; }
    }
}
