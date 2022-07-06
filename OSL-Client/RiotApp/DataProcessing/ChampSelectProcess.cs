using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Client.FileManager;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;

namespace OSL_Client.RiotApp.DataProcessing
{
    internal class ChampSelectProcess
    {
        private static OSLLogger _logger = new OSLLogger("ChampionSelect");
        /// <summary>
        /// Recovery of information on the champion selection dans send it to the API
        /// </summary>
        static private System.Random random = new System.Random(DateTime.Now.Millisecond);

        public static void InChampSelect()
        {
            NewGameProcess.IdGame = random.NextInt64(); //Possible server give IdGame
            //Send to server json
            var champSelect = new ChampSelect
            {
                IdGame = NewGameProcess.IdGame,
                Info = "ChampSelect",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string InChampSelectSend = JsonConvert.SerializeObject(champSelect); //send to server information

            //All information necessary for display pick and ban overlay
            string champSelectContentPrevious = "";
            string champSelectContent;
            int i = 0;
            while ((champSelectContent = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectv1session)) != null)
            {
                _logger.log(LoggingLevel.INFO, "ManageChampionSelect()", $"ChampSelectContent is {champSelectContent}");
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
                    _logger.log(LoggingLevel.INFO, "ManageChampionSelect()", "Send ChampSelectContent");
                    i++;
                    //Send to Server ChampSelectContent
                }
                else
                {
                    _logger.log(LoggingLevel.WARN, "ManageChampionSelect()", "No modification of ChampSelectContent");
                }
                Thread.Sleep(1000);
            }
            _logger.log(LoggingLevel.WARN, "ManageChampionSelect()", "End of ChampSelect");
        }

        private class summoner
        {
            public string NameSummoner { get; set; }
        }

        private class ChampSelect
        {
            public Int64 IdGame { get; set; }
            public string? Info { get; set; }
            public string? Status { get; set; }
            public string? Date { get; set; }
        }
    }
}
