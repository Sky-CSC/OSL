using Newtonsoft.Json;
using OSL_Client.Configuration;
using OSL_Client.Sockets;
using OSL_Common.System.Logging;
using OSL_LcuApi;

namespace OSL_Client.Riot.GameFlow.Phase
{
    public class EndGame
    {
        private static Logger _logger = new("EndGame");
        public static void Progress()
        {
            var endGameStart = new GameFlow.PhaseStatus
            {
                Phase = "EndGame",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string endGameStartSend = JsonConvert.SerializeObject(endGameStart);
            AsyncClient.Send(endGameStartSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "End game start");

            string sessionInfo = LcuApi.Request(LcuApi.Url.lolendofgamev1eogstatsblock, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
            AsyncClient.Send(sessionInfo);

            while (sessionInfo != null && LcuApi.Request(LcuApi.Url.lolgameflowv1gameflowphase, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword).Equals("\"EndOfGame\""))
            {
                _logger.log(LoggingLevel.INFO, "Progress()", "End game");
                Thread.Sleep(5000);
            }

            var endGameEnd = new GameFlow.PhaseStatus
            {
                Phase = "EndGame",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string endGameEndSend = JsonConvert.SerializeObject(endGameEnd); //send to server information
            AsyncClient.Send(endGameEndSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "End game end");
        }   
    }
}
