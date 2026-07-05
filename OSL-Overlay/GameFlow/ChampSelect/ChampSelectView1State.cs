using Newtonsoft.Json;

namespace OSL_Overlay.GameFlow.ChampSelect
{
    /// <summary>
    /// Champ Select View 1 management
    /// </summary>
    public class ChampSelectView1State
    {
        /// <summary>
        /// Champ Select global state
        /// </summary>
        private readonly ChampSelectState _ChampSelectState;
        /// <summary>
        /// Champ Select local info (data from global state)
        /// </summary>
        public ChampSelectInfo LocalInfo = new();
        /// <summary>
        /// Champ Select local style (data from style file)
        /// </summary>
        public ChampSelectInfo LocalInfoStyle = new();
        /// <summary>
        /// Curent style file path
        /// </summary>
        public string CurrentFile = "wwwroot/styles/champselect/view1/default.json";

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="champSelectState"></param>
        public ChampSelectView1State(ChampSelectState champSelectState)
        {
            _ChampSelectState = champSelectState;
            _ChampSelectState.OnChange += SyncFromGlobal;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// Sync local info from global state
        /// </summary>
        public void SyncFromGlobal()
        {
            LocalInfo = _ChampSelectState.Info.CloneInfo();
            LoadStyle(CurrentFile);
            NotifyStateChanged();
        }

        /// <summary>
        /// Load style from json file
        /// </summary>
        /// <param name="path"></param>
        public void LoadStyle(string path)
        {
            string? json = OSL_Utils.File.Read(path);
            if (json == null)
                return;
            var settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var info = JsonConvert.DeserializeObject<ChampSelectInfo>(json, settings);
            if (info != null)
            {
                CurrentFile = path;
                LocalInfoStyle = info;
                UpdateInfoCss();
            }
        }

        /// <summary>
        /// Save current style to json file
        /// </summary>
        /// <param name="path"></param>
        public void SaveStyle(string path)
        {
            string json = JsonConvert.SerializeObject(LocalInfo, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
            NotifyStateChanged();
        }

        /// <summary>
        /// Update local info css from local style
        /// </summary>
        public void UpdateInfoCss()
        {
            // General
            LocalInfo.Background = LocalInfoStyle.Background;
            LocalInfo.TeamsBackground = LocalInfoStyle.TeamsBackground;

            // Blue Team
            LocalInfo.BlueTeam.Side = LocalInfoStyle.BlueTeam.Side;
            LocalInfo.BlueTeam.Background = LocalInfoStyle.BlueTeam.Background;
            LocalInfo.BlueTeam.Name.Font = LocalInfoStyle.BlueTeam.Name.Font;
            LocalInfo.BlueTeam.Name.Color = LocalInfoStyle.BlueTeam.Name.Color;
            LocalInfo.BlueTeam.Tag.Font = LocalInfoStyle.BlueTeam.Tag.Font;
            LocalInfo.BlueTeam.Tag.Color = LocalInfoStyle.BlueTeam.Tag.Color;
            LocalInfo.BlueTeam.BoGraphic.Win.Font = LocalInfoStyle.BlueTeam.BoGraphic.Win.Font;
            LocalInfo.BlueTeam.BoGraphic.Win.Color = LocalInfoStyle.BlueTeam.BoGraphic.Win.Color;
            LocalInfo.BlueTeam.BoGraphic.Win.Background = LocalInfoStyle.BlueTeam.BoGraphic.Win.Background;
            LocalInfo.BlueTeam.BoGraphic.Win.Border = LocalInfoStyle.BlueTeam.BoGraphic.Win.Border;
            // Ban
            for (int i = 0; i < LocalInfoStyle.BlueTeam.Bans.Count; i++)
            {
                if (LocalInfo.BlueTeam.Bans.Count > i)
                {
                    LocalInfo.BlueTeam.Bans[i].BanImage = LocalInfoStyle.BlueTeam.Bans[i].BanImage;
                    LocalInfo.BlueTeam.Bans[i].BackgroundColor = LocalInfoStyle.BlueTeam.Bans[i].BackgroundColor;
                    LocalInfo.BlueTeam.Bans[i].BlinkColor = LocalInfoStyle.BlueTeam.Bans[i].BlinkColor;
                    LocalInfo.BlueTeam.Bans[i].BorderBanning = LocalInfoStyle.BlueTeam.Bans[i].BorderBanning;
                    LocalInfo.BlueTeam.Bans[i].Greyscale = LocalInfoStyle.BlueTeam.Bans[i].Greyscale;
                    LocalInfo.BlueTeam.Bans[i].BorderCompleted = LocalInfoStyle.BlueTeam.Bans[i].BorderCompleted;
                }
            }
            // Coach
            LocalInfo.BlueTeam.Coach.Show = LocalInfoStyle.BlueTeam.Coach.Show;
            LocalInfo.BlueTeam.Coach.Background = LocalInfoStyle.BlueTeam.Coach.Background;
            LocalInfo.BlueTeam.Coach.Border = LocalInfoStyle.BlueTeam.Coach.Border;
            LocalInfo.BlueTeam.Coach.Text.Txt = LocalInfoStyle.BlueTeam.Coach.Text.Txt;
            LocalInfo.BlueTeam.Coach.Text.Font = LocalInfoStyle.BlueTeam.Coach.Text.Font;
            LocalInfo.BlueTeam.Coach.Text.Color = LocalInfoStyle.BlueTeam.Coach.Text.Color;
            LocalInfo.BlueTeam.Coach.Name.Font = LocalInfoStyle.BlueTeam.Coach.Name.Font;
            LocalInfo.BlueTeam.Coach.Name.Color = LocalInfoStyle.BlueTeam.Coach.Name.Color;
            //Timer
            LocalInfo.BlueTeam.Timer.Direction = LocalInfoStyle.BlueTeam.Timer.Direction;
            LocalInfo.BlueTeam.Timer.BarColor = LocalInfoStyle.BlueTeam.Timer.BarColor;
            LocalInfo.BlueTeam.Timer.FillColor = LocalInfoStyle.BlueTeam.Timer.FillColor;
            // Picks
            for (int i = 0; i < LocalInfoStyle.BlueTeam.Picks.Count; i++)
            {
                if (LocalInfo.BlueTeam.Picks.Count > i)
                {
                    LocalInfo.BlueTeam.Picks[i].BorderImage = LocalInfoStyle.BlueTeam.Picks[i].BorderImage;
                    LocalInfo.BlueTeam.Picks[i].LaneImage = LocalInfoStyle.BlueTeam.Picks[i].LaneImage;
                    LocalInfo.BlueTeam.Picks[i].BlinkColor = LocalInfoStyle.BlueTeam.Picks[i].BlinkColor;
                    LocalInfo.BlueTeam.Picks[i].Name.Font = LocalInfoStyle.BlueTeam.Picks[i].Name.Font;
                    LocalInfo.BlueTeam.Picks[i].Name.Color = LocalInfoStyle.BlueTeam.Picks[i].Name.Color;
                    LocalInfo.BlueTeam.Picks[i].Action.Font = LocalInfoStyle.BlueTeam.Picks[i].Action.Font;
                    LocalInfo.BlueTeam.Picks[i].Action.Color = LocalInfoStyle.BlueTeam.Picks[i].Action.Color;
                }
            }
            // Bo
            LocalInfo.BlueTeam.BoGraphic.Show = LocalInfoStyle.BlueTeam.BoGraphic.Show;
            LocalInfo.BlueTeam.BoGraphic.Win.Color = LocalInfoStyle.BlueTeam.BoGraphic.Win.Color;
            LocalInfo.BlueTeam.BoGraphic.Win.Background = LocalInfoStyle.BlueTeam.BoGraphic.Win.Background;
            LocalInfo.BlueTeam.BoGraphic.Win.Border = LocalInfoStyle.BlueTeam.BoGraphic.Win.Border;
            LocalInfo.BlueTeam.BoGraphic.Undef.Color = LocalInfoStyle.BlueTeam.BoGraphic.Undef.Color;
            LocalInfo.BlueTeam.BoGraphic.Undef.Background = LocalInfoStyle.BlueTeam.BoGraphic.Undef.Background;
            LocalInfo.BlueTeam.BoGraphic.Undef.Border = LocalInfoStyle.BlueTeam.BoGraphic.Undef.Border;
            // Team info
            LocalInfo.BlueTeam.ShowLogo = LocalInfoStyle.BlueTeam.ShowLogo;
            LocalInfo.BlueTeam.ShowTag = LocalInfoStyle.BlueTeam.ShowTag;
            LocalInfo.BlueTeam.ShowName = LocalInfoStyle.BlueTeam.ShowName;

            // Red Team
            LocalInfo.RedTeam.Side = LocalInfoStyle.RedTeam.Side;
            LocalInfo.RedTeam.Background = LocalInfoStyle.RedTeam.Background;
            LocalInfo.RedTeam.Name.Font = LocalInfoStyle.RedTeam.Name.Font;
            LocalInfo.RedTeam.Name.Color = LocalInfoStyle.RedTeam.Name.Color;
            LocalInfo.RedTeam.Tag.Font = LocalInfoStyle.RedTeam.Tag.Font;
            LocalInfo.RedTeam.Tag.Color = LocalInfoStyle.RedTeam.Tag.Color;
            LocalInfo.RedTeam.BoGraphic.Win.Font = LocalInfoStyle.RedTeam.BoGraphic.Win.Font;
            LocalInfo.RedTeam.BoGraphic.Win.Color = LocalInfoStyle.RedTeam.BoGraphic.Win.Color;
            LocalInfo.RedTeam.BoGraphic.Win.Background = LocalInfoStyle.RedTeam.BoGraphic.Win.Background;
            LocalInfo.RedTeam.BoGraphic.Win.Border = LocalInfoStyle.RedTeam.BoGraphic.Win.Border;
            // Ban
            for (int i = 0; i < LocalInfoStyle.RedTeam.Bans.Count; i++)
            {
                if (LocalInfo.RedTeam.Bans.Count > i)
                {
                    LocalInfo.RedTeam.Bans[i].BanImage = LocalInfoStyle.RedTeam.Bans[i].BanImage;
                    LocalInfo.RedTeam.Bans[i].BackgroundColor = LocalInfoStyle.RedTeam.Bans[i].BackgroundColor;
                    LocalInfo.RedTeam.Bans[i].BlinkColor = LocalInfoStyle.RedTeam.Bans[i].BlinkColor;
                    LocalInfo.RedTeam.Bans[i].BorderBanning = LocalInfoStyle.RedTeam.Bans[i].BorderBanning;
                    LocalInfo.RedTeam.Bans[i].Greyscale = LocalInfoStyle.RedTeam.Bans[i].Greyscale;
                    LocalInfo.RedTeam.Bans[i].BorderCompleted = LocalInfoStyle.RedTeam.Bans[i].BorderCompleted;
                }
            }
            // Coach
            LocalInfo.RedTeam.Coach.Show = LocalInfoStyle.RedTeam.Coach.Show;
            LocalInfo.RedTeam.Coach.Background = LocalInfoStyle.RedTeam.Coach.Background;
            LocalInfo.RedTeam.Coach.Border = LocalInfoStyle.RedTeam.Coach.Border;
            LocalInfo.RedTeam.Coach.Text.Txt = LocalInfoStyle.RedTeam.Coach.Text.Txt;
            LocalInfo.RedTeam.Coach.Text.Font = LocalInfoStyle.RedTeam.Coach.Text.Font;
            LocalInfo.RedTeam.Coach.Text.Color = LocalInfoStyle.RedTeam.Coach.Text.Color;
            LocalInfo.RedTeam.Coach.Name.Font = LocalInfoStyle.RedTeam.Coach.Name.Font;
            LocalInfo.RedTeam.Coach.Name.Color = LocalInfoStyle.RedTeam.Coach.Name.Color;
            //Timer
            LocalInfo.RedTeam.Timer.Direction = LocalInfoStyle.RedTeam.Timer.Direction;
            LocalInfo.RedTeam.Timer.BarColor = LocalInfoStyle.RedTeam.Timer.BarColor;
            LocalInfo.RedTeam.Timer.FillColor = LocalInfoStyle.RedTeam.Timer.FillColor;
            // Picks
            for (int i = 0; i < LocalInfoStyle.RedTeam.Picks.Count; i++)
            {
                if (LocalInfo.RedTeam.Picks.Count > i)
                {
                    LocalInfo.RedTeam.Picks[i].BorderImage = LocalInfoStyle.RedTeam.Picks[i].BorderImage;
                    LocalInfo.RedTeam.Picks[i].LaneImage = LocalInfoStyle.RedTeam.Picks[i].LaneImage;
                    LocalInfo.RedTeam.Picks[i].BlinkColor = LocalInfoStyle.RedTeam.Picks[i].BlinkColor;
                    LocalInfo.RedTeam.Picks[i].Name.Font = LocalInfoStyle.RedTeam.Picks[i].Name.Font;
                    LocalInfo.RedTeam.Picks[i].Name.Color = LocalInfoStyle.RedTeam.Picks[i].Name.Color;
                    LocalInfo.RedTeam.Picks[i].Action.Font = LocalInfoStyle.RedTeam.Picks[i].Action.Font;
                    LocalInfo.RedTeam.Picks[i].Action.Color = LocalInfoStyle.RedTeam.Picks[i].Action.Color;
                }
            }
            // Bo
            LocalInfo.RedTeam.BoGraphic.Show = LocalInfoStyle.RedTeam.BoGraphic.Show;
            LocalInfo.RedTeam.BoGraphic.Win.Color = LocalInfoStyle.RedTeam.BoGraphic.Win.Color;
            LocalInfo.RedTeam.BoGraphic.Win.Background = LocalInfoStyle.RedTeam.BoGraphic.Win.Background;
            LocalInfo.RedTeam.BoGraphic.Win.Border = LocalInfoStyle.RedTeam.BoGraphic.Win.Border;
            LocalInfo.RedTeam.BoGraphic.Undef.Color = LocalInfoStyle.RedTeam.BoGraphic.Undef.Color;
            LocalInfo.RedTeam.BoGraphic.Undef.Background = LocalInfoStyle.RedTeam.BoGraphic.Undef.Background;
            LocalInfo.RedTeam.BoGraphic.Undef.Border = LocalInfoStyle.RedTeam.BoGraphic.Undef.Border;
            // Team info
            LocalInfo.RedTeam.ShowLogo = LocalInfoStyle.RedTeam.ShowLogo;
            LocalInfo.RedTeam.ShowTag = LocalInfoStyle.RedTeam.ShowTag;
            LocalInfo.RedTeam.ShowName = LocalInfoStyle.RedTeam.ShowName;

            // Patch
            LocalInfo.Patch.Show = LocalInfoStyle.Patch.Show;
            LocalInfo.Patch.BackgroundColor = LocalInfoStyle.Patch.BackgroundColor;
            LocalInfo.Patch.BorderColor = LocalInfoStyle.Patch.BorderColor;
            LocalInfo.Patch.PatchInfo.Font = LocalInfoStyle.Patch.PatchInfo.Font;
            LocalInfo.Patch.PatchInfo.Color = LocalInfoStyle.Patch.PatchInfo.Color;
            LocalInfo.Patch.Version.Font = LocalInfoStyle.Patch.Version.Font;
            LocalInfo.Patch.Version.Color = LocalInfoStyle.Patch.Version.Color;

            // Common Timer
            LocalInfo.CommonTimer.Direction = LocalInfoStyle.CommonTimer.Direction;
            LocalInfo.CommonTimer.BarColor = LocalInfoStyle.CommonTimer.BarColor;
            LocalInfo.CommonTimer.FillColor = LocalInfoStyle.CommonTimer.FillColor;

            // Phase
            LocalInfo.PhaseInfo.Phase.Font = LocalInfoStyle.PhaseInfo.Phase.Font;
            LocalInfo.PhaseInfo.Phase.Color = LocalInfoStyle.PhaseInfo.Phase.Color;

            // VS
            LocalInfo.Vs.Font = LocalInfoStyle.Vs.Font;
            LocalInfo.Vs.Color = LocalInfoStyle.Vs.Color;
            NotifyStateChanged();
        }
    }
}
