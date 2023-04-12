using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.EndGame;


namespace OSL_Web.Configuration.Overlay.EndGame.View1
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
                EndGameView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                EndGameView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            EndGameView1Page.formatingData.DefaultRegion = "fr_fr";
            _logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultPatch}");
            _logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultRegion}");
        }

        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/EndGame/View1/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //EndGameView1Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //EndGameView1Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            EndGameView1Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
            EndGameView1Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
            EndGameView1Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
            EndGameView1Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
            EndGameView1Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
            EndGameView1Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
            EndGameView1Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
            EndGameView1Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
            EndGameView1Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
            EndGameView1Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
            EndGameView1Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
            EndGameView1Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
            EndGameView1Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
            EndGameView1Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
            EndGameView1Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
            EndGameView1Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
            EndGameView1Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
            EndGameView1Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
            EndGameView1Page.formatingData.TopBarBlueTeamScore = jsonContent.TopBarBlueTeamScore;
            EndGameView1Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
            EndGameView1Page.formatingData.TopBarBlueTeamScoreColor = jsonContent.TopBarBlueTeamScoreColor;
            EndGameView1Page.formatingData.TopBarBlueTeamWinLossColor = jsonContent.TopBarBlueTeamWinLossColor;
            EndGameView1Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
            EndGameView1Page.formatingData.TopBarRedTeamScore = jsonContent.TopBarRedTeamScore;
            EndGameView1Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
            EndGameView1Page.formatingData.TopBarRedTeamScoreColor = jsonContent.TopBarRedTeamScoreColor;
            EndGameView1Page.formatingData.TopBarRedTeamWinLossColor = jsonContent.TopBarRedTeamWinLossColor;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
            EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
            EndGameView1Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
            EndGameView1Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
            EndGameView1Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
            EndGameView1Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
            EndGameView1Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
            EndGameView1Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
            EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
            EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
            EndGameView1Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
            EndGameView1Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
            EndGameView1Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
            EndGameView1Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
            EndGameView1Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
            EndGameView1Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
            EndGameView1Page.formatingData.BansGradiant = jsonContent.BansGradiant;
            EndGameView1Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
            EndGameView1Page.formatingData.BansTextColor = jsonContent.BansTextColor;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
            EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
            EndGameView1Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
            EndGameView1Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
            EndGameView1Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
            EndGameView1Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
            EndGameView1Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
            EndGameView1Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
            EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
            EndGameView1Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
            EndGameView1Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
            EndGameView1Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
            EndGameView1Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
            EndGameView1Page.formatingData.GoldDiffBlueTextGoldColor = jsonContent.GoldDiffBlueTextGoldColor;
            EndGameView1Page.formatingData.GoldDiffRedTextGoldColor = jsonContent.GoldDiffRedTextGoldColor;
            EndGameView1Page.formatingData.GoldDiffZeroTextGoldColor = jsonContent.GoldDiffZeroTextGoldColor;
            EndGameView1Page.formatingData.GoldDiffBluePointGoldColor = jsonContent.GoldDiffBluePointGoldColor;
            EndGameView1Page.formatingData.GoldDiffRedPointGoldColor = jsonContent.GoldDiffRedPointGoldColor;
            EndGameView1Page.formatingData.GoldDiffZeroPointGoldColor = jsonContent.GoldDiffZeroPointGoldColor;
            EndGameView1Page.formatingData.GoldDiffStartEndPointGoldColor = jsonContent.GoldDiffStartEndPointGoldColor;
            EndGameView1Page.formatingData.GoldDiffLinkPointGoldColor = jsonContent.GoldDiffLinkPointGoldColor;
            EndGameView1Page.formatingData.GoldDiffBarColor = jsonContent.GoldDiffBarColor;
        }
    }
}
