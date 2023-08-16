using OSL_Common.System.Logging;
using OSL_Web.Configuration.CDragon;

namespace OSL_Web.Pages.CDragon
{
    /// <summary>
    /// CDragon Page
    /// </summary>
    public partial class CDragonPage
    {
        private static Logger _logger = new("CDragonPage");

        /// <summary>
        /// Launch on thread download of last version of league of legends data
        /// </summary>
        public static void UpdateManual()
        {
            _logger.log(LoggingLevel.INFO, "UpdateManual()", "Update in progress");
            CDragonConfig.LoadDirectoryConfig();
            Thread DownloadFilesFr = new Thread(() => OSL_CDragon.CDragon.DownloadData.DownloadFiles("latest", "fr_fr"));
            DownloadFilesFr.Start();
        }
    }
}
