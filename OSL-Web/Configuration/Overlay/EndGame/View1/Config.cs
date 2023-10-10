using Newtonsoft.Json;
using OSL_Common.System.DirectoryManager;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Web.Pages.EndGame;


namespace OSL_Web.Configuration.Overlay.EndGame.View1
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
                EndGameView1Page.formatingData.DefaultPatch = temps[0] + "." + temps[1];
            }
            catch (Exception e)
            {
                EndGameView1Page.formatingData.DefaultPatch = DirectoryManagerLocal.CheckExistingDirectoryPatch("./wwwroot/assets");
            }
            EndGameView1Page.formatingData.DefaultRegion = OSL_CDragon.CDragon.region;
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultPatch}");
            //_logger.log(LoggingLevel.INFO, "LoadConfigEndGameView1Page()", $"{EndGameView1Page.formatingData.DefaultRegion}");
        }

        /// <summary>
        /// Load default json file for overlay view 1
        /// </summary>
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
            EndGameView1Page.formatingData.WinText = jsonContent.WinText;
            EndGameView1Page.formatingData.LoseText = jsonContent.LoseText;
            EndGameView1Page.formatingData.ASSISTS = jsonContent.ASSISTS;
            EndGameView1Page.formatingData.BARRACKS_KILLED = jsonContent.BARRACKS_KILLED;
            EndGameView1Page.formatingData.CHAMPIONS_KILLED = jsonContent.CHAMPIONS_KILLED;
            EndGameView1Page.formatingData.GOLD_EARNED = jsonContent.GOLD_EARNED;
            EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = jsonContent.LARGEST_CRITICAL_STRIKE;
            EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = jsonContent.LARGEST_KILLING_SPREE;
            EndGameView1Page.formatingData.LARGEST_MULTI_KILL = jsonContent.LARGEST_MULTI_KILL;
            EndGameView1Page.formatingData.LEVEL = jsonContent.LEVEL;
            EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = jsonContent.MAGIC_DAMAGE_DEALT_PLAYER;
            EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = jsonContent.MAGIC_DAMAGE_TAKEN;
            EndGameView1Page.formatingData.MINIONS_KILLED = jsonContent.MINIONS_KILLED;
            EndGameView1Page.formatingData.NUM_DEATHS = jsonContent.NUM_DEATHS;
            EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = jsonContent.PHYSICAL_DAMAGE_DEALT_PLAYER;
            EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = jsonContent.PHYSICAL_DAMAGE_TAKEN;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = jsonContent.TOTAL_DAMAGE_DEALT;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = jsonContent.TOTAL_DAMAGE_DEALT_TO_BUILDINGS;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = jsonContent.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = jsonContent.TOTAL_DAMAGE_DEALT_TO_TURRETS;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = jsonContent.TOTAL_DAMAGE_SELF_MITIGATED;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = jsonContent.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES;
            EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = jsonContent.TOTAL_DAMAGE_TAKEN;
            EndGameView1Page.formatingData.TOTAL_HEAL = jsonContent.TOTAL_HEAL;
            EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = jsonContent.TOTAL_HEAL_ON_TEAMMATES;
            EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = jsonContent.TOTAL_TIME_CROWD_CONTROL_DEALT;
            EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = jsonContent.TRUE_DAMAGE_DEALT_PLAYER;
            EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = jsonContent.TRUE_DAMAGE_DEALT_TO_CHAMPIONS;
            EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = jsonContent.TRUE_DAMAGE_TAKEN;
            EndGameView1Page.formatingData.TURRETS_KILLED = jsonContent.TURRETS_KILLED;
            EndGameView1Page.formatingData.VISION_SCORE = jsonContent.VISION_SCORE;
            EndGameView1Page.formatingData.WARD_KILLED = jsonContent.WARD_KILLED;
            EndGameView1Page.formatingData.WARD_PLACED = jsonContent.WARD_PLACED;
            EndGameView1Page.formatingData.TextAssist = jsonContent.TextAssist;
            EndGameView1Page.formatingData.TextBarracksKilled = jsonContent.TextBarracksKilled;
            EndGameView1Page.formatingData.TextChampionsKilled = jsonContent.TextChampionsKilled;
            EndGameView1Page.formatingData.TextGoldEarned = jsonContent.TextGoldEarned;
            EndGameView1Page.formatingData.TextLargestCriticalStrike = jsonContent.TextLargestCriticalStrike;
            EndGameView1Page.formatingData.TextLargestKillingSpree = jsonContent.TextLargestKillingSpree;
            EndGameView1Page.formatingData.TextLargestMultiKill = jsonContent.TextLargestMultiKill;
            EndGameView1Page.formatingData.TextLevel = jsonContent.TextLevel;
            EndGameView1Page.formatingData.TextMagicDamageDealtPlayer = jsonContent.TextMagicDamageDealtPlayer;
            EndGameView1Page.formatingData.TextMagicDamageDealtToChampions = jsonContent.TextMagicDamageDealtToChampions;
            EndGameView1Page.formatingData.TextMagicDamageTaken = jsonContent.TextMagicDamageTaken;
            EndGameView1Page.formatingData.TextMinionsKilled = jsonContent.TextMinionsKilled;
            EndGameView1Page.formatingData.TextNumDeaths = jsonContent.TextNumDeaths;
            EndGameView1Page.formatingData.TextPhysicalDamageDealtPlayer = jsonContent.TextPhysicalDamageDealtPlayer;
            EndGameView1Page.formatingData.TextPhysicalDamageDealtToChampions = jsonContent.TextPhysicalDamageDealtToChampions;
            EndGameView1Page.formatingData.TextPhysicalDamageTaken = jsonContent.TextPhysicalDamageTaken;
            EndGameView1Page.formatingData.TextTotalDamageDealt = jsonContent.TextTotalDamageDealt;
            EndGameView1Page.formatingData.TextTotalDamageDealtToBuildings = jsonContent.TextTotalDamageDealtToBuildings;
            EndGameView1Page.formatingData.TextTotalDamageDealtToChampions = jsonContent.TextTotalDamageDealtToChampions;
            EndGameView1Page.formatingData.TextTotalDamageDealtToObjectives = jsonContent.TextTotalDamageDealtToObjectives;
            EndGameView1Page.formatingData.TextTotalDamageDealtToTurrets = jsonContent.TextTotalDamageDealtToTurrets;
            EndGameView1Page.formatingData.TextTotalDamageSelfMitigated = jsonContent.TextTotalDamageSelfMitigated;
            EndGameView1Page.formatingData.TextTotalDamageShieldedOnTeammates = jsonContent.TextTotalDamageShieldedOnTeammates;
            EndGameView1Page.formatingData.TextTotalDamageTaken = jsonContent.TextTotalDamageTaken;
            EndGameView1Page.formatingData.TextTotalHeal = jsonContent.TextTotalHeal;
            EndGameView1Page.formatingData.TextTotalHealOnTeammates = jsonContent.TextTotalHealOnTeammates;
            EndGameView1Page.formatingData.TextTotalTimeCrowdControlDealt = jsonContent.TextTotalTimeCrowdControlDealt;
            EndGameView1Page.formatingData.TextTrueDamageDealtPlayer = jsonContent.TextTrueDamageDealtPlayer;
            EndGameView1Page.formatingData.TextTrueDamageDealtToChampions = jsonContent.TextTrueDamageDealtToChampions;
            EndGameView1Page.formatingData.TextTrueDamageTaken = jsonContent.TextTrueDamageTaken;
            EndGameView1Page.formatingData.TextTurretsKilled = jsonContent.TextTurretsKilled;
            EndGameView1Page.formatingData.TextVisionScore = jsonContent.TextVisionScore;
            EndGameView1Page.formatingData.TextWardKilled = jsonContent.TextWardKilled;
            EndGameView1Page.formatingData.TextWardPlaced = jsonContent.TextWardPlaced;
        }
    }
}
