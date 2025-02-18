using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Manage download of League of Legends assets
    /// </summary>
    public class CDragon
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("CDragon");

        /// <summary>
        /// The général information used for download assets
        /// </summary>
        private Info _info = new();

        /// <summary>
        /// Save data of all assets
        /// </summary>
        private Data _data = new();

        /// <summary>
        /// The index of the patch current used
        /// </summary>
        private int _indexPatch = -1;
        /// <summary>
        /// The index of the region current used
        /// </summary>
        private int _indexRegion = -1;

        /// <summary>
        /// Download champions, items, summoner spells, perks and perkstyles assets
        /// </summary>
        /// <returns>True if assets are downloaded</returns>
        public bool DownloadAssets()
        {
            if (CheckPatchRegion() && CreateDirectories())
            {
                Champions champion = new(_info);
                _data.Patchs[_indexPatch].Regions[_indexRegion].Champions = champion.Download();
                Items items = new(_info);
                _data.Patchs[_indexPatch].Regions[_indexRegion].Items = items.Download();
                Perks perks = new(_info);
                _data.Patchs[_indexPatch].Regions[_indexRegion].Perks = perks.Download();
                SummonerSpells summonerSpell = new(_info);
                _data.Patchs[_indexPatch].Regions[_indexRegion].SummonerSpells = summonerSpell.Download();

                // Save data in local file
                string saveData = JsonConvert.SerializeObject(_data, Formatting.Indented);
                OSL_Utils.File.Write("./wwwroot/assets/_data.json", saveData);
                // Save info in local file
                string saveInfo = JsonConvert.SerializeObject(_info, Formatting.Indented);
                OSL_Utils.File.Write("./wwwroot/assets/_info.json", saveInfo);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Load data from local file
        /// </summary>
        /// <returns>True if info file are loaded</returns>
        public bool LoadData()
        {
            string? data = OSL_Utils.File.Read("./wwwroot/assets/_data.json");
            if (data != null)
            {
                _data = JsonConvert.DeserializeObject<Data>(data) ?? new Data();
                _logger.Log(LoggingLevel.INFO, "LoadData()", "Data loaded");
                return true;
            }
            _logger.Log(LoggingLevel.ERROR, "LoadData()", "Data not loaded");
            return false;
        }

        /// <summary>
        /// Load info from local file
        /// </summary>
        /// <returns>True if info file are loaded</returns>
        public bool LoadInfo()
        {
            string? info = OSL_Utils.File.Read("./wwwroot/assets/_info.json");
            if (info != null)
            {
                _info = JsonConvert.DeserializeObject<Info>(info);
                _logger.Log(LoggingLevel.INFO, "LoadInfo()", "Info loaded");
                return true;
            }
            _logger.Log(LoggingLevel.ERROR, "LoadInfo()", "Info not loaded");
            return false;
        }

        /// <summary>
        /// Check if data loaded are the latest and all assets are downloaded
        /// </summary>
        /// <returns>True if assets of last patch are present</returns>
        public bool CheckDataLatest()
        {
            if (!LoadData() || !DownloadPatchNumber())
            {
                return false;
            }

            foreach (var patch in _data.Patchs)
            {
                if (patch.Number == _info.Patch)
                {
                    // Check patch directory
                    string patchShortNumber = $"./wwwroot/assets/{patch.ShortNumber}";
                    if (!OSL_Utils.Directory.Exist(patchShortNumber))
                    {
                        return false;
                    }
                    _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Patch {patchShortNumber} are already downloaded");
                    // Check all regions
                    foreach (var region in patch.Regions)
                    {
                        //Check region directory
                        string pathRegionName = $"{patchShortNumber}/{region.Name}";
                        if (!OSL_Utils.Directory.Exist(pathRegionName))
                        {
                            return false;
                        }
                        _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Region {pathRegionName} are already downloaded");
                        // Check all champions directory
                        if (region.Champions.Count == 0)
                        {
                            return false;
                        }
                        foreach (var champion in region.Champions)
                        {
                            if (champion.Id != -1)
                            {
                                if (!CheckChampion(champion))
                                {
                                    return false;
                                }
                                if (!CheckSound(champion.Sounds))
                                {
                                    return false;
                                }
                                foreach (var skin in champion.Skins)
                                {
                                    if (!CheckSkin(skin))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }

                        if (region.Items.Count == 0)
                        {
                            return false;
                        }
                        foreach (var item in region.Items)
                        {
                            if (!OSL_Utils.File.Exist(item.IconPath))
                            {
                                _logger.Log(LoggingLevel.ERROR, "CheckDataLatest()", $"Item {item.IconPath} not exist");
                                return false;
                            }
                            _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Item {item.IconPath} exist");
                        }

                        if (region.Perks.Count == 0)
                        {
                            return false;
                        }
                        foreach (var perk in region.Perks)
                        {
                            if (!OSL_Utils.File.Exist(perk.IconPath))
                            {
                                _logger.Log(LoggingLevel.ERROR, "CheckDataLatest()", $"Perk {perk.IconPath} not exist");
                                return false;
                            }
                            _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Perk {perk.IconPath} exist");
                        }
                        if (region.SummonerSpells.Count == 0)
                        {
                            return false;
                        }
                        foreach (var summonerSpell in region.SummonerSpells)
                        {
                            if (!OSL_Utils.File.Exist(summonerSpell.IconPath))
                            {
                                _logger.Log(LoggingLevel.ERROR, "CheckDataLatest()", $"Summoner spell {summonerSpell.IconPath} not exist");
                                return false;
                            }
                            _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Summoner spell {summonerSpell.IconPath} exist");
                        }
                    }
                    _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Latest patch {patch.Number} are already downloaded");
                    return true;
                }
            }
            _logger.Log(LoggingLevel.WARN, "CheckDataLatest()", $"Latest patch {_info.Patch} not found in data");
            return false;
        }

        /// <summary>
        /// Check if the champion assets are downloaded
        /// </summary>
        /// <param name="champion"></param>
        /// <returns>True if champion assets are present</returns>
        private static bool CheckChampion(Schema.Champion champion)
        {
            if (!OSL_Utils.File.Exist(champion.SquarePortraitPath))
            {
                _logger.Log(LoggingLevel.ERROR, "CheckChampion()", $"Champion {champion.SquarePortraitPath} portrait not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckChampion()", $"Champion {champion.SquarePortraitPath} portrait exist");
            return true;
        }

        /// <summary>
        /// Check if the sound assets are downloaded
        /// </summary>
        /// <param name="sound">Sound information</param>
        /// <returns>True if all assets of sound are present</returns>
        private static bool CheckSound(Sound sound)
        {
            if (!OSL_Utils.File.Exist(sound.ChoosePath) && sound.ChoosePath != "")
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSound()", $"Sound {sound.ChoosePath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSound()", $"Sound {sound.ChoosePath} exist");
            if (!OSL_Utils.File.Exist(sound.BanPath) && sound.BanPath != "")
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSound()", $"Sound {sound.BanPath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSound()", $"Sound {sound.BanPath} exist");
            if (!OSL_Utils.File.Exist(sound.SfxPath) && sound.SfxPath != "")
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSound()", $"Sound {sound.SfxPath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSound()", $"Sound {sound.SfxPath} exist");
            return true;
        }

        /// <summary>
        /// Check if the skin assets are downloaded
        /// </summary>
        /// <param name="skin">Skin information</param>
        /// <returns>True if all assets of skin are present</returns>
        private static bool CheckSkin(Schema.Skin skin)
        {
            if (!OSL_Utils.File.Exist(skin.Splashe))
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSkin()", $"Skin {skin.Splashe} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSkin()", $"Skin {skin.Splashe} exist");
            if (!OSL_Utils.File.Exist(skin.SplasheUncentered))
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSkin()", $"Skin {skin.SplasheUncentered} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSkin()", $"Skin {skin.SplasheUncentered} exist");
            if (!OSL_Utils.File.Exist(skin.Tile))
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSkin()", $"Skin {skin.Tile} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSkin()", $"Skin {skin.Tile} exist");
            if (!OSL_Utils.File.Exist(skin.LoadScreen))
            {
                _logger.Log(LoggingLevel.ERROR, "CheckSkin()", $"Skin {skin.LoadScreen} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, "CheckSkin()", $"Skin {skin.LoadScreen} exist");
            return true;
        }

        /// <summary>
        /// Create directories for champion, items, summoner spells, perks and perkstyles assets
        /// </summary>
        /// <returns>True if the creation are succesful</returns>
        private bool CreateDirectories()
        {
            try
            {
                _info.AssetsDir = OSL_Utils.Path.Combine("./wwwroot/assets/", _info.ShortPatch, _info.Region);
                OSL_Utils.Directory.Create(_info.AssetsDir);
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "champions"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "items"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "summonerspells"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "perks"));

                _logger.Log(LoggingLevel.INFO, "CreateDirectories()", "Directories created");
                return true;
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, "CreateDirectories()", "Directories not created");
                return false;
            }
        }

        /// <summary>
        /// Check if the patch and region already exist in data
        /// </summary>
        /// <returns>True if patch not present</returns>
        private bool CheckPatchRegion()
        {
            FindIndexPatch();
            FindIndexRegion();
            if (_indexRegion != -1)
            {
                _logger.Log(LoggingLevel.WARN, "CheckPatchRegion()", $"Patch {_info.ShortPatch} and {_info.Region} already exist");
                return true;
            }

            if (DownloadPatchNumber())
            {
                if (_indexPatch != -1 && AddRegion())
                {
                    return true;
                }
                else if (AddPatch() && AddRegion())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Download the patch number in _info
        /// </summary>
        /// <returns>True if patch number is downloaded</returns>
        private bool DownloadPatchNumber()
        {
            Uri urlPatchContentMetadata = new($"https://raw.communitydragon.org/{_info.Patch}/content-metadata.json");
            try
            {
                // Download the patch content metadata
                Download download = new();
                string? patchContentMetadata = download.StringAsync(urlPatchContentMetadata).Result;
                if (patchContentMetadata != null)
                {
                    Schema.CDragon.ContentMetadata version = JsonConvert.DeserializeObject<Schema.CDragon.ContentMetadata>(patchContentMetadata);
                    if (version.Version == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "DownloadPatchNumber()", $"Json content metadata {patchContentMetadata} not valid");
                        return false;
                    }

                    // Update the patch number
                    _info.Patch = version.Version;
                    string[] shortPatch = _info.Patch.Split(".");
                    // Update the short patch number
                    _info.ShortPatch = shortPatch[0] + "." + shortPatch[1];
                    // Update the date
                    _info.Date = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
                    _logger.Log(LoggingLevel.INFO, "DownloadPatchNumber()", $"New patch number is : {_info.Patch}");
                    return true;
                }
                else
                {
                    _logger.Log(LoggingLevel.ERROR, "DownloadPatchNumber()", $"No patch number valid in {urlPatchContentMetadata}");
                }
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, "DownloadPatchNumber()", $"No path number set");
            }
            return false;
        }

        /// <summary>
        /// Find the index of the patch in _data
        /// </summary>
        private void FindIndexPatch()
        {
            _indexPatch = -1;
            try
            {
                _indexPatch = _data.Patchs.FindIndex(x => x.ShortNumber == _info.ShortPatch);
                _logger.Log(LoggingLevel.INFO, "FindIndexPatch()", $"Index of patch {_info.ShortPatch} is {_indexPatch}");
            }
            catch
            {
                _logger.Log(LoggingLevel.WARN, "FindIndexPatch()", $"Patch {_info.ShortPatch} not found");
            }
        }

        /// <summary>
        /// Find the index of the region in _data
        /// </summary>
        private void FindIndexRegion()
        {
            _indexRegion = -1;
            try
            {
                _indexRegion = _data.Patchs[_indexPatch].Regions.FindIndex(x => x.Name == _info.Region);
                _logger.Log(LoggingLevel.INFO, "FindIndexRegion()", $"Index of region {_info.Region} in Patch {_info.Patch} is {_indexRegion}");
            }
            catch
            {
                _logger.Log(LoggingLevel.WARN, "FindIndexRegion()", $"Region {_info.ShortPatch} in Patch {_info.Patch} not found");
            }
        }

        /// <summary>
        /// Add a region in _data
        /// </summary>
        /// <returns>True if region is added</returns>
        private bool AddRegion()
        {
            try
            {
                _data.Patchs[_indexPatch].Regions.Add(new Region(_info.Region));
                _logger.Log(LoggingLevel.INFO, "AddRegion()", $"Region {_info.Region} added");
                FindIndexRegion();
                return true;
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, "AddRegion()", $"Region {_info.Region} not added");
                return false;
            }
        }

        /// <summary>
        /// Add a patch in _data
        /// </summary>
        /// <returns>True if patch id added</returns>
        private bool AddPatch()
        {
            try
            {
                _data.Patchs.Add(new Patch(_info.Patch, _info.ShortPatch));
                _logger.Log(LoggingLevel.INFO, "AddPatch()", $"Patch {_info.Patch}, {_info.ShortPatch} added");
                FindIndexPatch();
                return true;
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, "AddPatch()", $"Patch {_info.ShortPatch} not added");
                return false;
            }
        }
    }
}
