using Newtonsoft.Json;
using OSL_Server.FileManager;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Communication;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using System.Net;
using OSL_Server.Pages;
using OSL_Server.Pages.ChampSelect;
using OSL_Server.Pages.InGame;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using OSL_Server.DataLoader.WebApiRiot;
using OSL_Server.Pages.Runes;
using OSL_Server.Pages.EndGame;

namespace OSL_Server.Configuration
{
    /// <summary>
    /// Class for configure client application
    /// </summary>
    public class Config
    {
        private static OSLLogger _logger = new OSLLogger("Config");

        public static IPHostEntry oslServerHost;
        public static string oslServerHostName;
        public static int oslServerHttpPort;
        public static int oslServerHttpsPort;

        /// <summary>
        /// Load configuration
        /// </summary>
        public static void LoadConfig()
        {
            LoadConfigOslServerHost();

            LoadConfigServerSocket();

            LoadConfigCDragon();

            LoadConfigTimer();

            LoadDefaultSession();

            LoadWebRiotApiKey();

            LoadFormatingDataConfigChampSelectView1();
            LoadConfigChampSelectView1();
            LoadFormatingDataConfigChampSelectView2();
            LoadConfigChampSelectView2();
            LoadFormatingDataConfigChampSelectView3();
            LoadConfigChampSelectView3();
            LoadFormatingDataConfigChampSelectView4();
            LoadConfigChampSelectView4();

            LoadFormatingDataConfigInGameView1();
            LoadConfigInGameView1();
            LoadFormatingDataConfigInGameView2();
            LoadConfigInGameView2();
            LoadFormatingDataConfigInGameView3();
            LoadConfigInGameView3();


            LoadConfigRunesPage();
            LoadFormatingDataConfigRunesTopPage();
            LoadConfigRunesTopPage();
            LoadFormatingDataConfigRunesMidPage();
            LoadConfigRunesMidPage();
            LoadFormatingDataConfigRunesJunglePage();
            LoadConfigRunesJunglePage();
            LoadFormatingDataConfigRunesAdcPage();
            LoadConfigRunesAdcPage();
            LoadFormatingDataConfigRunesSuppPage();
            LoadConfigRunesSuppPage();
            LoadFormatingDataConfigRunesAdcSuppPage();
            LoadConfigRunesAdcSuppPage();

            LoadFormatingDataConfigEndGameView1();
            LoadConfigEndGameView1Page();
        }

        /// <summary>
        /// Load Config Osl Server Host for urls
        /// </summary>
        public static void LoadConfigOslServerHost()
        {
            oslServerHost = Dns.Resolve("0.0.0.0");
            oslServerHostName = oslServerHost.HostName;
            oslServerHttpPort = 4141;
            oslServerHttpsPort = 4242;
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

        /// <summary>
        /// Load timer for champ select view
        /// </summary>
        public static void LoadConfigTimer()
        {
            //Creation of timer for display him in champ select
            ChampSelectTimer.DecreasingTimerChapSelect(100);
            ChampSelectTimer.DecreasingTimerChapSelectFast(100, 50);
            ChampSelectTimer.DecreasingTimerChapSelectView3(100, 50);
        }

        /// <summary>
        /// Load configuration Champ Select View1
        /// </summary>
        public static void LoadConfigChampSelectView1()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView1Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.formatingData.DefaultRegion}");
            //ChampSelectView1Page.DefaultPatch = "12.12";
        }

        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
        public static void LoadFormatingDataConfigChampSelectView1()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View1/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //ChampSelectView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            ChampSelectView1Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView1Page.formatingData.BlueTeamSubtext = jsonContent.BlueTeamSubtext;
            ChampSelectView1Page.formatingData.BlueTeamNameColor = jsonContent.BlueTeamNameColor;
            ChampSelectView1Page.formatingData.BlueTeamSubtextColor = jsonContent.BlueTeamSubtextColor;
            ChampSelectView1Page.formatingData.BlueLogo = jsonContent.BlueLogo;
            ChampSelectView1Page.formatingData.BlueSideTexteColor = jsonContent.BlueSideTexteColor;
            ChampSelectView1Page.formatingData.BlueSideBackgroudColor = jsonContent.BlueSideBackgroudColor;
            ChampSelectView1Page.formatingData.BlueSideBorderColor = jsonContent.BlueSideBorderColor;
            ChampSelectView1Page.formatingData.BlueSideTimerBackgroudColor = jsonContent.BlueSideTimerBackgroudColor;
            ChampSelectView1Page.formatingData.BlueSideTimerBorderColor = jsonContent.BlueSideTimerBorderColor;
            ChampSelectView1Page.formatingData.BlueSideTimerTexteColor = jsonContent.BlueSideTimerTexteColor;
            ChampSelectView1Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView1Page.formatingData.RedTeamSubtext = jsonContent.RedTeamSubtext;
            ChampSelectView1Page.formatingData.RedTeamNameColor = jsonContent.RedTeamNameColor;
            ChampSelectView1Page.formatingData.RedTeamSubtextColor = jsonContent.RedTeamSubtextColor;
            ChampSelectView1Page.formatingData.RedLogo = jsonContent.RedLogo;
            ChampSelectView1Page.formatingData.RedSideTexteColor = jsonContent.RedSideTexteColor;
            ChampSelectView1Page.formatingData.RedSideBackgroudColor = jsonContent.RedSideBackgroudColor;
            ChampSelectView1Page.formatingData.RedSideBorderColor = jsonContent.RedSideBorderColor;
            ChampSelectView1Page.formatingData.RedSideTimerBackgroudColor = jsonContent.RedSideTimerBackgroudColor;
            ChampSelectView1Page.formatingData.RedSideTimerBorderColor = jsonContent.RedSideTimerBorderColor;
            ChampSelectView1Page.formatingData.RedSideTimerTexteColor = jsonContent.RedSideTimerTexteColor;
            ChampSelectView1Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
            ChampSelectView1Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
            ChampSelectView1Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
            ChampSelectView1Page.formatingData.OverlayBackground = jsonContent.OverlayBackground;
        }
        /// <summary>
        /// Load configuration Champ Select View2
        /// </summary>
        public static void LoadConfigChampSelectView2()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView2Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView2Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView2Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.formatingData.DefaultRegion}");

            //ChampSelectView2Page.DefaultPatch = "12.12";
        }

        /// <summary>
        /// Load default json file for overlay view 2
        /// </summary>
        public static void LoadFormatingDataConfigChampSelectView2()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View2/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //ChampSelectView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            ChampSelectView2Page.formatingData.TimerBackground = jsonContent.TimerBackground;
            ChampSelectView2Page.formatingData.TimerBlue = jsonContent.TimerBlue;
            ChampSelectView2Page.formatingData.TimerRed = jsonContent.TimerRed;
            ChampSelectView2Page.formatingData.TimerEnd = jsonContent.TimerEnd;
            ChampSelectView2Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
            ChampSelectView2Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
            ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
            ChampSelectView2Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
            ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
            ChampSelectView2Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView2Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
            ChampSelectView2Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
            ChampSelectView2Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
            ChampSelectView2Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
            ChampSelectView2Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
            ChampSelectView2Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
            ChampSelectView2Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
            ChampSelectView2Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
            ChampSelectView2Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
            ChampSelectView2Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
            ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
            ChampSelectView2Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
            ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
            ChampSelectView2Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView2Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
            ChampSelectView2Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
            ChampSelectView2Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
            ChampSelectView2Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
            ChampSelectView2Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
            ChampSelectView2Page.formatingData.BanBackgroundColorSave = jsonContent.BanBackgroundColorSav;
        }

        /// <summary>
        /// Load configuration Champ Select View3
        /// </summary>
        public static void LoadConfigChampSelectView3()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView3Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView3Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView3Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.formatingData.DefaultRegion}");

            //ChampSelectView3Page.DefaultPatch = "12.12";
        }

        /// <summary>
        /// Load default json file for overlay view 3
        /// </summary>
        public static void LoadFormatingDataConfigChampSelectView3()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View3/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);

            //ChampSelectView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            ChampSelectView3Page.formatingData.TimerBackground = jsonContent.TimerBackground;
            ChampSelectView3Page.formatingData.TimerBlue = jsonContent.TimerBlue;
            ChampSelectView3Page.formatingData.TimerRed = jsonContent.TimerRed;
            ChampSelectView3Page.formatingData.TimerEnd = jsonContent.TimerEnd;
            ChampSelectView3Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
            ChampSelectView3Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
            ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
            ChampSelectView3Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
            ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
            ChampSelectView3Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView3Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
            ChampSelectView3Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
            ChampSelectView3Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
            ChampSelectView3Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
            ChampSelectView3Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
            ChampSelectView3Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
            ChampSelectView3Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
            ChampSelectView3Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
            ChampSelectView3Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
            ChampSelectView3Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
            ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
            ChampSelectView3Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
            ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
            ChampSelectView3Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView3Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
            ChampSelectView3Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
            ChampSelectView3Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
            ChampSelectView3Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
            ChampSelectView3Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
            ChampSelectView3Page.formatingData.BanBackgroundColorSave = jsonContent.BanBackgroundColorSav;
        }

        /// <summary>
        /// Load configuration Champ Select View4
        /// </summary>
        public static void LoadConfigChampSelectView4()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                ChampSelectView4Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView4Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView4Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.formatingData.DefaultRegion}");

            //ChampSelectView3Page.DefaultPatch = "12.12";
        }

        /// <summary>
        /// Load default json file for overlay view 4
        /// </summary>
        public static void LoadFormatingDataConfigChampSelectView4()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View4/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //ChampSelectView4Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView4Page.formatingData.DefaultRegion = jsonContent.DefaultRegion ;
            ChampSelectView4Page.formatingData.BorderBottomPixel = jsonContent.BorderBottomPixel;
            ChampSelectView4Page.formatingData.BorderTop = jsonContent.BorderTop;
            ChampSelectView4Page.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            ChampSelectView4Page.formatingData.BackgroudGradientDeg = jsonContent.BackgroudGradientDeg;
            ChampSelectView4Page.formatingData.BackgroudGradientColor1 = jsonContent.BackgroudGradientColor1;
            ChampSelectView4Page.formatingData.BackgroudGradientPercent1 = jsonContent.BackgroudGradientPercent1;
            ChampSelectView4Page.formatingData.BackgroudGradientColor2 = jsonContent.BackgroudGradientColor2;
            ChampSelectView4Page.formatingData.BackgroudGradientPercent2 = jsonContent.BackgroudGradientPercent2;
            ChampSelectView4Page.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            ChampSelectView4Page.formatingData.BlueSideBorderColorPick = jsonContent.BlueSideBorderColorPick;
            ChampSelectView4Page.formatingData.BlueSideBorderColorBan = jsonContent.BlueSideBorderColorBan;
            ChampSelectView4Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext = jsonContent.BlueSideTeamNameSubtext;
            ChampSelectView4Page.formatingData.BlueSideBanText = jsonContent.BlueSideBanText;
            ChampSelectView4Page.formatingData.BlueSidePickText = jsonContent.BlueSidePickText;
            ChampSelectView4Page.formatingData.BlueSideColorText = jsonContent.BlueSideColorText;
            ChampSelectView4Page.formatingData.BlueSideColorSubText = jsonContent.BlueSideColorSubText;
            ChampSelectView4Page.formatingData.BlueSideColorTextBan = jsonContent.BlueSideColorTextBan;
            ChampSelectView4Page.formatingData.BlueSideColorTextPick = jsonContent.BlueSideColorTextPick;
            ChampSelectView4Page.formatingData.RedSideBorderColorPick = jsonContent.RedSideBorderColorPick;
            ChampSelectView4Page.formatingData.RedSideBorderColorBan = jsonContent.RedSideBorderColorBan;
            ChampSelectView4Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView4Page.formatingData.RedSideTeamNameSubtext = jsonContent.RedSideTeamNameSubtext;
            ChampSelectView4Page.formatingData.RedSideBanText = jsonContent.RedSideBanText;
            ChampSelectView4Page.formatingData.RedSidePickText = jsonContent.RedSidePickText;
            ChampSelectView4Page.formatingData.RedSideColorText = jsonContent.RedSideColorText;
            ChampSelectView4Page.formatingData.RedSideColorSubText = jsonContent.RedSideColorSubText;
            ChampSelectView4Page.formatingData.RedSideColorTextBan = jsonContent.RedSideColorTextBan;
            ChampSelectView4Page.formatingData.RedSideColorTextPick = jsonContent.RedSideColorTextPick;

        }

        /// <summary>
        /// Load Default Session for display att start information on champ select views
        /// </summary>
        public static void LoadDefaultSession()
        {
            string dataDefaultSession = FileManagerLocal.ReadInFile("./wwwroot/assets/champselect/defaultSession.json");
            ChampSelectInfo.InChampSelect(dataDefaultSession);
        }

        public static void LoadConfigInGameView1()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                InGameView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                InGameView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            InGameView1Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1Page.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigInGameView1()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/InGame/View1/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //InGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //InGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            InGameView1Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
            InGameView1Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
            InGameView1Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
            InGameView1Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
            InGameView1Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
            InGameView1Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
            InGameView1Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
            InGameView1Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
            InGameView1Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
            InGameView1Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
            InGameView1Page.formatingData.RightInfoFrame = jsonContent.RightInfoFrame;
            InGameView1Page.formatingData.DisplayRightInfo = jsonContent.DisplayRightInfo;
            InGameView1Page.formatingData.TeamBanner = jsonContent.TeamBanner;
            InGameView1Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
            InGameView1Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
            InGameView1Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
            InGameView1Page.formatingData.RedTeamText = jsonContent.RedTeamText;
            InGameView1Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
            InGameView1Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
            InGameView1Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
            InGameView1Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
            InGameView1Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
            InGameView1Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
            InGameView1Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
            InGameView1Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
            InGameView1Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
            InGameView1Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
            InGameView1Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;
        }

        public static void LoadConfigInGameView2()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                InGameView2Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                InGameView2Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            InGameView2Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView2Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView2Page.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigInGameView2()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/InGame/View2/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //InGameView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //InGameView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            InGameView2Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
            InGameView2Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
            InGameView2Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
            InGameView2Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
            InGameView2Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
            InGameView2Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
            InGameView2Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
            InGameView2Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
            InGameView2Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
            InGameView2Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
            InGameView2Page.formatingData.TeamBanner = jsonContent.TeamBanner;
            InGameView2Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
            InGameView2Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
            InGameView2Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
            InGameView2Page.formatingData.RedTeamText = jsonContent.RedTeamText;
            InGameView2Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
            InGameView2Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
            InGameView2Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
            InGameView2Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
            InGameView2Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
            InGameView2Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
            InGameView2Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
            InGameView2Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
            InGameView2Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
            InGameView2Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
            InGameView2Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;
        }

        public static void LoadConfigInGameView3()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                InGameView3Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                InGameView3Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            InGameView3Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView3Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView3Page.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigInGameView3()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/InGame/View3/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //InGameView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //InGameView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            InGameView3Page.formatingData.ReplayInfoFrame = jsonContent.ReplayInfoFrame;
            InGameView3Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
            InGameView3Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
            InGameView3Page.formatingData.ReplayInfoText = jsonContent.ReplayInfoText;
            InGameView3Page.formatingData.ColorReplayInfoText = jsonContent.ColorReplayInfoText;
            InGameView3Page.formatingData.DisplayReplayInfoFrame = jsonContent.DisplayReplayInfoFrame;
            InGameView3Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
            InGameView3Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
        }

        public static void LoadWebRiotApiKey()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/webApiRiot.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            WebApiRiot.apiKey = jsonContent.apiKey;
            _logger.log(LoggingLevel.INFO, "LoadWebRiotApiKey()", $"Api key loaded");
        }


        public static void LoadConfigRunesPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesPage()", $"{RunesPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesPage()", $"{RunesPage.formatingData.DefaultRegion}");
        }

        public static void LoadConfigRunesTopPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesTopPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesTopPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesTopPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesTopPage()", $"{RunesTopPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesTopPage()", $"{RunesTopPage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesTopPage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/Top/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesTopPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesTopPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesTopPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesTopPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesTopPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesTopPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesTopPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesTopPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesTopPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesTopPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesTopPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesTopPage.formatingData.LanePicture = jsonContent.LanePicture;
        }

        public static void LoadConfigRunesMidPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesMidPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesMidPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesMidPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesMidPage()", $"{RunesMidPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesMidPage()", $"{RunesMidPage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesMidPage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/Mid/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesMidPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesMidPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesMidPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesMidPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesMidPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesMidPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesMidPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesMidPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesMidPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesMidPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesMidPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesMidPage.formatingData.LanePicture = jsonContent.LanePicture;
        }

        public static void LoadConfigRunesJunglePage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesJunglePage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesJunglePage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesJunglePage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesJunglePage()", $"{RunesJunglePage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesJunglePage()", $"{RunesJunglePage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesJunglePage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/Jungle/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesJunglePage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesJunglePage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesJunglePage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesJunglePage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesJunglePage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesJunglePage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesJunglePage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesJunglePage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesJunglePage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesJunglePage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesJunglePage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesJunglePage.formatingData.LanePicture = jsonContent.LanePicture;
        }

        public static void LoadConfigRunesAdcPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesAdcPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesAdcPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesAdcPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcPage()", $"{RunesAdcPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcPage()", $"{RunesAdcPage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesAdcPage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/Adc/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesAdcPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesAdcPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesAdcPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesAdcPage.formatingData.BackgroudGradientDeg = jsonContent.BackgroudGradientDeg;
            RunesAdcPage.formatingData.BackgroudGradientColor1 = jsonContent.BackgroudGradientColor1;
            RunesAdcPage.formatingData.BackgroudGradientPercent1 = jsonContent.BackgroudGradientPercent1;
            RunesAdcPage.formatingData.BackgroudGradientColor2 = jsonContent.BackgroudGradientColor2;
            RunesAdcPage.formatingData.BackgroudGradientPercent2 = jsonContent.BackgroudGradientPercent2;
            RunesAdcPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesAdcPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesAdcPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesAdcPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesAdcPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesAdcPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesAdcPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesAdcPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesAdcPage.formatingData.LanePicture = jsonContent.LanePicture;
        }

        public static void LoadConfigRunesSuppPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesSuppPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesSuppPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesSuppPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesSuppPage()", $"{RunesSuppPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesSuppPage()", $"{RunesSuppPage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesSuppPage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/Support/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesSuppPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesSuppPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesSuppPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesSuppPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesSuppPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesSuppPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesSuppPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesSuppPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesSuppPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesSuppPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesSuppPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesSuppPage.formatingData.LanePicture = jsonContent.LanePicture;
        }

        public static void LoadConfigRunesAdcSuppPage()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                RunesAdcSuppPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesAdcSuppPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesAdcSuppPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcSuppPage()", $"{RunesAdcSuppPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcSuppPage()", $"{RunesAdcSuppPage.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigRunesAdcSuppPage()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Runes/AdcSupp/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesAdcSuppPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesAdcSuppPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesAdcSuppPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesAdcSuppPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesAdcSuppPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesAdcSuppPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesAdcSuppPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesAdcSuppPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesAdcSuppPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesAdcSuppPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesAdcSuppPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesAdcSuppPage.formatingData.LanePictureAdc = jsonContent.LanePictureAdc;
            RunesAdcSuppPage.formatingData.LanePictureSupp = jsonContent.LanePictureSupp;
        }

        public static void LoadConfigEndGameView1Page()
        {
            try
            {
                string[] temps = CDragon.patch.Split(".");
                Console.WriteLine(temps[0] + temps[1]);
                EndGameView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                EndGameView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            EndGameView1Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfigEndGameView1()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/EndGame/View1/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //EndGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //EndGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            EndGameView1Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
            EndGameView1Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
            EndGameView1Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
            EndGameView1Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
            EndGameView1Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
            EndGameView1Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
            EndGameView1Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
            EndGameView1Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
            EndGameView1Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
            EndGameView1Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
            EndGameView1Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
            EndGameView1Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
            EndGameView1Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
            EndGameView1Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
            EndGameView1Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
            EndGameView1Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
            EndGameView1Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
            EndGameView1Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
            EndGameView1Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
            EndGameView1Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
            EndGameView1Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
            EndGameView1Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
            EndGameView1Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
            EndGameView1Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
            EndGameView1Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
            EndGameView1Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
            EndGameView1Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
            EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
            EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
            EndGameView1Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
            EndGameView1Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
            EndGameView1Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
            EndGameView1Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
            EndGameView1Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
            EndGameView1Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
            EndGameView1Page.formatingData.BansGradiant = jsonContent.BansGradiant;
            EndGameView1Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
            EndGameView1Page.formatingData.BansTextColor = jsonContent.BansTextColor;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
            EndGameView1Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
            EndGameView1Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
            EndGameView1Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
            EndGameView1Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
            EndGameView1Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
            EndGameView1Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
            EndGameView1Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
            EndGameView1Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
            EndGameView1Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
            EndGameView1Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
        }
    }
}