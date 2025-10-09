using Newtonsoft.Json;
using OSL_Overlay.GameFlow.Fearless;

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

        public void UpdateInfoCss()
        {
            // Général
            LocalInfo.Background = LocalInfoStyle.Background;
            LocalInfo.Border = LocalInfoStyle.Border;

            // Timer
            LocalInfo.Timer.Background = LocalInfoStyle.Timer.Background;
            LocalInfo.Timer.Border = LocalInfoStyle.Timer.Border;

            // Timer text
            LocalInfo.Timer.Text.Txt = LocalInfoStyle.Timer.Text.Txt;
            LocalInfo.Timer.Text.Color = LocalInfoStyle.Timer.Text.Color;
            LocalInfo.Timer.Text.Font = LocalInfoStyle.Timer.Text.Font;
            LocalInfo.Timer.Text.Background = LocalInfoStyle.Timer.Text.Background;
            LocalInfo.Timer.Text.Border = LocalInfoStyle.Timer.Text.Border;
            LocalInfo.Timer.Text.Align = LocalInfoStyle.Timer.Text.Align;

            // Timer time
            LocalInfo.Timer.Time.Color = LocalInfoStyle.Timer.Time.Color;
            LocalInfo.Timer.Time.Font = LocalInfoStyle.Timer.Time.Font;
            LocalInfo.Timer.Time.Background = LocalInfoStyle.Timer.Time.Background;
            LocalInfo.Timer.Time.Border = LocalInfoStyle.Timer.Time.Border;
            LocalInfo.Timer.Time.Align = LocalInfoStyle.Timer.Time.Align;

            // Timer text win
            LocalInfo.Timer.Win.Txt = LocalInfoStyle.Timer.Win.Txt;
            LocalInfo.Timer.Win.Color = LocalInfoStyle.Timer.Win.Color;
            LocalInfo.Timer.Win.Font = LocalInfoStyle.Timer.Win.Font;
            LocalInfo.Timer.Win.Background = LocalInfoStyle.Timer.Win.Background;
            LocalInfo.Timer.Win.Border = LocalInfoStyle.Timer.Win.Border;
            LocalInfo.Timer.Win.Align = LocalInfoStyle.Timer.Win.Align;

            // Timer text loss
            LocalInfo.Timer.Loss.Txt = LocalInfoStyle.Timer.Loss.Txt;
            LocalInfo.Timer.Loss.Color = LocalInfoStyle.Timer.Loss.Color;
            LocalInfo.Timer.Loss.Font = LocalInfoStyle.Timer.Loss.Font;
            LocalInfo.Timer.Loss.Background = LocalInfoStyle.Timer.Loss.Background;
            LocalInfo.Timer.Loss.Border = LocalInfoStyle.Timer.Loss.Border;
            LocalInfo.Timer.Loss.Align = LocalInfoStyle.Timer.Loss.Align;

            // Timer blue team
            LocalInfo.Timer.BlueSide.Background = LocalInfoStyle.Timer.BlueSide.Background;
            LocalInfo.Timer.BlueSide.Border = LocalInfoStyle.Timer.BlueSide.Border;
            // Timer blue team logo
            LocalInfo.Timer.BlueSide.ShowLogo = LocalInfoStyle.Timer.BlueSide.ShowLogo;
            LocalInfo.Timer.BlueSide.Logo.Background = LocalInfoStyle.Timer.BlueSide.Logo.Background;
            LocalInfo.Timer.BlueSide.Logo.Border = LocalInfoStyle.Timer.BlueSide.Logo.Border;
            // Timer blue team name
            LocalInfo.Timer.BlueSide.ShowName = LocalInfoStyle.Timer.BlueSide.ShowName;
            LocalInfo.Timer.BlueSide.Name.Color = LocalInfoStyle.Timer.BlueSide.Name.Color;
            LocalInfo.Timer.BlueSide.Name.Font = LocalInfoStyle.Timer.BlueSide.Name.Font;
            LocalInfo.Timer.BlueSide.Name.Background = LocalInfoStyle.Timer.BlueSide.Name.Background;
            LocalInfo.Timer.BlueSide.Name.Border = LocalInfoStyle.Timer.BlueSide.Name.Border;
            LocalInfo.Timer.BlueSide.Name.Align = LocalInfoStyle.Timer.BlueSide.Name.Align;
            // Timer blue team tag
            LocalInfo.Timer.BlueSide.ShowTag = LocalInfoStyle.Timer.BlueSide.ShowTag;
            LocalInfo.Timer.BlueSide.Tag.Color = LocalInfoStyle.Timer.BlueSide.Tag.Color;
            LocalInfo.Timer.BlueSide.Tag.Font = LocalInfoStyle.Timer.BlueSide.Tag.Font;
            LocalInfo.Timer.BlueSide.Tag.Background = LocalInfoStyle.Timer.BlueSide.Tag.Background;
            LocalInfo.Timer.BlueSide.Tag.Border = LocalInfoStyle.Timer.BlueSide.Tag.Border;
            LocalInfo.Timer.BlueSide.Tag.Align = LocalInfoStyle.Timer.BlueSide.Tag.Align;
            // Timer blue team Bo graphic
            LocalInfo.Timer.BlueSide.BoGraphic.Win.Background = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Background;
            LocalInfo.Timer.BlueSide.BoGraphic.Win.Border = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Border;
            LocalInfo.Timer.BlueSide.BoGraphic.Win.Color = LocalInfoStyle.Timer.BlueSide.BoGraphic.Win.Color;
            LocalInfo.Timer.BlueSide.BoGraphic.Undef.Background = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Background;
            LocalInfo.Timer.BlueSide.BoGraphic.Undef.Border = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Border;
            LocalInfo.Timer.BlueSide.BoGraphic.Undef.Color = LocalInfoStyle.Timer.BlueSide.BoGraphic.Undef.Color;

            // Timer blue team
            LocalInfo.Timer.RedSide.Background = LocalInfoStyle.Timer.RedSide.Background;
            LocalInfo.Timer.RedSide.Border = LocalInfoStyle.Timer.RedSide.Border;
            // Timer blue team logo
            LocalInfo.Timer.RedSide.ShowLogo = LocalInfoStyle.Timer.RedSide.ShowLogo;
            LocalInfo.Timer.RedSide.Logo.Background = LocalInfoStyle.Timer.RedSide.Logo.Background;
            LocalInfo.Timer.RedSide.Logo.Border = LocalInfoStyle.Timer.RedSide.Logo.Border;
            // Timer blue team name
            LocalInfo.Timer.RedSide.ShowName = LocalInfoStyle.Timer.RedSide.ShowName;
            LocalInfo.Timer.RedSide.Name.Color = LocalInfoStyle.Timer.RedSide.Name.Color;
            LocalInfo.Timer.RedSide.Name.Font = LocalInfoStyle.Timer.RedSide.Name.Font;
            LocalInfo.Timer.RedSide.Name.Background = LocalInfoStyle.Timer.RedSide.Name.Background;
            LocalInfo.Timer.RedSide.Name.Border = LocalInfoStyle.Timer.RedSide.Name.Border;
            LocalInfo.Timer.RedSide.Name.Align = LocalInfoStyle.Timer.RedSide.Name.Align;
            // Timer blue team tag
            LocalInfo.Timer.RedSide.ShowTag = LocalInfoStyle.Timer.RedSide.ShowTag;
            LocalInfo.Timer.RedSide.Tag.Color = LocalInfoStyle.Timer.RedSide.Tag.Color;
            LocalInfo.Timer.RedSide.Tag.Font = LocalInfoStyle.Timer.RedSide.Tag.Font;
            LocalInfo.Timer.RedSide.Tag.Background = LocalInfoStyle.Timer.RedSide.Tag.Background;
            LocalInfo.Timer.RedSide.Tag.Border = LocalInfoStyle.Timer.RedSide.Tag.Border;
            LocalInfo.Timer.RedSide.Tag.Align = LocalInfoStyle.Timer.RedSide.Tag.Align;
            // Timer blue team bo graphic
            LocalInfo.Timer.RedSide.BoGraphic.Win.Background = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Background;
            LocalInfo.Timer.RedSide.BoGraphic.Win.Border = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Border;
            LocalInfo.Timer.RedSide.BoGraphic.Win.Color = LocalInfoStyle.Timer.RedSide.BoGraphic.Win.Color;
            LocalInfo.Timer.RedSide.BoGraphic.Undef.Background = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Background;
            LocalInfo.Timer.RedSide.BoGraphic.Undef.Border = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Border;
            LocalInfo.Timer.RedSide.BoGraphic.Undef.Color = LocalInfoStyle.Timer.RedSide.BoGraphic.Undef.Color;

            // Game data
            LocalInfo.GameData.Background = LocalInfoStyle.GameData.Background;
            LocalInfo.GameData.Border = LocalInfoStyle.GameData.Border;

            // Game data game stats
            LocalInfo.GameData.GameStats.Background = LocalInfoStyle.GameData.GameStats.Background;
            LocalInfo.GameData.GameStats.Border = LocalInfoStyle.GameData.GameStats.Border;

            // Game data game stats title
            LocalInfo.GameData.GameStats.Title.Txt = LocalInfoStyle.GameData.GameStats.Title.Txt;
            LocalInfo.GameData.GameStats.Title.Color = LocalInfoStyle.GameData.GameStats.Title.Color;
            LocalInfo.GameData.GameStats.Title.Font = LocalInfoStyle.GameData.GameStats.Title.Font;
            LocalInfo.GameData.GameStats.Title.Background = LocalInfoStyle.GameData.GameStats.Title.Background;
            LocalInfo.GameData.GameStats.Title.Border = LocalInfoStyle.GameData.GameStats.Title.Border;
            LocalInfo.GameData.GameStats.Title.Align = LocalInfoStyle.GameData.GameStats.Title.Align;

            // Game data game stats kda text
            LocalInfo.GameData.GameStats.Kda.Name.Txt = LocalInfoStyle.GameData.GameStats.Kda.Name.Txt;
            LocalInfo.GameData.GameStats.Kda.Name.Color = LocalInfoStyle.GameData.GameStats.Kda.Name.Color;
            LocalInfo.GameData.GameStats.Kda.Name.Font = LocalInfoStyle.GameData.GameStats.Kda.Name.Font;
            LocalInfo.GameData.GameStats.Kda.Name.Background = LocalInfoStyle.GameData.GameStats.Kda.Name.Background;
            LocalInfo.GameData.GameStats.Kda.Name.Border = LocalInfoStyle.GameData.GameStats.Kda.Name.Border;
            LocalInfo.GameData.GameStats.Kda.Name.Align = LocalInfoStyle.GameData.GameStats.Kda.Name.Align;

            // Game data game stats kda blue team value
            LocalInfo.GameData.GameStats.Kda.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Color;
            LocalInfo.GameData.GameStats.Kda.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Font;
            LocalInfo.GameData.GameStats.Kda.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Background;
            LocalInfo.GameData.GameStats.Kda.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Border;
            LocalInfo.GameData.GameStats.Kda.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Kda.BlueTeam.Align;

            // Game data game stats kda red team value
            LocalInfo.GameData.GameStats.Kda.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Color;
            LocalInfo.GameData.GameStats.Kda.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Font;
            LocalInfo.GameData.GameStats.Kda.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Background;
            LocalInfo.GameData.GameStats.Kda.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Border;
            LocalInfo.GameData.GameStats.Kda.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Kda.RedTeam.Align;

            // Game data game stats Golds text
            LocalInfo.GameData.GameStats.Golds.Name.Txt = LocalInfoStyle.GameData.GameStats.Golds.Name.Txt;
            LocalInfo.GameData.GameStats.Golds.Name.Color = LocalInfoStyle.GameData.GameStats.Golds.Name.Color;
            LocalInfo.GameData.GameStats.Golds.Name.Font = LocalInfoStyle.GameData.GameStats.Golds.Name.Font;
            LocalInfo.GameData.GameStats.Golds.Name.Background = LocalInfoStyle.GameData.GameStats.Golds.Name.Background;
            LocalInfo.GameData.GameStats.Golds.Name.Border = LocalInfoStyle.GameData.GameStats.Golds.Name.Border;
            LocalInfo.GameData.GameStats.Golds.Name.Align = LocalInfoStyle.GameData.GameStats.Golds.Name.Align;

            // Game data game stats Golds blue team value
            LocalInfo.GameData.GameStats.Golds.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Color;
            LocalInfo.GameData.GameStats.Golds.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Font;
            LocalInfo.GameData.GameStats.Golds.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Background;
            LocalInfo.GameData.GameStats.Golds.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Border;
            LocalInfo.GameData.GameStats.Golds.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Golds.BlueTeam.Align;

            // Game data game stats Golds red team value
            LocalInfo.GameData.GameStats.Golds.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Color;
            LocalInfo.GameData.GameStats.Golds.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Font;
            LocalInfo.GameData.GameStats.Golds.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Background;
            LocalInfo.GameData.GameStats.Golds.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Border;
            LocalInfo.GameData.GameStats.Golds.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Golds.RedTeam.Align;

            // Game data game stats Tower text
            LocalInfo.GameData.GameStats.Towers.Name.Txt = LocalInfoStyle.GameData.GameStats.Towers.Name.Txt;
            LocalInfo.GameData.GameStats.Towers.Name.Color = LocalInfoStyle.GameData.GameStats.Towers.Name.Color;
            LocalInfo.GameData.GameStats.Towers.Name.Font = LocalInfoStyle.GameData.GameStats.Towers.Name.Font;
            LocalInfo.GameData.GameStats.Towers.Name.Background = LocalInfoStyle.GameData.GameStats.Towers.Name.Background;
            LocalInfo.GameData.GameStats.Towers.Name.Border = LocalInfoStyle.GameData.GameStats.Towers.Name.Border;
            LocalInfo.GameData.GameStats.Towers.Name.Align = LocalInfoStyle.GameData.GameStats.Towers.Name.Align;

            // Game data game stats Tower blue team value
            LocalInfo.GameData.GameStats.Towers.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Color;
            LocalInfo.GameData.GameStats.Towers.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Font;
            LocalInfo.GameData.GameStats.Towers.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Background;
            LocalInfo.GameData.GameStats.Towers.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Border;
            LocalInfo.GameData.GameStats.Towers.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.Towers.BlueTeam.Align;

            // Game data game stats Tower red team value
            LocalInfo.GameData.GameStats.Towers.RedTeam.Color = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Color;
            LocalInfo.GameData.GameStats.Towers.RedTeam.Font = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Font;
            LocalInfo.GameData.GameStats.Towers.RedTeam.Background = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Background;
            LocalInfo.GameData.GameStats.Towers.RedTeam.Border = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Border;
            LocalInfo.GameData.GameStats.Towers.RedTeam.Align = LocalInfoStyle.GameData.GameStats.Towers.RedTeam.Align;

            // Game data game stats VoidGrubs text
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Txt = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Txt;
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Color = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Color;
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Font = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Font;
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Background;
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Border;
            LocalInfo.GameData.GameStats.VoidGrubs.Name.Align = LocalInfoStyle.GameData.GameStats.VoidGrubs.Name.Align;

            // Game data game stats VoidGrubs blue team value and image
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeam.Color = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeam.Color;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeam.Font = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeam.Font;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeam.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeam.Background;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeam.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeam.Border;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeam.Align = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeam.Align;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Path = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Path;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Background;
            LocalInfo.GameData.GameStats.VoidGrubs.BlueTeamImages.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.BlueTeamImages.Border;


            // Game data game stats VoidGrubs red team value and image
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeam.Color = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeam.Color;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeam.Font = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeam.Font;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeam.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeam.Background;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeam.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeam.Border;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeam.Align = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeam.Align;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Path = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Path;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Background = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Background;
            LocalInfo.GameData.GameStats.VoidGrubs.RedTeamImages.Border = LocalInfoStyle.GameData.GameStats.VoidGrubs.RedTeamImages.Border;





            NotifyStateChanged();
        }
    }
}
