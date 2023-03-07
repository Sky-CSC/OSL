using Newtonsoft.Json;
using OSL_Client.Communication.OSLServer;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.RiotApp.DataProcessing
{
    /// <summary>
    /// End Game Process
    /// </summary>
    internal class EndGameProcess
    {
        /// <summary>
        /// Send to socket server data recive from riot client from end game
        /// </summary>
        public static void InEndGame()
        {
            var inGameStart = new GameFlowPhaseStatus
            {
                //IdGame = NewGameProcess.IdGame,
                Phase = "EndGame",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string inGameStartSend = JsonConvert.SerializeObject(inGameStart); //send to server information
            AsyncClient.StartClient(inGameStartSend);

            string sessionInfo = ApiRequest.RequestGameClientAPI("/lol-end-of-game/v1/eog-stats-block");
            AsyncClient.StartClient(sessionInfo);

            var inGameEnd = new GameFlowPhaseStatus
            {
                //IdGame = NewGameProcess.IdGame,
                Phase = "EndGame",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string inGameEndSend = JsonConvert.SerializeObject(inGameEnd); //send to server information
            AsyncClient.StartClient(inGameEndSend);
        }
    }
}
