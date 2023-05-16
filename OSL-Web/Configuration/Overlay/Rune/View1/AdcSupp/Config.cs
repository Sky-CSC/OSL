using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.AdcSupp
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
                //Console.WriteLine(temps[0] + temps[1]);
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
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/AdcSupp/default.json");
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
    }
}
