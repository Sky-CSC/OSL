using Newtonsoft.Json;
using OSL_Server.Pages.Runes;

namespace OSL_Server.DataReciveClient.Processing.InGame
{
    public class InGameInfo
    {
        private static OSLLogger _logger = new OSLLogger("InGameInfo");
        public static bool firstCall = false;
        public static void InGame(string content)
        {
            //if (firstCall)
            //{
            //    //_logger.log(LoggingLevel.INFO, "InGame()", $"Content InGame : {content}");
            //    dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //    //foreach (var info in jsonContent)
            //    //{
            //    //    Console.WriteLine(info.summonerName);
            //    //}
            //    Console.WriteLine(jsonContent[0].summonerName);
            //    string summonerName = jsonContent[0].summonerName;
            //    Console.WriteLine(summonerName);
            //    RunesPage.CreateSummonerPerksList(summonerName);
            //    firstCall = false;
            //}
            if (firstCall)
            {
                RunesPage.CreateSummonerPerksListV2(content);
                firstCall = false;
            }
        }
    }
}
