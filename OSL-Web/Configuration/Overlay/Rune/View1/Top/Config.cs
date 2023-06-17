using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.Top
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
                RunesTopPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesTopPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesTopPage.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesTopPage()", $"{RunesTopPage.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesTopPage()", $"{RunesTopPage.formatingData.DefaultRegion}");
        }
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/Top/default.json");
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
    }
}
