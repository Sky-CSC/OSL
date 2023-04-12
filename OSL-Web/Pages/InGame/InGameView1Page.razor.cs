
using OSL_Common.System.Logging;

namespace OSL_Web.Pages.InGame
{
    public partial class InGameView1Page
    {
        private static Logger _logger = new("InGameView1Page");

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

        /// <summary>
        /// Load default data in game
        /// </summary>
        public static void ResetColor()
        {
            Configuration.Overlay.InGame.View1.Config.LoadFormatingDataConfig();
        }
    }
}
