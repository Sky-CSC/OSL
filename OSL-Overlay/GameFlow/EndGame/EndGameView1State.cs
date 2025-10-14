using Newtonsoft.Json;

namespace OSL_Overlay.GameFlow.EndGame
{
    public class EndGameView1State
    {

        private readonly EndGameState _endgameState;
        public EndGameInfo LocalInfo = new();
        public EndGameInfo LocalInfoStyle = new();

        public string CurrentFile = "wwwroot/styles/endgame/view1/default.json";
        public event Action? OnChange;

        public EndGameView1State(EndGameState endGameState)
        {
            _endgameState = endGameState;
            _endgameState.OnChange += SyncFromGlobal;
        }

        public void NotifyStateChanged() => OnChange?.Invoke();

        public void SyncFromGlobal()
        {
            LocalInfo = _endgameState.Info.CloneInfo();
            LoadStyle(CurrentFile);
            NotifyStateChanged();
        }

        public void LoadStyle(string path)
        {
            string? json = OSL_Utils.File.Read(path);
            if (json == null)
                return;
            var info = JsonConvert.DeserializeObject<EndGameInfo>(json);
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
            // Général background
            LocalInfo.Background = LocalInfoStyle.Background;
            LocalInfo.Border = LocalInfoStyle.Border;

            // TimerTeamsHeadband
            LocalInfo.TimerTeamsHeadband.Background = LocalInfoStyle.TimerTeamsHeadband.Background;
            LocalInfo.TimerTeamsHeadband.Border = LocalInfoStyle.TimerTeamsHeadband.Border;
            // Title
            LocalInfo.TimerTeamsHeadband.Title.Txt = LocalInfoStyle.TimerTeamsHeadband.Title.Txt;
            LocalInfo.TimerTeamsHeadband.Title.Font = LocalInfoStyle.TimerTeamsHeadband.Title.Font;
            LocalInfo.TimerTeamsHeadband.Title.Color = LocalInfoStyle.TimerTeamsHeadband.Title.Color;
            // Timer
            LocalInfo.TimerTeamsHeadband.Title.Font = LocalInfoStyle.TimerTeamsHeadband.Title.Font;
            LocalInfo.TimerTeamsHeadband.Title.Color = LocalInfoStyle.TimerTeamsHeadband.Title.Color;
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
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowLogo = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowLogo;
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowName = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowName;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Name.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Name.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Name.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Name.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.ShowTag = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.ShowTag;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Tag.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Tag.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.Tag.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.Tag.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Font = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Font;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Color = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Color;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Background = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Background;
            LocalInfo.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Border = LocalInfoStyle.TimerTeamsHeadband.BlueTeam.BoGraphic.Win.Border;
            // Red Team
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowLogo = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowLogo;
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowName = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowName;
            LocalInfo.TimerTeamsHeadband.RedTeam.Name.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Name.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.Name.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Name.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.ShowTag = LocalInfoStyle.TimerTeamsHeadband.RedTeam.ShowTag;
            LocalInfo.TimerTeamsHeadband.RedTeam.Tag.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Tag.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.Tag.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.Tag.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Font = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Font;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Color = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Color;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Background = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Background;
            LocalInfo.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Border = LocalInfoStyle.TimerTeamsHeadband.RedTeam.BoGraphic.Win.Border;

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
            LocalInfo.ChampionStats.Title.Txt = LocalInfoStyle.ChampionStats.Title.Txt;
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
                    LocalInfo.ChampionStats.BlueTeam[i].Bar.Backgournd = LocalInfoStyle.ChampionStats.BlueTeam[i].Bar.Backgournd;
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
                    LocalInfo.ChampionStats.RedTeam[i].Bar.Backgournd = LocalInfoStyle.ChampionStats.RedTeam[i].Bar.Backgournd;
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
        }

        //public void UpdateInfoCss()
        //{
        //    // Général
        //    LocalInfo.Background = LocalInfoStyle.Background;
        //    LocalInfo.Border = LocalInfoStyle.Border;

        //    // Timer
        //    LocalInfo.Timer.Background = LocalInfoStyle.Timer.Background;
        //    LocalInfo.Timer.Border = LocalInfoStyle.Timer.Border;

        //    // Timer text
        //    LocalInfo.Timer.Text.Txt = LocalInfoStyle.Timer.Text.Txt;
        //    LocalInfo.Timer.Text.Color = LocalInfoStyle.Timer.Text.Color;
        //    LocalInfo.Timer.Text.Font = LocalInfoStyle.Timer.Text.Font;
        //    LocalInfo.Timer.Text.Background = LocalInfoStyle.Timer.Text.Background;
        //    LocalInfo.Timer.Text.Border = LocalInfoStyle.Timer.Text.Border;
        //    LocalInfo.Timer.Text.Align = LocalInfoStyle.Timer.Text.Align;

        //    // Timer time
        //    LocalInfo.Timer.Time.Color = LocalInfoStyle.Timer.Time.Color;
        //    LocalInfo.Timer.Time.Font = LocalInfoStyle.Timer.Time.Font;
        //    LocalInfo.Timer.Time.Background = LocalInfoStyle.Timer.Time.Background;
        //    LocalInfo.Timer.Time.Border = LocalInfoStyle.Timer.Time.Border;
        //    LocalInfo.Timer.Time.Align = LocalInfoStyle.Timer.Time.Align;

        //    // Timer text win
        //    LocalInfo.Timer.Win.Txt = LocalInfoStyle.Timer.Win.Txt;
        //    LocalInfo.Timer.Win.Color = LocalInfoStyle.Timer.Win.Color;
        //    LocalInfo.Timer.Win.Font = LocalInfoStyle.Timer.Win.Font;
        //    LocalInfo.Timer.Win.Background = LocalInfoStyle.Timer.Win.Background;
        //    LocalInfo.Timer.Win.Border = LocalInfoStyle.Timer.Win.Border;
        //    LocalInfo.Timer.Win.Align = LocalInfoStyle.Timer.Win.Align;

        //    // Timer text loss
        //    LocalInfo.Timer.Loss.Txt = LocalInfoStyle.Timer.Loss.Txt;
        //    LocalInfo.Timer.Loss.Color = LocalInfoStyle.Timer.Loss.Color;
        //    LocalInfo.Timer.Loss.Font = LocalInfoStyle.Timer.Loss.Font;
        //    LocalInfo.Timer.Loss.Background = LocalInfoStyle.Timer.Loss.Background;
        //    LocalInfo.Timer.Loss.Border = LocalInfoStyle.Timer.Loss.Border;
        //    LocalInfo.Timer.Loss.Align = LocalInfoStyle.Timer.Loss.Align;

        //    // Timer blue team
        //    LocalInfo.Timer.BlueSide.Background = LocalInfoStyle.Timer.BlueSide.Background;
        //    LocalInfo.Timer.BlueSide.Border = LocalInfoStyle.Timer.BlueSide.Border;
        //    // Timer blue team logo
        //    LocalInfo.Timer.BlueSide.ShowLogo = LocalInfoStyle.Timer.BlueSide.ShowLogo;
        //    LocalInfo.Timer.BlueSide.Logo.Background = LocalInfoStyle.Timer.BlueSide.Logo.Background;
        //    LocalInfo.Timer.BlueSide.Logo.Border = LocalInfoStyle.Timer.BlueSide.Logo.Border;
        //    // Timer blue team name
        //    LocalInfo.Timer.BlueSide.ShowName = LocalInfoStyle.Timer.BlueSide.ShowName;
        //    LocalInfo.Timer.BlueSide.Name.Color = LocalInfoStyle.Timer.BlueSide.Name.Color;
        //    LocalInfo.Timer.BlueSide.Name.Font = LocalInfoStyle.Timer.BlueSide.Name.Font;
        //    LocalInfo.Timer.BlueSide.Name.Background = LocalInfoStyle.Timer.BlueSide.Name.Background;
        //    LocalInfo.Timer.BlueSide.Name.Border = LocalInfoStyle.Timer.BlueSide.Name.Border;
        //    LocalInfo.Timer.BlueSide.Name.Align = LocalInfoStyle.Timer.BlueSide.Name.Align;
        //    // Timer blue team tag
        //    LocalInfo.Timer.BlueSide.ShowTag = LocalInfoStyle.Timer.BlueSide.ShowTag;
        //    LocalInfo.Timer.BlueSide.Tag.Color = LocalInfoStyle.Timer.BlueSide.Tag.Color;
        //    LocalInfo.Timer.BlueSide.Tag.Font = LocalInfoStyle.Timer.BlueSide.Tag.Font;
        //    LocalInfo.Timer.BlueSide.Tag.Background = LocalInfoStyle.Timer.BlueSide.Tag.Background;
        //    LocalInfo.Timer.BlueSide.Tag.Border = LocalInfoStyle.Timer.BlueSide.Tag.Border;
        //    LocalInfo.Timer.BlueSide.Tag.Align = LocalInfoStyle.Timer.BlueSide.Tag.Align;
        //    // Timer blue team Bo graphic
        //    LocalInfo.Timer.BlueSide.BoGraphic.Win.Background = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Background;
        //    LocalInfo.Timer.BlueSide.BoGraphic.Win.Border = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Border;
        //    LocalInfo.Timer.BlueSide.BoGraphic.Win.Color = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Color;
        //    LocalInfo.Timer.BlueSide.BoGraphic.Undef.Background = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Background;
        //    LocalInfo.Timer.BlueSide.BoGraphic.Undef.Border = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Border;
        //    LocalInfo.Timer.BlueSide.BoGraphic.Undef.Color = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Color;

        //    // Timer blue team
        //    LocalInfo.Timer.RedSide.Background = LocalInfoStyle.Timer.RedSide.Background;
        //    LocalInfo.Timer.RedSide.Border = LocalInfoStyle.Timer.RedSide.Border;
        //    // Timer blue team logo
        //    LocalInfo.Timer.RedSide.ShowLogo = LocalInfoStyle.Timer.RedSide.ShowLogo;
        //    LocalInfo.Timer.RedSide.Logo.Background = LocalInfoStyle.Timer.RedSide.Logo.Background;
        //    LocalInfo.Timer.RedSide.Logo.Border = LocalInfoStyle.Timer.RedSide.Logo.Border;
        //    // Timer blue team name
        //    LocalInfo.Timer.RedSide.ShowName = LocalInfoStyle.Timer.RedSide.ShowName;
        //    LocalInfo.Timer.RedSide.Name.Color = LocalInfoStyle.Timer.RedSide.Name.Color;
        //    LocalInfo.Timer.RedSide.Name.Font = LocalInfoStyle.Timer.RedSide.Name.Font;
        //    LocalInfo.Timer.RedSide.Name.Background = LocalInfoStyle.Timer.RedSide.Name.Background;
        //    LocalInfo.Timer.RedSide.Name.Border = LocalInfoStyle.Timer.RedSide.Name.Border;
        //    LocalInfo.Timer.RedSide.Name.Align = LocalInfoStyle.Timer.RedSide.Name.Align;
        //    // Timer blue team tag
        //    LocalInfo.Timer.RedSide.ShowTag = LocalInfoStyle.Timer.RedSide.ShowTag;
        //    LocalInfo.Timer.RedSide.Tag.Color = LocalInfoStyle.Timer.RedSide.Tag.Color;
        //    LocalInfo.Timer.RedSide.Tag.Font = LocalInfoStyle.Timer.RedSide.Tag.Font;
        //    LocalInfo.Timer.RedSide.Tag.Background = LocalInfoStyle.Timer.RedSide.Tag.Background;
        //    LocalInfo.Timer.RedSide.Tag.Border = LocalInfoStyle.Timer.RedSide.Tag.Border;
        //    LocalInfo.Timer.RedSide.Tag.Align = LocalInfoStyle.Timer.RedSide.Tag.Align;
        //    // Timer blue team bo graphic
        //    LocalInfo.Timer.RedSide.BoGraphic.Win.Background = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Background;
        //    LocalInfo.Timer.RedSide.BoGraphic.Win.Border = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Border;
        //    LocalInfo.Timer.RedSide.BoGraphic.Win.Color = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Color;
        //    LocalInfo.Timer.RedSide.BoGraphic.Undef.Background = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Background;
        //    LocalInfo.Timer.RedSide.BoGraphic.Undef.Border = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Border;
        //    LocalInfo.Timer.RedSide.BoGraphic.Undef.Color = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Color;

        //    // Game data
        //    LocalInfo.GameData.Background = LocalInfoStyle.GameData.Background;
        //    LocalInfo.GameData.Border = LocalInfoStyle.GameData.Border;

        //    // Game data game stats
        //    LocalInfo.GameData.GameStats.Background = LocalInfoStyle.GameData.GameStats.Background;
        //    LocalInfo.GameData.GameStats.Border = LocalInfoStyle.GameData.GameStats.Border;

        //    // Game data game stats title
        //    LocalInfo.GameData.GameStats.Title.Txt = LocalInfoStyle.GameData.GameStats.Title.Txt;
        //    LocalInfo.GameData.GameStats.Title.Color = LocalInfoStyle.GameData.GameStats.Title.Color;
        //    LocalInfo.GameData.GameStats.Title.Font = LocalInfoStyle.GameData.GameStats.Title.Font;
        //    LocalInfo.GameData.GameStats.Title.Background = LocalInfoStyle.GameData.GameStats.Title.Background;
        //    LocalInfo.GameData.GameStats.Title.Border = LocalInfoStyle.GameData.GameStats.Title.Border;
        //    LocalInfo.GameData.GameStats.Title.Align = LocalInfoStyle.GameData.GameStats.Title.Align;

        //    // Game data game stats kda text
        //    LocalInfo.GameData.GameStats.Kda.Name.Txt = LocalInfoStyle.GameData.GameStats.Kda.Name.Txt;
        //    LocalInfo.GameData.GameStats.Kda.Name.Color = LocalInfoStyle.GameData.GameStats.Kda.Name.Color;
        //    LocalInfo.GameData.GameStats.Kda.Name.Font = LocalInfoStyle.GameData.GameStats.Kda.Name.Font;
        //    LocalInfo.GameData.GameStats.Kda.Name.Background = LocalInfoStyle.GameData.GameStats.Kda.Name.Background;
        //    LocalInfo.GameData.GameStats.Kda.Name.Border = LocalInfoStyle.GameData.GameStats.Kda.Name.Border;
        //    LocalInfo.GameData.GameStats.Kda.Name.Align = LocalInfoStyle.GameData.GameStats.Kda.Name.Align;

        //    // Game data game stats kda blue team value
        //    LocalInfo.GameData.GameStats.Kda.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Color;
        //    LocalInfo.GameData.GameStats.Kda.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Font;
        //    LocalInfo.GameData.GameStats.Kda.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Background;
        //    LocalInfo.GameData.GameStats.Kda.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Border;
        //    LocalInfo.GameData.GameStats.Kda.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Align;

        //    // Game data game stats kda red team value
        //    LocalInfo.GameData.GameStats.Kda.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Color;
        //    LocalInfo.GameData.GameStats.Kda.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Font;
        //    LocalInfo.GameData.GameStats.Kda.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Background;
        //    LocalInfo.GameData.GameStats.Kda.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Border;
        //    LocalInfo.GameData.GameStats.Kda.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Align;

        //    // Game data game stats Golds text
        //    LocalInfo.GameData.GameStats.Golds.Name.Txt = LocalInfoStyle.GameData.GameStats.Golds.Name.Txt;
        //    LocalInfo.GameData.GameStats.Golds.Name.Color = LocalInfoStyle.GameData.GameStats.Golds.Name.Color;
        //    LocalInfo.GameData.GameStats.Golds.Name.Font = LocalInfoStyle.GameData.GameStats.Golds.Name.Font;
        //    LocalInfo.GameData.GameStats.Golds.Name.Background = LocalInfoStyle.GameData.GameStats.Golds.Name.Background;
        //    LocalInfo.GameData.GameStats.Golds.Name.Border = LocalInfoStyle.GameData.GameStats.Golds.Name.Border;
        //    LocalInfo.GameData.GameStats.Golds.Name.Align = LocalInfoStyle.GameData.GameStats.Golds.Name.Align;

        //    // Game data game stats Golds blue team value
        //    LocalInfo.GameData.GameStats.Golds.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Color;
        //    LocalInfo.GameData.GameStats.Golds.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Font;
        //    LocalInfo.GameData.GameStats.Golds.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Background;
        //    LocalInfo.GameData.GameStats.Golds.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Border;
        //    LocalInfo.GameData.GameStats.Golds.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Align;

        //    // Game data game stats Golds red team value
        //    LocalInfo.GameData.GameStats.Golds.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Color;
        //    LocalInfo.GameData.GameStats.Golds.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Font;
        //    LocalInfo.GameData.GameStats.Golds.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Background;
        //    LocalInfo.GameData.GameStats.Golds.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Border;
        //    LocalInfo.GameData.GameStats.Golds.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Align;

        //    // Game data game stats Tower text
        //    LocalInfo.GameData.GameStats.Towers.Name.Txt = LocalInfoStyle.GameData.GameStats.Towers.Name.Txt;
        //    LocalInfo.GameData.GameStats.Towers.Name.Color = LocalInfoStyle.GameData.GameStats.Towers.Name.Color;
        //    LocalInfo.GameData.GameStats.Towers.Name.Font = LocalInfoStyle.GameData.GameStats.Towers.Name.Font;
        //    LocalInfo.GameData.GameStats.Towers.Name.Background = LocalInfoStyle.GameData.GameStats.Towers.Name.Background;
        //    LocalInfo.GameData.GameStats.Towers.Name.Border = LocalInfoStyle.GameData.GameStats.Towers.Name.Border;
        //    LocalInfo.GameData.GameStats.Towers.Name.Align = LocalInfoStyle.GameData.GameStats.Towers.Name.Align;

        //    // Game data game stats Tower blue team value
        //    LocalInfo.GameData.GameStats.Towers.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Color;
        //    LocalInfo.GameData.GameStats.Towers.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Font;
        //    LocalInfo.GameData.GameStats.Towers.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Background;
        //    LocalInfo.GameData.GameStats.Towers.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Border;
        //    LocalInfo.GameData.GameStats.Towers.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Align;

        //    // Game data game stats Tower red team value
        //    LocalInfo.GameData.GameStats.Towers.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Color;
        //    LocalInfo.GameData.GameStats.Towers.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Font;
        //    LocalInfo.GameData.GameStats.Towers.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Background;
        //    LocalInfo.GameData.GameStats.Towers.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Border;
        //    LocalInfo.GameData.GameStats.Towers.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Align;

        //    // Game data game stats VoidGrubs text
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Txt = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Txt;
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Color = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Color;
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Font = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Font;
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Background;
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Border;
        //    LocalInfo.GameData.GameStats.VoidGrubs.Name.Align = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Align;

        //    // Game data game stats VoidGrubs blue team value and image
        //    LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Border;


        //    // Game data game stats VoidGrubs red team value and image
        //    LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Border;

        //    // Game data game stats Herald text
        //    LocalInfo.GameData.GameStats.Herald.Name.Txt = LocalInfoStyle.GameData.GameStats.Herald.Name.Txt;
        //    LocalInfo.GameData.GameStats.Herald.Name.Color = LocalInfoStyle.GameData.GameStats.Herald.Name.Color;
        //    LocalInfo.GameData.GameStats.Herald.Name.Font = LocalInfoStyle.GameData.GameStats.Herald.Name.Font;
        //    LocalInfo.GameData.GameStats.Herald.Name.Background = LocalInfoStyle.GameData.GameStats.Herald.Name.Background;
        //    LocalInfo.GameData.GameStats.Herald.Name.Border = LocalInfoStyle.GameData.GameStats.Herald.Name.Border;
        //    LocalInfo.GameData.GameStats.Herald.Name.Align = LocalInfoStyle.GameData.GameStats.Herald.Name.Align;

        //    // Game data game stats Herald blue team value and image
        //    LocalInfo.GameData.GameStats.Herald.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Herald.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Herald.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Herald.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Herald.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Herald.BlueTeamImages.Border;


        //    // Game data game stats Herald red team value and image            
        //    LocalInfo.GameData.GameStats.Herald.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Herald.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Herald.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Herald.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Herald.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Herald.RedTeamImages.Border;

        //    // Game data game stats Dragon text
        //    LocalInfo.GameData.GameStats.Dragon.Name.Txt = LocalInfoStyle.GameData.GameStats.Dragon.Name.Txt;
        //    LocalInfo.GameData.GameStats.Dragon.Name.Color = LocalInfoStyle.GameData.GameStats.Dragon.Name.Color;
        //    LocalInfo.GameData.GameStats.Dragon.Name.Font = LocalInfoStyle.GameData.GameStats.Dragon.Name.Font;
        //    LocalInfo.GameData.GameStats.Dragon.Name.Background = LocalInfoStyle.GameData.GameStats.Dragon.Name.Background;
        //    LocalInfo.GameData.GameStats.Dragon.Name.Border = LocalInfoStyle.GameData.GameStats.Dragon.Name.Border;
        //    LocalInfo.GameData.GameStats.Dragon.Name.Align = LocalInfoStyle.GameData.GameStats.Dragon.Name.Align;

        //    // Game data game stats Air blue team image
        //    LocalInfo.GameData.GameStats.Air.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Air.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Air.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Air.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Air.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Air.BlueTeamImages.Border;
        //    // Game data game stats Air red team image            
        //    LocalInfo.GameData.GameStats.Air.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Air.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Air.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Air.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Air.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Air.RedTeamImages.Border;
        //    // Game data game stats Chemtech blue team image
        //    LocalInfo.GameData.GameStats.Chemtech.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Chemtech.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Chemtech.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Chemtech.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Chemtech.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Chemtech.BlueTeamImages.Border;
        //    // Game data game stats Chemtech red team image            
        //    LocalInfo.GameData.GameStats.Chemtech.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Chemtech.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Chemtech.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Chemtech.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Chemtech.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Chemtech.RedTeamImages.Border;
        //    // Game data game stats Earth blue team image
        //    LocalInfo.GameData.GameStats.Earth.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Earth.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Earth.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Earth.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Earth.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Earth.BlueTeamImages.Border;
        //    // Game data game stats Earth red team image            
        //    LocalInfo.GameData.GameStats.Earth.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Earth.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Earth.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Earth.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Earth.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Earth.RedTeamImages.Border;
        //    // Game data game stats Fire blue team image
        //    LocalInfo.GameData.GameStats.Fire.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Fire.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Fire.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Fire.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Fire.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Fire.BlueTeamImages.Border;
        //    // Game data game stats Fire red team image            
        //    LocalInfo.GameData.GameStats.Fire.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Fire.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Fire.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Fire.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Fire.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Fire.RedTeamImages.Border;
        //    // Game data game stats Hextech blue team image
        //    LocalInfo.GameData.GameStats.Hextech.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Hextech.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Hextech.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Hextech.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Hextech.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Hextech.BlueTeamImages.Border;
        //    // Game data game stats Hextech red team image            
        //    LocalInfo.GameData.GameStats.Hextech.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Hextech.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Hextech.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Hextech.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Hextech.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Hextech.RedTeamImages.Border;
        //    // Game data game stats Water blue team image
        //    LocalInfo.GameData.GameStats.Water.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Water.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Water.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Water.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Water.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Water.BlueTeamImages.Border;
        //    // Game data game stats Water red team image            
        //    LocalInfo.GameData.GameStats.Water.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Water.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Water.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Water.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Water.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Water.RedTeamImages.Border;

        //    // Game data game stats Atakhan text
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Txt = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Txt;
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Color = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Color;
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Font = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Font;
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Background = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Background;
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Border = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Border;
        //    LocalInfo.GameData.GameStats.Atakhan.Name.Align = LocalInfoStyle.GameData.GameStats.Atakhan.Name.Align;
        //    // Game data game stats Atakhan blue team image
        //    LocalInfo.GameData.GameStats.Atakhan.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Atakhan.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Atakhan.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Atakhan.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Atakhan.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Atakhan.BlueTeamImages.Border;
        //    // Game data game stats Atakhan red team image            
        //    LocalInfo.GameData.GameStats.Atakhan.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Atakhan.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Atakhan.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Atakhan.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Atakhan.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Atakhan.RedTeamImages.Border;

        //    // Game data game stats Elders text
        //    LocalInfo.GameData.GameStats.Elders.Name.Txt = LocalInfoStyle.GameData.GameStats.Elders.Name.Txt;
        //    LocalInfo.GameData.GameStats.Elders.Name.Color = LocalInfoStyle.GameData.GameStats.Elders.Name.Color;
        //    LocalInfo.GameData.GameStats.Elders.Name.Font = LocalInfoStyle.GameData.GameStats.Elders.Name.Font;
        //    LocalInfo.GameData.GameStats.Elders.Name.Background = LocalInfoStyle.GameData.GameStats.Elders.Name.Background;
        //    LocalInfo.GameData.GameStats.Elders.Name.Border = LocalInfoStyle.GameData.GameStats.Elders.Name.Border;
        //    LocalInfo.GameData.GameStats.Elders.Name.Align = LocalInfoStyle.GameData.GameStats.Elders.Name.Align;
        //    // Game data game stats Elders blue team image
        //    LocalInfo.GameData.GameStats.Elders.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Elders.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Elders.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Elders.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Elders.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Elders.BlueTeamImages.Border;
        //    // Game data game stats Elders red team image            
        //    LocalInfo.GameData.GameStats.Elders.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Elders.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Elders.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Elders.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Elders.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Elders.RedTeamImages.Border;

        //    // Game data game stats Barons text
        //    LocalInfo.GameData.GameStats.Barons.Name.Txt = LocalInfoStyle.GameData.GameStats.Barons.Name.Txt;
        //    LocalInfo.GameData.GameStats.Barons.Name.Color = LocalInfoStyle.GameData.GameStats.Barons.Name.Color;
        //    LocalInfo.GameData.GameStats.Barons.Name.Font = LocalInfoStyle.GameData.GameStats.Barons.Name.Font;
        //    LocalInfo.GameData.GameStats.Barons.Name.Background = LocalInfoStyle.GameData.GameStats.Barons.Name.Background;
        //    LocalInfo.GameData.GameStats.Barons.Name.Border = LocalInfoStyle.GameData.GameStats.Barons.Name.Border;
        //    LocalInfo.GameData.GameStats.Barons.Name.Align = LocalInfoStyle.GameData.GameStats.Barons.Name.Align;
        //    // Game data game stats Barons blue team image
        //    LocalInfo.GameData.GameStats.Barons.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.Barons.BlueTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Barons.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.Barons.BlueTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Barons.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.Barons.BlueTeamImages.Border;
        //    // Game data game stats Barons red team image            
        //    LocalInfo.GameData.GameStats.Barons.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.Barons.RedTeamImages.Path;
        //    LocalInfo.GameData.GameStats.Barons.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.Barons.RedTeamImages.Background;
        //    LocalInfo.GameData.GameStats.Barons.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.Barons.RedTeamImages.Border;

        //    // Game data Ban
        //    LocalInfo.GameData.Bans.Background = LocalInfoStyle.GameData.Bans.Background;
        //    LocalInfo.GameData.Bans.Border = LocalInfoStyle.GameData.Bans.Border;
        //    // Game data Ban text
        //    LocalInfo.GameData.Bans.Title.Txt = LocalInfoStyle.GameData.Bans.Title.Txt;
        //    LocalInfo.GameData.Bans.Title.Color = LocalInfoStyle.GameData.Bans.Title.Color;
        //    LocalInfo.GameData.Bans.Title.Font = LocalInfoStyle.GameData.Bans.Title.Font;
        //    LocalInfo.GameData.Bans.Title.Background = LocalInfoStyle.GameData.Bans.Title.Background;
        //    LocalInfo.GameData.Bans.Title.Border = LocalInfoStyle.GameData.Bans.Title.Border;
        //    LocalInfo.GameData.Bans.Title.Align = LocalInfoStyle.GameData.Bans.Title.Align;



        //    NotifyStateChanged();
        //}
    }
}
