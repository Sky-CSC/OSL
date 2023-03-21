using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Client.Communication.OSLServer;
using OSL_Client.FileManager;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;

namespace OSL_Client.RiotApp.DataProcessing
{
    /// <summary>
    /// Champ select process
    /// </summary>
    internal class ChampSelectProcess
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectProcess");
        /// <summary>
        /// Recovery of information on the champion selection dans send it to the API
        /// </summary>
        static private System.Random random = new System.Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Send to socket server data recive from riot client from champ select, and add informations on him (summoner name, not just ID)
        /// </summary>
        public static void InChampSelect()
        {
            NewGameProcess.IdGame = random.NextInt64(); //Possible server give IdGame
            //Send to server json
            var champSelectStart = new GameFlowPhaseStatus
            {
                //IdGame = NewGameProcess.IdGame,
                Phase = "ChampSelect",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string InChampSelectStartSend = JsonConvert.SerializeObject(champSelectStart); //send to server information
            //AsyncClient.StartClient(InChampSelectStartSend);
            AsyncClient.Send(InChampSelectStartSend);

            //All information necessary for display pick and ban overlay
            string champSelectContentPrevious = "";
            string champSelectContent;
            int i = 0;
            while ((champSelectContent = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectv1session)) != null && ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase).Equals(GameFlowPhase.ChampSelect))
            {
                _logger.log(LoggingLevel.INFO, "InChampSelect()", $"In champ select");
                //_logger.log(LoggingLevel.INFO, "ManageChampionSelect()", $"ChampSelectContent is {champSelectContent}");
                if (!champSelectContent.Equals(champSelectContentPrevious))
                {
                    champSelectContentPrevious = champSelectContent;

                    try
                    {
                        dynamic champSelectContentJson = JsonConvert.DeserializeObject(champSelectContent);
                        foreach (var myTeamInfo in champSelectContentJson.myTeam)
                        {
                            string nameSummoner = "Bot";
                            if (myTeamInfo.summonerId != 0)
                            {
                                string requestSummonerName = UrlRequest.lolsummonerv1summonersid + myTeamInfo.summonerId;
                                string summonerContent = ApiRequest.RequestGameClientAPI(requestSummonerName);
                                dynamic info = JsonConvert.DeserializeObject(summonerContent);
                                nameSummoner = info.displayName;
                                myTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                            else
                            {
                                myTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                        }

                        foreach (var theirTeamInfo in champSelectContentJson.theirTeam)
                        {
                            string nameSummoner = "Bot";
                            if (theirTeamInfo.summonerId != 0)
                            {
                                string requestSummonerName = UrlRequest.lolsummonerv1summonersid + theirTeamInfo.summonerId;
                                string summonerContent = ApiRequest.RequestGameClientAPI(requestSummonerName);
                                dynamic info = JsonConvert.DeserializeObject(summonerContent);
                                nameSummoner = info.displayName;
                                theirTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                            else
                            {
                                theirTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                        }

                        //foreach (var myTeamInfo in champSelectContentJson)
                        //{
                        //    Console.WriteLine(myTeamInfo);
                        //}

                        champSelectContent = JsonConvert.SerializeObject(champSelectContentJson);

                    }
                    catch (Exception e)
                    {
                        _logger.log(LoggingLevel.ERROR, "InChampSelect()", $"Error Name Summoners {e.Message}");
                    }

                    FileManagerLocal.RewrittenFile($"E:/Overlay-found-riot/ChampSelectAll/champSelectAll{i}.json", champSelectContent);
                    _logger.log(LoggingLevel.INFO, "InChampSelect()", "Send ChampSelectContent");
                    i++;

                    //Send to Server ChampSelectContent
                    //AsyncClient.StartClient(champSelectContent);
                    AsyncClient.Send(champSelectContent);


                }
                else
                {
                    _logger.log(LoggingLevel.WARN, "InChampSelect()", "No modification of ChampSelectContent");
                }
                Thread.Sleep(1000);
            }
            //Send to server json
            var champSelectEnd = new GameFlowPhaseStatus
            {
                //IdGame = NewGameProcess.IdGame,
                Phase = "ChampSelect",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string InChampSelectEndSend = JsonConvert.SerializeObject(champSelectEnd); //send to server information
            //AsyncClient.StartClient(InChampSelectEndSend);
            AsyncClient.Send(InChampSelectEndSend);
            _logger.log(LoggingLevel.WARN, "InChampSelect()", "End of ChampSelect");
        }

        /// <summary>
        /// Summoner name
        /// </summary>
        private class summoner
        {
            public string NameSummoner { get; set; }
        }

        //private class ChampSelect
        //{
        //    public Int64 IdGame { get; set; }
        //    public string? Info { get; set; }
        //    public string? Status { get; set; }
        //    public string? Date { get; set; }
        //}
    }
}
