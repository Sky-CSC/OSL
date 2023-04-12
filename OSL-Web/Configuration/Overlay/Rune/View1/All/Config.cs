using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.All
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
                RunesAllPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesAllPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesAllPage.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAllPage()", $"{RunesAllPage.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigRunesAllPage()", $"{RunesAllPage.formatingData.DefaultRegion}");
        }
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/All/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesAllPage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesAllPage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesAllPage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesAllPage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesAllPage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesAllPage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesAllPage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesAllPage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesAllPage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesAllPage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesAllPage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesAllPage.formatingData.LanePictureAdc = jsonContent.LanePictureAdc;
            RunesAllPage.formatingData.LanePictureSupp = jsonContent.LanePictureSupp;
            RunesAllPage.formatingData.LanePictureTop = jsonContent.LanePictureTop;
            RunesAllPage.formatingData.LanePictureMid = jsonContent.LanePictureMid;
            RunesAllPage.formatingData.LanePictureJungle = jsonContent.LanePictureJungle;
        }
    }
}
