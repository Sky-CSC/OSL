using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.ChampSelect;

namespace OSL_Web.Configuration.Overlay.ChampSelect.View3
{
    /// <summary>
    /// Configuration Champ Select View 3
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
        /// Load configuration Champ Select View3
        /// </summary>
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                ChampSelectView3Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView3Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView3Page.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView3", $"{ChampSelectView3Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 3
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View3/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);

            //ChampSelectView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            ChampSelectView3Page.formatingData.TimerBackground = jsonContent.TimerBackground;
            ChampSelectView3Page.formatingData.TimerBlue = jsonContent.TimerBlue;
            ChampSelectView3Page.formatingData.TimerRed = jsonContent.TimerRed;
            ChampSelectView3Page.formatingData.TimerEnd = jsonContent.TimerEnd;
            ChampSelectView3Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
            ChampSelectView3Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
            ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
            ChampSelectView3Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
            ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
            ChampSelectView3Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView3Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
            ChampSelectView3Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
            ChampSelectView3Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
            ChampSelectView3Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
            ChampSelectView3Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
            ChampSelectView3Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
            ChampSelectView3Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
            ChampSelectView3Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
            ChampSelectView3Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
            ChampSelectView3Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
            ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
            ChampSelectView3Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
            ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
            ChampSelectView3Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView3Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
            ChampSelectView3Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
            ChampSelectView3Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
            ChampSelectView3Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
            ChampSelectView3Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
            ChampSelectView3Page.formatingData.BanBackgroundColorSave = jsonContent.BanBackgroundColorSav;
        }
    }
}
