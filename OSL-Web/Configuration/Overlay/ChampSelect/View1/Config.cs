using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.ChampSelect;

namespace OSL_Web.Configuration.Overlay.ChampSelect.View1
{
    /// <summary>
    /// Configuration Champ Select View 1
    /// </summary>
    public class Config
    {
        private static Logger _logger = new("Config");

        public static void LoadConfig()
        {
            LoadFormatingDataConfig();
            LoadPatchRegionConfig();
        }

        /// <summary>
        /// Load configuration
        /// </summary>
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                ChampSelectView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView1Page.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView1", $"{ChampSelectView1Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
        public static void LoadFormatingDataConfig()
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
    }
}
