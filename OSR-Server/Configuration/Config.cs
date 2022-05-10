using Newtonsoft.Json;
using OSR_Server;
using OSR_Server.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSR_Server.Configuration
{
    public class Config
    {
        private static OSRLogger _logger = new OSRLogger("Config");

        public static string patch = "latest";
        public static string region = "fr_fr";
        public static string championSummary = "champion-summary";
        public static string items = "items";
        public static string summonerSpells = "summoner-spells";
        public static string perks = "perks";
        public static string perkstyles = "perkstyles";
        
        public static void LoadConfigCDragon()
        {

            string filePath = "./" + "Configuration" + "/" + "configCDragon.json";
            dynamic configCDragon = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
            try
            {
                patch = configCDragon.patch;
                region = configCDragon.region;
                championSummary = configCDragon.championSummary;
                items = configCDragon.items;
                summonerSpells = configCDragon.summonerSpells;
                perks = configCDragon.perks;
                perkstyles = configCDragon.perkstyles;
                _logger.log(LoggingLevel.INFO, "LoadConfigCDragon", "Config loaded");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigCDragon", e.Message);
            }
        }
    }
}
