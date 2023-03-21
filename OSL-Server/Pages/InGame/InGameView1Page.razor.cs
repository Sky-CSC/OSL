using OSL_Server.Configuration;

namespace OSL_Server.Pages.InGame
{
    public partial class InGameView1Page
    {
        private static OSLLogger _logger = new OSLLogger("InGameView1Page");

        public static FormatingData formatingData = new();

        /// <summary>
        /// Formating Data
        /// </summary>
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BluePlayerFrame { get; set; }
            public bool DisplayBluePlayerFrame { get; set; }
            public string RedPlayerFrame { get; set; }
            public bool DisplayRedPlayerFrame { get; set; }
            public string DragonTimerFrame { get; set; }
            public bool DisplayDragonTimer { get; set; }
            public string HeraldBaronTimerFrame { get; set; }
            public bool DisplayHeraldBaronTimer { get; set; }
            public string LeftInfoFrame { get; set; }
            public bool DisplayLeftInfo { get; set; }
            public string RightInfoFrame { get; set; }
            public bool DisplayRightInfo { get; set; }
            public string TeamBanner { get; set; }
            public string TeamScoreBanner { get; set; }
            public string BlueTeamText { get; set; }
            public string BlueTeamScoreText { get; set; }
            public string RedTeamText { get; set; }
            public string RedTeamScoreText { get; set; }
            public bool DisplayBlueTeam { get; set; }
            public bool DisplayBlueTeamScore { get; set; }
            public bool DisplayBlueTeamText { get; set; }
            public bool DisplayRedTeam { get; set; }
            public bool DisplayRedTeamScore { get; set; }
            public bool DisplayRedTeamText { get; set; }
            public string ColorBlueTeamScoreText { get; set; }
            public string ColorBlueTeamText { get; set; }
            public string ColorRedTeamScoreText { get; set; }
            public string ColorRedTeamText { get; set; }
        }

        //private static void DefaultLoadTempsForTest()
        //{
        //    formatingData.DefaultPatch = "latest";
        //    formatingData.DefaultRegion = "fr_fr";
        //    formatingData.OverlayBackground = "../assets/lolspritefile/testInGame.png";
        //    formatingData.BluePlayerFrame = "../assets/ingame/frame/blue_player_frame.png";
        //    formatingData.RedPlayerFrame = "../assets/ingame/frame/red_player_frame.png";
        //    formatingData.DragonTimerFrame = "../assets/ingame/frame/frame_time_dragon_herald_baron.png";
        //    formatingData.HeraldBaronTimerFrame = "../assets/ingame/frame/frame_time_dragon_herald_baron.png";
        //    formatingData.LeftInfoFrame = "../assets/ingame/frame/left_info_frame_all.png";
        //    formatingData.RightInfoFrame = "../assets/ingame/frame/right_info_frame.png";
        //    formatingData.DisplayDragonTimer = true;
        //    formatingData.DisplayHeraldBaronTimer = true;
        //    formatingData.DisplayBluePlayerFrame = true;
        //    formatingData.DisplayRedPlayerFrame = true;
        //    formatingData.DisplayLeftInfo = true;
        //    formatingData.DisplayRightInfo = true;
        //    formatingData.TeamBanner = "../assets/ingame/banner/team_banner.png";
        //    formatingData.TeamScoreBanner = "../assets/ingame/banner/team_score_banner.png";
        //    formatingData.BlueTeamText = "Le clan des Semi-Croustillants";
        //    formatingData.BlueTeamScoreText = "12-24";
        //    formatingData.RedTeamText= "Les Serpents géants du lac de l'Ombre";
        //    formatingData.RedTeamScoreText = "24-12";
        //    formatingData.DisplayBlueTeam = true;
        //    formatingData.DisplayBlueTeamScore = true;
        //    formatingData.DisplayBlueTeamText = true;
        //    formatingData.DisplayRedTeam = true;
        //    formatingData.DisplayRedTeamScore = true;
        //    formatingData.DisplayRedTeamText = true;
        //    formatingData.ColorBlueTeamScoreText = "#0b849e";
        //    formatingData.ColorBlueTeamText = "#0b849e";
        //    formatingData.ColorRedTeamScoreText = "#be1e37";
        //    formatingData.ColorRedTeamText = "#be1e37";
        //}

        /// <summary>
        /// Load default data in game
        /// </summary>
        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigInGameView1();
        }
    }
}
