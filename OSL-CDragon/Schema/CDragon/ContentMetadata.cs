using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents the metadata of the version.
    /// </summary>
    internal struct ContentMetadata
    {
        /// <summary>
        /// The version of path.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
        public ContentMetadata()
        {
            Version = string.Empty;
        }
    }
}
