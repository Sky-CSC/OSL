using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.InGame;

namespace OSL_Web.Configuration.Overlay.InGame.View3
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
        public static void LoadFormatingDataConfig()
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
    }
}
