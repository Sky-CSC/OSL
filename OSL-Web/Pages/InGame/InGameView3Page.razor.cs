using OSL_Common.System.Logging;

namespace OSL_Web.Pages.InGame
{
    public partial class InGameView3Page
    {
        private static Logger _logger = new("InGameView3Page");

        public static FormatingData formatingData = new();

        /// <summary>
        /// Formating Data
        /// </summary>
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string ReplayInfoFrame { get; set; }
            public string BluePlayerFrame { get; set; }
            public string RedPlayerFrame { get; set; }
            public string ReplayInfoText { get; set; }
            public string ColorReplayInfoText { get; set; }
            public bool DisplayReplayInfoFrame { get; set; }
            public bool DisplayBluePlayerFrame { get; set; }
            public bool DisplayRedPlayerFrame { get; set; }
        }

        /// <summary>
        /// Load default data in game
        /// </summary>
        public static void ResetColor()
        {
            Configuration.Overlay.InGame.View3.Config.LoadFormatingDataConfig();
        }
    }
}
