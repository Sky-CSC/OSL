using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.InGame;

namespace OSL_Web.Configuration.Overlay.InGame.View2
{
    public class Config
    {
        private static Logger _logger = new("Config");
        public static void LoadConfig()
        {
            LoadFormatingDataConfig();
            LoadPatchRegionConfig();
        }

        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
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
        public static void LoadFormatingDataConfig()
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
    }
}
