using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_WebApiRiot.WebApiRiot;

namespace OSL_Web.DataProcessing
{
    public class EndGame
    {
        private static Logger _logger = new("EndGame");
        public static dynamic jsonContentEndOfMatch = null;
        public static dynamic jsonContentMatch = null;
        public static dynamic jsonContentTimeline = null;
        public static void ReadData(string content)
        {
            try
            {
                jsonContentEndOfMatch = JsonConvert.DeserializeObject(content); //Game client information
                Int64 gameId = jsonContentEndOfMatch.gameId; //Get gameID
                jsonContentMatch = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Match_V5.Matches(gameId)));//Get game information from web api riot
                jsonContentTimeline = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Match_V5.Timeline(gameId)));//Get game information from web api riot
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadData()", $"Error read end game data {e.Message}");
            }
        }
    }
}
