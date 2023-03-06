using Newtonsoft.Json;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.DataReciveClient.Processing.InGame;

namespace OSL_Server.DataReciveClient
{
    /// <summary>
    /// Reciva data from client
    /// </summary>
    public class ReciveFromClient
    {
        private static OSLLogger _logger = new OSLLogger("ReciveFromClient");

        private static bool gameFlowPhaseStatus = false;
        private static bool champSelectStatus = false;
        private static bool inGameStatus = false;
        /// <summary>
        /// Read data for set right status
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ReadData(string content)
        {
            string returnData = "default data Server";
            try
            {
                GameFlowPhaseStatus dataJsonRecive = JsonConvert.DeserializeObject<GameFlowPhaseStatus>(content);
                _logger.log(LoggingLevel.INFO, "ReadData()", $"DeserializeObject {content}");
                if (dataJsonRecive.Phase != null)
                {
                    gameFlowPhaseStatus = true;
                    if (dataJsonRecive.Phase.Equals("ChampSelect"))
                    {
                        if (dataJsonRecive.Status.Equals("Running"))
                        {
                            champSelectStatus = true;
                            returnData = "champ select Server running";
                        }
                        else
                        {
                            champSelectStatus = false;
                        }
                    }
                    else if (dataJsonRecive.Phase.Equals("InGame"))
                    {
                        if (dataJsonRecive.Status.Equals("Running"))
                        {
                            inGameStatus = true;
                            InGameInfo.firstCall = true;
                            returnData = "in game Server running";
                        }
                        else
                        {
                            inGameStatus = false;
                        }
                    }
                }
                else
                {
                    gameFlowPhaseStatus = false;
                    returnData = "game flow phase Server OFF";
                }
                _logger.log(LoggingLevel.INFO, "ReadData()", "Read Json GameFlowPhaseStatus");
            }
            catch (Exception e)
            {
                gameFlowPhaseStatus = false;
                _logger.log(LoggingLevel.ERROR, "ReadData()", $"Error Read Json GameFlowPhaseStatus {e.Message}");
                returnData = "game flow phase Server OFF";
            }
            if (!gameFlowPhaseStatus)
            {
                try
                {
                    //dynamic dataJsonRecive = JsonConvert.DeserializeObject(content);
                    if (champSelectStatus)
                    {
                        ChampSelectInfo.InChampSelect(content);
                        returnData = "champ select Server running";
                    }
                    if (inGameStatus)
                    {
                        InGameInfo.InGame(content);
                        returnData = "in game Server running";
                    }
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "ReadData()", $"Error Read Json {e.Message}");
                    returnData = "game flow phase Server OFF";
                }
            }
            return returnData;
        }
    }
    /// <summary>
    /// Game Flow Phase Status
    /// </summary>
    public class GameFlowPhaseStatus
    {
        //public Int64 IdGame { get; set; }
        public string? Phase { get; set; }
        public string? Status { get; set; }
        public string? Date { get; set; }
    }
















    //Server recive from client : 
    //Waiting a Game
    //
    //Champ Select
    //Recive start champ select
    //Prepare to recive data
    //Recive data
    //Display on overlay information of data recive
    //When a champ is pick make request to a API
    //Stats pick
    //Stats ban
    //Stats win
    //Recive end champ select
    //End of champ select

    //Waiting Game Start
    //Display rune of summoners
    //Line vs line
    //Make stats of champ pick by summoners
    //Stats of Champ
    //Line vs line

    //In Game

    //End Game





    /// <summary>
    /// Recovery of information on the champion selection dans send it to the API
    /// </summary>
    //public static void InChampSelect()
    //{
    //    //All information necessary for display pick and ban overlay
    //    string champSelectContentPrevious = "";
    //    string champSelectContent;
    //    while ((champSelectContent = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectv1session)) != null)
    //    {
    //        _logger.log(LoggingLevel.INFO, "ManageChampionSelect()", $"ChampSelectContent is {champSelectContent}");
    //        if (!champSelectContent.Equals(champSelectContentPrevious))
    //        {
    //            _logger.log(LoggingLevel.INFO, "ManageChampionSelect()", "Send ChampSelectContent");
    //            champSelectContentPrevious = champSelectContent;
    //            //Send to Server ChampSelectContent
    //        }
    //        else
    //        {
    //            _logger.log(LoggingLevel.WARN, "ManageChampionSelect()", "No modification of ChampSelectContent");
    //        }
    //        Thread.Sleep(1000);
    //    }
    //}
}

