using Newtonsoft.Json;
using OSL_CDragon;
using OSL_RGDP.WebSocketResponse;
using WebSocket = OSL_Overlay.WebSocketClient.WebSocketClient;

namespace OSL_Overlay.Phase.Fearless
{
    public class FearlessState
    {
        private readonly WebSocket _client;

        private readonly CDragon _cdragon;

        public List<List<FearlessInfo>> FearlessList = [];

        public event Action? OnChange;

        public FearlessState(WebSocket client, CDragon cDragon)
        {
            _client = client;
            _cdragon = cDragon;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        // TODO: manueal setup

        /// <summary>
        /// Get match data from matchId
        /// </summary>
        /// <param name="matchId"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task MatchIdModeAsync(long matchId, int index)
        {
            // Send message to websocket to get match data
            FearlessMatchId fearlessMatchId = new(matchId, index);
            var payload = new { type = "fearlessGameMatch", data = fearlessMatchId };
            await _client.SendAsync(payload);
        }

        /// <summary>
        /// Add a fearless info to the list
        /// </summary>
        /// <param name="fearlessMatchDto"></param>
        public void AddFearlessList(FearlessMatchDto fearlessMatchDto)
        {
            // Add a new fearless info to the list
            if (FearlessList.Count <= fearlessMatchDto.Index)
            {
                FearlessList.Add([new FearlessInfo(), new FearlessInfo()]);
            }
            // Reset the fearless info at the index
            else
            {
                ResetFearlessIndex(fearlessMatchDto.Index);
            }

            FearlessList[fearlessMatchDto.Index][0].IdMatch = fearlessMatchDto.Match.Info.GameId.ToString();
            FearlessList[fearlessMatchDto.Index][1].IdMatch = fearlessMatchDto.Match.Info.GameId.ToString();

            foreach (var player in fearlessMatchDto.Match.Info.Participants)
            {
                Champion champion = new(_cdragon.GetChampionSquare(player.ChampionId));
                if (player.TeamId == 100)
                {
                    FearlessList[fearlessMatchDto.Index][0].Champions.Add(champion);
                }
                else
                {
                    FearlessList[fearlessMatchDto.Index][1].Champions.Add(champion);
                }
            }
            NotifyStateChanged();
        }

        public void ResetFearlessList()
        {
            FearlessList.Clear();
            NotifyStateChanged();
        }

        public void ResetFearlessIndex(int index)
        {
            if (FearlessList.Count > index)
            {
                FearlessList[index] = [new FearlessInfo(), new FearlessInfo()];
                NotifyStateChanged();
            }
        }

        public void DeleteFearlessIndex(int index)
        {
            if (FearlessList.Count > index)
            {
                FearlessList.RemoveAt(index);
                NotifyStateChanged();
            }
        }
    }

    public static class FearlessStateExtensions
    {
        public static List<List<FearlessInfo>> CloneFirelessList(this List<List<FearlessInfo>> source)
        {
            return source.Select(team => team.Select(info => info.Clone()).ToList()).ToList();
        }
    }
}
