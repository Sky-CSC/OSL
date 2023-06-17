using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.InGame;

namespace OSL_Web.Configuration.Overlay.InGame.View1
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
                InGameView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                InGameView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            InGameView1Page.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{InGameView1Page.formatingData.DefaultRegion}");
        }
        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
        public static void LoadFormatingDataConfig()
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
    }
}
