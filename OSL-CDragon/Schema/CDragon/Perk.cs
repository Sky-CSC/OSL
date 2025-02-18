using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// Represents a perk in the game. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct Perk
    {
        /// <summary>
        /// The ID of the perk.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the perk.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Path to the perk's icon.
        /// </summary>
        [JsonProperty("iconPath")]
        public string IconPath { get; set; }
    }

    /// <summary>
    /// Represents a perk style in the game. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct PerkStyle
    {
        /// <summary>
        /// The schema version.
        /// </summary>
        [JsonProperty("schemaVersion")]
        public string SchemaVersion { get; set; }
        /// <summary>
        /// The list of perks styles.
        /// </summary>
        [JsonProperty("styles")]
        public List<Style> Styles { get; set; }

    }

    /// <summary>
    /// Represents a style in the game. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct Style
    {
        /// <summary>
        /// The unique identifier of the style.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the style.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The path to the style's icon.
        /// </summary>
        [JsonProperty("iconPath")]
        public string IconPath { get; set; }
        /// <summary>
        /// Other images of perk style.
        /// </summary>
        [JsonProperty("assetMap")]
        public AssetMap AssetMap { get; set; }
    }

    /// <summary>
    /// Represents a asset map in the game. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct AssetMap
    {
        /// <summary>
        /// The svg icon of the perk style.
        /// </summary>
        [JsonProperty("svg_icon")]
        public string SvgIcon { get; set; }
        /// <summary>
        /// The svg 16 icon of the perk style.
        /// </summary>
        [JsonProperty("svg_icon_16")]
        public string SvgIcon16 { get; set; }
    }
}
