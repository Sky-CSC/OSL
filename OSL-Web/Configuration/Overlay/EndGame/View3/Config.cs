using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.EndGame;


namespace OSL_Web.Configuration.Overlay.EndGame.View3
{
    /// <summary>
    /// Configuration End Game View 1
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
                EndGameView3Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                EndGameView3Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            EndGameView3Page.formatingData.DefaultRegion = "fr_fr";
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView3Page()", $"{EndGameView3Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView3Page()", $"{EndGameView3Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 3
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/EndGame/View3/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //EndGameView3Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //EndGameView3Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            EndGameView3Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
            EndGameView3Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
            EndGameView3Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
            EndGameView3Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
            EndGameView3Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
            EndGameView3Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
            EndGameView3Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
            EndGameView3Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
            EndGameView3Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
            EndGameView3Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
            EndGameView3Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
            EndGameView3Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
            EndGameView3Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
            EndGameView3Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
            EndGameView3Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
            EndGameView3Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
            EndGameView3Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
            EndGameView3Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
            EndGameView3Page.formatingData.TopBarBlueTeamScore = jsonContent.TopBarBlueTeamScore;
            EndGameView3Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
            EndGameView3Page.formatingData.TopBarBlueTeamScoreColor = jsonContent.TopBarBlueTeamScoreColor;
            EndGameView3Page.formatingData.TopBarBlueTeamWinLossColor = jsonContent.TopBarBlueTeamWinLossColor;
            EndGameView3Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
            EndGameView3Page.formatingData.TopBarRedTeamScore = jsonContent.TopBarRedTeamScore;
            EndGameView3Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
            EndGameView3Page.formatingData.TopBarRedTeamScoreColor = jsonContent.TopBarRedTeamScoreColor;
            EndGameView3Page.formatingData.TopBarRedTeamWinLossColor = jsonContent.TopBarRedTeamWinLossColor;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
            EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
            EndGameView3Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
            EndGameView3Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
            EndGameView3Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
            EndGameView3Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
            EndGameView3Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
            EndGameView3Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
            EndGameView3Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
            EndGameView3Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
            EndGameView3Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
            EndGameView3Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
            EndGameView3Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
            EndGameView3Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
            EndGameView3Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
            EndGameView3Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
            EndGameView3Page.formatingData.BansGradiant = jsonContent.BansGradiant;
            EndGameView3Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
            EndGameView3Page.formatingData.BansTextColor = jsonContent.BansTextColor;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
            EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
            EndGameView3Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
            EndGameView3Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
            EndGameView3Page.formatingData.GlobalStatsSeparationColor = jsonContent.GlobalStatsSeparationColor;
            EndGameView3Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
            EndGameView3Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
            EndGameView3Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
            EndGameView3Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
            EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
            EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
            EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
            EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
            EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
            EndGameView3Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
            EndGameView3Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
            EndGameView3Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
            EndGameView3Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
            EndGameView3Page.formatingData.GoldDiffBlueTextGoldColor = jsonContent.GoldDiffBlueTextGoldColor;
            EndGameView3Page.formatingData.GoldDiffRedTextGoldColor = jsonContent.GoldDiffRedTextGoldColor;
            EndGameView3Page.formatingData.GoldDiffZeroTextGoldColor = jsonContent.GoldDiffZeroTextGoldColor;
            EndGameView3Page.formatingData.GoldDiffBluePointGoldColor = jsonContent.GoldDiffBluePointGoldColor;
            EndGameView3Page.formatingData.GoldDiffRedPointGoldColor = jsonContent.GoldDiffRedPointGoldColor;
            EndGameView3Page.formatingData.GoldDiffZeroPointGoldColor = jsonContent.GoldDiffZeroPointGoldColor;
            EndGameView3Page.formatingData.GoldDiffStartEndPointGoldColor = jsonContent.GoldDiffStartEndPointGoldColor;
            EndGameView3Page.formatingData.GoldDiffLinkPointGoldColor = jsonContent.GoldDiffLinkPointGoldColor;
            EndGameView3Page.formatingData.GoldDiffBarColor = jsonContent.GoldDiffBarColor;
        }
    }
}
