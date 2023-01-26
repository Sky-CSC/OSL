using OSL_Server.DataLoader.CDragon;

namespace OSL_Server.Pages
{
    /// <summary>
    /// CDragon Page
    /// </summary>
    public partial class CDragonPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        public static void UpdateManual()
        {
            _logger.log(LoggingLevel.INFO, "UpdateManual()", "Update in progress");
            Thread DownloadFilesFr = new Thread(() => CDragon.Download.DownloadFiles("latest", "fr_fr"));
            DownloadFilesFr.Start();
        }
    }
}
