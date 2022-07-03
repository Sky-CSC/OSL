using Newtonsoft.Json;
using OSL_Server;
using OSL_Server.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSL_Server.DataLoader.CDragon;
using static OSL_Server.Pages.ChampSelectView1Page;

namespace OSL_Server.Configuration
{
    public class Config
    {
        private static OSLLogger _logger = new OSLLogger("Config");

        public static void LoadConfig()
        {
            LoadConfigCDragon();
            LoadConfigChampSelect();
        }

        public static void LoadConfigCDragon()
        {

            string filePath = "./" + "Configuration" + "/" + "configCDragon.json";
            try
            {
                dynamic configCDragon = JsonConvert.DeserializeObject<CDragonInfo>(FileManagerLocal.ReadInFile(filePath));
                //CDragon.patch = configCDragon.pasici;
                CDragon.patch = configCDragon.Patch;
                CDragon.region = configCDragon.Region;
                CDragon.championSummary = configCDragon.ChampionSummary;
                CDragon.items = configCDragon.Items;
                CDragon.summonerSpells = configCDragon.SummonerSpells;
                CDragon.perks = configCDragon.Perks;
                CDragon.perkstyles = configCDragon.Perkstyles;
                _logger.log(LoggingLevel.INFO, "LoadConfigCDragon", $"Config CDragon loaded to {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigCDragon", $"Config loadeding error {filePath}");
                var cdragonInformation = new CDragonInfo
                {
                    Patch = "latest",
                    Region = "fr_fr",
                    ChampionSummary = "champion-summary",
                    Items = "items",
                    SummonerSpells = "summoner-spells",
                    Perks = "perks",
                    Perkstyles = "perkstyles"
                };
                string configCDragon = JsonConvert.SerializeObject(cdragonInformation);
                FileManagerLocal.RewrittenFile(filePath, configCDragon);
                _logger.log(LoggingLevel.WARN, "LoadConfigCDragon", $"Default Config created {filePath}");

            }
        }

        public static void LoadConfigChampSelect()
        {
            string filePath = "./" + "Configuration" + "/" + "configChampSelect.json";
            try
            {
                dynamic configChampSelect = JsonConvert.DeserializeObject<ChampSelect>(FileManagerLocal.ReadInFile(filePath));
                DefaultPatch = configChampSelect.DefaultPatch;
                DefaultRegion = configChampSelect.DefaultRegion;

                BlueTeamName = configChampSelect.BlueTeamName;
                BlueTeamSubtext = configChampSelect.BlueTeamSubtext;
                ColorBlueTeamName = configChampSelect.ColorBlueTeamName;
                ColorBlueTeamSubtext = configChampSelect.ColorBlueTeamSubtext;
                BlueLogo = configChampSelect.BlueLogo;
                ColorBlueSideTexte = configChampSelect.ColorBlueSideTexte;
                ColorBlueSideBackgroud = configChampSelect.ColorBlueSideBackgroud;
                ColorBlueSideBorder = configChampSelect.ColorBlueSideBorder;
                ColorBlueSideTimerBackgroud = configChampSelect.ColorBlueSideTimerBackgroud;
                ColorBlueSideTimerBorder = configChampSelect.ColorBlueSideTimerBorder;
                ColorBlueSideTimerTexte = configChampSelect.ColorBlueSideTimerTexte;

                RedTeamName = configChampSelect.RedTeamName;
                RedTeamSubtext = configChampSelect.RedTeamSubtext;
                ColorRedTeamName = configChampSelect.ColorRedTeamName;
                ColorRedTeamSubtext = configChampSelect.ColorRedTeamSubtext;
                RedLogo = configChampSelect.RedLogo;
                ColorRedSideTexte = configChampSelect.ColorRedSideTexte;
                ColorRedSideBackgroud = configChampSelect.ColorRedSideBackgroud;
                ColorRedSideBorder = configChampSelect.ColorRedSideBorder;
                ColorRedSideTimerBackgroud = configChampSelect.ColorRedSideTimerBackgroud;
                ColorRedSideTimerBorder = configChampSelect.ColorRedSideTimerBorder;
                ColorRedSideTimerTexte = configChampSelect.ColorRedSideTimerTexte;

                BanBackgroundPicture = configChampSelect.BanBackgroundPicture;
                BanOverlayPicture = configChampSelect.BanOverlayPicture;
                BanBackgroundColor = configChampSelect.BanBackgroundColor;

                OverlayBackground = configChampSelect.OverlayBackground;
                _logger.log(LoggingLevel.INFO, "LoadConfigChampSelect()", $"Config ChampSelect loaded to {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigChampSelect()", $"Config loadeding error {filePath} {e.Message}");
                var champSelectInformation = new ChampSelect
                {
                    DefaultPatch = "latest",
                    DefaultRegion = "fr_fr",

                    BlueTeamName = "",
                    BlueTeamSubtext = "",
                    ColorBlueTeamName = "white",
                    ColorBlueTeamSubtext = "white",
                    BlueLogo = "",
                    ColorBlueSideTexte = "white",
                    ColorBlueSideBackgroud = "#0b849e",
                    ColorBlueSideBorder = "5px solid yellow",
                    ColorBlueSideTimerBackgroud = "#0b849e",
                    ColorBlueSideTimerBorder = "5px solid blue",
                    ColorBlueSideTimerTexte = "white",

                    RedTeamName = "",
                    RedTeamSubtext = "",
                    ColorRedTeamName = "white",
                    ColorRedTeamSubtext = "white",
                    RedLogo = "",
                    ColorRedSideTexte = "white",
                    ColorRedSideBackgroud = "#be1e37",
                    ColorRedSideBorder = "5px solid yellow",
                    ColorRedSideTimerBackgroud = "#be1e37",
                    ColorRedSideTimerBorder = "5px solid red",
                    ColorRedSideTimerTexte = "white",

                    BanBackgroundPicture = "../assets/champselect/banning-1.png",
                    BanOverlayPicture = "../assets/champselect/ban-completed-2.png",
                    BanBackgroundColor = "#010a13",

                    OverlayBackground = "../assets/champselect/backgroud-view-1.png"
                };
                string configChampSelect = JsonConvert.SerializeObject(champSelectInformation);
                FileManagerLocal.RewrittenFile(filePath, configChampSelect);
                _logger.log(LoggingLevel.WARN, "LoadConfigChampSelect()", $"Default Config created {filePath}");
            }
            if (DefaultPatch.Equals("latest"))
            {
                //string[] temps = CDragon.patch.Split(".");
                //DefaultPatch = temps[0] + "." + temps[1];
                DefaultPatch = "12.12";
            }
        }
    }
}
