﻿using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_Common.Download;

namespace OSL_CDragon
{
    /// <summary>
    /// Retrieve data from each items
    /// </summary>
    public class ItemManager
    {
        private static Logger _logger = new("ItemManager");
        public static dynamic itemsList;
        /// <summary>
        /// Recover all items existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        public static void DownloadItems(string numPatch, string region)
        {
            //Items
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{items}.json
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{item});
            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(x => x.Name == numPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);

            //string itemsDirectory = "./" + numPatch + "/" + region + "/" + "Items" + "/";
            string itemsDirectory = CDragon.itemsDirectory;
            Uri urlItems = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.items}.json");
            string itemsData = OSL_Common.Download.Download.DownloadStringAsync(urlItems).Result;
            if (itemsData != null)
            {
                try
                {
                    dynamic jsonItems = JsonConvert.DeserializeObject(itemsData);
                    itemsList = jsonItems;
                    OSL_Common.Download.Download.downloadAllFile = 0;
                    OSL_Common.Download.Download.errorDownloadAllFile = 0;
                    foreach (dynamic item in jsonItems)
                    {
                        int itemId = item.id;
                        //string itemName = item.name;
                        string iconPath = item.iconPath;
                        string[] parseIconPath = iconPath.Split('/');
                        string itemFullName = parseIconPath[parseIconPath.Length - 1];
                        itemFullName = itemFullName.ToLower();
                        ItemsAsyncDownload(indexPatch, indexRegion, numPatch, item, itemsDirectory, itemId, itemFullName);
                    }
                    int infini = 0;
                    while (OSL_Common.Download.Download.downloadAllFile > 0 && OSL_Common.Download.Download.errorDownloadAllFile == 0 && infini != 200)
                    {
                        _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"Waiting end DownloadFileAsync() download : {OSL_Common.Download.Download.downloadAllFile} error : {OSL_Common.Download.Download.errorDownloadAllFile}");
                        infini++;
                        Thread.Sleep(100);
                    }
                    _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"{OSL_Common.Download.Download.errorDownloadAllFile} error of download");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadItems()", $"Error json items {e.Message}");
                }
            }
        }

        /// <summary>
        /// Download and save in local items async
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="numPatch"></param>
        /// <param name="item"></param>
        /// <param name="itemsDirectory"></param>
        /// <param name="itemId"></param>
        /// <param name="itemFullName"></param>
        public static void ItemsAsyncDownload(int indexPatch, int indexRegion, string numPatch, dynamic item, string itemsDirectory, int itemId, string itemFullName)
        {
            Uri urlItemId = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{itemFullName}");
            string itemIcone = itemsDirectory + itemId + ".png";
            OSL_Common.Download.Download.DownloadFileAsync(urlItemId, itemIcone);
            UpdateDataCDragonItems(indexPatch, indexRegion, item, itemIcone);
        }

        /// <summary>
        /// Update <see cref="dataCDragon"/> with items
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="item"></param>
        /// <param name="itemIcone"></param>
        public static void UpdateDataCDragonItems(int indexPatch, int indexRegion, dynamic item, string itemIcone)
        {
            Items itemData = new Items();
            itemData.Id = item.id;
            itemData.Name = item.name;
            String[] splitItemIcone = itemIcone.Split("/wwwroot");
            itemData.IconPath = splitItemIcone[0] + splitItemIcone[1];
            //itemData.From = new();
            foreach (string from in item.from)
            {
                itemData.From.Add(from);
            }
            foreach (string to in item.to)
            {
                itemData.To.Add(to);
            }

            int itemId = item.id;
            int itemDataCDragonIndex = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Items.FindIndex(x => x.Id == itemId);
            if (itemDataCDragonIndex == -1)
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Items.Add(itemData);
            }
            else
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Items[itemDataCDragonIndex] = itemData;
            }
        }        
    }
}
