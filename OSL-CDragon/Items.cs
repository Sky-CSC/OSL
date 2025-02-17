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
        /// <returns></returns>
        internal List<Item> Download()
        {
            Uri urlItems = new($"https://raw.communitydragon.org/{_info.PatchShort}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/{_info.Items}.json");
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
        /// Download item icons2d asset.
        /// </summary>
        /// <param name="itemCDragon"></param>
        /// <returns></returns>
        private Item ItemAssets(Schema.CDragon.Item itemCDragon)
        {
            string itemName = itemCDragon.IconPath.Split("/Icons2D/")[^1].ToLower();
            Uri urlItem = new($"https://raw.communitydragon.org/{_info.PatchShort}/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{itemName}");
            Item item = new(itemCDragon.Id, itemCDragon.Name, DownloadFile(urlItem, itemCDragon.Id, "items"), itemCDragon.From, itemCDragon.To);
            return item;
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="id">item id</param>
        /// <param name="directory">directory how to save files</param>
        /// <returns></returns>
        private string DownloadFile(Uri url, int id, string directory)
        {
            byte[]? data = _download.FileAsync(url).Result;
            if (data != null)
            {
                try
                {
                    string filePath = OSL_Utils.Path.Combine(_info.AssetsDir, directory, $"{id}.png");
                    OSL_Utils.File.Write(filePath, data);
                    _logger.Log(LoggingLevel.INFO, "DownloadFile()", $"File {id} downloaded");
                    return filePath;

                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, "DownloadFile()", $"File {id} not downloaded : {e.Message}");
                }
            }
            _logger.Log(LoggingLevel.ERROR, "DownloadFile()", $"File {id} not downloaded");
            return "";
        }
    }
}
