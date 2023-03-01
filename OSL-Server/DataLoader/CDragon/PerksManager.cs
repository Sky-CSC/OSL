using Newtonsoft.Json;

namespace OSL_Server.DataLoader.CDragon
{
    /// <summary>
    /// Perks Manager
    /// </summary>
    public class PerksManager
    {
        private static OSLLogger _logger = new OSLLogger("PerksManager");

        /// <summary>
        /// Recover all perks existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        public static void DownloadPerks(string numPatch, string region)
        {
            //Perks
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{perks}.json
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{itemUrlDirectory}{item}
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{perkstyles}.json
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{itemUrlDirectory}{item}
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{svg_iconUrlDirectory}{svg}

            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(x => x.Name == numPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);

            //string perksDirectory = "./" + numPatch + "/" + region + "/" + "Perks" + "/";
            string perksDirectory = DirectoryManagerLocal.perksDirectory;
            DownloadPerksComposent(numPatch, region, perksDirectory, indexPatch, indexRegion);
            DownloadPerksStyle(numPatch, region, perksDirectory, indexPatch, indexRegion);
        }

        /// <summary>
        /// Download all perks existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        /// <param name="perksDirectory"></param>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        public static void DownloadPerksComposent(string numPatch, string region, string perksDirectory, int indexPatch, int indexRegion)
        {
            Uri urlPerks = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.perks}.json");
            string perksData = OSL_Server.Download.Download.DownloadStringAsync(urlPerks).Result;
            if (perksData != null)
            {
                try
                {
                    dynamic jsonPerks = JsonConvert.DeserializeObject(perksData);
                    OSL_Server.Download.Download.downloadAllFile = 0;
                    OSL_Server.Download.Download.errorDownloadAllFile = 0;
                    foreach (dynamic perk in jsonPerks)
                    {
                        try
                        {
                            perksDirectory = DirectoryManagerLocal.perksDirectory;
                            int perkId = perk.id;
                            //string perkName = perk.name;
                            string iconPath = perk.iconPath;
                            string[] parseIconPath = iconPath.Split('/');
                            string perkFullName = "";
                            if (iconPath.Contains("StatMods/"))
                            {
                                perkFullName = parseIconPath[parseIconPath.Length - 2] + "/" + parseIconPath[parseIconPath.Length - 1];
                                perkFullName = perkFullName.ToLower();
                                perksDirectory += "StatMods/";
                                DirectoryManagerLocal.CreateDirectory(perksDirectory);
                            }
                            else if (iconPath.Contains("Styles/"))
                            {
                                for (int i = 5; i < parseIconPath.Length; i++)
                                {
                                    perkFullName += parseIconPath[i];
                                    if (i != parseIconPath.Length - 1)
                                    {
                                        perkFullName += "/";
                                    }
                                }
                                perkFullName = perkFullName.ToLower();
                                perksDirectory += "Styles/";
                                if (parseIconPath.Length > 5)
                                {
                                    perksDirectory += parseIconPath[6] + "/";
                                }
                                DirectoryManagerLocal.CreateDirectory(perksDirectory);
                            }
                            //string perkFullName = parseIconPath[parseIconPath.Length - 1];
                            //perkFullName = perkFullName.ToLower();
                            _logger.log(LoggingLevel.INFO, "PerksAsyncDownload()", $"Run PerksAsyncDownload");
                            PerksAsyncDownload(indexPatch, indexRegion, numPatch, perk, perksDirectory, perkId, perkFullName);
                        }
                        catch (Exception e)
                        {
                            _logger.log(LoggingLevel.ERROR, "PerksAsyncDownload()", $"Errot, PerksAsyncDownload not run : {e.Message}");
                        }
                    }
                    int infini = 0;
                    while (OSL_Server.Download.Download.downloadAllFile > 0 && OSL_Server.Download.Download.errorDownloadAllFile == 0 && infini != 200)
                    {
                        _logger.log(LoggingLevel.INFO, "PerksAsyncDownload()", $"Waiting end DownloadFileAsync() download : {Download.Download.downloadAllFile} error : {Download.Download.errorDownloadAllFile}");
                        infini++;
                        Thread.Sleep(100);
                    }
                    _logger.log(LoggingLevel.INFO, "PerksAsyncDownload()", $"{OSL_Server.Download.Download.errorDownloadAllFile} error of download");

                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadPerksComposent()", $"Error json perks component : {e.Message}");
                }
            }
        }

        /// <summary>
        /// Download all perks existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        /// <param name="perksDirectory"></param>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        public static void DownloadPerksStyle(string numPatch, string region, string perksDirectory, int indexPatch, int indexRegion)
        {
            Uri urlPerks = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.perkstyles}.json");
            string perksData = OSL_Server.Download.Download.DownloadStringAsync(urlPerks).Result;
            if (perksData != null)
            {
                try
                {
                    dynamic jsonPerks = JsonConvert.DeserializeObject(perksData);
                    OSL_Server.Download.Download.downloadAllFile = 0;
                    OSL_Server.Download.Download.errorDownloadAllFile = 0;
                    foreach (dynamic perk in jsonPerks.styles)
                    {
                        perksDirectory = DirectoryManagerLocal.perksDirectory;
                        int perkId = perk.id;
                        string iconPath = perk.iconPath;
                        string[] parseIconPath = iconPath.Split('/');
                        string perkFullName = parseIconPath[parseIconPath.Length - 2] + "/" + parseIconPath[parseIconPath.Length - 1];
                        perkFullName = perkFullName.ToLower();
                        PerksAsyncDownload(indexPatch, indexRegion, numPatch, perk, perksDirectory, perkId, perkFullName);
                    }
                    int infini = 0;
                    while (OSL_Server.Download.Download.downloadAllFile > 0 && OSL_Server.Download.Download.errorDownloadAllFile == 0 && infini != 200)
                    {
                        _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"Waiting end DownloadFileAsync() download : {Download.Download.downloadAllFile} error : {Download.Download.errorDownloadAllFile}");
                        infini++;
                        Thread.Sleep(100);
                    }
                    _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"{OSL_Server.Download.Download.errorDownloadAllFile} error of download");
                }
                catch
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadPerksStyle()", $"Error json perks style");
                }
            }
        }

        /// <summary>
        /// Download perks async
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="numPatch"></param>
        /// <param name="perk"></param>
        /// <param name="perksDirectory"></param>
        /// <param name="perkId"></param>
        /// <param name="perkFullName"></param>
        public static void PerksAsyncDownload(int indexPatch, int indexRegion, string numPatch, dynamic perk, string perksDirectory, int perkId, string perkFullName)
        {
            Uri urlPerkId = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{perkFullName}");
            string perkIcone = perksDirectory + perkId + ".png";
            OSL_Server.Download.Download.DownloadFileAsync(urlPerkId, perkIcone);

            UpdateDataCDragonPerks(indexPatch, indexRegion, perk, perkIcone);
        }

        ///
        /// Update perks in <see cref="dataCDragon"/>
        ///
        public static void UpdateDataCDragonPerks(int indexPatch, int indexRegion, dynamic perk, string perkIcone)
        {
            Perks perksData = new Perks();
            perksData.Id = perk.id;
            perksData.Name = perk.name;
            String[] splitPerkIcone = perkIcone.Split("/wwwroot");
            //perksData.IconPath = perkIcone.Remove(1, 7);
            perksData.IconPath = splitPerkIcone[0] + splitPerkIcone[1];
            //itemData.From = new();

            int perksId = perk.id;
            int perksDataCDragonIndex = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Items.FindIndex(x => x.Id == perksId);
            if (perksDataCDragonIndex == -1)
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Perks.Add(perksData);
            }
            else
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Perks[perksDataCDragonIndex] = perksData;
            }
        }
    }
}
