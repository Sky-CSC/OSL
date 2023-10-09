using Newtonsoft.Json;
using OSL_Common.System.Logging;

namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        public static bool LiveClientDataPlayerList(string content)
        {
            try
            {
                if (content.Contains("championName") && content.Contains("isBot") && content.Contains("isDead") && content.Contains("items")) //is playerlist
                {
                    _logger.log(LoggingLevel.INFO, "LiveClientDataPlayerList()", "In LiveClientDataPlayerList");
                    allPlayerList = JsonConvert.DeserializeObject(content);

                    //Console.WriteLine("ici");
                    //Console.WriteLine(allPlayerList[0]);
                    //Console.WriteLine(allPlayerList[0].championName);

                    List<dynamic> allPlayers = new();
                    allPlayers = allPlayerList.ToObject<List<dynamic>>();
                    //dynamic allPlayers = allPlayerList;
                    //Console.WriteLine(allPlayers.Count());
                    //Console.WriteLine("la");
                    for (int i = 0; i < allPlayers.Count(); i++)
                    {
                        string team = allPlayers[i].team;
                        if (team.Equals("ORDER"))
                        {
                            int indexSummoner = gameInformation.Order.Summoners.FindIndex(x => x.SummonerName == (string)allPlayers[i].summonerName);
                            //Console.WriteLine("ORDER -> indexSummoner : " + indexSummoner);
                            if (indexSummoner != -1) //Exist
                            {
                                gameInformation.Order.Summoners[indexSummoner].IsDead = (bool)allPlayers[i].isDead;
                                //Console.WriteLine("ORDER -> allPlayers[i].isDead : " + allPlayers[i].isDead);
                                gameInformation.Order.Summoners[indexSummoner].Levels.Level = (int)allPlayers[i].level;
                                //Console.WriteLine("ORDER -> allPlayers[i].Level : " + allPlayers[i].level);

                                if (gameInformation.Order.Summoners[indexSummoner].Levels.Level > gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel + 1)
                                {
                                    gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel++;
                                    //Console.WriteLine("ORDER -> gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel : " + gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel);
                                    gameInformation.Order.Summoners[indexSummoner].Levels.ToShow = true;
                                }
                                gameInformation.Order.Summoners[indexSummoner].PositionIndice = i;
                                //Console.WriteLine("ORDER -> PositionIndice : " + i);
                                foreach (var item in allPlayers[i].items)
                                {
                                    int indexItem = gameInformation.Order.Summoners[indexSummoner].Items.FindIndex(x => x.ItemID == (int)item.itemID);
                                    //Console.WriteLine("ORDER -> indexItem : " + indexItem);
                                    if (indexItem == -1) //Cet item n'est pas présent
                                    {
                                        Items items = new()
                                        {
                                            ItemID = (int)item.itemID,
                                            ToShow = false,
                                        };
                                        //Console.WriteLine("ORDER -> items : " + items);
                                        gameInformation.Order.Summoners[indexSummoner].Items.Add(items);
                                    }
                                    //Console.WriteLine("ORDER -> idItem : " + (int)item.itemID);
                                }
                            }
                            else
                            {
                                Summoner summoner = new()
                                {
                                    ChampionName = (string)allPlayers[i].championName,
                                    IsDead = (bool)allPlayers[i].isDead,
                                    Levels = new()
                                    {
                                        Level = (int)allPlayers[i].level,
                                        PreviousLevel = (int)allPlayers[i].level - 1,
                                        ToShow = false,
                                    },
                                    SummonerName = (string)allPlayers[i].summonerName,
                                    PositionIndice = i,
                                    ElderBuff = false,
                                    BaronBuff = false
                                };
                                //Console.WriteLine("ORDER -> summoner : " + summoner);
                                gameInformation.Order.Summoners.Add(summoner);
                                gameInformation.Order.ElderKill = false;
                                gameInformation.Order.Herald.Killed = false;
                                gameInformation.Order.Herald.Take = false;
                                gameInformation.Order.BaronKill = false;
                                gameInformation.Order.Inhib.TopKilled = false;
                                gameInformation.Order.Inhib.MidKilled = false;
                                gameInformation.Order.Inhib.BotKilled = false;

                            }
                        }
                        else //Chaos
                        {
                            int indexSummoner = gameInformation.Chaos.Summoners.FindIndex(x => x.SummonerName == (string)allPlayers[i].summonerName);
                            if (indexSummoner != -1) //Exist
                            {
                                gameInformation.Chaos.Summoners[indexSummoner].IsDead = (bool)allPlayers[i].isDead;
                                gameInformation.Chaos.Summoners[indexSummoner].Levels.Level = (int)allPlayers[i].level;
                                if (allPlayers[i].Level > gameInformation.Chaos.Summoners[indexSummoner].Levels.PreviousLevel + 1)
                                {
                                    gameInformation.Chaos.Summoners[indexSummoner].Levels.PreviousLevel++;
                                    gameInformation.Chaos.Summoners[indexSummoner].Levels.ToShow = true;
                                }
                                gameInformation.Chaos.Summoners[indexSummoner].PositionIndice = i;
                                foreach (var item in allPlayers[i].items)
                                {
                                    int indexItem = gameInformation.Chaos.Summoners[indexSummoner].Items.FindIndex(x => x.ItemID == (int)item.itemID);
                                    if (indexItem == -1) //Cet item n'est pas présent
                                    {
                                        Items items = new()
                                        {
                                            ItemID = (int)item.itemID,
                                            ToShow = false,
                                        };
                                        gameInformation.Chaos.Summoners[indexSummoner].Items.Add(items);
                                    }
                                }
                            }
                            else
                            {
                                Summoner summoner = new()
                                {
                                    ChampionName = (string)allPlayers[i].championName,
                                    IsDead = (bool)allPlayers[i].isDead,
                                    Levels = new()
                                    {
                                        Level = (int)allPlayers[i].level,
                                        PreviousLevel = (int)allPlayers[i].level - 1,
                                        ToShow = false,
                                    },
                                    SummonerName = (string)allPlayers[i].summonerName,
                                    PositionIndice = i,
                                    ElderBuff = false,
                                    BaronBuff = false
                                };
                                gameInformation.Chaos.Summoners.Add(summoner);
                                gameInformation.Chaos.ElderKill = false;
                                gameInformation.Chaos.Herald.Killed = false;
                                gameInformation.Chaos.Herald.Take = false;
                                gameInformation.Chaos.BaronKill = false;
                                gameInformation.Chaos.Inhib.TopKilled = false;
                                gameInformation.Chaos.Inhib.MidKilled = false;
                                gameInformation.Chaos.Inhib.BotKilled = false;
                            }
                        }

                    }


                    //Check if player are dead when herald buff
                    if (gameInformation.Order.ElderKill)
                    {
                        int countChampNotBuffed = 0;
                        foreach (var summoner in gameInformation.Order.Summoners)
                        {
                            if (summoner.ElderBuff)
                            {
                                if (summoner.IsDead)
                                {
                                    summoner.ElderBuff = false;
                                    countChampNotBuffed++;
                                }
                            }
                            else
                            {
                                countChampNotBuffed++;
                            }
                        }
                        if (countChampNotBuffed == gameInformation.Order.Summoners.Count())
                        {
                            gameInformation.Order.ElderKill = false;
                            //Buff timer 0
                            Pages.InGame.TimerControl.buffElder = 0;
                        }
                        if (Pages.InGame.TimerControl.buffElder == 0)
                        {
                            gameInformation.Order.ElderKill = false;
                        }
                    }
                    else
                    {
                        int countChampNotBuffed = 0;
                        foreach (var summoner in gameInformation.Chaos.Summoners)
                        {
                            if (summoner.ElderBuff)
                            {
                                if (summoner.IsDead)
                                {
                                    summoner.ElderBuff = false;
                                    countChampNotBuffed++;
                                }
                            }
                            else
                            {
                                countChampNotBuffed++;
                            }
                        }
                        if (countChampNotBuffed == gameInformation.Chaos.Summoners.Count())
                        {
                            gameInformation.Chaos.ElderKill = false;
                            //Buff timer 0
                            Pages.InGame.TimerControl.buffElder = 0;
                        }
                        if (Pages.InGame.TimerControl.buffElder == 0)
                        {
                            gameInformation.Chaos.ElderKill = false;
                        }
                    }

                    //Check if player are dead when baron buff
                    if (gameInformation.Order.BaronKill)
                    {
                        int countChampNotBuffed = 0;
                        foreach (var summoner in gameInformation.Order.Summoners)
                        {
                            if (summoner.BaronBuff)
                            {
                                if (summoner.IsDead)
                                {
                                    summoner.BaronBuff = false;
                                    countChampNotBuffed++;
                                }
                            }
                            else
                            {
                                countChampNotBuffed++;
                            }
                        }
                        if (countChampNotBuffed == gameInformation.Order.Summoners.Count())
                        {
                            gameInformation.Order.BaronKill = false;
                            //Buff timer 0
                            Pages.InGame.TimerControl.buffBaron = 0;
                        }
                        if (Pages.InGame.TimerControl.buffBaron == 0)
                        {
                            gameInformation.Order.BaronKill = false;
                        }
                    }
                    else
                    {
                        int countChampNotBuffed = 0;
                        foreach (var summoner in gameInformation.Chaos.Summoners)
                        {
                            if (summoner.BaronBuff)
                            {
                                if (summoner.IsDead)
                                {
                                    summoner.BaronBuff= false;
                                    countChampNotBuffed++;
                                }
                            }
                            else
                            {
                                countChampNotBuffed++;
                            }
                        }
                        if (countChampNotBuffed == gameInformation.Chaos.Summoners.Count())
                        {
                            gameInformation.Chaos.BaronKill = false;
                            //Buff timer 0
                            Pages.InGame.TimerControl.buffBaron = 0;
                        }
                        if (Pages.InGame.TimerControl.buffBaron == 0)
                        {
                            gameInformation.Chaos.BaronKill = false;
                        }
                    }
                    return true;
                }
                _logger.log(LoggingLevel.WARN, "LiveClientDataPlayerList()", "Not LiveClientDataPlayerList");
                return false;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "LiveClientDataPlayerList()", "Error deserialize LiveClientDataPlayerList, possible not LiveClientDataPlayerList" + e);
                return false;
            }
        }
    }
}
