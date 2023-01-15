using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;

namespace OSL_Server.Pages
{
    public partial class RecapLinkPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        private string linkWaitingAGame = "";
        static private System.Random random = new System.Random(DateTime.Now.Millisecond);
        private void GenerateLink()
        {
            Int64 RandomLink = random.NextInt64();

            linkWaitingAGame = $"https://localhost:7045/{RandomLink}";
        }
    }
}
