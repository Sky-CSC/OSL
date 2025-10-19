using Newtonsoft.Json;

namespace OSL_Overlay.GameFlow.EndGame
{
    /// <summary>
    /// End game view 1 state management
    /// </summary>
    public class EndGameView1State
    {
        /// <summary>
        /// End game global state
        /// </summary>
        private readonly EndGameState _endgameState;
        /// <summary>
        /// End game local info
        /// </summary>
        public EndGameInfo LocalInfo = new();
        /// <summary>
        /// End game local style info
        /// </summary>
        public EndGameInfo LocalInfoStyle = new();
        /// <summary>
        /// File currently loaded
        /// </summary>
        public string CurrentFile = "wwwroot/styles/endgame/view1/default.json";
        public event Action? OnChange;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="endGameState"></param>
        public EndGameView1State(EndGameState endGameState)
        {
            _endgameState = endGameState;
            _endgameState.OnChange += SyncFromGlobal;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        /// <summary>
        /// Synchronize local info from global info
        /// </summary>
        public void SyncFromGlobal()
        {
            LocalInfo = _endgameState.Info.CloneInfo();
            LoadStyle(CurrentFile);
            NotifyStateChanged();
        }

        /// <summary>
        /// Load style from a json file
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
            var info = JsonConvert.DeserializeObject<EndGameInfo>(json, settings);
            Console.WriteLine(info.ChampionStats.Background);
            if (info != null)
            {
                CurrentFile = path;
                LocalInfoStyle = info;
                UpdateInfoCss();
            }
        }

        /// <summary>
        /// Save style to a json file
        /// </summary>
        /// <param name="path"></param>
        public void SaveStyle(string path)
        {
            string json = JsonConvert.SerializeObject(LocalInfo, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
            NotifyStateChanged();
        }

        /// <summary>
        /// Update local info css from local style info
        /// </summary>
        public void UpdateInfoCss()
        {
            // Général background
            LocalInfo.Background = LocalInfoStyle.Background;
            LocalInfo.Border = LocalInfoStyle.Border;
            LocalInfo.StatsBackground = LocalInfoStyle.StatsBackground;
            LocalInfo.StatsBorder = LocalInfoStyle.StatsBorder;

            // TimerTeamsHeadband
            LocalInfo.TimerTeamsHeadband.Background = LocalInfoStyle.TimerTeamsHeadband.Background;
            LocalInfo.TimerTeamsHeadband.Border = LocalInfoStyle.TimerTeamsHeadband.Border;
            // Title
            LocalInfo.TimerTeamsHeadband.Title.Txt = LocalInfoStyle.TimerTeamsHeadband.Title.Txt;
            LocalInfo.TimerTeamsHeadband.Title.Font = LocalInfoStyle.TimerTeamsHeadband.Title.Font;
            LocalInfo.TimerTeamsHeadband.Title.Color = LocalInfoStyle.TimerTeamsHeadband.Title.Color;
            // Timer
            LocalInfo.TimerTeamsHeadband.Timer.Font = LocalInfoStyle.TimerTeamsHeadband.Timer.Font;
            LocalInfo.TimerTeamsHeadband.Timer.Color = LocalInfoStyle.TimerTeamsHeadband.Timer.Color;
            // Win
            LocalInfo.TimerTeamsHeadband.WinText.Txt = LocalInfoStyle.TimerTeamsHeadband.WinText.Txt;
            LocalInfo.TimerTeamsHeadband.WinText.Font = LocalInfoStyle.TimerTeamsHeadband.WinText.Font;
            LocalInfo.TimerTeamsHeadband.WinText.Color = LocalInfoStyle.TimerTeamsHeadband.WinText.Color;
            LocalInfo.TimerTeamsHeadband.WinText.Border = LocalInfoStyle.TimerTeamsHeadband.WinText.Border;
            // Loss
            LocalInfo.TimerTeamsHeadband.LossText.Txt = LocalInfoStyle.TimerTeamsHeadband.LossText.Txt;
            LocalInfo.TimerTeamsHeadband.LossText.Font = LocalInfoStyle.TimerTeamsHeadband.LossText.Font;
            LocalInfo.TimerTeamsHeadband.LossText.Color = LocalInfoStyle.TimerTeamsHeadband.LossText.Color;
            LocalInfo.TimerTeamsHeadband.LossText.Border = LocalInfoStyle.TimerTeamsHeadband.LossText.Border;
            // Blue Team
            LocalInfo.TimerTeamsHeadband.BlueTeam.Side = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Side;
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowLogo = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowLogo;
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowName = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowName;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Name.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Name.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Name.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Name.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowTag = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowTag;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Tag.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Tag.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Tag.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Tag.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Show = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Show;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Background = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Background;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Border = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Border;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Background = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Background;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Border = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Undef.Border;
            // Red Team
            LocalInfo.TimerTeamsHeadband.RedTeam.Side = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Side;
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowLogo = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowLogo;
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowName = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowName;
            LocalInfo.TimerTeamsHeadband.RedTeam.Name.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Name.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.Name.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Name.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowTag = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowTag;
            LocalInfo.TimerTeamsHeadband.RedTeam.Tag.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Tag.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.Tag.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Tag.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Show = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Show;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Background = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Background;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Border = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Border;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Background = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Background;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Border = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Undef.Border;

            // Game Stats
            LocalInfo.GameStats.Background = LocalInfoStyle.GameStats.Background;
            LocalInfo.GameStats.Border = LocalInfoStyle.GameStats.Border;
            // Title
            LocalInfo.GameStats.Title.Txt = LocalInfoStyle.GameStats.Title.Txt;
            LocalInfo.GameStats.Title.Font = LocalInfoStyle.GameStats.Title.Font;
            LocalInfo.GameStats.Title.Color = LocalInfoStyle.GameStats.Title.Color;
            // KDA
            LocalInfo.GameStats.Kda.Background = LocalInfoStyle.GameStats.Kda.Background;
            LocalInfo.GameStats.Kda.Border = LocalInfoStyle.GameStats.Kda.Border;
            LocalInfo.GameStats.Kda.Title.Txt = LocalInfoStyle.GameStats.Kda.Title.Txt;
            LocalInfo.GameStats.Kda.Title.Font = LocalInfoStyle.GameStats.Kda.Title.Font;
            LocalInfo.GameStats.Kda.Title.Color = LocalInfoStyle.GameStats.Kda.Title.Color;
            LocalInfo.GameStats.Kda.BlueTeam.Font = LocalInfoStyle.GameStats.Kda.BlueTeam.Font;
            LocalInfo.GameStats.Kda.BlueTeam.Color = LocalInfoStyle.GameStats.Kda.BlueTeam.Color;
            LocalInfo.GameStats.Kda.RedTeam.Font = LocalInfoStyle.GameStats.Kda.RedTeam.Font;
            LocalInfo.GameStats.Kda.RedTeam.Color = LocalInfoStyle.GameStats.Kda.RedTeam.Color;
            // Golds
            LocalInfo.GameStats.Golds.Background = LocalInfoStyle.GameStats.Golds.Background;
            LocalInfo.GameStats.Golds.Border = LocalInfoStyle.GameStats.Golds.Border;
            LocalInfo.GameStats.Golds.Title.Txt = LocalInfoStyle.GameStats.Golds.Title.Txt;
            LocalInfo.GameStats.Golds.Title.Font = LocalInfoStyle.GameStats.Golds.Title.Font;
            LocalInfo.GameStats.Golds.Title.Color = LocalInfoStyle.GameStats.Golds.Title.Color;
            LocalInfo.GameStats.Golds.BlueTeam.Font = LocalInfoStyle.GameStats.Golds.BlueTeam.Font;
            LocalInfo.GameStats.Golds.BlueTeam.Color = LocalInfoStyle.GameStats.Golds.BlueTeam.Color;
            LocalInfo.GameStats.Golds.RedTeam.Font = LocalInfoStyle.GameStats.Golds.RedTeam.Font;
            LocalInfo.GameStats.Golds.RedTeam.Color = LocalInfoStyle.GameStats.Golds.RedTeam.Color;
            // Towers
            LocalInfo.GameStats.Towers.Background = LocalInfoStyle.GameStats.Towers.Background;
            LocalInfo.GameStats.Towers.Border = LocalInfoStyle.GameStats.Towers.Border;
            LocalInfo.GameStats.Towers.Title.Txt = LocalInfoStyle.GameStats.Towers.Title.Txt;
            LocalInfo.GameStats.Towers.Title.Font = LocalInfoStyle.GameStats.Towers.Title.Font;
            LocalInfo.GameStats.Towers.Title.Color = LocalInfoStyle.GameStats.Towers.Title.Color;
            LocalInfo.GameStats.Towers.BlueTeam.Font = LocalInfoStyle.GameStats.Towers.BlueTeam.Font;
            LocalInfo.GameStats.Towers.BlueTeam.Color = LocalInfoStyle.GameStats.Towers.BlueTeam.Color;
            LocalInfo.GameStats.Towers.RedTeam.Font = LocalInfoStyle.GameStats.Towers.RedTeam.Font;
            LocalInfo.GameStats.Towers.RedTeam.Color = LocalInfoStyle.GameStats.Towers.RedTeam.Color;
            // VoidGrubs
            LocalInfo.GameStats.VoidGrubs.Background = LocalInfoStyle.GameStats.VoidGrubs.Background;
            LocalInfo.GameStats.VoidGrubs.Border = LocalInfoStyle.GameStats.VoidGrubs.Border;
            LocalInfo.GameStats.VoidGrubs.Title.Txt = LocalInfoStyle.GameStats.VoidGrubs.Title.Txt;
            LocalInfo.GameStats.VoidGrubs.Title.Font = LocalInfoStyle.GameStats.VoidGrubs.Title.Font;
            LocalInfo.GameStats.VoidGrubs.Title.Color = LocalInfoStyle.GameStats.VoidGrubs.Title.Color;
            LocalInfo.GameStats.VoidGrubs.Image.Path = LocalInfoStyle.GameStats.VoidGrubs.Image.Path;
            // Herald
            LocalInfo.GameStats.Herald.Background = LocalInfoStyle.GameStats.Herald.Background;
            LocalInfo.GameStats.Herald.Border = LocalInfoStyle.GameStats.Herald.Border;
            LocalInfo.GameStats.Herald.Title.Txt = LocalInfoStyle.GameStats.Herald.Title.Txt;
            LocalInfo.GameStats.Herald.Title.Font = LocalInfoStyle.GameStats.Herald.Title.Font;
            LocalInfo.GameStats.Herald.Title.Color = LocalInfoStyle.GameStats.Herald.Title.Color;
            LocalInfo.GameStats.Herald.Image.Path = LocalInfoStyle.GameStats.Herald.Image.Path;
            // Atakhan
            LocalInfo.GameStats.Atakhan.Background = LocalInfoStyle.GameStats.Atakhan.Background;
            LocalInfo.GameStats.Atakhan.Border = LocalInfoStyle.GameStats.Atakhan.Border;
            LocalInfo.GameStats.Atakhan.Title.Txt = LocalInfoStyle.GameStats.Atakhan.Title.Txt;
            LocalInfo.GameStats.Atakhan.Title.Font = LocalInfoStyle.GameStats.Atakhan.Title.Font;
            LocalInfo.GameStats.Atakhan.Title.Color = LocalInfoStyle.GameStats.Atakhan.Title.Color;
            LocalInfo.GameStats.Atakhan.Image.Path = LocalInfoStyle.GameStats.Atakhan.Image.Path;
            //Drakes
            LocalInfo.GameStats.Drakes.Background = LocalInfoStyle.GameStats.Drakes.Background;
            LocalInfo.GameStats.Drakes.Border = LocalInfoStyle.GameStats.Drakes.Border;
            LocalInfo.GameStats.Drakes.Title.Txt = LocalInfoStyle.GameStats.Drakes.Title.Txt;
            LocalInfo.GameStats.Drakes.Title.Font = LocalInfoStyle.GameStats.Drakes.Title.Font;
            LocalInfo.GameStats.Drakes.Title.Color = LocalInfoStyle.GameStats.Drakes.Title.Color;
            LocalInfo.GameStats.Drakes.Air.Image.Path = LocalInfoStyle.GameStats.Drakes.Air.Image.Path;
            LocalInfo.GameStats.Drakes.Chemtech.Image.Path = LocalInfoStyle.GameStats.Drakes.Chemtech.Image.Path;
            LocalInfo.GameStats.Drakes.Earth.Image.Path = LocalInfoStyle.GameStats.Drakes.Earth.Image.Path;
            LocalInfo.GameStats.Drakes.Fire.Image.Path = LocalInfoStyle.GameStats.Drakes.Fire.Image.Path;
            LocalInfo.GameStats.Drakes.Hextech.Image.Path = LocalInfoStyle.GameStats.Drakes.Hextech.Image.Path;
            LocalInfo.GameStats.Drakes.Water.Image.Path = LocalInfoStyle.GameStats.Drakes.Water.Image.Path;
            // Elders
            LocalInfo.GameStats.Elders.Background = LocalInfoStyle.GameStats.Elders.Background;
            LocalInfo.GameStats.Elders.Border = LocalInfoStyle.GameStats.Elders.Border;
            LocalInfo.GameStats.Elders.Title.Txt = LocalInfoStyle.GameStats.Elders.Title.Txt;
            LocalInfo.GameStats.Elders.Title.Font = LocalInfoStyle.GameStats.Elders.Title.Font;
            LocalInfo.GameStats.Elders.Title.Color = LocalInfoStyle.GameStats.Elders.Title.Color;
            LocalInfo.GameStats.Elders.Image.Path = LocalInfoStyle.GameStats.Elders.Image.Path;
            // Barons
            LocalInfo.GameStats.Barons.Background = LocalInfoStyle.GameStats.Barons.Background;
            LocalInfo.GameStats.Barons.Border = LocalInfoStyle.GameStats.Barons.Border;
            LocalInfo.GameStats.Barons.Title.Txt = LocalInfoStyle.GameStats.Barons.Title.Txt;
            LocalInfo.GameStats.Barons.Title.Font = LocalInfoStyle.GameStats.Barons.Title.Font;
            LocalInfo.GameStats.Barons.Title.Color = LocalInfoStyle.GameStats.Barons.Title.Color;
            LocalInfo.GameStats.Barons.Image.Path = LocalInfoStyle.GameStats.Barons.Image.Path;

            //Champion Stats
            LocalInfo.ChampionStats.Background = LocalInfoStyle.ChampionStats.Background;
            LocalInfo.ChampionStats.Border = LocalInfoStyle.ChampionStats.Border;
            LocalInfo.ChampionStats.Title.Font = LocalInfoStyle.ChampionStats.Title.Font;
            LocalInfo.ChampionStats.Title.Color = LocalInfoStyle.ChampionStats.Title.Color;
            for (int i = 0; i < LocalInfoStyle.ChampionStats.BlueTeam.Count; i++)
            {
                if (LocalInfo.ChampionStats.BlueTeam.Count > i)
                {
                    LocalInfo.ChampionStats.BlueTeam[i].Image.Border = LocalInfoStyle.ChampionStats.BlueTeam[i].Image.Border;
                    LocalInfo.ChampionStats.BlueTeam[i].Name.Font = LocalInfoStyle.ChampionStats.BlueTeam[i].Name.Font;
                    LocalInfo.ChampionStats.BlueTeam[i].Name.Color = LocalInfoStyle.ChampionStats.BlueTeam[i].Name.Color;
                    LocalInfo.ChampionStats.BlueTeam[i].Stat.Font = LocalInfoStyle.ChampionStats.BlueTeam[i].Stat.Font;
                    LocalInfo.ChampionStats.BlueTeam[i].Stat.Color = LocalInfoStyle.ChampionStats.BlueTeam[i].Stat.Color;
                    LocalInfo.ChampionStats.BlueTeam[i].Bar.Background = LocalInfoStyle.ChampionStats.BlueTeam[i].Bar.Background;
                    LocalInfo.ChampionStats.BlueTeam[i].Bar.Border = LocalInfoStyle.ChampionStats.BlueTeam[i].Bar.Border;
                }
            }
            for (int i = 0; i < LocalInfoStyle.ChampionStats.RedTeam.Count; i++)
            {
                if (LocalInfo.ChampionStats.RedTeam.Count > i)
                {
                    LocalInfo.ChampionStats.RedTeam[i].Image.Border = LocalInfoStyle.ChampionStats.RedTeam[i].Image.Border;
                    LocalInfo.ChampionStats.RedTeam[i].Name.Font = LocalInfoStyle.ChampionStats.RedTeam[i].Name.Font;
                    LocalInfo.ChampionStats.RedTeam[i].Name.Color = LocalInfoStyle.ChampionStats.RedTeam[i].Name.Color;
                    LocalInfo.ChampionStats.RedTeam[i].Stat.Font = LocalInfoStyle.ChampionStats.RedTeam[i].Stat.Font;
                    LocalInfo.ChampionStats.RedTeam[i].Stat.Color = LocalInfoStyle.ChampionStats.RedTeam[i].Stat.Color;
                    LocalInfo.ChampionStats.RedTeam[i].Bar.Background = LocalInfoStyle.ChampionStats.RedTeam[i].Bar.Background;
                    LocalInfo.ChampionStats.RedTeam[i].Bar.Border = LocalInfoStyle.ChampionStats.RedTeam[i].Bar.Border;
                }
            }

            // Bans
            LocalInfo.Bans.Background = LocalInfoStyle.Bans.Background;
            LocalInfo.Bans.Border = LocalInfoStyle.Bans.Border;
            LocalInfo.Bans.Title.Txt = LocalInfoStyle.Bans.Title.Txt;
            LocalInfo.Bans.Title.Font = LocalInfoStyle.Bans.Title.Font;
            LocalInfo.Bans.Title.Color = LocalInfoStyle.Bans.Title.Color;
            for (int i = 0; i < LocalInfoStyle.Bans.BlueTeam.Count; i++)
            {
                if (LocalInfo.Bans.BlueTeam.Count > i)
                {
                    LocalInfo.Bans.BlueTeam[i].Border = LocalInfoStyle.Bans.BlueTeam[i].Border;
                }
            }
            for (int i = 0; i < LocalInfoStyle.Bans.RedTeam.Count; i++)
            {
                if (LocalInfo.Bans.RedTeam.Count > i)
                {
                    LocalInfo.Bans.RedTeam[i].Border = LocalInfoStyle.Bans.RedTeam[i].Border;
                }
            }

            // Golds
            LocalInfo.Golds.Background = LocalInfoStyle.Golds.Background;
            LocalInfo.Golds.Border = LocalInfoStyle.Golds.Border;
            LocalInfo.Golds.Title.Txt = LocalInfoStyle.Golds.Title.Txt;
            LocalInfo.Golds.Title.Font = LocalInfoStyle.Golds.Title.Font;
            LocalInfo.Golds.Title.Color = LocalInfoStyle.Golds.Title.Color;
            LocalInfo.Golds.BlueGoldsColor = LocalInfoStyle.Golds.BlueGoldsColor;
            LocalInfo.Golds.BlueText.Font = LocalInfoStyle.Golds.BlueText.Font;
            LocalInfo.Golds.BlueText.Color = LocalInfoStyle.Golds.BlueText.Color;
            LocalInfo.Golds.RedGoldsColor = LocalInfoStyle.Golds.RedGoldsColor;
            LocalInfo.Golds.RedText.Font = LocalInfoStyle.Golds.RedText.Font;
            LocalInfo.Golds.RedText.Color = LocalInfoStyle.Golds.RedText.Color;
            LocalInfo.Golds.CommonGoldsColor = LocalInfoStyle.Golds.CommonGoldsColor;
            LocalInfo.Golds.CommonText.Font = LocalInfoStyle.Golds.CommonText.Font;
            LocalInfo.Golds.CommonText.Color = LocalInfoStyle.Golds.CommonText.Color;
            LocalInfo.Golds.GoldLinkColor = LocalInfoStyle.Golds.GoldLinkColor;
            LocalInfo.Golds.BackgroundChartColor = LocalInfoStyle.Golds.BackgroundChartColor;
            for (int i = 0; i < LocalInfoStyle.Golds.Events.Count; i++)
            {
                if (LocalInfo.Golds.Events.Count > i)
                {
                    if (LocalInfo.Golds.Events[i].TeamId == 100)
                        LocalInfo.Golds.Events[i].Image.Background = LocalInfoStyle.Golds.BlueGoldsColor;
                    else
                        LocalInfo.Golds.Events[i].Image.Background = LocalInfoStyle.Golds.RedGoldsColor;
                }
            }

            // Event Info
            LocalInfo.EventInfo.Background = LocalInfoStyle.EventInfo.Background;
            LocalInfo.EventInfo.Border = LocalInfoStyle.EventInfo.Border;
            LocalInfo.EventInfo.Event.Font = LocalInfoStyle.EventInfo.Event.Font;
            LocalInfo.EventInfo.Event.Color = LocalInfoStyle.EventInfo.Event.Color;
            LocalInfo.EventInfo.Phase.Font = LocalInfoStyle.EventInfo.Phase.Font;
            LocalInfo.EventInfo.Phase.Color = LocalInfoStyle.EventInfo.Phase.Color;
            LocalInfo.EventInfo.Date.Font = LocalInfoStyle.EventInfo.Date.Font;
            LocalInfo.EventInfo.Date.Color = LocalInfoStyle.EventInfo.Date.Color;
        }
    }
}
