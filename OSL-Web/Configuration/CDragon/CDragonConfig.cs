using Newtonsoft.Json;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_CDragon;
using OSL_Common.System.DirectoryManager;

namespace OSL_Web.Configuration.CDragon
{
    /// <summary>
    /// CDragon configuration
    /// </summary>
    public class CDragonConfig
    {
        private static Logger _logger = new("CDragonConfig");
        /// <summary>
        /// Load configuration
        /// </summary>
        public static void LoadJsonConfig()
        {
            string filePath = "./" + "Configuration" + "/" + "CDragon" + "/" + "cdragon.json";
            try
            {
                dynamic configCDragon = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
                OSL_CDragon.CDragon.patch = configCDragon.patch;
                OSL_CDragon.CDragon.region = configCDragon.region;
                OSL_CDragon.CDragon.championSummary = configCDragon.championSummary;
                OSL_CDragon.CDragon.items = configCDragon.items;
                OSL_CDragon.CDragon.summonerSpells = configCDragon.summonerSpells;
                OSL_CDragon.CDragon.perks = configCDragon.perks;
                OSL_CDragon.CDragon.perkstyles = configCDragon.perkstyles;
                //Console.WriteLine(OSL_CDragon.CDragon.perkstyles);
                _logger.log(LoggingLevel.INFO, "LoadConfigCDragon", $"Config CDragon loaded to {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigCDragon", $"Config loadeding error {filePath} : {e.Message}");
                var cdragonInformation = new CDragonInfo
                {
                    patch = "latest",
                    region = "fr_fr",
                    championSummary = "champion-summary",
                    items = "items",
                    summonerSpells = "summoner-spells",
                    perks = "perks",
                    perkstyles = "perkstyles"
                };
                string configCDragon = JsonConvert.SerializeObject(cdragonInformation);
                FileManagerLocal.RewrittenFile(filePath, configCDragon);
                _logger.log(LoggingLevel.WARN, "LoadConfigCDragon", $"Default Config created {filePath}");
            }
        }

        /// <summary>
        /// Create variable for default directory
        /// </summary>
        public static void LoadDirectoryConfig()
        {
            //string path = Directory.GetCurrentDirectory().Replace("\\", "/");
            OSL_CDragon.CDragon.championDirectory = "./wwwroot/assets/";
            OSL_CDragon.CDragon.itemsDirectory = "./wwwroot/assets/";
            OSL_CDragon.CDragon.summonerSpellsDirectory = "./wwwroot/assets/";
            OSL_CDragon.CDragon.perksDirectory = "./wwwroot/assets/";
        }
    }
}
