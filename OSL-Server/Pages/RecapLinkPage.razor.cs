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
