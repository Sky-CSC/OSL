﻿using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.Logging;
using OSL_Common.Download;

namespace OSL_CDragon
{
    /// <summary>
    /// Download data from CDragon
    /// </summary>
    public class CDragon
    {
        private static Logger _logger = new("CDragon");
        public static DataCDragon dataCDragon = new();


        public static string patch = "latest";
        public static string date = "";
        public static string region = "fr_fr";
        public static string championSummary = "champion-summary";
        public static string items = "items";
        public static string summonerSpells = "summoner-spells";
        public static string perks = "perks";
        public static string perkstyles = "perkstyles";

        public static string championDirectory;
        public static string itemsDirectory;
        public static string summonerSpellsDirectory;
        public static string perksDirectory;
        public static string perksDirectoryWebPath;

        public static string defaultNumPatch = "";
        public static string defaultRegionPatch = "";

        public static string dataCDragonPath = "./" + "dataCDragon.json";

        public static void SetRegion(string newRegion)
        {
            region = newRegion;
        }

        public static void SetPatch(string newPatch)
        {
            patch = newPatch;
        }

        /// <summary>
        /// Download files if patch and refion not already present
        /// </summary>
        /// <param name="patch"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        public static void DownloadAsyncWithCheck(string patch, string region)
        {
            int indexPatch = dataCDragon.Patch.FindIndex(x => x.Name == patch);
            if (indexPatch != -1)
            {
                int indexlocale = dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);
                if (indexlocale == -1)
                {
                    Thread DownloadFilesFr = new Thread(() => DownloadData.DownloadFiles(patch, region));
                    DownloadFilesFr.Start();
                }
            }
            else
            {
                Thread DownloadFilesFr = new Thread(() => DownloadData.DownloadFiles(patch, region));
                DownloadFilesFr.Start();
            }
        }

        /// <summary>
        /// Download data
        /// </summary>
        public class DownloadData
        {
            /// <summary>
            /// Download files for overlay display
            /// </summary>
            /// <param name="patch"></param>
            /// <param name="region"></param>
            public static void DownloadFiles(string patch, string region)
            {
                //Download 
                //https://raw.communitydragon.org/latest/content-metadata.json
                Uri urlPatchContentMetadata = new($"https://raw.communitydragon.org/{patch}/content-metadata.json");
                string numPatch = patch;
                try
                {
                    string patchContentMetadata = OSL_Common.Download.Download.DownloadStringAsync(urlPatchContentMetadata).Result;
                    //convert in json patchContentMetadata
                    if (patchContentMetadata != null)
                    {
                        dynamic jsonContentMetadata = JsonConvert.DeserializeObject(patchContentMetadata);
                        string ContentMetadataVersion = jsonContentMetadata.version;
                        if (numPatch.Equals("latest"))
                        {
                            string[] split = ContentMetadataVersion.Split("+");
                            CDragon.patch = split[0];
                            //date now
                            CDragon.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }
                        CDragon.date = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        string[] splitContentMetadata = ContentMetadataVersion.Split(".");
                        numPatch = splitContentMetadata[0] + "." + splitContentMetadata[1];
                        //_logger.log(LoggingLevel.INFO, "DownloadFiles()", $"Num patch : {numPatch}, Region : {region}");
                    }
                }
                catch
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadFiles()", $"Error num patch : {numPatch}");
                }

                int indexPatch = dataCDragon.Patch.FindIndex(x => x.Name == numPatch);
                //If patch already exist in dataCDragon
                if (indexPatch != -1)
                {
                    int indexRegion = dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);
                    _logger.log(LoggingLevel.ERROR, "DownloadFiles()", $"Patch {numPatch}, {region}, {indexRegion}");

                    //If region already exist in dataCDragon
                    if (indexRegion == -1)
                    {
                        _logger.log(LoggingLevel.INFO, "DownloadFiles()", $"Patch {numPatch}, creation {region}");
                        dataCDragon.Patch[indexPatch].Region.Add(new Region()
                        {
                            Name = region,
                            RegionContent = new RegionContent()
                        });
                        string regionTemps = region;

                        //Download data
                        CreatedDirectory(numPatch, regionTemps);
                        ChampionManager.DownloadChampion(numPatch, regionTemps);
                        ItemManager.DownloadItems(numPatch, regionTemps);
                        PerksManager.DownloadPerks(numPatch, regionTemps);
                        SummonerSpellManager.DownloadSummonersSpell(numPatch, regionTemps);
                    }
                    else
                    {
                        _logger.log(LoggingLevel.WARN, "DownloadFiles()", $"Patch {numPatch} and region {region} already exist");
                    }
                }
                //If patch not exist in dataCDragon
                else
                {
                    _logger.log(LoggingLevel.INFO, "DownloadFiles()", $"Patch {numPatch} creation, Region {region} creation");
                    dataCDragon.Patch.Add(new Patch()
                    {
                        Name = numPatch,
                        Region = new List<Region>()
                        {
                            new Region()
                            {
                                Name = region,
                                RegionContent = new RegionContent()
                            }
                        }
                    });
                    string regionTemps = region;

                    //Download data
                    CreatedDirectory(numPatch, regionTemps);
                    ChampionManager.DownloadChampion(numPatch, regionTemps);
                    ItemManager.DownloadItems(numPatch, regionTemps);
                    PerksManager.DownloadPerks(numPatch, regionTemps);
                    SummonerSpellManager.DownloadSummonersSpell(numPatch, regionTemps);
                }
                _logger.log(LoggingLevel.INFO, "DownloadFiles()", $"End download and charge config view");
            }

            /// <summary>
            /// Create directory for save data
            /// </summary>
            /// <param name="numPatch"></param>
            /// <param name="region"></param>
            private static void CreatedDirectory(string numPatch, string region)
            {
                championDirectory += numPatch + "/" + region + "/" + "Champions" + "/";
                itemsDirectory += numPatch + "/" + region + "/" + "Items" + "/";
                summonerSpellsDirectory += numPatch + "/" + region + "/" + "SummonerSpell" + "/";
                perksDirectory += numPatch + "/" + region + "/" + "Perks" + "/";
                DirectoryManagerLocal.CreateDirectory(championDirectory);
                DirectoryManagerLocal.CreateDirectory(itemsDirectory);
                DirectoryManagerLocal.CreateDirectory(summonerSpellsDirectory);
                DirectoryManagerLocal.CreateDirectory(perksDirectory);
            }
        }
    }

    /// <summary>
    /// Class for the CDragonInfo
    /// </summary>
    public class CDragonInfo
    {
        public string? patch { get; set; }
        public string? region { get; set; }
        public string? championSummary { get; set; }
        public string? items { get; set; }
        public string? summonerSpells { get; set; }
        public string? perks { get; set; }
        public string? perkstyles { get; set; }
    }

    /// <summary>
    /// Class for the dataCDragon <see cref="dataCDragon"/>
    /// </summary>
    public class DataCDragon
    {
        public List<Patch> Patch { get; set; }
        public DataCDragon()
        {
            Patch = new List<Patch>();
        }
    }

    /// <summary>
    /// Patch and list of region
    /// </summary>
    public class Patch
    {
        public string Name { get; set; }
        //public string Link { get; set; }
        public List<Region> Region { get; set; }
    }

    /// <summary>
    /// Name region and content picture/sound/info of the region
    /// </summary>
    public class Region
    {
        public string Name { get; set; }
        //public string Link { get; set; }
        public RegionContent RegionContent { get; set; }
    }

    /// <summary>
    /// Champion, items, summonerspell, perks data
    /// </summary>
    public class RegionContent
    {
        public List<Champion> Champion { get; set; }
        public List<Items> Items { get; set; }
        public List<SummonerSpells> SummonerSpells { get; set; }
        public List<Perks> Perks { get; set; }
        public RegionContent()
        {
            Champion = new List<Champion>();
            Items = new List<Items>();
            SummonerSpells = new List<SummonerSpells>();
            Perks = new List<Perks>();
        }
    }

    /// <summary>
    /// Champion information
    /// </summary>
    public class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string SquarePortraitPath { get; set; }
        public Sound Sound { get; set; } //Ban, Choose
        public List<string> Roles { get; set; } //Tank/fighter
        public List<Skins> Skins { get; set; }

        public Champion()
        {
            Sound = new Sound();
            Roles = new List<string>();
            Skins = new List<Skins>();
        }
    }

    /// <summary>
    /// Sound data
    /// </summary>
    public class Sound
    {
        public string ChoosePath { get; set; }
        public string BanPath { get; set; }
        public string SfxPath { get; set; }
    }

    /// <summary>
    /// Skins information
    /// </summary>
    public class Skins
    {
        public int Id { get; set; }
        public bool IsBase { get; set; }
        public string SplashePath { get; set; }
        public string SplasheUncenteredPath { get; set; }
        public string TilePath { get; set; }
        public string LoadScreenPath { get; set; }
    }

    /// <summary>
    /// Items information
    /// </summary>
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public List<string> From { get; set; }
        public List<string> To { get; set; } //Si To est vide alors c'est un item final
        public Items()
        {
            From = new List<string>();
            To = new List<string>();
        }
    }

    /// <summary>
    /// SummonerSpells information
    /// </summary>
    public class SummonerSpells
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }

    /// <summary>
    /// Perks information
    /// </summary>
    public class Perks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }
}
