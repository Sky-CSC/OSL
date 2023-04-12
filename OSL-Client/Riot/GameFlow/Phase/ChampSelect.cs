using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Client.Configuration;
using OSL_Client.Sockets;
using OSL_Common.System.Logging;
using OSL_LcuApi;

namespace OSL_Client.Riot.GameFlow.Phase
{
    public class ChampSelect
    {
        private static Logger _logger = new("ChampSelect");
        public static void Progress()
        {
            var champSelectStart = new GameFlow.PhaseStatus
            {
                Phase = "ChampSelect",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string InChampSelectStartSend = JsonConvert.SerializeObject(champSelectStart); //send to server information
            AsyncClient.Send(InChampSelectStartSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "Champ select start");

            //All information necessary for display pick and ban overlay
            string champSelectContentPrevious = "";
            string champSelectContent;
            while ((champSelectContent = LcuApi.Request(LcuApi.Url.lolchampselectv1session, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword)) != null && LcuApi.Request(LcuApi.Url.lolgameflowv1gameflowphase, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword).Equals("\"ChampSelect\""))
            {
                _logger.log(LoggingLevel.INFO, "Progress()", "In champ select");
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
                                string requestSummonerName = LcuApi.Url.lolsummonerv1summonersid + myTeamInfo.summonerId;
                                string summonerContent = LcuApi.Request(requestSummonerName, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
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
                                string requestSummonerName = LcuApi.Url.lolsummonerv1summonersid + theirTeamInfo.summonerId;
                                string summonerContent = LcuApi.Request(requestSummonerName, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
                                dynamic info = JsonConvert.DeserializeObject(summonerContent);
                                nameSummoner = info.displayName;
                                theirTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                            else
                            {
                                theirTeamInfo.Property("summonerId").AddAfterSelf(new JProperty("summonerName", nameSummoner));
                            }
                        }

                        champSelectContent = JsonConvert.SerializeObject(champSelectContentJson);

                    }
                    catch (Exception e)
                    {
                        _logger.log(LoggingLevel.ERROR, "InChampSelect()", $"Error Name Summoners {e.Message}");
                    }

                    _logger.log(LoggingLevel.INFO, "InChampSelect()", "Send ChampSelectContent");

                    //Send to Server ChampSelectContent
                    AsyncClient.Send(champSelectContent);


                }
                else
                {
                    _logger.log(LoggingLevel.WARN, "InChampSelect()", "No modification of ChampSelectContent");
                }
                Thread.Sleep(1000);
            }
            //Send to server json
            var champSelectEnd = new GameFlow.PhaseStatus
            {
                Phase = "ChampSelect",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string InChampSelectEndSend = JsonConvert.SerializeObject(champSelectEnd); //send to server information
            AsyncClient.Send(InChampSelectEndSend);

            _logger.log(LoggingLevel.INFO, "Progress()", "Champ select end");
        }
    }
}
