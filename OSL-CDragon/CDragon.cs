using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.Schema.Asset;

namespace OSL_CDragon
{
    /// <summary>
    /// Manage download of League of Legends assets
    /// </summary>
    public partial class CDragon
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
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

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
                DownloadAllData();

                DownloadPositionsData();
                DownloadEpicMonstersData();

                // Save data in local file
                SaveData();
                // Save info in local file
                SaveInfo();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Download assets and check if all assets in file are downloaded
        /// </summary>
        /// <returns></returns>
        public bool DownloadAssetsWithCheck()
        {
            if (CheckPatchRegion() && CreateDirectories())
            {
                // Check if champion, itemps, perks and summoner spells of spécific région and patch are downloaded
                CheckPatchsData();

                // Check if positions are downloaded
                CheckPositionsData();
                // Check if epic monsters are downloaded
                CheckEpicMonstersData();
                // Check if fonts are downloaded
                CheckFontsData();

                //Rajouter le télécharmenet des assets des runes, ban, logo et images pour l'affichage de l'application et des autres assets

                // Save data in local file
                SaveData();
                // Save info in local file
                SaveInfo();

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
        /// Save data in local file
        /// </summary>
        public void SaveData()
        {
            string saveData = JsonConvert.SerializeObject(_data, Formatting.Indented);
            OSL_Utils.File.Write("./wwwroot/assets/_data.json", saveData);
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
        /// Save info in local file
        /// </summary>
        private void SaveInfo()
        {
            string saveInfo = JsonConvert.SerializeObject(_info, Formatting.Indented);
            OSL_Utils.File.Write("./wwwroot/assets/_info.json", saveInfo);
        }

        /// <summary>
        /// Check if all assets in _data file are downloaded
        /// </summary>
        public void CheckPatchsData()
        {
            // Check if the latets patch is already downloaded
            if (!CheckDataLatest())
            {
                //Download latest patch
                DownloadAllData();
            }
            // Check all paths assets in file
            Patchs();
        }

        /// <summary>
        /// Download all assets
        /// </summary>
        private void DownloadAllData()
        {
            DownloadChampionsData();
            DownloadItemsData();
            DownloadPerksData();
            DownloadSummonerSpellsData();
        }

        /// <summary>
        /// Check if positions data are downloaded
        /// </summary>
        public void CheckPositionsData()
        {
            // If positions are not downloaded, download it
            if (!Position(_data.Positions))
            {
                DownloadPositionsData();
            }
        }

        /// <summary>
        /// Check if epic monsters data are downloaded
        /// </summary>
        public void CheckEpicMonstersData()
        {
            // If epic monsters are not downloaded, download it
            if (!EpicMonster(_data.EpicMonsters))
            {
                DownloadEpicMonstersData();
            }
        }

        public void CheckFontsData()
        {
            // If epic monsters are not downloaded, download it
            if (!Font(_data.Fonts))
            {
                DownloadFontsData();
            }
        }

        /// <summary>
        /// Download positions data
        /// </summary>
        private void DownloadPositionsData()
        {
            Positions positions = new();
            _data.Positions = positions.Download();
        }

        /// <summary>
        /// Download epic monsters data
        /// </summary>
        private void DownloadEpicMonstersData()
        {
            EpicMonsters epicMonsters = new();
            _data.EpicMonsters = epicMonsters.Download();
        }

        /// <summary>
        /// Download epic monsters data
        /// </summary>
        private void DownloadFontsData()
        {
            Fonts fonts = new();
            _data.Fonts = fonts.Download();
        }

        /// <summary>
        /// Download champions data
        /// </summary>
        private void DownloadChampionsData()
        {
            Champions champion = new(_info);
            _data.Patchs[_indexPatch].Regions[_indexRegion].Champions = champion.Download();
        }

        /// <summary>
        /// Download items data
        /// </summary>
        private void DownloadItemsData()
        {
            Items items = new(_info);
            _data.Patchs[_indexPatch].Regions[_indexRegion].Items = items.Download();
        }

        /// <summary>
        /// Download perks data
        /// </summary>
        private void DownloadPerksData()
        {
            Perks perks = new(_info);
            _data.Patchs[_indexPatch].Regions[_indexRegion].Perks = perks.Download();
        }

        /// <summary>
        /// Download summoner spells data
        /// </summary>
        private void DownloadSummonerSpellsData()
        {
            SummonerSpells summonerSpells = new(_info);
            _data.Patchs[_indexPatch].Regions[_indexRegion].SummonerSpells = summonerSpells.Download();
        }

        /// <summary>
        /// Check if data loaded are the latest and all assets are downloaded
        /// </summary>
        /// <returns>True if assets of last patch are present</returns>
        private bool CheckDataLatest()
        {
            // Load data from file and download patch number
            if (!LoadData() || !DownloadPatchNumber())
            {
                return false;
            }
            // Check in _data if the latest patch is already downloaded, check just the Number
            var patch = _data.Patchs.Find(p => p.Number == _info.Patch);
            if (patch != null)
            {
                _logger.Log(LoggingLevel.INFO, "CheckDataLatest()", $"Latest patch {patch.Number} are already downloaded");
                return true;
            }
            _logger.Log(LoggingLevel.WARN, "CheckDataLatest()", $"Latest patch {_info.Patch} not found in data");
            return false;
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
                // Create patch and region directories with champion, items, summoner spells, perks sub directories 
                OSL_Utils.Directory.Create(_info.AssetsDir);
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "champions"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "items"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "summonerspells"));
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(_info.AssetsDir, "perks"));
                // Create positions directories
                OSL_Utils.Directory.Create("./wwwroot/assets/positions/top");
                OSL_Utils.Directory.Create("./wwwroot/assets/positions/jungle");
                OSL_Utils.Directory.Create("./wwwroot/assets/positions/mid");
                OSL_Utils.Directory.Create("./wwwroot/assets/positions/adc");
                OSL_Utils.Directory.Create("./wwwroot/assets/positions/support");
                // Create epic monsters directories
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/atakhan");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/baron");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/cloud");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/chemtech");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/mountain");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/infernal");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/hextech");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/ocean");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/dragons/elder");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/herald");
                OSL_Utils.Directory.Create("./wwwroot/assets/epicmonsters/voidgrub");
                // Create runes directorie
                OSL_Utils.Directory.Create("./wwwroot/assets/runes");
                // Create font directiorie
                OSL_Utils.Directory.Create("./wwwroot/assets/fonts");

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
            // Set global index of patch and region
            FindIndexPatch();
            FindIndexRegion();

            // If region already exist
            if (_indexRegion != -1)
            {
                _logger.Log(LoggingLevel.WARN, "CheckPatchRegion()", $"Patch {_info.ShortPatch} and {_info.Region} already exist");
                return true;
            }
            // Download patch number and add patch and region if not exist
            if (DownloadPatchNumber())
            {
                // Add patch if path not exist
                if (_indexPatch == -1 && !AddPatch())
                {
                    return false;
                }

                // Add region
                if (AddRegion())
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
            Uri urlPatchContentMetadata = new($"https://raw.communitydragon.org/{_info.ShortPatch}/content-metadata.json");
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

        /// <summary>
        /// Create the assets info for download and save
        /// </summary>
        /// <param name="url">Url to download</param>
        /// <param name="name">File name for save</param>
        /// <param name="subPath">Path for save file</param>
        /// <param name="description">Description</param>
        /// <param name="extension">File extension</param>
        /// <param name="type">Type of asset</param>
        /// <param name="addAssetAction">Action for add asset to list</param>
        internal static void CreateAssetInfo(Uri url, string id, string name, string subPath, string description, string extension, List<AssetType> type, Action<Asset> addAssetAction)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = Generator.GenerateSha1Id();
            }
            string filePath = _download.DownloadFile(url, subPath, $"{name}{extension}");
            Asset asset = new(id, name, description, url, filePath, type);

            if (!string.IsNullOrEmpty(asset.Path))
            {
                addAssetAction(asset);
            }
        }
    }
}
