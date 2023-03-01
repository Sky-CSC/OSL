using OSL_Server.Configuration;

namespace OSL_Server.Pages.InGame
{
    public partial class InGameView3Page
    {
        private static OSLLogger _logger = new OSLLogger("InGameView3Page");

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
            Config.LoadFormatingDataConfigInGameView3();
        }
    }
}
