using OSL_Common.System.Logging;

namespace OSL_Web.Pages.EndGame
{
    public partial class EndGameView3Page
    {
        private static Logger _logger = new("EndGameView3Page");

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        public static List<int> goldDiff = new();
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }

            public string BackgroundColor { get; set; }
            public string BackgroundColorDeg { get; set; }
            public string BackgroundColorColor1 { get; set; }
            public string BackgroundColorPercent1 { get; set; }
            public string BackgroundColorColor2 { get; set; }
            public string BackgroundColorPercent2 { get; set; }

            public string TopBarBackgroundColor { get; set; }
            public string TopBarBackgroundColorDeg { get; set; }
            public string TopBarBackgroundColorColor1 { get; set; }
            public string TopBarBackgroundColorPercent1 { get; set; }
            public string TopBarBackgroundColorColor2 { get; set; }
            public string TopBarBackgroundColorPercent2 { get; set; }
            public string TopBarGradiant { get; set; }
            public string TopBarBorderColor { get; set; }
            public string TopBarTimerText { get; set; }
            public string TopBarTimerTextColor { get; set; }
            public string TopBarTimerColor { get; set; }
            public string TopBarBlueTeamName { get; set; }
            public string TopBarBlueTeamScore { get; set; }
            public string TopBarBlueTeamNameColor { get; set; }
            public string TopBarBlueTeamScoreColor { get; set; }
            public string TopBarBlueTeamWinLossColor { get; set; }
            public string TopBarRedTeamName { get; set; }
            public string TopBarRedTeamScore { get; set; }
            public string TopBarRedTeamNameColor { get; set; }
            public string TopBarRedTeamScoreColor { get; set; }
            public string TopBarRedTeamWinLossColor { get; set; }

            public string ChampionInfoBackgroundColor { get; set; }
            public string ChampionInfoBackgroundColorDeg { get; set; }
            public string ChampionInfoBackgroundColorColor1 { get; set; }
            public string ChampionInfoBackgroundColorPercent1 { get; set; }
            public string ChampionInfoBackgroundColorColor2 { get; set; }
            public string ChampionInfoBackgroundColorPercent2 { get; set; }
            public string ChampionInfoGradiant { get; set; }
            public string ChampionInfoBorderColor { get; set; }
            public string ChampionInfoText { get; set; }
            public string ChampionInfoTextColor { get; set; }
            public string ChampionInfoBlueBarColor { get; set; }
            public string ChampionInfoRedBarColor { get; set; }
            public string ChampionInfoBlueDegaTextColor { get; set; }
            public string ChampionInfoRedDegaTextColor { get; set; }

            public string BansBackgroundColor { get; set; }
            public string BansBackgroundColorDeg { get; set; }
            public string BansBackgroundColorColor1 { get; set; }
            public string BansBackgroundColorPercent1 { get; set; }
            public string BansBackgroundColorColor2 { get; set; }
            public string BansBackgroundColorPercent2 { get; set; }
            public string BansGradiant { get; set; }
            public string BansBorderColor { get; set; }
            public string BansTextColor { get; set; }

            public string GlobalStatsBackgroundColor { get; set; }
            public string GlobalStatsBackgroundColorDeg { get; set; }
            public string GlobalStatsBackgroundColorColor1 { get; set; }
            public string GlobalStatsBackgroundColorPercent1 { get; set; }
            public string GlobalStatsBackgroundColorColor2 { get; set; }
            public string GlobalStatsBackgroundColorPercent2 { get; set; }
            public string GlobalStatsGradiant { get; set; }
            public string GlobalStatsBorderColor { get; set; }
            public string GlobalStatsSeparationColor { get; set; }
            public string GlobalStatsTextColor { get; set; }
            public string GlobalStatsBlueTextColor { get; set; }
            public string GlobalStatsRedTextColor { get; set; }

            public string GoldDiffBackgroundColor { get; set; }
            public string GoldDiffBackgroundColorDeg { get; set; }
            public string GoldDiffBackgroundColorColor1 { get; set; }
            public string GoldDiffBackgroundColorPercent1 { get; set; }
            public string GoldDiffBackgroundColorColor2 { get; set; }
            public string GoldDiffBackgroundColorPercent2 { get; set; }
            public string GoldDiffGradiant { get; set; }
            public string GoldDiffBorderColor { get; set; }
            public string GoldDiffText { get; set; }
            public string GoldDiffTextColor { get; set; }
            public string GoldDiffBlueTextGoldColor { get; set; }
            public string GoldDiffRedTextGoldColor { get; set; }
            public string GoldDiffZeroTextGoldColor { get; set; }
            public string GoldDiffBluePointGoldColor { get; set; }
            public string GoldDiffRedPointGoldColor { get; set; }
            public string GoldDiffZeroPointGoldColor { get; set; }
            public string GoldDiffStartEndPointGoldColor { get; set; }
            public string GoldDiffLinkPointGoldColor { get; set; }
            public string GoldDiffBarColor { get; set; }
            public string WinText { get; set; }
            public string LoseText { get; set; }
            //For display more information Order vs Chaos
            public bool ASSISTS { get; set; }
            public string TextAssist { get; set; }
            public bool BARRACKS_KILLED { get; set; }
            public string TextBarracksKilled { get; set; }
            public bool CHAMPIONS_KILLED { get; set; }
            public string TextChampionsKilled { get; set; }
            public bool GOLD_EARNED { get; set; }
            public string TextGoldEarned { get; set; }
            public bool LARGEST_CRITICAL_STRIKE { get; set; }
            public string TextLargestCriticalStrike { get; set; }
            public bool LARGEST_KILLING_SPREE { get; set; }
            public string TextLargestKillingSpree { get; set; }
            public bool LARGEST_MULTI_KILL { get; set; }
            public string TextLargestMultiKill { get; set; }
            public bool LEVEL { get; set; }
            public string TextLevel { get; set; }
            public bool MAGIC_DAMAGE_DEALT_PLAYER { get; set; }
            public string TextMagicDamageDealtPlayer { get; set; }
            public bool MAGIC_DAMAGE_DEALT_TO_CHAMPIONS { get; set; }
            public string TextMagicDamageDealtToChampions { get; set; }
            public bool MAGIC_DAMAGE_TAKEN { get; set; }
            public string TextMagicDamageTaken { get; set; }
            public bool MINIONS_KILLED { get; set; }
            public string TextMinionsKilled { get; set; }
            public bool NUM_DEATHS { get; set; }
            public string TextNumDeaths { get; set; }
            public bool PHYSICAL_DAMAGE_DEALT_PLAYER { get; set; }
            public string TextPhysicalDamageDealtPlayer { get; set; }
            public bool PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS { get; set; }
            public string TextPhysicalDamageDealtToChampions { get; set; }
            public bool PHYSICAL_DAMAGE_TAKEN { get; set; }
            public string TextPhysicalDamageTaken { get; set; }
            public bool TOTAL_DAMAGE_DEALT { get; set; }
            public string TextTotalDamageDealt { get; set; }
            public bool TOTAL_DAMAGE_DEALT_TO_BUILDINGS { get; set; }
            public string TextTotalDamageDealtToBuildings { get; set; }
            public bool TOTAL_DAMAGE_DEALT_TO_CHAMPIONS { get; set; }
            public string TextTotalDamageDealtToChampions { get; set; }
            public bool TOTAL_DAMAGE_DEALT_TO_OBJECTIVES { get; set; }
            public string TextTotalDamageDealtToObjectives { get; set; }
            public bool TOTAL_DAMAGE_DEALT_TO_TURRETS { get; set; }
            public string TextTotalDamageDealtToTurrets { get; set; }
            public bool TOTAL_DAMAGE_SELF_MITIGATED { get; set; }
            public string TextTotalDamageSelfMitigated { get; set; }
            public bool TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES { get; set; }
            public string TextTotalDamageShieldedOnTeammates { get; set; }
            public bool TOTAL_DAMAGE_TAKEN { get; set; }
            public string TextTotalDamageTaken { get; set; }
            public bool TOTAL_HEAL { get; set; }
            public string TextTotalHeal { get; set; }
            public bool TOTAL_HEAL_ON_TEAMMATES { get; set; }
            public string TextTotalHealOnTeammates { get; set; }
            public bool TOTAL_TIME_CROWD_CONTROL_DEALT { get; set; }
            public string TextTotalTimeCrowdControlDealt { get; set; }
            public bool TRUE_DAMAGE_DEALT_PLAYER { get; set; }
            public string TextTrueDamageDealtPlayer { get; set; }
            public bool TRUE_DAMAGE_DEALT_TO_CHAMPIONS { get; set; }
            public string TextTrueDamageDealtToChampions { get; set; }
            public bool TRUE_DAMAGE_TAKEN { get; set; }
            public string TextTrueDamageTaken { get; set; }
            public bool TURRETS_KILLED { get; set; }
            public string TextTurretsKilled { get; set; }
            public bool VISION_SCORE { get; set; }
            public string TextVisionScore { get; set; }
            public bool WARD_KILLED { get; set; }
            public string TextWardKilled { get; set; }
            public bool WARD_PLACED { get; set; }
            public string TextWardPlaced { get; set; }
        }

        public string GetTimer()
        {
            try
            {
                int gameLength = DataProcessing.EndGame.jsonContentMatch.info.gameDuration;
                TimeSpan time = TimeSpan.FromSeconds(gameLength);
                return time.ToString("mm':'ss");
            }
            catch
            {
                return "00:00";
            }
        }

        public int GetTimerInt()
        {
            try
            {
                int gameLength = DataProcessing.EndGame.jsonContentMatch.info.gameDuration;
                TimeSpan time = TimeSpan.FromSeconds(gameLength);
                int timeLength = int.Parse(time.ToString("mm"));
                return timeLength;
            }
            catch
            {
                return 0;
            }
        }

        public string GetChampionPathByPath(string championId)
        {
            string[] parsePath = championId.Split("/");
            string[] parseId = parsePath[parsePath.Length - 1].Split(".");
            return GetChampionPath(parseId[0]);
        }

        public string GetChampionPath(string championId)
        {
            return $"./assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{championId}/default-square.png";
        }

        public string ConvertToK(double total)
        {
            if (total > 1000000)
            {
                return $"{Math.Round(total / 1000000, 1)} M";
            }
            else if (total > 1000)
            {
                return $"{Math.Round(total / 1000, 1)}k";
            }
            else
            {
                return $"{total}";
            }
        }

        public string ConvertToWidth(int total)
        {
            int max = 0;
            foreach (var teams in DataProcessing.EndGame.jsonContentEndOfMatch.teams)
            {
                foreach (var players in teams.players)
                {
                    if (formatingData.ASSISTS)
                    {
                        if (Convert.ToInt32(players.stats.ASSISTS) > max)
                        {
                            max = Convert.ToInt32(players.stats.ASSISTS);
                        }
                    }
                    else if (formatingData.BARRACKS_KILLED)
                    {
                        if (Convert.ToInt32(players.stats.BARRACKS_KILLED) > max)
                        {
                            max = Convert.ToInt32(players.stats.BARRACKS_KILLED);
                        }
                    }
                    else if (formatingData.CHAMPIONS_KILLED)
                    {
                        if (Convert.ToInt32(players.stats.CHAMPIONS_KILLED) > max)
                        {
                            max = Convert.ToInt32(players.stats.CHAMPIONS_KILLED);
                        }
                    }
                    else if (formatingData.GOLD_EARNED)
                    {
                        if (Convert.ToInt32(players.stats.GOLD_EARNED) > max)
                        {
                            max = Convert.ToInt32(players.stats.GOLD_EARNED);
                        }
                    }
                    else if (formatingData.LARGEST_CRITICAL_STRIKE)
                    {
                        if (Convert.ToInt32(players.stats.LARGEST_CRITICAL_STRIKE) > max)
                        {
                            max = Convert.ToInt32(players.stats.LARGEST_CRITICAL_STRIKE);
                        }
                    }
                    else if (formatingData.LARGEST_KILLING_SPREE)
                    {
                        if (Convert.ToInt32(players.stats.LARGEST_KILLING_SPREE) > max)
                        {
                            max = Convert.ToInt32(players.stats.LARGEST_KILLING_SPREE);
                        }
                    }
                    else if (formatingData.LARGEST_MULTI_KILL)
                    {
                        if (Convert.ToInt32(players.stats.LARGEST_MULTI_KILL) > max)
                        {
                            max = Convert.ToInt32(players.stats.LARGEST_MULTI_KILL);
                        }
                    }
                    else if (formatingData.LEVEL)
                    {
                        if (Convert.ToInt32(players.stats.LEVEL) > max)
                        {
                            max = Convert.ToInt32(players.stats.LEVEL);
                        }
                    }
                    else if (formatingData.MAGIC_DAMAGE_DEALT_PLAYER)
                    {
                        if (Convert.ToInt32(players.stats.MAGIC_DAMAGE_DEALT_PLAYER) > max)
                        {
                            max = Convert.ToInt32(players.stats.MAGIC_DAMAGE_DEALT_PLAYER);
                        }
                    }
                    else if (formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS)
                    {
                        if (Convert.ToInt32(players.stats.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS) > max)
                        {
                            max = Convert.ToInt32(players.stats.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS);
                        }
                    }
                    else if (formatingData.MAGIC_DAMAGE_TAKEN)
                    {
                        if (Convert.ToInt32(players.stats.MAGIC_DAMAGE_TAKEN) > max)
                        {
                            max = Convert.ToInt32(players.stats.MAGIC_DAMAGE_TAKEN);
                        }
                    }
                    else if (formatingData.MINIONS_KILLED)
                    {
                        if (Convert.ToInt32(players.stats.MINIONS_KILLED) > max)
                        {
                            max = Convert.ToInt32(players.stats.MINIONS_KILLED);
                        }
                    }
                    else if (formatingData.NUM_DEATHS)
                    {
                        if (Convert.ToInt32(players.stats.NUM_DEATHS) > max)
                        {
                            max = Convert.ToInt32(players.stats.NUM_DEATHS);
                        }
                    }
                    else if (formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER)
                    {
                        if (Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_DEALT_PLAYER) > max)
                        {
                            max = Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_DEALT_PLAYER);
                        }
                    }
                    else if (formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS)
                    {
                        if (Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS) > max)
                        {
                            max = Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS);
                        }
                    }
                    else if (formatingData.PHYSICAL_DAMAGE_TAKEN)
                    {
                        if (Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_TAKEN) > max)
                        {
                            max = Convert.ToInt32(players.stats.PHYSICAL_DAMAGE_TAKEN);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_DEALT)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_BUILDINGS) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_BUILDINGS);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_TURRETS) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_TURRETS);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_SELF_MITIGATED)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_SELF_MITIGATED) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_SELF_MITIGATED);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES);
                        }
                    }
                    else if (formatingData.TOTAL_DAMAGE_TAKEN)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_TAKEN) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_TAKEN);
                        }
                    }
                    else if (formatingData.TOTAL_HEAL)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_HEAL) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_HEAL);
                        }
                    }
                    else if (formatingData.TOTAL_HEAL_ON_TEAMMATES)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_HEAL_ON_TEAMMATES) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_HEAL_ON_TEAMMATES);
                        }
                    }
                    else if (formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT)
                    {
                        if (Convert.ToInt32(players.stats.TOTAL_TIME_CROWD_CONTROL_DEALT) > max)
                        {
                            max = Convert.ToInt32(players.stats.TOTAL_TIME_CROWD_CONTROL_DEALT);
                        }
                    }
                    else if (formatingData.TRUE_DAMAGE_DEALT_PLAYER)
                    {
                        if (Convert.ToInt32(players.stats.TRUE_DAMAGE_DEALT_PLAYER) > max)
                        {
                            max = Convert.ToInt32(players.stats.TRUE_DAMAGE_DEALT_PLAYER);
                        }
                    }
                    else if (formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS)
                    {
                        if (Convert.ToInt32(players.stats.TRUE_DAMAGE_DEALT_TO_CHAMPIONS) > max)
                        {
                            max = Convert.ToInt32(players.stats.TRUE_DAMAGE_DEALT_TO_CHAMPIONS);
                        }
                    }
                    else if (formatingData.TRUE_DAMAGE_TAKEN)
                    {
                        if (Convert.ToInt32(players.stats.TRUE_DAMAGE_TAKEN) > max)
                        {
                            max = Convert.ToInt32(players.stats.TRUE_DAMAGE_TAKEN);
                        }
                    }
                    else if (formatingData.TURRETS_KILLED)
                    {
                        if (Convert.ToInt32(players.stats.TURRETS_KILLED) > max)
                        {
                            max = Convert.ToInt32(players.stats.TURRETS_KILLED);
                        }
                    }
                    else if (formatingData.VISION_SCORE)
                    {
                        if (Convert.ToInt32(players.stats.VISION_SCORE) > max)
                        {
                            max = Convert.ToInt32(players.stats.VISION_SCORE);
                        }
                    }
                    else if (formatingData.WARD_KILLED)
                    {
                        if (Convert.ToInt32(players.stats.WARD_KILLED) > max)
                        {
                            max = Convert.ToInt32(players.stats.WARD_KILLED);
                        }
                    }
                    else if (formatingData.WARD_PLACED)
                    {
                        if (Convert.ToInt32(players.stats.WARD_PLACED) > max)
                        {
                            max = Convert.ToInt32(players.stats.WARD_PLACED);
                        }
                    }
                }
            }
            double calculPourcent2 = (total * 360) / max;
            return $"{calculPourcent2}px";
        }

        public string GetKDABlue()
        {
            string kill = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.CHAMPIONS_KILLED;
            string death = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.NUM_DEATHS;
            string assist = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.ASSISTS;
            return $"{kill}/{death}/{assist}";
        }
        public string GetKDARed()
        {
            string kill = DataProcessing.EndGame.jsonContentEndOfMatch.teams[1].stats.CHAMPIONS_KILLED;
            string death = DataProcessing.EndGame.jsonContentEndOfMatch.teams[1].stats.NUM_DEATHS;
            string assist = DataProcessing.EndGame.jsonContentEndOfMatch.teams[1].stats.ASSISTS;
            return $"{kill}/{death}/{assist}";
        }

        public string GetGoldBlue()
        {
            float gold = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.GOLD_EARNED;
            if (gold > 1000000)
            {
                return $"{Math.Round(gold / 1000000, 1)} M";
            }
            else if (gold > 1000)
            {
                return $"{Math.Round(gold / 1000, 1)} k";
            }
            else
            {
                return $"{gold}";
            }
        }
        public string GetGoldRed()
        {
            float gold = DataProcessing.EndGame.jsonContentEndOfMatch.teams[1].stats.GOLD_EARNED;
            if (gold > 1000000)
            {
                return $"{Math.Round(gold / 1000000, 1)} M";
            }
            else if (gold > 1000)
            {
                return $"{Math.Round(gold / 1000, 1)} k";
            }
            else
            {
                return $"{gold}";
            }
        }

        public string GetTowerKillBlue()
        {
            int tower = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.TURRETS_KILLED;
            return $"{tower}";
        }

        public string GetTowerKillRed()
        {
            int tower = DataProcessing.EndGame.jsonContentEndOfMatch.teams[1].stats.TURRETS_KILLED;
            return $"{tower}";
        }

        public string GetDragonsKill(string monsterSubType)
        {
            if (monsterSubType != null && monsterSubType.Equals("HEXTECH_DRAGON"))
            {
                return $"./assets/endgame/dragon/hextech_dragon_icon.png";
            }
            if (monsterSubType != null && monsterSubType.Equals("WATER_DRAGON"))
            {
                return $"./assets/endgame/dragon/ocean_dragon_icon.png";
            }
            if (monsterSubType != null && monsterSubType.Equals("FIRE_DRAGON"))
            {
                return $"./assets/endgame/dragon/infernal_dragon_icon.png";
            }
            if (monsterSubType != null && monsterSubType.Equals("AIR_DRAGON"))
            {
                return $"./assets/endgame/dragon/cloud_dragon_icon.png";
            }
            if (monsterSubType != null && monsterSubType.Equals("CHEMTECH_DRAGON"))
            {
                return $"./assets/endgame/dragon/chemtech_dragon_icon.png";
            }
            if (monsterSubType != null && monsterSubType.Equals("EARTH_DRAGON"))
            {
                return $"./assets/endgame/dragon/mountain_dragon_icon.png";
            }
            //int tower = DataProcessing.EndGame.jsonContentEndOfMatch.teams[0].stats.TURRETS_KILLED;
            return $"";
        }

        public string GetElderKillBlue()
        {
            int nbElderKillBlue = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterSubType = events.monsterSubType;
                    if (monsterSubType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 100)
                        {
                            if (monsterSubType.Equals("ELDER_DRAGON"))
                            {
                                nbElderKillBlue++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKillBlue}";
        }

        public string GetElderKillRed()
        {
            int nbElderKillRed = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterSubType = events.monsterSubType;
                    if (monsterSubType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 200)
                        {
                            if (monsterSubType.Equals("ELDER_DRAGON"))
                            {
                                nbElderKillRed++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKillRed}";
        }

        public string GetHeraldKillBlue()
        {
            int nbHeraldKillBlue = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterType = events.monsterType;
                    if (monsterType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 100)
                        {
                            if (monsterType != null && monsterType.Equals("RIFTHERALD"))
                            {
                                nbHeraldKillBlue++;
                            }
                        }
                    }
                }
            }
            return $"{nbHeraldKillBlue}";
        }

        public string GetHeraldKillRed()
        {
            int nbHeraldKillRed = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterType = events.monsterType;
                    if (monsterType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 200)
                        {
                            if (monsterType != null && monsterType.Equals("RIFTHERALD"))
                            {
                                nbHeraldKillRed++;
                            }
                        }
                    }
                }
            }
            return $"{nbHeraldKillRed}";
        }

        public string GetBaronKillBlue()
        {
            int nbBaronKillBlue = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterType = events.monsterType;
                    if (monsterType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 100)
                        {
                            if (monsterType != null && monsterType.Equals("BARON_NASHOR"))
                            {
                                nbBaronKillBlue++;
                            }
                        }
                    }
                }
            }
            return $"{nbBaronKillBlue}";
        }

        public string GetBaronKillRed()
        {
            int nbBaronKillRed = 0;
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                foreach (var events in frames.events)
                {
                    string monsterType = events.monsterType;
                    if (monsterType != null)
                    {
                        int killerTeamId = events.killerTeamId;
                        if (killerTeamId == 200)
                        {
                            if (monsterType != null && monsterType.Equals("BARON_NASHOR"))
                            {
                                nbBaronKillRed++;
                            }
                        }
                    }
                }
            }
            return $"{nbBaronKillRed}";
        }

        public string GetWinLossBlue()
        {
            foreach (var participants in DataProcessing.EndGame.jsonContentMatch.info.participants)
            {
                int teamId = participants.teamId;
                if (teamId == 100)
                {
                    bool win = participants.win;
                    if (win)
                    {
                        return formatingData.WinText;
                    }
                }
            }
            return formatingData.LoseText;
        }

        public string GetWinLossRed()
        {
            foreach (var participants in DataProcessing.EndGame.jsonContentMatch.info.participants)
            {
                int teamId = participants.teamId;
                if (teamId == 200)
                {
                    bool win = participants.win;
                    if (win)
                    {
                        return formatingData.WinText;
                    }
                }
            }
            return formatingData.LoseText;
        }

        public static void ResetColor()
        {
            Configuration.Overlay.EndGame.View3.Config.LoadFormatingDataConfig();
            EndGamePage.textValueOverlayView3.TopBarBlueTeamName = "";
            EndGamePage.textValueOverlayView3.TopBarRedTeamName = "";
            EndGamePage.textValueOverlayView3.TopBarBlueTeamScore = "";
            EndGamePage.textValueOverlayView3.TopBarRedTeamScore = "";
            EndGamePage.textValueOverlayView3.TopBarTimerText = "";
            EndGamePage.textValueOverlayView3.ChampionInfoText = "";
            EndGamePage.textValueOverlayView3.GoldDiffText = "";
            EndGamePage.textValueOverlayView3.BackgroundColor = true;
            EndGamePage.textValueOverlayView3.TopBarGradiant = false;
            EndGamePage.textValueOverlayView3.ChampionInfoGradiant = false;
            EndGamePage.textValueOverlayView3.BansGradiant = false;
            EndGamePage.textValueOverlayView3.GlobalStatsGradiant = false;
            EndGamePage.textValueOverlayView3.GoldDiffGradiant = false;
            EndGamePage.textValueOverlayView3.TopBarBackground = false;
            EndGamePage.textValueOverlayView3.ChampionInfoBackground = false;
            EndGamePage.textValueOverlayView3.BansBackground = false;
            EndGamePage.textValueOverlayView3.GlobalStatsBackground = false;
            EndGamePage.textValueOverlayView3.GoldDiffBackground = false;
            EndGamePage.textValueOverlayView3.BackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.BackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.BackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.TopBarBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.TopBarBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.TopBarBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.ChampionInfoBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.ChampionInfoBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.ChampionInfoBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.BansBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.BansBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.BansBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.GlobalStatsBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.GlobalStatsBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.GlobalStatsBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.GoldDiffBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView3.GoldDiffBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView3.GoldDiffBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView3.TopBarBorderColor = 5;
            EndGamePage.textValueOverlayView3.ChampionInfoBorderColor = 5;
            EndGamePage.textValueOverlayView3.BansBorderColor = 5;
            EndGamePage.textValueOverlayView3.GlobalStatsBorderColor = 5;
            EndGamePage.textValueOverlayView3.GoldDiffBorderColor = 5;
            EndGamePage.textValueOverlayView3.ValueStats = "TOTAL_DAMAGE_DEALT_TO_CHAMPIONS";

        }

        public static void CreateTabGold()
        {
            goldDiff = new();
            foreach (var frames in DataProcessing.EndGame.jsonContentTimeline.info.frames)
            {
                int totalGoldBlue = 0;
                int totalGoldRed = 0;
                int i = 0;
                foreach (var participantFrames in frames.participantFrames)
                {
                    i++;
                    if (i < 6)
                    {
                        foreach (var intVar in participantFrames)
                        {
                            totalGoldBlue += Convert.ToInt32(intVar.totalGold);
                        }
                    }
                    else
                    {
                        foreach (var intVar in participantFrames)
                        {
                            totalGoldRed += Convert.ToInt32(intVar.totalGold);
                        }
                    }
                }
                int diffGold = totalGoldBlue - totalGoldRed;
                goldDiff.Add(diffGold);
            }
        }
        public static int MaxGold()
        {
            int max = goldDiff.Max();
            int min = goldDiff.Min();
            if (max > Math.Abs(min))
            {
                return max;
            }
            else
            {
                return Math.Abs(min);
            }
        }


        public static string ConvertToString(int x)
        {
            return $"{x}px";
        }

        public static string ConvertToString(double x)
        {
            return $"{x}px";
        }

        public static string ConvertToHyp(double x, double y, double prex, double prey)
        {
            double newY = y - prey;
            double newX = x - prex;
            double sqrt = Math.Sqrt(newX * newX + newY * newY);
            string machin = sqrt.ToString();
            return machin.Replace(",", ".");
        }

        public static string ConvertToAngle(double x, double y, double prex, double prey)
        {
            double newY = y - prey;
            double newX = x - prex;
            double sqrt = Math.Sqrt(newX * newX + newY * newY);
            double sin = newY / sqrt;
            double test = Math.Asin(sin) * (180 / Math.PI);
            string machin = test.ToString();
            return machin.Replace(",", ".");
        }
    }
}
