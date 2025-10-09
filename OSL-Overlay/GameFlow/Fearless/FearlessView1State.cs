using Newtonsoft.Json;

namespace OSL_Overlay.GameFlow.Fearless
{
    public class FearlessView1State
    {
        public List<List<FearlessInfo>> LocalFearlessList { get; private set; } = [];
        private List<List<FearlessInfo>> LocalFearlessStyle { get; set; } = [];
        private readonly FearlessState _fearlessState;
        public string CurrentFile = "wwwroot/styles/fearless/view1/default.json";
        public event Action? OnChange;

        public FearlessView1State(FearlessState fearlessState)
        {
            _fearlessState = fearlessState;
            _fearlessState.OnChange += SyncFromGlobal;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        public void SyncFromGlobal()
        {
            LocalFearlessList = _fearlessState.FearlessList.CloneFirelessList();
            LoadStyle(CurrentFile);
            NotifyStateChanged();
        }

        // Mettre ces fonctions dans FearlessState.cs
        public void LoadStyle(string path)
        {
            string? json = OSL_Utils.File.Read(path);
            if (json == null)
                return;
            var info = JsonConvert.DeserializeObject<List<List<FearlessInfo>>>(json);
            if (info != null)
            {
                CurrentFile = path;
                LocalFearlessStyle = info;
                UpdateInfoCss();
            }
        }

        public void SaveStyle(string path)
        {
            List<List<FearlessInfo>> fearlessStyle = LocalFearlessList.CloneFirelessList();

            if (LocalFearlessList.Count > 0)
            {
                foreach (var item in fearlessStyle)
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

            if (fearlessStyle.Count == 0)
            {
                // TODO : no save
            }
            else if (fearlessStyle.Count == 1)
            {
                fearlessStyle.Add(fearlessStyle[0]);
                fearlessStyle.Add(fearlessStyle[0]);
            }
            else if (fearlessStyle.Count == 2)
            {
                fearlessStyle.Add(fearlessStyle[1]);
            }

            string json = JsonConvert.SerializeObject(fearlessStyle, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
            NotifyStateChanged();
        }

        public void UpdateInfoCss()
        {
            for (int i = 0; i < LocalFearlessStyle.Count; i++)
            {
                for (int j = 0; j < LocalFearlessStyle[i].Count; j++)
                {
                    if (LocalFearlessList.Count > i && LocalFearlessList[i].Count > j)
                    {
                        LocalFearlessList[i][j].Text.Txt = LocalFearlessStyle[i][j].Text.Txt;
                        LocalFearlessList[i][j].Text.Color = LocalFearlessStyle[i][j].Text.Color;
                        LocalFearlessList[i][j].Text.Font = LocalFearlessStyle[i][j].Text.Font;
                        LocalFearlessList[i][j].Text.Background = LocalFearlessStyle[i][j].Text.Background;
                        LocalFearlessList[i][j].Text.Border = LocalFearlessStyle[i][j].Text.Border;
                        LocalFearlessList[i][j].Text.Align = LocalFearlessStyle[i][j].Text.Align;
                        LocalFearlessList[i][j].Background = LocalFearlessStyle[i][j].Background;
                        LocalFearlessList[i][j].Line.Background = LocalFearlessStyle[i][j].Line.Background;
                        LocalFearlessList[i][j].Border = LocalFearlessStyle[i][j].Border;
                        for (int k = 0; k < LocalFearlessStyle[i][j].Champions.Count; k++)
                        {
                            if (LocalFearlessList[i][j].Champions.Count > k)
                            {
                                LocalFearlessList[i][j].Champions[k].Border = LocalFearlessStyle[i][j].Champions[k].Border;
                                LocalFearlessList[i][j].Champions[k].Lane.Border = LocalFearlessStyle[i][j].Champions[k].Lane.Border;
                                LocalFearlessList[i][j].Champions[k].Greyscale = LocalFearlessStyle[i][j].Champions[k].Greyscale;
                                LocalFearlessList[i][j].Champions[k].Cross.Image = LocalFearlessStyle[i][j].Champions[k].Cross.Image;
                                LocalFearlessList[i][j].Champions[k].Cross.GraphicLineColor = LocalFearlessStyle[i][j].Champions[k].Cross.GraphicLineColor;
                                LocalFearlessList[i][j].Champions[k].Cross.GraphicCrossColor = LocalFearlessStyle[i][j].Champions[k].Cross.GraphicCrossColor;
                                LocalFearlessList[i][j].Champions[k].Cross.Width = LocalFearlessStyle[i][j].Champions[k].Cross.Width;
                                LocalFearlessList[i][j].Champions[k].Cross.Height = LocalFearlessStyle[i][j].Champions[k].Cross.Height;
                                LocalFearlessList[i][j].Champions[k].Cross.Rotate = LocalFearlessStyle[i][j].Champions[k].Cross.Rotate;
                            }
                        }
                    }
                }
            }
            NotifyStateChanged();
        }
    }
}
