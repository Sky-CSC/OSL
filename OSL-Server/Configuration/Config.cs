using Newtonsoft.Json;
using OSL_Server.FileManager;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Pages;
using OSL_Server.Communication;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Configuration
{
    /// <summary>
    /// Class for configure client application
    /// </summary>
    public class Config
    {
        private static OSLLogger _logger = new OSLLogger("Config");

        /// <summary>
        /// Load configuration
        /// </summary>
        public static void LoadConfig()
        {
            LoadConfigServerSocket();
            LoadConfigCDragon();
            LoadConfigTimer();
            LoadDefaultSession();
            LoadConfigChampSelectView1();
            LoadConfigChampSelectView2();
            LoadConfigChampSelectView3();
            LoadConfigChampSelectView4();
        }

        /// <summary>
        /// Configuration of server socker port
        /// </summary>
        public static void LoadConfigServerSocket()
        {
            string filePath = "./" + "Configuration" + "/" + "configServerSocket.json";
            dynamic configHost = JsonConvert.DeserializeObject(FileManagerLocal.ReadInFile(filePath));
            try
            {
                AsyncServer.portSocketOSLServer = configHost.portOSLServer;
                _logger.log(LoggingLevel.INFO, "LoadConfigServerSocket()", $"Config host load Port : {AsyncServer.portSocketOSLServer}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "LoadConfigServerSocket()", e.Message);
            }
        }

        /// <summary>
        /// Load configuration of CDragon
        /// </summary>
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
                _logger.log(LoggingLevel.ERROR, "LoadConfigCDragon", $"Config loadeding error {filePath} : {e.Message}");
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

        public static void LoadConfigTimer()
        {
            //Creation of timer for display him in champ select
            ChampSelectTimer.DecreasingTimerChapSelect(100);
            ChampSelectTimer.DecreasingTimerChapSelectFast(100, 50);
            ChampSelectTimer.DecreasingTimerChapSelectView3(100, 50);
        }

        //public static void LoadConfigChampSelectView1()
        //{
        //    string filePath = "./" + "Configuration" + "/" + "configChampSelectView1.json";
        //    try
        //    {
        //        dynamic configChampSelect = JsonConvert.DeserializeObject<ChampSelectView1Page.ChampSelect>(FileManagerLocal.ReadInFile(filePath));
        //        ChampSelectView1Page.DefaultPatch = configChampSelect.DefaultPatch;
        //        ChampSelectView1Page.DefaultRegion = configChampSelect.DefaultRegion;

        //        ChampSelectView1Page.BlueTeamName = configChampSelect.BlueTeamName;
        //        ChampSelectView1Page.BlueTeamSubtext = configChampSelect.BlueTeamSubtext;
        //        ChampSelectView1Page.BlueTeamNameColor = configChampSelect.BlueTeamNameColor;
        //        ChampSelectView1Page.BlueTeamSubtextColor = configChampSelect.BlueTeamSubtextColor;
        //        ChampSelectView1Page.BlueLogo = configChampSelect.BlueLogo;
        //        ChampSelectView1Page.BlueSideTexteColor = configChampSelect.BlueSideTexteColor;
        //        ChampSelectView1Page.BlueSideBackgroudColor = configChampSelect.BlueSideBackgroudColor;
        //        ChampSelectView1Page.BlueSideBorderColor = configChampSelect.BlueSideBorderColor;
        //        ChampSelectView1Page.BlueSideTimerBackgroudColor = configChampSelect.BlueSideTimerBackgroudColor;
        //        ChampSelectView1Page.ColorBlueSideTimerBorder = configChampSelect.ColorBlueSideTimerBorder;
        //        ChampSelectView1Page.ColorBlueSideTimerTexte = configChampSelect.ColorBlueSideTimerTexte;

        //        ChampSelectView1Page.RedTeamName = configChampSelect.RedTeamName;
        //        ChampSelectView1Page.RedTeamSubtext = configChampSelect.RedTeamSubtext;
        //        ChampSelectView1Page.ColorRedTeamName = configChampSelect.ColorRedTeamName;
        //        ChampSelectView1Page.ColorRedTeamSubtext = configChampSelect.ColorRedTeamSubtext;
        //        ChampSelectView1Page.RedLogo = configChampSelect.RedLogo;
        //        ChampSelectView1Page.ColorRedSideTexte = configChampSelect.ColorRedSideTexte;
        //        ChampSelectView1Page.ColorRedSideBackgroud = configChampSelect.ColorRedSideBackgroud;
        //        ChampSelectView1Page.ColorRedSideBorder = configChampSelect.ColorRedSideBorder;
        //        ChampSelectView1Page.ColorRedSideTimerBackgroud = configChampSelect.ColorRedSideTimerBackgroud;
        //        ChampSelectView1Page.ColorRedSideTimerBorder = configChampSelect.ColorRedSideTimerBorder;
        //        ChampSelectView1Page.ColorRedSideTimerTexte = configChampSelect.ColorRedSideTimerTexte;

        //        ChampSelectView1Page.BanBackgroundPicture = configChampSelect.BanBackgroundPicture;
        //        ChampSelectView1Page.BanOverlayPicture = configChampSelect.BanOverlayPicture;
        //        ChampSelectView1Page.BanBackgroundColor = configChampSelect.BanBackgroundColor;

        //        ChampSelectView1Page.OverlayBackground = configChampSelect.OverlayBackground;
        //        _logger.log(LoggingLevel.INFO, "LoadConfigChampSelect()", $"Config ChampSelect loaded to {filePath}");
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.log(LoggingLevel.ERROR, "LoadConfigChampSelect()", $"Config loadeding error {filePath} {e.Message}");
        //        var champSelectInformation = new ChampSelectView1Page.ChampSelect
        //        {
        //            DefaultPatch = "latest",
        //            DefaultRegion = "fr_fr",

        //            BlueTeamName = "",
        //            BlueTeamSubtext = "",
        //            BlueTeamNameColor = "white",
        //            BlueTeamSubtextColor = "white",
        //            BlueLogo = "",
        //            BlueSideTexteColor = "white",
        //            BlueSideBackgroudColor = "#0b849e",
        //            BlueSideBorderColor = "5px solid yellow",
        //            BlueSideTimerBackgroudColor = "#0b849e",
        //            ColorBlueSideTimerBorder = "5px solid blue",
        //            ColorBlueSideTimerTexte = "white",

        //            RedTeamName = "",
        //            RedTeamSubtext = "",
        //            ColorRedTeamName = "white",
        //            ColorRedTeamSubtext = "white",
        //            RedLogo = "",
        //            ColorRedSideTexte = "white",
        //            ColorRedSideBackgroud = "#be1e37",
        //            ColorRedSideBorder = "5px solid yellow",
        //            ColorRedSideTimerBackgroud = "#be1e37",
        //            ColorRedSideTimerBorder = "5px solid red",
        //            ColorRedSideTimerTexte = "white",

        //            BanBackgroundPicture = "../assets/champselect/banning-1.png",
        //            BanOverlayPicture = "../assets/champselect/ban-completed-2.png",
        //            BanBackgroundColor = "#010a13",

        //            OverlayBackground = "../assets/champselect/backgroud-view-1.png"
        //        };
        //        string configChampSelect = JsonConvert.SerializeObject(champSelectInformation);
        //        FileManagerLocal.RewrittenFile(filePath, configChampSelect);
        //        _logger.log(LoggingLevel.WARN, "LoadConfigChampSelect()", $"Default Config created {filePath}");
        //    }
        //    if (ChampSelectView1Page.DefaultPatch.Equals("latest"))
        //    {
        //        //string[] temps = CDragon.patch.Split(".");
        //        //DefaultPatch = temps[0] + "." + temps[1];
        //        ChampSelectView1Page.DefaultPatch = "12.12";
        //    }
        //}

        /// <summary>
        /// Load configuration Champ Select View1
        /// </summary>
        public static void LoadConfigChampSelectView1()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView1Page.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch(Exception e)
            {
                ChampSelectView1Page.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView1Page.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.DefaultRegion}");
            //ChampSelectView1Page.DefaultPatch = "12.12";
        }
        /// <summary>
        /// Load configuration Champ Select View2
        /// </summary>
        public static void LoadConfigChampSelectView2()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView2Page.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView2Page.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView2Page.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.DefaultRegion}");

            //ChampSelectView2Page.DefaultPatch = "12.12";

        }

        /// <summary>
        /// Load configuration Champ Select View3
        /// </summary>
        public static void LoadConfigChampSelectView3()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView3Page.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView3Page.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView3Page.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.DefaultRegion}");

            //ChampSelectView3Page.DefaultPatch = "12.12";
        }

        public static void LoadConfigChampSelectView4()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView4Page.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView4Page.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView4Page.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.DefaultRegion}");

            //ChampSelectView3Page.DefaultPatch = "12.12";
        }

        public static void LoadDefaultSession()
        {
            string dataDefaultSession = FileManagerLocal.ReadInFile("./wwwroot/assets/champselect/defaultSession.json");
            ChampSelectInfo.InChampSelect(dataDefaultSession);
        }
    }
}
