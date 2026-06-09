using Newtonsoft.Json;

namespace OSL_Overlay.GameFlow.Rune
{
    public class RuneView1State
    {
        private readonly RuneState _runeState;

        public RuneInfo LocalInfo = new();

        public RuneInfo LocalInfoStyle = new();

        public string CurrentFile = "wwwroot/styles/rune/view1/default.json";

        public event Action? OnChange;

        public RuneView1State(RuneState runeState)
        {
            _runeState = runeState;
            _runeState.OnChange += SyncFromGlobal;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        public void SyncFromGlobal()
        {
            LocalInfo = _runeState.Info.CloneInfo();
            LoadStyle(CurrentFile);
            NotifyStateChanged();
        }

        public void LoadStyle(string path)
        {
            string? json = OSL_Utils.File.Read(path);
            if (json == null)
                return;
            var settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var info = JsonConvert.DeserializeObject<RuneInfo>(json, settings);
            if (info != null)
            {
                CurrentFile = path;
                LocalInfoStyle = info;
                UpdateInfoCss();
            }
        }

        public void SaveStyle(string path)
        {
            string json = JsonConvert.SerializeObject(LocalInfo, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
            NotifyStateChanged();
        }

        public void UpdateInfoCss()
        {
            LocalInfo.BackgroundImage = LocalInfoStyle.BackgroundImage;
            LocalInfo.BackgroundColor = LocalInfoStyle.BackgroundColor;
            LocalInfo.Border = LocalInfoStyle.Border;
            LocalInfo.Title = LocalInfoStyle.Title;
            for (int i = 0; i < LocalInfo.BlueTeam.Count; i++)
            {
                LocalInfo.BlueTeam[i].Background = LocalInfoStyle.BlueTeam[i].Background;
                LocalInfo.BlueTeam[i].Border = LocalInfoStyle.BlueTeam[i].Border;
                LocalInfo.BlueTeam[i].Name.Color = LocalInfoStyle.BlueTeam[i].Name.Color;
                LocalInfo.BlueTeam[i].Name.Font = LocalInfoStyle.BlueTeam[i].Name.Font;
                LocalInfo.BlueTeam[i].Name.Background = LocalInfoStyle.BlueTeam[i].Name.Background;
                LocalInfo.BlueTeam[i].Name.Border = LocalInfoStyle.BlueTeam[i].Name.Border;
                LocalInfo.BlueTeam[i].Avatar.Background = LocalInfoStyle.BlueTeam[i].Avatar.Background;
                LocalInfo.BlueTeam[i].Avatar.Border = LocalInfoStyle.BlueTeam[i].Avatar.Border;
            }
            for (int i = 0; i < LocalInfo.RedTeam.Count; i++)
            {
                LocalInfo.RedTeam[i].Background = LocalInfoStyle.RedTeam[i].Background;
                LocalInfo.RedTeam[i].Border = LocalInfoStyle.RedTeam[i].Border;
                LocalInfo.RedTeam[i].Name.Color = LocalInfoStyle.RedTeam[i].Name.Color;
                LocalInfo.RedTeam[i].Name.Font = LocalInfoStyle.RedTeam[i].Name.Font;
                LocalInfo.RedTeam[i].Name.Background = LocalInfoStyle.RedTeam[i].Name.Background;
                LocalInfo.RedTeam[i].Name.Border = LocalInfoStyle.RedTeam[i].Name.Border;
                LocalInfo.RedTeam[i].Avatar.Background = LocalInfoStyle.RedTeam[i].Avatar.Background;
                LocalInfo.RedTeam[i].Avatar.Border = LocalInfoStyle.RedTeam[i].Avatar.Border;
            }
        }
    }
}
