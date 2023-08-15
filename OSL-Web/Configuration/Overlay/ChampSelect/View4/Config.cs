using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.ChampSelect;

namespace OSL_Web.Configuration.Overlay.ChampSelect.View4
{
    /// <summary>
    /// Configuration Champ Select View 4
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
        /// Load configuration Champ Select View 4
        /// </summary>
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                ChampSelectView4Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView4Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView4Page.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView4", $"{ChampSelectView4Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 4
        /// </summary>
        public static void LoadFormatingDataConfig()
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
    }
}
