using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.EndGame;


namespace OSL_Web.Configuration.Overlay.EndGame.View2
{
    /// <summary>
    /// Configuration End Game View 2
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
                EndGameView2Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                EndGameView2Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            EndGameView2Page.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView2Page()", $"{EndGameView2Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView2Page()", $"{EndGameView2Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 2
        /// </summary>
        public static void LoadFormatingDataConfig()
        {
            string content = FileManagerLocal.ReadInFile("./Configuration/Overlay/EndGame/View2/default.json");
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //EndGameView2Page.formatingData.DefaultPatch = jsonContent.DefaultPatch;
            //EndGameView2Page.formatingData.DefaultRegion = jsonContent.DefaultRegion;
            EndGameView2Page.formatingData.BackgroundColor = jsonContent.BackgroundColor;
            EndGameView2Page.formatingData.BackgroundColorDeg = jsonContent.BackgroundColorDeg;
            EndGameView2Page.formatingData.BackgroundColorColor1 = jsonContent.BackgroundColorColor1;
            EndGameView2Page.formatingData.BackgroundColorPercent1 = jsonContent.BackgroundColorPercent1;
            EndGameView2Page.formatingData.BackgroundColorColor2 = jsonContent.BackgroundColorColor2;
            EndGameView2Page.formatingData.BackgroundColorPercent2 = jsonContent.BackgroundColorPercent2;
            EndGameView2Page.formatingData.TopBarBackgroundColor = jsonContent.TopBarBackgroundColor;
            EndGameView2Page.formatingData.TopBarBackgroundColorDeg = jsonContent.TopBarBackgroundColorDeg;
            EndGameView2Page.formatingData.TopBarBackgroundColorColor1 = jsonContent.TopBarBackgroundColorColor1;
            EndGameView2Page.formatingData.TopBarBackgroundColorPercent1 = jsonContent.TopBarBackgroundColorPercent1;
            EndGameView2Page.formatingData.TopBarBackgroundColorColor2 = jsonContent.TopBarBackgroundColorColor2;
            EndGameView2Page.formatingData.TopBarBackgroundColorPercent2 = jsonContent.TopBarBackgroundColorPercent2;
            EndGameView2Page.formatingData.TopBarGradiant = jsonContent.TopBarGradiant;
            EndGameView2Page.formatingData.TopBarBorderColor = jsonContent.TopBarBorderColor;
            EndGameView2Page.formatingData.TopBarTimerText = jsonContent.TopBarTimerText;
            EndGameView2Page.formatingData.TopBarTimerTextColor = jsonContent.TopBarTimerTextColor;
            EndGameView2Page.formatingData.TopBarTimerColor = jsonContent.TopBarTimerColor;
            EndGameView2Page.formatingData.TopBarBlueTeamName = jsonContent.TopBarBlueTeamName;
            EndGameView2Page.formatingData.TopBarBlueTeamScore = jsonContent.TopBarBlueTeamScore;
            EndGameView2Page.formatingData.TopBarBlueTeamNameColor = jsonContent.TopBarBlueTeamNameColor;
            EndGameView2Page.formatingData.TopBarBlueTeamScoreColor = jsonContent.TopBarBlueTeamScoreColor;
            EndGameView2Page.formatingData.TopBarBlueTeamWinLossColor = jsonContent.TopBarBlueTeamWinLossColor;
            EndGameView2Page.formatingData.TopBarRedTeamName = jsonContent.TopBarRedTeamName;
            EndGameView2Page.formatingData.TopBarRedTeamScore = jsonContent.TopBarRedTeamScore;
            EndGameView2Page.formatingData.TopBarRedTeamNameColor = jsonContent.TopBarRedTeamNameColor;
            EndGameView2Page.formatingData.TopBarRedTeamScoreColor = jsonContent.TopBarRedTeamScoreColor;
            EndGameView2Page.formatingData.TopBarRedTeamWinLossColor = jsonContent.TopBarRedTeamWinLossColor;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColor = jsonContent.ChampionInfoBackgroundColor;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg = jsonContent.ChampionInfoBackgroundColorDeg;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1 = jsonContent.ChampionInfoBackgroundColorColor1;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1 = jsonContent.ChampionInfoBackgroundColorPercent1;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2 = jsonContent.ChampionInfoBackgroundColorColor2;
            EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2 = jsonContent.ChampionInfoBackgroundColorPercent2;
            EndGameView2Page.formatingData.ChampionInfoGradiant = jsonContent.ChampionInfoGradiant;
            EndGameView2Page.formatingData.ChampionInfoBorderColor = jsonContent.ChampionInfoBorderColor;
            EndGameView2Page.formatingData.ChampionInfoText = jsonContent.ChampionInfoText;
            EndGameView2Page.formatingData.ChampionInfoTextColor = jsonContent.ChampionInfoTextColor;
            EndGameView2Page.formatingData.ChampionInfoBlueBarColor = jsonContent.ChampionInfoBlueBarColor;
            EndGameView2Page.formatingData.ChampionInfoRedBarColor = jsonContent.ChampionInfoRedBarColor;
            EndGameView2Page.formatingData.ChampionInfoBlueDegaTextColor = jsonContent.ChampionInfoBlueDegaTextColor;
            EndGameView2Page.formatingData.ChampionInfoRedDegaTextColor = jsonContent.ChampionInfoRedDegaTextColor;
            EndGameView2Page.formatingData.BansBackgroundColor = jsonContent.BansBackgroundColor;
            EndGameView2Page.formatingData.BansBackgroundColorDeg = jsonContent.BansBackgroundColorDeg;
            EndGameView2Page.formatingData.BansBackgroundColorColor1 = jsonContent.BansBackgroundColorColor1;
            EndGameView2Page.formatingData.BansBackgroundColorPercent1 = jsonContent.BansBackgroundColorPercent1;
            EndGameView2Page.formatingData.BansBackgroundColorColor2 = jsonContent.BansBackgroundColorColor2;
            EndGameView2Page.formatingData.BansBackgroundColorPercent2 = jsonContent.BansBackgroundColorPercent2;
            EndGameView2Page.formatingData.BansGradiant = jsonContent.BansGradiant;
            EndGameView2Page.formatingData.BansBorderColor = jsonContent.BansBorderColor;
            EndGameView2Page.formatingData.BansTextColor = jsonContent.BansTextColor;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColor = jsonContent.GlobalStatsBackgroundColor;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg = jsonContent.GlobalStatsBackgroundColorDeg;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1 = jsonContent.GlobalStatsBackgroundColorColor1;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1 = jsonContent.GlobalStatsBackgroundColorPercent1;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2 = jsonContent.GlobalStatsBackgroundColorColor2;
            EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2 = jsonContent.GlobalStatsBackgroundColorPercent2;
            EndGameView2Page.formatingData.GlobalStatsGradiant = jsonContent.GlobalStatsGradiant;
            EndGameView2Page.formatingData.GlobalStatsBorderColor = jsonContent.GlobalStatsBorderColor;
            EndGameView2Page.formatingData.GlobalStatsTextColor = jsonContent.GlobalStatsTextColor;
            EndGameView2Page.formatingData.GlobalStatsBlueTextColor = jsonContent.GlobalStatsBlueTextColor;
            EndGameView2Page.formatingData.GlobalStatsRedTextColor = jsonContent.GlobalStatsRedTextColor;
            EndGameView2Page.formatingData.GoldDiffBackgroundColor = jsonContent.GoldDiffBackgroundColor;
            EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg = jsonContent.GoldDiffBackgroundColorDeg;
            EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1 = jsonContent.GoldDiffBackgroundColorColor1;
            EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1 = jsonContent.GoldDiffBackgroundColorPercent1;
            EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2 = jsonContent.GoldDiffBackgroundColorColor2;
            EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2 = jsonContent.GoldDiffBackgroundColorPercent2;
            EndGameView2Page.formatingData.GoldDiffGradiant = jsonContent.GoldDiffGradiant;
            EndGameView2Page.formatingData.GoldDiffBorderColor = jsonContent.GoldDiffBorderColor;
            EndGameView2Page.formatingData.GoldDiffText = jsonContent.GoldDiffText;
            EndGameView2Page.formatingData.GoldDiffTextColor = jsonContent.GoldDiffTextColor;
            EndGameView2Page.formatingData.GoldDiffBlueTextGoldColor = jsonContent.GoldDiffBlueTextGoldColor;
            EndGameView2Page.formatingData.GoldDiffRedTextGoldColor = jsonContent.GoldDiffRedTextGoldColor;
            EndGameView2Page.formatingData.GoldDiffZeroTextGoldColor = jsonContent.GoldDiffZeroTextGoldColor;
            EndGameView2Page.formatingData.GoldDiffBluePointGoldColor = jsonContent.GoldDiffBluePointGoldColor;
            EndGameView2Page.formatingData.GoldDiffRedPointGoldColor = jsonContent.GoldDiffRedPointGoldColor;
            EndGameView2Page.formatingData.GoldDiffZeroPointGoldColor = jsonContent.GoldDiffZeroPointGoldColor;
            EndGameView2Page.formatingData.GoldDiffStartEndPointGoldColor = jsonContent.GoldDiffStartEndPointGoldColor;
            EndGameView2Page.formatingData.GoldDiffLinkPointGoldColor = jsonContent.GoldDiffLinkPointGoldColor;
            EndGameView2Page.formatingData.GoldDiffBarColor = jsonContent.GoldDiffBarColor;
            EndGameView2Page.formatingData.WinText = jsonContent.WinText;
            EndGameView2Page.formatingData.LoseText = jsonContent.LoseText;
            EndGameView2Page.formatingData.ASSISTS = jsonContent.ASSISTS;
            EndGameView2Page.formatingData.BARRACKS_KILLED = jsonContent.BARRACKS_KILLED;
            EndGameView2Page.formatingData.CHAMPIONS_KILLED = jsonContent.CHAMPIONS_KILLED;
            EndGameView2Page.formatingData.GOLD_EARNED = jsonContent.GOLD_EARNED;
            EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = jsonContent.LARGEST_CRITICAL_STRIKE;
            EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = jsonContent.LARGEST_KILLING_SPREE;
            EndGameView2Page.formatingData.LARGEST_MULTI_KILL = jsonContent.LARGEST_MULTI_KILL;
            EndGameView2Page.formatingData.LEVEL = jsonContent.LEVEL;
            EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = jsonContent.MAGIC_DAMAGE_DEALT_PLAYER;
            EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = jsonContent.MAGIC_DAMAGE_TAKEN;
            EndGameView2Page.formatingData.MINIONS_KILLED = jsonContent.MINIONS_KILLED;
            EndGameView2Page.formatingData.NUM_DEATHS = jsonContent.NUM_DEATHS;
            EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = jsonContent.PHYSICAL_DAMAGE_DEALT_PLAYER;
            EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = jsonContent.PHYSICAL_DAMAGE_TAKEN;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = jsonContent.TOTAL_DAMAGE_DEALT;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = jsonContent.TOTAL_DAMAGE_DEALT_TO_BUILDINGS;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = jsonContent.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = jsonContent.TOTAL_DAMAGE_DEALT_TO_TURRETS;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = jsonContent.TOTAL_DAMAGE_SELF_MITIGATED;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = jsonContent.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES;
            EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = jsonContent.TOTAL_DAMAGE_TAKEN;
            EndGameView2Page.formatingData.TOTAL_HEAL = jsonContent.TOTAL_HEAL;
            EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = jsonContent.TOTAL_HEAL_ON_TEAMMATES;
            EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = jsonContent.TOTAL_TIME_CROWD_CONTROL_DEALT;
            EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = jsonContent.TRUE_DAMAGE_DEALT_PLAYER;
            EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TRUE_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = jsonContent.TRUE_DAMAGE_TAKEN;
            EndGameView2Page.formatingData.TURRETS_KILLED = jsonContent.TURRETS_KILLED;
            EndGameView2Page.formatingData.VISION_SCORE = jsonContent.VISION_SCORE;
            EndGameView2Page.formatingData.WARD_KILLED = jsonContent.WARD_KILLED;
            EndGameView2Page.formatingData.WARD_PLACED = jsonContent.WARD_PLACED;
            EndGameView2Page.formatingData.TextAssist = jsonContent.TextAssist;
            EndGameView2Page.formatingData.TextBarracksKilled = jsonContent.TextBarracksKilled;
            EndGameView2Page.formatingData.TextChampionsKilled = jsonContent.TextChampionsKilled;
            EndGameView2Page.formatingData.TextGoldEarned = jsonContent.TextGoldEarned;
            EndGameView2Page.formatingData.TextLargestCriticalStrike = jsonContent.TextLargestCriticalStrike;
            EndGameView2Page.formatingData.TextLargestKillingSpree = jsonContent.TextLargestKillingSpree;
            EndGameView2Page.formatingData.TextLargestMultiKill = jsonContent.TextLargestMultiKill;
            EndGameView2Page.formatingData.TextLevel = jsonContent.TextLevel;
            EndGameView2Page.formatingData.TextMagicDamageDealtPlayer = jsonContent.TextMagicDamageDealtPlayer;
            EndGameView2Page.formatingData.TextMagicDamageDealtToChampions = jsonContent.TextMagicDamageDealtToChampions;
            EndGameView2Page.formatingData.TextMagicDamageTaken = jsonContent.TextMagicDamageTaken;
            EndGameView2Page.formatingData.TextMinionsKilled = jsonContent.TextMinionsKilled;
            EndGameView2Page.formatingData.TextNumDeaths = jsonContent.TextNumDeaths;
            EndGameView2Page.formatingData.TextPhysicalDamageDealtPlayer = jsonContent.TextPhysicalDamageDealtPlayer;
            EndGameView2Page.formatingData.TextPhysicalDamageDealtToChampions = jsonContent.TextPhysicalDamageDealtToChampions;
            EndGameView2Page.formatingData.TextPhysicalDamageTaken = jsonContent.TextPhysicalDamageTaken;
            EndGameView2Page.formatingData.TextTotalDamageDealt = jsonContent.TextTotalDamageDealt;
            EndGameView2Page.formatingData.TextTotalDamageDealtToBuildings = jsonContent.TextTotalDamageDealtToBuildings;
            EndGameView2Page.formatingData.TextTotalDamageDealtToChampions = jsonContent.TextTotalDamageDealtToChampions;
            EndGameView2Page.formatingData.TextTotalDamageDealtToObjectives = jsonContent.TextTotalDamageDealtToObjectives;
            EndGameView2Page.formatingData.TextTotalDamageDealtToTurrets = jsonContent.TextTotalDamageDealtToTurrets;
            EndGameView2Page.formatingData.TextTotalDamageSelfMitigated = jsonContent.TextTotalDamageSelfMitigated;
            EndGameView2Page.formatingData.TextTotalDamageShieldedOnTeammates = jsonContent.TextTotalDamageShieldedOnTeammates;
            EndGameView2Page.formatingData.TextTotalDamageTaken = jsonContent.TextTotalDamageTaken;
            EndGameView2Page.formatingData.TextTotalHeal = jsonContent.TextTotalHeal;
            EndGameView2Page.formatingData.TextTotalHealOnTeammates = jsonContent.TextTotalHealOnTeammates;
            EndGameView2Page.formatingData.TextTotalTimeCrowdControlDealt = jsonContent.TextTotalTimeCrowdControlDealt;
            EndGameView2Page.formatingData.TextTrueDamageDealtPlayer = jsonContent.TextTrueDamageDealtPlayer;
            EndGameView2Page.formatingData.TextTrueDamageDealtToChampions = jsonContent.TextTrueDamageDealtToChampions;
            EndGameView2Page.formatingData.TextTrueDamageTaken = jsonContent.TextTrueDamageTaken;
            EndGameView2Page.formatingData.TextTurretsKilled = jsonContent.TextTurretsKilled;
            EndGameView2Page.formatingData.TextVisionScore = jsonContent.TextVisionScore;
            EndGameView2Page.formatingData.TextWardKilled = jsonContent.TextWardKilled;
            EndGameView2Page.formatingData.TextWardPlaced = jsonContent.TextWardPlaced;
        }
    }
}
