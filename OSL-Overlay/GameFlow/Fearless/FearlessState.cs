using OSL_CDragon;
using OSL_RGDP.WebSocketResponse;
using WebSocket = OSL_Overlay.WebSocketClient.WebSocketClient;

namespace OSL_Overlay.GameFlow.Fearless
{
    /// <summary>
    /// Fearless management
    /// </summary>
    public class FearlessState
    {
        /// <summary>
        /// WebSocket client to communicate with the WebSocket server
        /// </summary>
        private readonly WebSocket _client;
        /// <summary>
        /// CDragon instance to get champion data
        /// </summary>
        private readonly CDragon _cdragon;
        /// <summary>
        /// Feraless info list
        /// </summary>
        public List<List<FearlessInfo>> FearlessList = [];

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="cDragon"></param>
        public FearlessState(WebSocket client, CDragon cDragon)
        {
            _client = client;
            _cdragon = cDragon;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

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
            await _client.SendAsync("fearlessGameMatch", fearlessMatchId);
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

        /// <summary>
        /// Reset the fearless info list
        /// </summary>
        public void ResetFearlessList()
        {
            FearlessList.Clear();
            NotifyStateChanged();
        }

        /// <summary>
        /// Reset the fearless info at the index
        /// </summary>
        /// <param name="index"></param>
        public void ResetFearlessIndex(int index)
        {
            if (FearlessList.Count > index)
            {
                FearlessList[index] = [new FearlessInfo(), new FearlessInfo()];
            }
        }

        /// <summary>
        /// Delete the fearless info at the index
        /// </summary>
        /// <param name="index"></param>
        public void DeleteFearlessIndex(int index)
        {
            if (FearlessList.Count > index)
            {
                FearlessList.RemoveAt(index);
                NotifyStateChanged();
            }
        }
    }

    /// <summary>
    /// Fearless state extensions
    /// </summary>
    public static class FearlessStateExtensions
    {
        /// <summary>
        /// Clone a list of list of FearlessInfo
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<List<FearlessInfo>> CloneFirelessList(this List<List<FearlessInfo>> source)
        {
            return source.Select(team => team.Select(info => info.Clone()).ToList()).ToList();
        }
    }
}
