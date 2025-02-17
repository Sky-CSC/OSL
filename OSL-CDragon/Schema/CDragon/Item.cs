using Newtonsoft.Json;

namespace OSL_CDragon.Schema.CDragon
{
    /// <summary>
    /// CDragon's representation of an item. Not all argument are present, just the ones that are used.
    /// </summary>
    internal struct Item
    {
        /// <summary>
        /// The ID of the item.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// The name of the item.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The description of the item.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// The list of the item used for build this item.
        /// </summary>
        [JsonProperty("from")]
        public List<int> From { get; set; }
        /// <summary>
        /// The list of the item use this item.
        /// </summary>
        [JsonProperty("to")]
        public List<int> To { get; set; }
        /// <summary>
        /// The price of the item.
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }
        /// <summary>
        /// The total price of the item.
        /// </summary>
        [JsonProperty("priceTotal")]
        public int PriceTotal { get; set; }
        /// <summary>
        /// The path to the item's icon.
        /// </summary>
        [JsonProperty("iconPath")]
        public string IconPath { get; set; }
    }
}
