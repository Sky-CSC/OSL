using OSL_Server.Configuration;

namespace OSL_Server.Pages
{
    public partial class InGameView2Page
    {
        private static OSLLogger _logger = new OSLLogger("InGameView2Page");

        public static FormatingData formatingData = new();

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

        /// <summary>
        /// Load default data in game
        /// </summary>
        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigInGameView2();
        }
    }
}
