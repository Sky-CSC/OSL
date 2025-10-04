using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Overlay.Phase.ChampSelect;
using OSL_RGDP.WebSocketResponse;
using System.Linq.Expressions;
using WebSocket = OSL_Overlay.WebSocketClient.WebSocketClient;

namespace OSL_Overlay.Phase.Fearless
{
    public class FearlessState
    {
        private readonly WebSocket _client;

        private readonly CDragon _cdragon;

        public List<List<FearlessInfo>> FearlessList = [];
        public List<List<FearlessInfo>> FearlessStyle = [];

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
        public async Task MatchIdModeAsync(Int64 matchId, int index)
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
            UpdateInfoCss(fearlessMatchDto.Index);
            NotifyStateChanged();
        }

        public void UpdateInfoCss(int index)
        {
            FearlessList[index][0].Text.Txt = $"Game {index + 1}";
            FearlessList[index][1].Text.Txt = $"Game {index + 1}";
            UpdateInfoCss(FearlessStyle);
        }

        public void UpdateInfoCss(List<List<FearlessInfo>> info)
        {
            for (int i = 0; i < info.Count; i++)
            {
                for (int j = 0; j < info[i].Count; j++)
                {
                    if (FearlessList.Count > i && FearlessList[i].Count > j)
                    {
                        FearlessList[i][j].Text.Txt = info[i][j].Text.Txt;
                        FearlessList[i][j].Text.Color = info[i][j].Text.Color;
                        FearlessList[i][j].Text.Font = info[i][j].Text.Font;
                        FearlessList[i][j].Text.Background = info[i][j].Text.Background;
                        FearlessList[i][j].Text.Border = info[i][j].Text.Border;
                        FearlessList[i][j].Text.Align = info[i][j].Text.Align;
                        FearlessList[i][j].Background = info[i][j].Background;
                        FearlessList[i][j].Line.Background = info[i][j].Line.Background;
                        FearlessList[i][j].Border = info[i][j].Border;
                        for (int k = 0; k < info[i][j].Champions.Count; k++)
                        {
                            if (FearlessList[i][j].Champions.Count > k)
                            {
                                FearlessList[i][j].Champions[k].Border = info[i][j].Champions[k].Border;
                                FearlessList[i][j].Champions[k].Lane.Border = info[i][j].Champions[k].Lane.Border;
                                FearlessList[i][j].Champions[k].Greyscale = info[i][j].Champions[k].Greyscale;
                                FearlessList[i][j].Champions[k].Cross.Image = info[i][j].Champions[k].Cross.Image;
                                FearlessList[i][j].Champions[k].Cross.GraphicLineColor = info[i][j].Champions[k].Cross.GraphicLineColor;
                                FearlessList[i][j].Champions[k].Cross.GraphicCrossColor = info[i][j].Champions[k].Cross.GraphicCrossColor;
                                FearlessList[i][j].Champions[k].Cross.Width = info[i][j].Champions[k].Cross.Width;
                                FearlessList[i][j].Champions[k].Cross.Height = info[i][j].Champions[k].Cross.Height;
                                FearlessList[i][j].Champions[k].Cross.Rotate = info[i][j].Champions[k].Cross.Rotate;
                            }
                        }
                    }
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

        public void LoadStyle(string path)
        {
            // TODO: Load style
            string? json = OSL_Utils.File.Read(path);
            if (json == null)
                return;
            var info = JsonConvert.DeserializeObject<List<List<FearlessInfo>>>(json);
            if (info != null)
            {
                FearlessStyle = info;
                UpdateInfoCss(info);
            }
            NotifyStateChanged();
        }

        public void SaveStyle(string path)
        {
            if (FearlessList.Count > 0)
            {
                FearlessStyle = [];
                foreach (var elem in FearlessList)
                {
                    FearlessStyle.Add([.. elem]);
                }

                foreach (var item in FearlessStyle)
                {
                    foreach (var champ in item[0].Champions)
                    {
                        champ.Image = string.Empty;
                    }
                    foreach (var champ in item[1].Champions)
                    {
                        champ.Image = string.Empty;
                    }
                }
            }

            if (FearlessStyle.Count == 0)
            {
                // TODO : no save
            }
            else if (FearlessStyle.Count == 1)
            {
                FearlessStyle.Add(FearlessStyle[0]);
                FearlessStyle.Add(FearlessStyle[0]);
            }
            else if (FearlessStyle.Count == 2)
            {
                FearlessStyle.Add(FearlessStyle[1]);
            }

            string json = JsonConvert.SerializeObject(FearlessStyle, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
            NotifyStateChanged();
        }
    }
}
