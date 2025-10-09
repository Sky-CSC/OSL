using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Common;
using OSL_Overlay.GameFlow.Fearless;
using OSL_RGDP.Schema.Riot;
using System.Reflection;
using System.Text.RegularExpressions;

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
            UpdateGameStatsGameDto();
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
            UpdateGameStatsTimelineDto();
            UpdateGolds();
        }

        /// <summary>
        /// Update Timer
        /// </summary>
        private void UpdateTimer()
        {
            if (MatchDto.Info.GameDuration != 0)
            {
                var ts = TimeSpan.FromSeconds(MatchDto.Info.GameDuration);
                Info.Timer.Time.Txt = ts.ToString(@"mm\:ss");
            }
            else
                Info.Timer.Time.Txt = "00:00";
        }

        /// <summary>
        /// Update Game Stats from MatchDto
        /// </summary>
        private void UpdateGameStatsGameDto()
        {
            UpdateParticipantsStats();
            UpdateGameStatsKda();
        }

        /// <summary>
        /// Update Game Stats from TimelineDto
        /// </summary>
        private void UpdateGameStatsTimelineDto()
        {
            UpdateEliteMonterStats();
            EliteMonsterDragon();
        }

        /// <summary>
        /// Update Kills, Deaths, Assists, Golds, Towers from participants
        /// </summary>
        private void UpdateParticipantsStats()
        {
            var baseStats = new Dictionary<string, (Stat stat, Func<ParticipantDto, int> selector)>
            {
                ["Kills"] = (Info.GameData.GameStats.Kills, p => p.Kills),
                ["Deaths"] = (Info.GameData.GameStats.Deaths, p => p.Deaths),
                ["Assists"] = (Info.GameData.GameStats.Assists, p => p.Assists),
                ["Golds"] = (Info.GameData.GameStats.Golds, p => p.GoldEarned),
                ["Towers"] = (Info.GameData.GameStats.Towers, p => p.TurretKills)
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
                data.stat.Name.Txt = key;
                data.stat.ShowText = true;
                data.stat.ShowImages = false;
                data.stat.BlueTeam.Txt = blueTotals[key].ToString();
                data.stat.RedTeam.Txt = redTotals[key].ToString();
            }
        }

        /// <summary>
        /// Update Elite Monster stats from TimelineDto
        /// </summary>
        private void UpdateEliteMonterStats()
        {
            Info.GameData.Events = [];
            var eliteStats = new Dictionary<string, (Stat stat, string displayName)>
            {
                ["HORDE"] = (Info.GameData.GameStats.VoidGrubs, "Void Grubs"),
                ["RIFTHERALD"] = (Info.GameData.GameStats.Heralds, "Heralds"),
                ["ATAKHAN"] = (Info.GameData.GameStats.Atakhan, "Atakhan"),
                ["ELDER_DRAGON"] = (Info.GameData.GameStats.Elders, "Elders"),
                ["BARON_NASHOR"] = (Info.GameData.GameStats.Barons, "Barons"),
                ["AIR_DRAGON"] = (Info.GameData.GameStats.Air, "Air"),
                ["CHEMTECH_DRAGON"] = (Info.GameData.GameStats.Chemtech, "Chemtech"),
                ["EARTH_DRAGON"] = (Info.GameData.GameStats.Earth, "Earth"),
                ["FIRE_DRAGON"] = (Info.GameData.GameStats.Fire, "Fire"),
                ["HEXTECH_DRAGON"] = (Info.GameData.GameStats.Hextech, "Hextech"),
                ["WATER_DRAGON"] = (Info.GameData.GameStats.Water, "Water")
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

                        Info.GameData.Events.Add(new Events
                        {
                            Type = ev.MonsterType,
                            Side = ev.KillerTeamId,
                            Time = ev.Timestamp
                        });
                    }
                }
            }

            foreach (var (key, data) in eliteStats)
            {
                data.stat.Name.Txt = data.displayName;
                data.stat.ShowText = true;
                data.stat.ShowImages = true;
                data.stat.BlueTeam.Txt = blueMonsters[key].ToString();
                data.stat.RedTeam.Txt = redMonsters[key].ToString();
            }
        }

        /// <summary>
        /// Update KDA stats
        /// </summary>
        private void UpdateGameStatsKda()
        {
            Info.GameData.GameStats.Kda.Name.Txt = "KDA";
            Info.GameData.GameStats.Kda.ShowText = true;
            Info.GameData.GameStats.Kda.ShowImages = false;
            Info.GameData.GameStats.Kda.BlueTeam.Txt = $"{Info.GameData.GameStats.Kills.BlueTeam}/{Info.GameData.GameStats.Deaths.BlueTeam}/{Info.GameData.GameStats.Assists.BlueTeam}";
            Info.GameData.GameStats.Kda.RedTeam.Txt = $"{Info.GameData.GameStats.Kills.RedTeam}/{Info.GameData.GameStats.Deaths.RedTeam}/{Info.GameData.GameStats.Assists.RedTeam}";
        }

        /// <summary>
        /// Update Dragon stats
        /// </summary>
        private void EliteMonsterDragon()
        {
            Info.GameData.GameStats.Dragon.Name.Txt = "Dragon";
            Info.GameData.GameStats.Dragon.ShowText = true;
            Info.GameData.GameStats.Dragon.ShowImages = true;
        }

        /// <summary>
        /// Update team win
        /// </summary>
        private void UpdateWin()
        {
            foreach (var team in MatchDto.Info.Teams)
            {
                if (team.TeamId == 100)
                    Info.Timer.BlueSide.Win = team.Win;
                else
                    Info.Timer.RedSide.Win = team.Win;
            }
        }

        /// <summary>
        /// Update bans images
        /// </summary>
        private void UpdateBans()
        {
            Info.GameData.Bans.BlueTeam = [];
            Info.GameData.Bans.RedTeam = [];
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
                        Info.GameData.Bans.BlueTeam.Add(image);
                    }
                    else
                    {
                        Info.GameData.Bans.RedTeam.Add(image);
                    }
                }
            }
        }

        /// <summary>
        /// Update gold difference from TimelineDto
        /// </summary>
        private void UpdateGolds()
        {
            Info.GameData.Golds.GoldDifference = [];
            foreach (var frames in TimelineDto.Info.Frames)
            {
                int blueGolds = 0;
                int redGolds = 0;
                blueGolds += frames.ParticipantFrames.Participant1.TotalGold;
                blueGolds += frames.ParticipantFrames.Participant2.TotalGold;
                blueGolds += frames.ParticipantFrames.Participant3.TotalGold;
                blueGolds += frames.ParticipantFrames.Participant4.TotalGold;
                blueGolds += frames.ParticipantFrames.Participant5.TotalGold;

                redGolds += frames.ParticipantFrames.Participant6.TotalGold;
                redGolds += frames.ParticipantFrames.Participant7.TotalGold;
                redGolds += frames.ParticipantFrames.Participant8.TotalGold;
                redGolds += frames.ParticipantFrames.Participant9.TotalGold;
                redGolds += frames.ParticipantFrames.Participant10.TotalGold;

                GoldDifference goldDiff = new()
                {
                    Gold = blueGolds - redGolds,
                    Time = frames.Timestamp
                };

                Info.GameData.Golds.GoldDifference.Add(goldDiff);
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

            Info.GameData.Total.Title.Txt = ToTitleCase(propertyName);

            foreach (var player in MatchDto.Info.Participants)
            {
                var value = GetPlayerStatValue(player, propertyName)?.ToString() ?? "0";

                if (player.TeamId == 100)
                {
                    Info.GameData.Total.BlueTeam[indexBlue].Value.Txt = value;
                    indexBlue++;
                }
                else
                {
                    Info.GameData.Total.RedTeam[indexRed].Value.Txt = value;
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
                Info.Timer.BlueSide.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.Timer.BlueSide.BoGraphic.NbWin = bo.Win;
                Info.Timer.BlueSide.BoGraphic.Win.Txt = bo.Text;
            }
            if (side == "red-side")
            {
                Info.Timer.RedSide.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.Timer.RedSide.BoGraphic.NbWin = bo.Win;
                Info.Timer.RedSide.BoGraphic.Win.Txt = bo.Text;
            }
            NotifyStateChanged();
        }
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
