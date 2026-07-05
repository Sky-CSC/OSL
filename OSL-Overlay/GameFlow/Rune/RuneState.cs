using Newtonsoft.Json;
using OSL_CDragon;
using OSL_RGDP.Schema.Riot;
using WebSocket = OSL_Overlay.WebSocketClient.WebSocketClient;

namespace OSL_Overlay.GameFlow.Rune
{
    public class RuneState
    {
        public RuneInfo Info { get; set; } = new();

        private readonly CDragon _cdragon;
        private readonly WebSocket _client;

        public event Action? OnChange;

        public RuneState(WebSocket client, CDragon cdragon)
        {
            _client = client;
            _cdragon = cdragon;

            // Initialize Info with empty data
            CurrentGameInfo currentGameInfo = null;
            string filePathCurentGameInfo = "./GameFlow/Rune/CurentGameInfo.json";
            if (File.Exists(filePathCurentGameInfo))
            {
                string json = File.ReadAllText(filePathCurentGameInfo);
                currentGameInfo = JsonConvert.DeserializeObject<CurrentGameInfo>(json);
            }

            if (currentGameInfo != null)
                SetRunesSpectatorCurentGameInfo(currentGameInfo);
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        public async Task CustomSetRunesWithCurrentGameInfo(string riotId)
        {
            await _client.SendAsync("spectatorCurentGameInfoByRiotId", riotId);
        }

        public void SetRunesSpectatorCurentGameInfo(CurrentGameInfo currentGameInfo)
        {
            int indexBlue = 0;
            int indexRed = 0;
            foreach (var player in currentGameInfo.Participants)
            {
                if (player.TeamId == 100)
                {
                    Info.BlueTeam[indexBlue].Name.Txt = player.RiotId.Split("#")[0];
                    Info.BlueTeam[indexBlue].Avatar.Path = _cdragon.GetChampionSquare(Convert.ToInt32(player.ChampionId));
                    Info.BlueTeam[indexBlue].Position = Lane.None;
                    Info.BlueTeam[indexBlue].Runes.Keystone.Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkIds[0]));
                    Info.BlueTeam[indexBlue].Runes.Primary[0].Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkStyle));
                    Info.BlueTeam[indexBlue].Runes.Secondary[0].Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkSubStyle));
                    indexBlue++;
                }
                else if (player.TeamId == 200)
                {
                    Info.RedTeam[indexRed].Name.Txt = player.RiotId.Split("#")[0];
                    Info.RedTeam[indexRed].Avatar.Path = _cdragon.GetChampionSquare(Convert.ToInt32(player.ChampionId));
                    Info.RedTeam[indexRed].Position = Lane.None;
                    Info.RedTeam[indexRed].Runes.Keystone.Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkIds[0]));
                    Info.RedTeam[indexRed].Runes.Primary[0].Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkStyle));
                    Info.RedTeam[indexRed].Runes.Secondary[0].Path = _cdragon.GetPerkIconPath(Convert.ToInt32(player.Perks.PerkSubStyle));
                    indexRed++;
                }
            }
            NotifyStateChanged();
        }

        public void SetRunesWithMatchDto(MatchDto matchDto)
        {
            int indexBlue = 0;
            int indexRed = 0;
            foreach (var player in matchDto.Info.Participants)
            {
                if (player.TeamId == 100)
                {
                    Info.BlueTeam[indexBlue].Name.Txt = player.RiotIdGameName;
                    Info.BlueTeam[indexBlue].Avatar.Path = _cdragon.GetChampionSquare(player.ChampionId);
                    string laneString = player.TeamPosition;
                    if (!string.IsNullOrWhiteSpace(laneString) && Enum.TryParse<Lane>(laneString, true, out var lane))
                        Info.BlueTeam[indexBlue].Position = lane;
                    else
                        Info.BlueTeam[indexBlue].Position = Lane.None;

                    Info.BlueTeam[indexBlue].Runes.StatPerks.Defense.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Defense);
                    Info.BlueTeam[indexBlue].Runes.StatPerks.Flex.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Flex);
                    Info.BlueTeam[indexBlue].Runes.StatPerks.Offense.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Offense);
                    foreach (var styles in player.Perks.Styles)
                    {
                        if (styles.Description == "primaryStyle")
                        {
                            for (int i = 0; i < styles.Selections.Count; i++)
                            {
                                if (i == 0)
                                {
                                    Info.BlueTeam[indexBlue].Runes.Keystone.Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                                }
                                else
                                {
                                    Info.BlueTeam[indexBlue].Runes.Primary[i - 1].Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                                }
                            }
                        }
                        else if (styles.Description == "subStyle")
                        {
                            for (int i = 0; i < styles.Selections.Count; i++)
                            {
                                Info.BlueTeam[indexBlue].Runes.Secondary[i].Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                            }
                        }
                    }
                    indexBlue++;
                }
                else if (player.TeamId == 200)
                {
                    Info.RedTeam[indexBlue].Name.Txt = player.RiotIdGameName;
                    Info.RedTeam[indexBlue].Avatar.Path = _cdragon.GetChampionSquare(player.ChampionId);
                    string laneString = player.TeamPosition;
                    if (!string.IsNullOrWhiteSpace(laneString) && Enum.TryParse<Lane>(laneString, true, out var lane))
                        Info.RedTeam[indexBlue].Position = lane;
                    else
                        Info.RedTeam[indexBlue].Position = Lane.None;

                    Info.RedTeam[indexRed].Runes.StatPerks.Defense.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Defense);
                    Info.RedTeam[indexRed].Runes.StatPerks.Flex.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Flex);
                    Info.RedTeam[indexRed].Runes.StatPerks.Offense.Path = _cdragon.GetPerkIconPath(player.Perks.StatPerks.Offense);
                    foreach (var styles in player.Perks.Styles)
                    {
                        if (styles.Description == "primaryStyle")
                        {
                            for (int i = 0; i < styles.Selections.Count; i++)
                            {
                                if (i == 0)
                                {
                                    Info.RedTeam[indexRed].Runes.Keystone.Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                                }
                                else
                                {
                                    Info.RedTeam[indexRed].Runes.Primary[i - 1].Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                                }
                            }
                        }
                        else if (styles.Description == "subStyle")
                        {
                            for (int i = 0; i < styles.Selections.Count; i++)
                            {
                                Info.RedTeam[indexRed].Runes.Secondary[i].Path = _cdragon.GetPerkIconPath(styles.Selections[i].Perk);
                            }
                        }
                    }
                    indexRed++;
                }
            }
            NotifyStateChanged();
        }

        public async Task GetRunesWithMatchId(Int64 matchDtoId)
        {
            await _client.SendAsync("runesMatch", matchDtoId);
        }
    }


    public static class RuneStateExtensions
    {

        public static RuneInfo CloneInfo(this RuneInfo source)
        {
            var json = JsonConvert.SerializeObject(source);
            var settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var clone = JsonConvert.DeserializeObject<RuneInfo>(json, settings);
            return clone ?? new RuneInfo();
        }
    }
}
