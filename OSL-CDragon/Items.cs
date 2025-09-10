using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Download items data.
    /// </summary>
    /// <param name="info"></param>
    internal class Items(Info info)
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Items");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();
        /// <summary>
        /// The information fort download assets.
        /// </summary>
        private Info _info = info;
        /// <summary>
        /// The list of items.
        /// </summary>
        private readonly List<Item> _items = [];

        /// <summary>
        /// Download items data.
        /// </summary>
        /// <returns>list of items</returns>
        internal List<Item> Download()
        {
            Uri urlItems = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/items.json");
            string? items = _download.StringAsync(urlItems).Result;
            if (items != null)
            {
                try
                {
                    List<Schema.CDragon.Item>? itemSummary = JsonConvert.DeserializeObject<List<Schema.CDragon.Item>>(items);
                    if (itemSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Items not downloaded");
                        return _items;
                    }
                    foreach (Schema.CDragon.Item item in itemSummary)
                    {
                        // Process each item 
                        _items.Add(ItemAssets(item));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Items not downloaded : {ex.Message}");
                    return _items;
                }
            }
            return _items;
        }

        /// <summary>
        /// Download item icons2d assets.
        /// </summary>
        /// <param name="itemCDragon">CDragon item info</param>
        /// <returns>Item</returns>
        private Item ItemAssets(Schema.CDragon.Item itemCDragon)
        {
            string itemName = itemCDragon.IconPath.Split("/Icons2D/")[^1].ToLower();
            Uri urlItem = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{itemName}");
            Item item = new(itemCDragon.Id, itemCDragon.Name, _download.DownloadFile(urlItem, $"{_info.AssetsDir}/items", $"{itemCDragon.Id}.png"), itemCDragon.From, itemCDragon.To);
            return item;
        }
    }
}
