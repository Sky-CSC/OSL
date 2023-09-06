using OSL_Common.System.Logging;

namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        public static bool GameFlowSession(string content)
        {
            try
            {
                if (content.Contains("gameClient") && content.Contains("gameData") && content.Contains("gameDodge") && content.Contains("map") && content.Contains("phase"))
                {
                    _logger.log(LoggingLevel.INFO, "GameFlowSession()", "In GameFlowSession");
                    Runes.CreateSummonerPerksList(content);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "GameFlowSession()", "Error deserialize GameFlowSession, possible not GameFlowSession" + e);
                return false;
            }
        }
    }
}
