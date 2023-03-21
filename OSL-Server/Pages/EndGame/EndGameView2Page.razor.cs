﻿using OSL_Server.Configuration;
using OSL_Server.DataReciveClient.Processing.EndGame;
using static OSL_Server.DataReciveClient.Processing.EndGame.EndGameInfo;
using static OSL_Server.Pages.EndGameTestPage;

namespace OSL_Server.Pages.EndGame
{
    public partial class EndGameView2Page
    {
        private static OSLLogger _logger = new OSLLogger("EndGameView2Page");

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

        public int GetTimerInt()
        {
            try
            {
                int gameLength = EndGameInfo.jsonContentMatch.info.gameDuration;
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
            double calculPourcent2 = (total * 320) / max;
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
                        return $"VICTOIRE";
                    }
                }
            }
            return $"DÉFAITE";
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
                        return $"VICTOIRE";
                    }
                }
            }
            return $"DÉFAITE";
        }

        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigEndGameView2();
            EndGamePage.textValueOverlayView2.TopBarBlueTeamName = "";
            EndGamePage.textValueOverlayView2.TopBarRedTeamName = "";
            EndGamePage.textValueOverlayView2.TopBarBlueTeamScore = "";
            EndGamePage.textValueOverlayView2.TopBarRedTeamScore = "";
            EndGamePage.textValueOverlayView2.TopBarTimerText = "";
            EndGamePage.textValueOverlayView2.ChampionInfoText = "";
            EndGamePage.textValueOverlayView2.GoldDiffText = "";
            EndGamePage.textValueOverlayView2.BackgroundColor = true;
            EndGamePage.textValueOverlayView2.TopBarGradiant = true;
            EndGamePage.textValueOverlayView2.ChampionInfoGradiant = true;
            EndGamePage.textValueOverlayView2.BansGradiant = true;
            EndGamePage.textValueOverlayView2.GlobalStatsGradiant = true;
            EndGamePage.textValueOverlayView2.GoldDiffGradiant = true;
            EndGamePage.textValueOverlayView2.BackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.BackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.BackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.TopBarBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.TopBarBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.TopBarBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.ChampionInfoBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.ChampionInfoBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.ChampionInfoBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.BansBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.BansBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.BansBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.GlobalStatsBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.GlobalStatsBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.GlobalStatsBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.GoldDiffBackgroundColorDeg = 90;
            EndGamePage.textValueOverlayView2.GoldDiffBackgroundColorPercent1 = 0;
            EndGamePage.textValueOverlayView2.GoldDiffBackgroundColorPercent2 = 100;
            EndGamePage.textValueOverlayView2.TopBarBorderColor = 5;
            EndGamePage.textValueOverlayView2.ChampionInfoBorderColor = 5;
            EndGamePage.textValueOverlayView2.BansBorderColor = 5;
            EndGamePage.textValueOverlayView2.GlobalStatsBorderColor = 5;
            EndGamePage.textValueOverlayView2.GoldDiffBorderColor = 5;

        }

        public static void CreateTabGold()
        {
            goldDiff = new();
            foreach (var frames in EndGameInfo.jsonContentTimeline.info.frames)
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

        public static string ConvertToHyp(int x, double y, int prex, double prey)
        {
            double newY = y - prey;
            double newX = x - prex;
            double sqrt = Math.Sqrt(newX * newX + newY * newY);
            string machin = sqrt.ToString();
            return machin.Replace(",", ".");
        }

        public static string ConvertToAngle(int x, double y, int prex, double prey)
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
