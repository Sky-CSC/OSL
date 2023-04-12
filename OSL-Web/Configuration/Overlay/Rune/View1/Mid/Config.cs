using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.Mid
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
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/Mid/default.json");
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
    }
}
