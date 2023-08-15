using OSL_Common.System.DirectoryManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.Runes;

namespace OSL_Web.Configuration.Overlay.Rune.View1
{
    public class Config
    {
        private static Logger _logger = new("Config");
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                //Console.WriteLine(temps[0] + temps[1]);
                RunesPage.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                RunesPage.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            RunesPage.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesPage()", $"{RunesPage.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigRunesPage()", $"{RunesPage.formatingData.DefaultRegion}");
        }
    }
}
