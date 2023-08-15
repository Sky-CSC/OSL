using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1.Jungle
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
                RunesJunglePage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesJunglePage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesJunglePage.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesJunglePage()", $"{RunesJunglePage.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesJunglePage()", $"{RunesJunglePage.formatingData.DefaultRegion}");
        }
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/Rune/View1/Jungle/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //RunesJunglePage.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //RunesJunglePage.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            RunesJunglePage.formatingData.BackgroudGradient = jsonContent.BackgroudGradient;
            RunesJunglePage.formatingData.OverlayColorBackgroudGradient = jsonContent.OverlayColorBackgroudGradient;
            RunesJunglePage.formatingData.BlueSideColorTextSummoner = jsonContent.BlueSideColorTextSummoner;
            RunesJunglePage.formatingData.RedSideColorTextSummoner = jsonContent.RedSideColorTextSummoner;
            RunesJunglePage.formatingData.BlueSideColorBorderChampion = jsonContent.BlueSideColorBorderChampion;
            RunesJunglePage.formatingData.RedSideColorBorderChampion = jsonContent.RedSideColorBorderChampion;
            RunesJunglePage.formatingData.BlueSideColorSeparationBar = jsonContent.BlueSideColorSeparationBar;
            RunesJunglePage.formatingData.RedSideColorSeparationBar = jsonContent.RedSideColorSeparationBar;
            RunesJunglePage.formatingData.BakgroundPicture = jsonContent.BakgroundPicture;
            RunesJunglePage.formatingData.LanePicture = jsonContent.LanePicture;
        }
    }
}
