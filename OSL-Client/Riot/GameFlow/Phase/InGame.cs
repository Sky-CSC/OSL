using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using OSL_Client.Configuration;
using OSL_Client.Sockets;
using OSL_Common.System.Logging;
using OSL_LcuApi;
using OSL_LiveEvents;
using OSL_ReplayApi;

namespace OSL_Client.Riot.GameFlow.Phase
{
    /// <summary>
    /// Gestion of champ selection
    /// </summary>
    public class InGame
    {
        private static Logger _logger = new("InGame");
        /// <summary>
        /// Send information of in game to server
        /// </summary>
        public static void Progress()
        {
            var inGameStart = new GameFlow.PhaseStatus
            {
                Phase = "InGame",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string inGameStartSend = JsonConvert.SerializeObject(inGameStart);
            AsyncClient.Send(inGameStartSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "In game start");

            try
            {
                string sessionInfo = LcuApi.Request(LcuApi.Url.lolgameflowv1session, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
                if (sessionInfo != null)
                {
                    AsyncClient.Send(sessionInfo);
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Progress()", "Error request lolgameflowv1session : " + e.Message);
            }


            //Connexion to LiveEvents
            for (int i = 0; LiveEvents.Connect(Config.localIpHttp, Config.leagueClientLiveEventsPort) == false && i < 20; i++)
            {
                _logger.log(LoggingLevel.INFO, "Progress()", "Wainting LiveEvents Connection");
                Thread.Sleep(1000);
            }

            try
            {

                string gameFlowPhase;
                gameFlowPhase = LcuApi.Request(LcuApi.Url.lolgameflowv1gameflowphase, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
                string replayApiContentPrevious = "";
                string replayApiContent;
                while (gameFlowPhase != null && LcuApi.Request(LcuApi.Url.lolgameflowv1gameflowphase, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword).Equals("\"InProgress\""))
                {
                    _logger.log(LoggingLevel.INFO, "Progress()", "In game");

                    replayApiContent = ReplayApi.Request(ReplayApi.Url.liveclientdataallgamedata, Config.riotPort);
                    if (!replayApiContent.Equals(replayApiContentPrevious))
                    {
                        replayApiContentPrevious = replayApiContent;
                        if (replayApiContent != null)
                        {
                            AsyncClient.Send(replayApiContent);
                        }
                    }
                    else
                    {
                        _logger.log(LoggingLevel.WARN, "Progress()", "No modification of replayApiContent");
                    }

                    string playBackContent = ReplayApi.Request(ReplayApi.Url.replayplayback, Config.riotPort);
                    AsyncClient.Send(playBackContent);

                    string liveEventsContent = LiveEvents.Read();
                    if (liveEventsContent != null)
                    {
                        AsyncClient.Send(liveEventsContent);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Progress()", "Error while (possible lolgameflowv1gameflowphase) : " + e.Message);
            }

            //Close LiveEvents
            LiveEvents.Close();

            var inGameEnd = new GameFlow.PhaseStatus
            {
                Phase = "InGame",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string inGameEndSend = JsonConvert.SerializeObject(inGameEnd); //send to server information
            AsyncClient.Send(inGameEndSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "In game end");
        }
    }
}
