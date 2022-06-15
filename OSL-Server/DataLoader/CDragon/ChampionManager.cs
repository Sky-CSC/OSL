using Newtonsoft.Json;

namespace OSL_Server.DataLoader.CDragon
{
    public class ChampionManager
    {
        private static OSLLogger _logger = new OSLLogger("ChampionManager");   
        /// <summary>
        /// Recover all champ existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        public static void DownloadChampion(string numPatch, string region)
        {
            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(x => x.Name == numPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);

            string championDirectory = "./" + numPatch + "/" + region + "/" + "Champions" + "/";
            Uri urlChampion = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.championSummary}.json");
            string champion = OSL_Server.Download.Download.DownloadStringAsync(urlChampion).Result;
            if (champion != null)
            {
                try
                {
                    dynamic jsonChampion = JsonConvert.DeserializeObject(champion);
                    OSL_Server.Download.Download.downloadAllFile = 0;
                    OSL_Server.Download.Download.errorDownloadAllFile = 0;
                    foreach (var champ in jsonChampion)
                    {
                        string champId = champ.id;
                        DirectoryManagerLocal.CreateDirectory(championDirectory + champId);
                        DirectoryManagerLocal.CreateDirectory(championDirectory + champId + "/" + "Sound");
                        DirectoryManagerLocal.CreateDirectory(championDirectory + champId + "/" + "Skins");
                        DirectoryManagerLocal.CreateDirectory(championDirectory + champId + "/" + "Abilitys");
                        ChampionAsyncDownload(indexPatch, indexRegion, numPatch, region, championDirectory, champId);
                    }
                    while (OSL_Server.Download.Download.downloadAllFile != 0 && OSL_Server.Download.Download.errorDownloadAllFile == 0)
                    {
                        _logger.log(LoggingLevel.INFO, "ChampionAsyncDownload()", $"Waiting end DownloadFileAsync()");
                        Thread.Sleep(100);
                    }
                    _logger.log(LoggingLevel.INFO, "ChampionAsyncDownload()", $"{OSL_Server.Download.Download.errorDownloadAllFile} error of download");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadChampion()", $"Error json champion {e.Message}");
                }
            }

            //Creer fichier json ou classe qui contient toute les infos des fichier télécharger
            //Téléchager :
            //
            //Champ
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{championSummary}.json
            //https://cdn.communitydragon.org/{patch}/champion/{championId}/data
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{championId}.png
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-choose-vo/{extentionSound}
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-ban-vo/{extentionSound}
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/uncentered/{championId}/{skinId}.jpg
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/{championId}/{skinId}.jpg
            //  
            //https://ddragon.leagueoflegends.com/cdn/img/champion/loading/{championName}_{skinIdModulo}.jpg

            //Dragons
            //Baron
            //Herald
            //Icon
            //Tower
            //Gold
            //Dega


            //Si pas les donées du champ mettre du vide
        }

        /// <summary>
        /// Download and save in local square, sound, splashe, splashe uncentered, loading screen of champ async
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        /// <param name="championDirectory"></param>
        /// <param name="champID"></param>
        public static void ChampionAsyncDownload(int indexPatch, int indexRegion, string numPatch, string region, string championDirectory, string champID)
        {
            //Uri urlChampionId = new($"https://cdn.communitydragon.org/{numPatch}/champion/{champ.id}/data");
            Uri urlChampionId = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champions/{champID}.json");
            string championId = OSL_Server.Download.Download.DownloadStringAsync(urlChampionId).Result;
            if (championId != null)
            {
                dynamic jsonChampionId = JsonConvert.DeserializeObject(championId);

                //download square portrait champion
                //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{championId}.png
                Uri urlChampionPicture = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{jsonChampionId.id}.png");
                string squarePortrait = championDirectory + jsonChampionId.id + "/" + "default-square.png";
                OSL_Server.Download.Download.DownloadFileAsync(urlChampionPicture, squarePortrait);

                //download sound champion
                string championChoose = "";
                string championBan = "";
                string championSfx = "";
                if (jsonChampionId.id != -1)
                {
                    //download sound choose champion
                    //Uri urlChampionSoundChoose = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-choose-vo/{jsonChampionId.id}.ogg");
                    Uri urlChampionSoundChoose;
                    //if (!region.Equals("cs_cz") && !region.Equals("de_de") && !region.Equals("el_gr") && !region.Equals("es_ar") && !region.Equals("es_es") && !region.Equals("es_mx") && !region.Equals("fr_fr") && !region.Equals("hu_hu"))
                    urlChampionSoundChoose = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-choose-vo/{jsonChampionId.id}.ogg");
                    championChoose = championDirectory + jsonChampionId.id + "/Sound/" + "champion-choose.ogg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionSoundChoose, championChoose);
                    if (!File.Exists(championChoose))
                    {
                        urlChampionSoundChoose = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-choose-vo/{jsonChampionId.id}.ogg");
                        OSL_Server.Download.Download.DownloadFileAsync(urlChampionSoundChoose, championChoose);
                    }

                    //download sound ban champion
                    Uri urlChampionSoundBan;
                    urlChampionSoundBan = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-ban-vo/{jsonChampionId.id}.ogg");
                    championBan = championDirectory + jsonChampionId.id + "/Sound/" + "champion-ban.ogg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionSoundBan, championBan);
                    if (!File.Exists(championBan))
                    {
                        urlChampionSoundBan = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-ban-vo/{jsonChampionId.id}.ogg");
                        OSL_Server.Download.Download.DownloadFileAsync(urlChampionSoundBan, championBan);
                    }

                    //download sound sfx champion
                    Uri urlChampionSoundSfx;
                    urlChampionSoundSfx = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-sfx-audios/{jsonChampionId.id}.ogg");
                    championSfx = championDirectory + jsonChampionId.id + "/Sound/" + "champion-sfx.ogg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionSoundSfx, championSfx);
                }

                //download skin champion
                if (jsonChampionId.skins.Count > 0)
                {
                    string championIdSkin = jsonChampionId.skins[0].id;
                    string skinDirectory = championDirectory + jsonChampionId.id + "/Skins/" + championIdSkin + "/";
                    DirectoryManagerLocal.CreateDirectory(skinDirectory);

                    //download splash champion
                    Uri urlChampionSplashe = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/{jsonChampionId.id}/{championIdSkin}.jpg");
                    string championSplashe = skinDirectory + championIdSkin + "_Splashe.jpg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionSplashe, championSplashe);

                    //download splash uncendered champion
                    Uri urlChampionSplasheUncentered = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/uncentered/{jsonChampionId.id}/{championIdSkin}.jpg");
                    string championSplasheUncentered = skinDirectory + championIdSkin + "_Splashe_Uncentered.jpg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionSplasheUncentered, championSplasheUncentered);

                    //download tile champion
                    Uri urlChampionTile = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-tiles/{jsonChampionId.id}/{championIdSkin}.jpg");
                    string championTile = skinDirectory + championIdSkin + "_Tile.jpg";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionTile, championTile);

                    //download load screen champion base
                    string nameChampion = jsonChampionId.alias;
                    string nameChampionToLower = nameChampion.ToLower();

                    string linkLoadScreenChamp = jsonChampionId.skins[0].loadScreenPath;
                    string[] parseLoadScreenChamp = linkLoadScreenChamp.Split('/');
                    string fullNameLoadScreenChamp = parseLoadScreenChamp[parseLoadScreenChamp.Length - 1];
                    string[] parseFullNameLoadScreenChamp = fullNameLoadScreenChamp.Split(".jpg");
                    string nameLoadScreenChamp = parseFullNameLoadScreenChamp[0];
                    nameLoadScreenChamp = nameLoadScreenChamp.ToLower();

                    Uri urlChampionLoadScreen = new($"https://raw.communitydragon.org/{numPatch}/game/assets/characters/{nameChampionToLower}/skins/base/{nameLoadScreenChamp}.png");
                    string championLoadScreen = skinDirectory + championIdSkin + "_LoadScreen.png";
                    OSL_Server.Download.Download.DownloadFileAsync(urlChampionLoadScreen, championLoadScreen);

                    //Update dataCDragon
                    UpdateDataCDragonChampion(indexPatch, indexRegion, jsonChampionId, squarePortrait, championChoose, championBan, championSfx, championSplashe, championSplasheUncentered, championTile, championLoadScreen);
                }
            }
        }

        /// <summary>
        /// Update champion in <see cref="dataCDragon"/>
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="jsonChampionId"></param>
        /// <param name="squarePortrait"></param>
        /// <param name="championChoose"></param>
        /// <param name="championBan"></param>
        /// <param name="championSfx"></param>
        /// <param name="championSplashe"></param>
        /// <param name="championSplasheUncentered"></param>
        /// <param name="championTile"></param>
        /// <param name="championLoadScreen"></param>
        public static void UpdateDataCDragonChampion(int indexPatch, int indexRegion, dynamic jsonChampionId, string squarePortrait, string championChoose, string championBan, string championSfx, string championSplashe, string championSplasheUncentered, string championTile, string championLoadScreen)
        {
            Champion champion = new Champion();
            champion.Id = jsonChampionId.id;
            champion.Name = jsonChampionId.name;
            champion.Alias = jsonChampionId.alias;
            champion.SquarePortraitPath = squarePortrait;
            champion.Sound.ChoosePath = championChoose;
            champion.Sound.BanPath = championBan;
            champion.Sound.SfxPath = championSfx;
            //roles
            //find champion on dataCDragon
            int idChamp = jsonChampionId.id;
            int championDataCDragonIndex = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion.FindIndex(x => x.Id == idChamp);
            if (championDataCDragonIndex != -1)
            {
                int skinDataCDragonIndex = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins.FindIndex(x => x.Id == jsonChampionId.skins[0].id);
                if (skinDataCDragonIndex != -1)
                {
                    CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins[skinDataCDragonIndex].IsBase = true;
                    CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins[skinDataCDragonIndex].SplashePath = championSplashe;
                    CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins[skinDataCDragonIndex].SplasheUncenteredPath = championSplasheUncentered;
                    CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins[skinDataCDragonIndex].TilePath = championTile;
                    CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex].Skins[skinDataCDragonIndex].LoadScreenPath = championLoadScreen;
                }
                else
                {
                    champion.Skins.Add(new Skins()
                    {
                        Id = jsonChampionId.skins[0].id,
                        IsBase = true,
                        SplashePath = championSplashe,
                        SplasheUncenteredPath = championSplasheUncentered,
                        TilePath = championTile,
                        LoadScreenPath = championLoadScreen
                    });
                }
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion[championDataCDragonIndex] = champion;
            }
            else
            {
                champion.Skins.Add(new Skins()
                {
                    Id = jsonChampionId.skins[0].id,
                    IsBase = true,
                    SplashePath = championSplashe,
                    SplasheUncenteredPath = championSplasheUncentered,
                    TilePath = championTile,
                    LoadScreenPath = championLoadScreen
                });
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Champion.Add(champion);
            }
        }
    }
}
