using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;

namespace OSL_Server.Pages
{
    public partial class CDragonPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        public string Message { get; private set; } = "PageModel in C#";

        public void OnGet()
        {
            Message = $"Server time is {CDragon.patch}";
            Console.WriteLine(Message);
        }

        public static void UpdateManual()
        {
            _logger.log(LoggingLevel.INFO, "UpdateManual()", "Update in progress");
            Thread DownloadFilesFr = new Thread(() => CDragon.Download.DownloadFiles("latest", "fr_fr"));
            DownloadFilesFr.Start();
            Thread.Sleep(1000);
            Thread DownloadFilesEn = new Thread(() => CDragon.Download.DownloadFiles("latest", "en_gb"));
            DownloadFilesEn.Start();
        }
    }
}
