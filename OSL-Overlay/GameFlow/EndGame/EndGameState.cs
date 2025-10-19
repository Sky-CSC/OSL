using MudBlazor;
using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Common;
using OSL_Overlay.GameFlow.Phase;
using OSL_Overlay.GameFlow.Team;
using OSL_RGDP.Schema.Riot;
using System.Reflection;
using System.Text.RegularExpressions;
using static OSL_Overlay.GameFlow.EndGame.EndGameStateExtensions;
using WebSocket = OSL_Overlay.WebSocketClient.WebSocketClient;

namespace OSL_Overlay.GameFlow.EndGame
{
    /// <summary>
    /// End game management
    /// </summary>
    public class EndGameState
    {
        /// <summary>
        /// End game info to display
        /// </summary>
        public EndGameInfo Info { get; private set; } = new();
        /// <summary>
        /// Match data from Riot API
        /// </summary>
        private MatchDto MatchDto { get; set; } = new();
        /// <summary>
        /// Timeline data from Riot API
        /// </summary>
        private TimelineDto TimelineDto { get; set; } = new();
        /// <summary>
        /// Properties of ParticipantDto that can be displayed in Total Info
        /// </summary>
        public List<string> ParticipantProperties { get; private set; } = new();
        /// <summary>
        /// Cache of PropertyInfo for ParticipantDto to improve performance
        /// </summary>
        private readonly Dictionary<string, PropertyInfo> _propertyCache = new();

        /// <summary>
        /// WebSocket client to communicate with the WebSocket server
        /// </summary>
        private readonly WebSocket _client;
        /// <summary>
        /// CDragon instance to get static data
        /// </summary>
        private readonly CDragon _cdragon;

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cdragon"></param>
        public EndGameState(WebSocket client, CDragon cdragon)
        {
            _client = client;
            _cdragon = cdragon;
            LoadParticipantProperties();
            // Load default data from local files for initialization
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
            MatchDto = new();
            MatchDto = matchDto;
            UpdateTimer();
            UpdateWin();
            UpdateParticipantsStats();
            UpdateBans();
            UpdateTotalInfo("TotalDamageDealtToChampions");
            NotifyStateChanged();
        }

        /// <summary>
        /// Update curent timeline and update game stats and golds
        /// </summary>
        /// <param name="timelineDto"></param>
        public void SetTimeline(TimelineDto timelineDto)
        {
            TimelineDto = new();
            TimelineDto = timelineDto;
            UpdateGolds();
            UpdateEliteMonterStats();
            SortEventsByTimestamp();
            NotifyStateChanged();
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
                data.statText.BlueTeam.Txt = CalculateStat(blueTotals[key].ToString());
                data.statText.RedTeam.Txt = CalculateStat(redTotals[key].ToString());
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
                ["RIFTHERALD"] = (Info.GameStats.Herald, "Herald"),
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

                    string key = ev.MonsterType;

                    if (ev.MonsterType == "DRAGON")
                        key = ev.MonsterSubType;

                     if (eliteStats.ContainsKey(key))
                    {
                        if (ev.KillerTeamId == 100)
                            blueMonsters[key]++;
                        else
                            redMonsters[key]++;

                        Info.Golds.Events.Add(new(key, ev.KillerTeamId,ev.Timestamp));
                    }
                }
            }

            foreach (var (key, data) in eliteStats)
            {
                data.statImage.Title.Txt = data.displayName;
                data.statImage.NbBlueTeam = blueMonsters[key];
                data.statImage.NbRedTeam = redMonsters[key];
            }

            EliteMonsterDragon();
        }

        public void SortEventsByTimestamp()
        {
            Info.Golds.Events = [.. Info.Golds.Events.OrderByDescending(e => e.Timetamps)];
        }

        /// <summary>
        /// Update KDA stats
        /// </summary>
        private void UpdateGameStatsKda(StatText k, StatText d, StatText a)
        {
            Info.GameStats.Kda.Title.Txt = "KDA";
            Info.GameStats.Kda.BlueTeam.Txt = $"{k.BlueTeam.Txt}/{d.BlueTeam.Txt}/{a.BlueTeam.Txt}";
            Info.GameStats.Kda.RedTeam.Txt = $"{k.RedTeam.Txt}/{d.RedTeam.Txt}/{a.RedTeam.Txt}";
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
            Info.Golds.Events = [];
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
                    Info.ChampionStats.BlueTeam[indexBlue].Image.Path = _cdragon.GetChampionTile(player.ChampionId);
                    Info.ChampionStats.BlueTeam[indexBlue].Name.Txt = player.RiotIdGameName;
                    Info.ChampionStats.BlueTeam[indexBlue].Stat.Txt = value;
                    indexBlue++;
                }
                else
                {
                    Info.ChampionStats.RedTeam[indexRed].Image.Path = _cdragon.GetChampionTile(player.ChampionId);
                    Info.ChampionStats.RedTeam[indexRed].Name.Txt = player.RiotIdGameName;
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

        public void UpdateBlueTeamInfo(TeamInfo info)
        {
            Info.TimerTeamsHeadband.BlueTeam.Name.Txt = info.Name;
            Info.TimerTeamsHeadband.BlueTeam.Tag.Txt = info.Tag;
            Info.TimerTeamsHeadband.BlueTeam.Logo = new(info.Logo);
            NotifyStateChanged();
        }

        public void UpdateRedTeamInfo(TeamInfo info)
        {
            Info.TimerTeamsHeadband.RedTeam.Name.Txt = info.Name;
            Info.TimerTeamsHeadband.RedTeam.Tag.Txt = info.Tag;
            Info.TimerTeamsHeadband.RedTeam.Logo = new(info.Logo);
            NotifyStateChanged();
        }

        public async Task CustomSetMatch(Int64 matchDtoId)
        {
            var payload = new { type = "endGameMatch", data = matchDtoId };
            await _client.SendAsync(payload);
        }
        public async Task CustomSetTimeline(Int64 timelineDtoId)
        {
            var payload = new { type = "endGameTimeline", data = timelineDtoId };
            await _client.SendAsync(payload);
        }

        public void UpdateInfoPhase(PhaseInfo phase)
        {
            Info.EventInfo.Phase.Txt = phase.Phase.Txt;
            Info.EventInfo.Event.Txt = phase.Event.Txt;
            Info.EventInfo.Date.Txt = phase.Date.Txt;
            NotifyStateChanged();
        }
    }

    /// <summary>
    /// Extension methods for EndGameState
    /// </summary>
    public static class EndGameStateExtensions
    {
        /// <summary>
        /// Clone EndGameInfo object by serializing and deserializing it
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static EndGameInfo CloneInfo(this EndGameInfo source)
        {
            Console.WriteLine(source.ChampionStats.RedTeam[0].Bar.Background);
            var json = JsonConvert.SerializeObject(source);
            var settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var clone = JsonConvert.DeserializeObject<EndGameInfo>(json, settings);
            Console.WriteLine(clone.ChampionStats.RedTeam[0].Bar.Background);
            return clone ?? new EndGameInfo();
        }

        public static Text CalculateStat(Text stat)
        {
            string text = stat.Txt;
            if (stat.Txt != string.Empty && Convert.ToDouble(stat.Txt) > 1000000)
            {
                text = $"{Math.Round(Convert.ToDouble(text) / 1000000, 1)}M";
            }
            else if (stat.Txt != string.Empty && Convert.ToDouble(stat.Txt) > 1000)
            {
                text = $"{Math.Round(Convert.ToDouble(text) / 1000, 1)}K";
            }
            return new(text, stat.Font, stat.Color, stat.Background, stat.Border, stat.Align);
        }

        public static string CalculateStat(string stat)
        {
            try
            {
                double value = Convert.ToDouble(stat);
                if (value > 1000000)
                {
                    return $"{Math.Round(value / 1000000, 1)}M";
                }
                else if (value > 1000)
                {
                    return $"{Math.Round(value / 1000, 1)}K";
                }
                return stat;
            }
            catch
            {
                return stat;
            }
        }
    }
}
