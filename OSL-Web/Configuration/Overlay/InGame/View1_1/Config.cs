using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.InGame;

namespace OSL_Web.Configuration.Overlay.InGame.View1_1
{
    /// <summary>
    /// Configuration In Game View 1
    /// </summary>
    public class Config
    {
        private static Logger _logger = new("Config");
        /// <summary>
        /// Load config
        /// </summary>
        public static void LoadConfig()
        {
            LoadFormatingDataConfig();
            LoadPatchRegionConfig();
        }

        /// <summary>
        /// Load num patch and région name
        /// </summary>
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                InGameView1_1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                InGameView1_1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            InGameView1_1Page.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1_1Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1_1Page.formatingData.DefaultRegion}");
        }
        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/InGame/View1_1/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //InGameView1_1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //InGameView1_1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            InGameView1_1Page.formatingData.BluePlayerFrame = jsonContent.BluePlayerFrame;
            InGameView1_1Page.formatingData.DisplayBluePlayerFrame = jsonContent.DisplayBluePlayerFrame;
            InGameView1_1Page.formatingData.RedPlayerFrame = jsonContent.RedPlayerFrame;
            InGameView1_1Page.formatingData.DisplayRedPlayerFrame = jsonContent.DisplayRedPlayerFrame;
            InGameView1_1Page.formatingData.DragonTimerFrame = jsonContent.DragonTimerFrame;
            InGameView1_1Page.formatingData.DisplayDragonTimer = jsonContent.DisplayDragonTimer;
            InGameView1_1Page.formatingData.HeraldBaronTimerFrame = jsonContent.HeraldBaronTimerFrame;
            InGameView1_1Page.formatingData.DisplayHeraldBaronTimer = jsonContent.DisplayHeraldBaronTimer;
            InGameView1_1Page.formatingData.LeftInfoFrame = jsonContent.LeftInfoFrame;
            InGameView1_1Page.formatingData.DisplayLeftInfo = jsonContent.DisplayLeftInfo;
            InGameView1_1Page.formatingData.RightInfoFrame = jsonContent.RightInfoFrame;
            InGameView1_1Page.formatingData.DisplayRightInfo = jsonContent.DisplayRightInfo;
            InGameView1_1Page.formatingData.TeamBanner = jsonContent.TeamBanner;
            InGameView1_1Page.formatingData.TeamScoreBanner = jsonContent.TeamScoreBanner;
            InGameView1_1Page.formatingData.BlueTeamText = jsonContent.BlueTeamText;
            InGameView1_1Page.formatingData.BlueTeamScoreText = jsonContent.BlueTeamScoreText;
            InGameView1_1Page.formatingData.RedTeamText = jsonContent.RedTeamText;
            InGameView1_1Page.formatingData.RedTeamScoreText = jsonContent.RedTeamScoreText;
            InGameView1_1Page.formatingData.DisplayBlueTeam = jsonContent.DisplayBlueTeam;
            InGameView1_1Page.formatingData.DisplayBlueTeamScore = jsonContent.DisplayBlueTeamScore;
            InGameView1_1Page.formatingData.DisplayBlueTeamText = jsonContent.DisplayBlueTeamText;
            InGameView1_1Page.formatingData.DisplayRedTeam = jsonContent.DisplayRedTeam;
            InGameView1_1Page.formatingData.DisplayRedTeamScore = jsonContent.DisplayRedTeamScore;
            InGameView1_1Page.formatingData.DisplayRedTeamText = jsonContent.DisplayRedTeamText;
            InGameView1_1Page.formatingData.ColorBlueTeamScoreText = jsonContent.ColorBlueTeamScoreText;
            InGameView1_1Page.formatingData.ColorBlueTeamText = jsonContent.ColorBlueTeamText;
            InGameView1_1Page.formatingData.ColorRedTeamScoreText = jsonContent.ColorRedTeamScoreText;
            InGameView1_1Page.formatingData.ColorRedTeamText = jsonContent.ColorRedTeamText;
            InGameView1_1Page.formatingData.DisplayItems = jsonContent.DisplayItems;
            InGameView1_1Page.formatingData.DisplayLevels = jsonContent.DisplayLevels;
            InGameView1_1Page.formatingData.DisplayDragonKill = jsonContent.DisplayDragonKill;
            InGameView1_1Page.formatingData.DisplayInhibKill = jsonContent.DisplayInhibKill;
            InGameView1_1Page.formatingData.DisplayBaronElderBuff = jsonContent.DisplayBaronElderBuff;

            InGameView1_1Page.formatingData.PictureOrderDragonBanner = jsonContent.PictureOrderDragonBanner;
            InGameView1_1Page.formatingData.PictureChaosDragonBanner = jsonContent.PictureChaosDragonBanner;
            InGameView1_1Page.formatingData.ElderDragonIcon = jsonContent.ElderDragonIcon;
            InGameView1_1Page.formatingData.HeraldIcon = jsonContent.HeraldIcon;
            InGameView1_1Page.formatingData.BaronIcon = jsonContent.BaronIcon;
            InGameView1_1Page.formatingData.PositionOrderTop = jsonContent.PositionOrderTop;
            InGameView1_1Page.formatingData.PositionChaosTop = jsonContent.PositionChaosTop;
            InGameView1_1Page.formatingData.PositionOrderJungle = jsonContent.PositionOrderJungle;
            InGameView1_1Page.formatingData.PositionChaosJungle = jsonContent.PositionChaosJungle;
            InGameView1_1Page.formatingData.PositionOrderMid = jsonContent.PositionOrderMid;
            InGameView1_1Page.formatingData.PositionChaosMid = jsonContent.PositionChaosMid;
            InGameView1_1Page.formatingData.PositionOrderBottom = jsonContent.PositionOrderBottom;
            InGameView1_1Page.formatingData.PositionChaosBottom = jsonContent.PositionChaosBottom;
            InGameView1_1Page.formatingData.PositionOrderSupport = jsonContent.PositionOrderSupport;
            InGameView1_1Page.formatingData.PositionChaosSupport = jsonContent.PositionChaosSupport;
            InGameView1_1Page.formatingData.InhibIcon = jsonContent.InhibIcon;
            InGameView1_1Page.formatingData.BaronBuffIcon = jsonContent.BaronBuffIcon;
            InGameView1_1Page.formatingData.ElderBuffIcon = jsonContent.ElderBuffIcon;
        }
    }
}
