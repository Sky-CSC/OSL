using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents a chroma of a skin.
    /// </summary>
    internal struct Chroma
    {
        /// <summary>
        /// The unique identifier of the chroma. Not all argument are present, just the ones that are used.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the chroma.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The content identifier of the chroma.
        /// </summary>
        [JsonProperty("contentId")]
        public string ContentId { get; set; }
        /// <summary>
        /// The path to the chroma's icon.
        /// </summary>
        [JsonProperty("chromaPath")]
        public string ChromaPath { get; set; }
        /// <summary>
        /// The list of colors that the chroma uses.
        /// </summary>
        [JsonProperty("colors")]
        public List<string> Colors { get; set; }
    }
}
