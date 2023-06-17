using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.ChampSelect;

namespace OSL_Web.Configuration.Overlay.ChampSelect.View2
{
    /// <summary>
    /// Configuration Champ Select View 2
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
        /// Load configuration Champ Select View2
        /// </summary>
        public static void LoadPatchRegionConfig()
        {
            try
            {
                string[] temps = OSL_CDragon.CDragon.patch.Split(".");
                ChampSelectView2Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                ChampSelectView2Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            ChampSelectView2Page.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigChampSelectView2", $"{ChampSelectView2Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 2
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/ChampSelect/View2/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //ChampSelectView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //ChampSelectView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            ChampSelectView2Page.formatingData.TimerBackground = jsonContent.TimerBackground;
            ChampSelectView2Page.formatingData.TimerBlue = jsonContent.TimerBlue;
            ChampSelectView2Page.formatingData.TimerRed = jsonContent.TimerRed;
            ChampSelectView2Page.formatingData.TimerEnd = jsonContent.TimerEnd;
            ChampSelectView2Page.formatingData.BlueSideBackgroud = jsonContent.BlueSideBackgroud;
            ChampSelectView2Page.formatingData.BlueSideSummoner = jsonContent.BlueSideSummoner;
            ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick = jsonContent.BlueSideBackgroudSummonerPick;
            ChampSelectView2Page.formatingData.BlueSideBlink = jsonContent.BlueSideBlink;
            ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd = jsonContent.BlueSideBackgroudSummonerPickEnd;
            ChampSelectView2Page.formatingData.BlueSideTeamName = jsonContent.BlueSideTeamName;
            ChampSelectView2Page.formatingData.BlueSideTeamNameColor = jsonContent.BlueSideTeamNameColor;
            ChampSelectView2Page.formatingData.BlueSideTeamNameSize = jsonContent.BlueSideTeamNameSize;
            ChampSelectView2Page.formatingData.KeystonePickColor = jsonContent.KeystonePickColor;
            ChampSelectView2Page.formatingData.KeystonePickColorDeg = jsonContent.KeystonePickColorDeg;
            ChampSelectView2Page.formatingData.KeystonePickColor1 = jsonContent.KeystonePickColor1;
            ChampSelectView2Page.formatingData.KeystonePickColorPercent1 = jsonContent.KeystonePickColorPercent1;
            ChampSelectView2Page.formatingData.KeystonePickColor2 = jsonContent.KeystonePickColor2;
            ChampSelectView2Page.formatingData.KeystonePickColorPercent2 = jsonContent.KeystonePickColorPercent2;
            ChampSelectView2Page.formatingData.RedSideBackgroud = jsonContent.RedSideBackgroud;
            ChampSelectView2Page.formatingData.RedSideSummoner = jsonContent.RedSideSummoner;
            ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick = jsonContent.RedSideBackgroudSummonerPick;
            ChampSelectView2Page.formatingData.RedSideBlink = jsonContent.RedSideBlink;
            ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd = jsonContent.RedSideBackgroudSummonerPickEnd;
            ChampSelectView2Page.formatingData.RedSideTeamName = jsonContent.RedSideTeamName;
            ChampSelectView2Page.formatingData.RedSideTeamNameColor = jsonContent.RedSideTeamNameColor;
            ChampSelectView2Page.formatingData.RedSideTeamNameSize = jsonContent.RedSideTeamNameSize;
            ChampSelectView2Page.formatingData.BanBackgroundPicture = jsonContent.BanBackgroundPicture;
            ChampSelectView2Page.formatingData.BanOverlayPicture = jsonContent.BanOverlayPicture;
            ChampSelectView2Page.formatingData.BanBackgroundColor = jsonContent.BanBackgroundColor;
            ChampSelectView2Page.formatingData.BanBackgroundColorSave = jsonContent.BanBackgroundColorSav;
        }
    }
}
