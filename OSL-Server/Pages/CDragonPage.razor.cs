using OSL_Server.DataLoader.CDragon;

namespace OSL_Server.Pages
{
    /// <summary>
    /// CDragon Page
    /// </summary>
    public partial class CDragonPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        /// <summary>
        /// Launch on thread download of last version of league of legends data
        /// </summary>
        public static void UpdateManual()
        {
            _logger.log(LoggingLevel.INFO, "UpdateManual()", "Update in progress");
            Thread DownloadFilesFr = new Thread(() => CDragon.Download.DownloadFiles("latest", "fr_fr"));
            DownloadFilesFr.Start();
        }
    }
}
