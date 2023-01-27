namespace OSL_Server.Pages
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
            public string OverlayBackground { get; set; }
        }

        private static void DefaultLoadTempsForTest()
        {
            formatingData.OverlayBackground = "../assets/ingame/frame/Replay.png";
        }
    }
}
