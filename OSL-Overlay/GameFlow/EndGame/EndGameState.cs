using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Common;
using OSL_RGDP.Schema.Riot;
using System.Reflection;
using System.Text.RegularExpressions;
using static OSL_Overlay.GameFlow.EndGame.EndGameInfo;

namespace OSL_Overlay.GameFlow.EndGame
{
    public class EndGameState
    {
        public EndGameInfo Info { get; private set; } = new();
        private MatchDto MatchDto { get; set; } = new();
        private TimelineDto TimelineDto { get; set; } = new();

        public List<string> ParticipantProperties { get; private set; } = new();

        private readonly Dictionary<string, PropertyInfo> _propertyCache = new();

        private readonly CDragon _cdragon;
        public event Action? OnChange;

        public EndGameState(CDragon cdragon)
        {
            _cdragon = cdragon;
            LoadParticipantProperties();
            // Load file for testing
            MatchDto matchDto = null;
            TimelineDto timelineDto = null;
            string filePathMatch = "./GameFlow/EndGame/MatchDto.json";
            string filePathTimeline = "./GameFlow/EndGame/TimelineDto.json";
            if (File.Exists(filePathMatch))
            {
                string json = File.ReadAllText(filePathMatch);
                matchDto = JsonConvert.DeserializeObject<MatchDto>(json);
            }
            if (File.Exists(filePathTimeline))
            {
                string json = File.ReadAllText(filePathTimeline);
                timelineDto = JsonConvert.DeserializeObject<TimelineDto>(json);
            }

            if (matchDto != null)
                SetMatch(matchDto);
            if (timelineDto != null)
                SetTimeline(timelineDto);
        }

        public void NotifyStateChanged() => OnChange?.Invoke();


        /// <summary>
        /// Update curent match and update Timer, Win, Game Stats, Ban and Total
        /// </summary>
        /// <param name="matchDto"></param>
        public void SetMatch(MatchDto matchDto)
        {
            MatchDto = matchDto;
            UpdateTimer();
            UpdateWin();
            UpdateParticipantsStats();
            UpdateBans();
            UpdateTotalInfo("TotalDamageDealtToChampions");
        }

        /// <summary>
        /// Update curent timeline and update game stats and golds
        /// </summary>
        /// <param name="timelineDto"></param>
        private void SetTimeline(TimelineDto timelineDto)
        {
            TimelineDto = timelineDto;
            UpdateGolds();
            UpdateEliteMonterStats();
        }

        /// <summary>
        /// Update Timer
        /// </summary>
        private void UpdateTimer()
        {
            if (MatchDto.Info.GameDuration != 0)
            {
                var ts = TimeSpan.FromSeconds(MatchDto.Info.GameDuration);
                Info.TimerTeamsHeadband.Timer.Txt = ts.ToString(@"mm\:ss");
            }
            else
                Info.TimerTeamsHeadband.Timer.Txt = "00:00";
        }

        /// <summary>
        /// Update Kills, Deaths, Assists, Golds, Towers from participants
        /// </summary>
        private void UpdateParticipantsStats()
        {
            StatText kills = new();
            StatText deaths = new();
            StatText assists = new();
            var baseStats = new Dictionary<string, (StatText statText, Func<ParticipantDto, int> selector)>
            {
                ["Kills"] = (kills, p => p.Kills),
                ["Deaths"] = (deaths, p => p.Deaths),
                ["Assists"] = (assists, p => p.Assists),
                ["Golds"] = (Info.GameStats.Golds, p => p.GoldEarned),
                ["Towers"] = (Info.GameStats.Towers, p => p.TurretKills)
            };

            var blueTotals = baseStats.ToDictionary(x => x.Key, x => 0);
            var redTotals = baseStats.ToDictionary(x => x.Key, x => 0);

            // Loop on participants
            foreach (var player in MatchDto.Info.Participants)
            {
                foreach (var (key, data) in baseStats)
                {
                    var value = data.selector(player);
                    if (player.TeamId == 100)
                        blueTotals[key] += value;
                    else
                        redTotals[key] += value;
                }
            }

            foreach (var (key, data) in baseStats)
            {
                data.statText.Title.Txt = key;
                data.statText.BlueTeam.Txt = blueTotals[key].ToString();
                data.statText.RedTeam.Txt = redTotals[key].ToString();
            }
            UpdateGameStatsKda(kills, deaths, assists);
        }

        /// <summary>
        /// Update Elite Monster stats from TimelineDto
        /// </summary>
        private void UpdateEliteMonterStats()
        {
            var eliteStats = new Dictionary<string, (StatImage statImage, string displayName)>
            {
                ["HORDE"] = (Info.GameStats.VoidGrubs, "Void Grubs"),
                ["RIFTHERALD"] = (Info.GameStats.Herald, "Heralds"),
                ["ATAKHAN"] = (Info.GameStats.Atakhan, "Atakhan"),
                ["ELDER_DRAGON"] = (Info.GameStats.Elders, "Elders"),
                ["BARON_NASHOR"] = (Info.GameStats.Barons, "Barons"),
                ["AIR_DRAGON"] = (Info.GameStats.Drakes.Air, "Air"),
                ["CHEMTECH_DRAGON"] = (Info.GameStats.Drakes.Chemtech, "Chemtech"),
                ["EARTH_DRAGON"] = (Info.GameStats.Drakes.Earth, "Earth"),
                ["FIRE_DRAGON"] = (Info.GameStats.Drakes.Fire, "Fire"),
                ["HEXTECH_DRAGON"] = (Info.GameStats.Drakes.Hextech, "Hextech"),
                ["WATER_DRAGON"] = (Info.GameStats.Drakes.Water, "Water")
            };

            var blueMonsters = eliteStats.ToDictionary(x => x.Key, x => 0);
            var redMonsters = eliteStats.ToDictionary(x => x.Key, x => 0);

            // Loop on Events
            foreach (var frame in TimelineDto.Info.Frames)
            {
                foreach (var ev in frame.Events)
                {
                    if (ev.Type != "ELITE_MONSTER_KILL") continue;

                    if (eliteStats.ContainsKey(ev.MonsterType))
                    {
                        if (ev.KillerTeamId == 100)
                            blueMonsters[ev.MonsterType]++;
                        else
                            redMonsters[ev.MonsterType]++;

                        Info.Golds.Events.Add(new(ev.MonsterType, ev.KillerTeamId,ev.Timestamp));
                    }
                }
            }

            foreach (var (key, data) in eliteStats)
            {
                data.statImage.Title.Txt = data.displayName;
                data.statImage.NbBlueTeam = blueMonsters[key].ToString();
                data.statImage.NbRedTeam = redMonsters[key].ToString();
            }

            EliteMonsterDragon();
        }

        /// <summary>
        /// Update KDA stats
        /// </summary>
        private void UpdateGameStatsKda(StatText k, StatText d, StatText a)
        {
            Info.GameStats.Kda.Title.Txt = "KDA";
            Info.GameStats.Kda.BlueTeam.Txt = $"{k.BlueTeam}/{d.BlueTeam}/{a.BlueTeam}";
            Info.GameStats.Kda.RedTeam.Txt = $"{k.RedTeam}/{d.RedTeam}/{a.RedTeam}";
        }

        /// <summary>
        /// Update Dragon stats
        /// </summary>
        private void EliteMonsterDragon()
        {
            Info.GameStats.Drakes.Title.Txt = "Drakes";
        }

        /// <summary>
        /// Update team win
        /// </summary>
        private void UpdateWin()
        {
            foreach (var team in MatchDto.Info.Teams)
            {
                if (team.TeamId == 100)
                    Info.TimerTeamsHeadband.BlueTeam.Win = team.Win;
                else
                    Info.TimerTeamsHeadband.RedTeam.Win = team.Win;
            }
        }

        /// <summary>
        /// Update bans images
        /// </summary>
        private void UpdateBans()
        {
            Info.Bans.BlueTeam = [];
            Info.Bans.RedTeam = [];
            foreach (var team in MatchDto.Info.Teams)
            {
                foreach (var ban in team.Bans)
                {
                    Image image = new()
                    {
                        Path = _cdragon.GetChampionSquare(ban.ChampionId)
                    };
                    if (team.TeamId == 100)
                    {
                        Info.Bans.BlueTeam.Add(image);
                    }
                    else
                    {
                        Info.Bans.RedTeam.Add(image);
                    }
                }
            }
        }

        /// <summary>
        /// Update gold difference from TimelineDto
        /// </summary>
        private void UpdateGolds()
        {
            foreach (var frame in TimelineDto.Info.Frames)
            {
                int blueGolds = 0;
                int redGolds = 0;
                blueGolds += frame.ParticipantFrames.Participant1.TotalGold;
                blueGolds += frame.ParticipantFrames.Participant2.TotalGold;
                blueGolds += frame.ParticipantFrames.Participant3.TotalGold;
                blueGolds += frame.ParticipantFrames.Participant4.TotalGold;
                blueGolds += frame.ParticipantFrames.Participant5.TotalGold;

                redGolds += frame.ParticipantFrames.Participant6.TotalGold;
                redGolds += frame.ParticipantFrames.Participant7.TotalGold;
                redGolds += frame.ParticipantFrames.Participant8.TotalGold;
                redGolds += frame.ParticipantFrames.Participant9.TotalGold;
                redGolds += frame.ParticipantFrames.Participant10.TotalGold;

                Info.Golds.Events.Add(new("Gold", 0, frame.Timestamp, blueGolds - redGolds));
            }
        }

        /// <summary>
        /// Load list of participant properties that can be displayed
        /// </summary>
        private void LoadParticipantProperties()
        {
            ParticipantProperties = typeof(ParticipantDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p =>
                {
                    var t = p.PropertyType;
                    return t == typeof(int) || t == typeof(double) || t == typeof(bool) || t == typeof(string);
                })
                .Select(p =>
                {
                    var attr = p.GetCustomAttribute<JsonPropertyAttribute>();
                    return attr?.PropertyName ?? p.Name;
                })
                .OrderBy(p => p)
                .ToList();
        }

        /// <summary>
        /// Update Total Info from a property name of ParticipantDto
        /// </summary>
        /// <param name="propertyName"></param>
        public void UpdateTotalInfo(string propertyName)
        {
            if (MatchDto?.Info?.Participants == null || !MatchDto.Info.Participants.Any())
                return;

            int indexBlue = 0;
            int indexRed = 0;

            Info.ChampionStats.Title.Txt = ToTitleCase(propertyName);

            foreach (var player in MatchDto.Info.Participants)
            {
                var value = GetPlayerStatValue(player, propertyName)?.ToString() ?? "0";

                if (player.TeamId == 100)
                {
                    Info.ChampionStats.BlueTeam[indexBlue].Stat.Txt = value;
                    indexBlue++;
                }
                else
                {
                    Info.ChampionStats.RedTeam[indexRed].Stat.Txt = value;
                    indexRed++;
                }
            }
            NotifyStateChanged();
        }

        /// <summary>
        /// Get the value of a property from ParticipantDto by its name or JsonProperty name
        /// </summary>
        /// <param name="player"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object? GetPlayerStatValue(ParticipantDto player, string propertyName)
        {
            if (player == null || string.IsNullOrWhiteSpace(propertyName))
                return null;

            if (!_propertyCache.TryGetValue(propertyName.ToLowerInvariant(), out var prop))
            {
                prop = typeof(ParticipantDto)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(p =>
                    {
                        var attr = p.GetCustomAttribute<JsonPropertyAttribute>();
                        return string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase)
                            || (attr != null && string.Equals(attr.PropertyName, propertyName, StringComparison.OrdinalIgnoreCase));
                    });

                if (prop != null)
                    _propertyCache[propertyName.ToLowerInvariant()] = prop;
            }

            return prop?.GetValue(player);
        }

        /// <summary>
        /// Convert input string to Title Case (remove Total prefix)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ToTitleCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = Regex.Replace(input.Trim(), @"^Total", "", RegexOptions.IgnoreCase);

            var text = Regex.Replace(input, "([a-z])([A-Z])", "$1 $2");
            text = text.Replace("_", " ").Replace("-", " ");
            return char.ToUpper(text[0]) + text[1..];
        }

        public void UpdateInfoBo(BoInfo bo, string side)
        {
            if (side == "blue-side")
            {
                Info.TimerTeamsHeadband.BlueTeam.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.TimerTeamsHeadband.BlueTeam.BoGraphic.NbWin = bo.Win;
                Info.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Txt = bo.Text;
            }
            if (side == "red-side")
            {
                Info.TimerTeamsHeadband.RedTeam.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.TimerTeamsHeadband.RedTeam.BoGraphic.NbWin = bo.Win;
                Info.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Txt = bo.Text;
            }
            NotifyStateChanged();
        }

        //Convert value to px 
    }

    public static class EndGameStateExtensions
    {
        public static EndGameInfo CloneInfo(this EndGameInfo source)
        {
            var json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<EndGameInfo>(json) ?? new EndGameInfo();
        }
    }
}
