using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.Adc
{
    /// <summary>
    /// Configuration Rune View 1
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
                //Console.WriteLine(temps[0] + temps[1]);
                RunesAdcPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesAdcPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesAdcPage.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcPage()", $"{RunesAdcPage.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesAdcPage()", $"{RunesAdcPage.formatingData.DefaultRegion}");
        }
        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/Adc/default.json");
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
    }
}
