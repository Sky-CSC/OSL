using OSL_Server.Configuration;
using OSL_Server.DataReciveClient.Processing.EndGame;
using static OSL_Server.DataReciveClient.Processing.EndGame.EndGameInfo;

namespace OSL_Server.Pages.EndGame
{
    public partial class EndGameView1Page
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

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
            public string TopBarBlueTeamNameColor { get; set; }
            public string TopBarRedTeamName { get; set; }
            public string TopBarRedTeamNameColor { get; set; }

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

        }

        public string GetTimer()
        {
            try
            {
                int gameLength = EndGameInfo.jsonContentMatch.info.gameDuration;
                TimeSpan time = TimeSpan.FromSeconds(gameLength);
                return time.ToString("mm':'ss");
            }
            catch
            {
                return "00:00";
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
            foreach (var teams in EndGameInfo.jsonContentEndOfMatch.teams)
            {
                foreach (var players in teams.players)
                {
                    if (Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS) > max)
                    {
                        max = Convert.ToInt32(players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS);
                    }
                }
            }
            double calculPourcent2 = (total * 220) / max;
            return $"{calculPourcent2}px";
        }

        public string GetKDABlue()
        {
            string kill = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.CHAMPIONS_KILLED;
            string death = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.NUM_DEATHS;
            string assist = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.ASSISTS;
            return $"{kill}/{death}/{assist}";
        }
        public string GetKDARed()
        {
            string kill = EndGameInfo.jsonContentEndOfMatch.teams[1].stats.CHAMPIONS_KILLED;
            string death = EndGameInfo.jsonContentEndOfMatch.teams[1].stats.NUM_DEATHS;
            string assist = EndGameInfo.jsonContentEndOfMatch.teams[1].stats.ASSISTS;
            return $"{kill}/{death}/{assist}";
        }

        public string GetGoldBlue()
        {
            float gold = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.GOLD_EARNED;
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
            float gold = EndGameInfo.jsonContentEndOfMatch.teams[1].stats.GOLD_EARNED;
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
            int tower = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.TURRETS_KILLED;
            return $"{tower}";
        }

        public string GetTowerKillRed()
        {
            int tower = EndGameInfo.jsonContentEndOfMatch.teams[1].stats.TURRETS_KILLED;
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
            if (monsterSubType != null && monsterSubType.Equals("MONTAIN_DRAGON"))
            {
                return $"./assets/endgame/dragon/mountain_dragon_icon.png";
            }
            //int tower = EndGameInfo.jsonContentEndOfMatch.teams[0].stats.TURRETS_KILLED;
            return $"";
        }

        public string GetElderKillBlue()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetElderKillRed()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetHeraldKillBlue()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetHeraldKillRed()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetBaronKillBlue()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetBaronKillRed()
        {
            int nbElderKill = 0;
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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
                                nbElderKill++;
                            }
                        }
                    }
                }
            }
            return $"{nbElderKill}";
        }

        public string GetWinLossBlue()
        {
            foreach (var participants in jsonContentMatch.info.participants)
            {
                int teamId = participants.teamId;
                if (teamId == 100)
                {
                    bool win = participants.win;
                    if (win)
                    {
                        return $"WIN";
                    }
                }
            }
            return $"LOSS";
        }

        public string GetWinLossRed()
        {
            foreach (var participants in jsonContentMatch.info.participants)
            {
                int teamId = participants.teamId;
                if (teamId == 200)
                {
                    bool win = participants.win;
                    if (win)
                    {
                        return $"WIN";
                    }
                }
            }
            return $"LOSS";
        }

        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigEndGameView1();
        }
    }
}
