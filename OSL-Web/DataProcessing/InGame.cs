using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Common.System.Logging;
using static OSL_Web.DataProcessing.InGame;


namespace OSL_Web.DataProcessing
{
    public class InGame
    {
        private static Logger _logger = new("InGame");
        public static bool firstCallPerks = false;
        public static bool initTimerGame = true;
        public static dynamic allPlayerList = null;
        public static dynamic playBack = null;
        public static bool liveEvent = false;
        public static dynamic liveEventContent = null;
        public static GameInformation gameInformation = new();
        public static void ReadData(string content)
        {
            if (content.Contains("gameClients") && content.Contains("gameData") && content.Contains("gameDodge") && content.Contains("map") && content.Contains("phase"))
            {
                Runes.CreateSummonerPerksList(content);
            }
            else
            {
                try
                {
                    //If is json allGameData recive
                    if (content.Contains("championName") && content.Contains("isBot") && content.Contains("isDead") && content.Contains("items")) //is playerlist
                    {
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
                                Console.WriteLine("ORDER -> indexSummoner : " + indexSummoner);
                                if (indexSummoner != -1) //Exist
                                {
                                    gameInformation.Order.Summoners[indexSummoner].IsDead = (bool)allPlayers[i].isDead;
                                    Console.WriteLine("ORDER -> allPlayers[i].isDead : " + allPlayers[i].isDead);
                                    gameInformation.Order.Summoners[indexSummoner].Levels.Level = (int)allPlayers[i].level;
                                    Console.WriteLine("ORDER -> allPlayers[i].Level : " + allPlayers[i].level);
                                    if (allPlayers[i].Level > gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel + 1)
                                    {
                                        gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel++;
                                        Console.WriteLine("ORDER -> gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel : " + gameInformation.Order.Summoners[indexSummoner].Levels.PreviousLevel);
                                        gameInformation.Order.Summoners[indexSummoner].Levels.ToShow = true;
                                    }
                                    gameInformation.Order.Summoners[indexSummoner].PositionIndice = i;
                                    Console.WriteLine("ORDER -> PositionIndice : " + i);
                                    foreach (var item in allPlayers[i].items)
                                    {
                                        int indexItem = gameInformation.Order.Summoners[indexSummoner].Items.FindIndex(x => x.ItemID == (int)item.itemID);
                                        Console.WriteLine("ORDER -> indexItem : " + indexItem);
                                        if (indexItem == -1) //Cet item n'est pas présent
                                        {
                                            Items items = new()
                                            {
                                                ItemID = (int)item.itemID,
                                                ToShow = false,
                                            };
                                            Console.WriteLine("ORDER -> items : " + items);
                                            gameInformation.Order.Summoners[indexSummoner].Items.Add(items);
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
                                        HelderBuff = false,
                                        BaronBuff = false
                                    };
                                    Console.WriteLine("ORDER -> summoner : " + summoner);
                                    gameInformation.Order.Summoners.Add(summoner);
                                    gameInformation.Order.HelderKill = false;
                                    gameInformation.Order.Herald.Killed = false;
                                    gameInformation.Order.Herald.Take = false;
                                    gameInformation.Order.BaronKill = false;
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
                                        HelderBuff = false,
                                        BaronBuff = false
                                    };
                                    gameInformation.Chaos.Summoners.Add(summoner);
                                    gameInformation.Chaos.HelderKill = false;
                                    gameInformation.Chaos.Herald.Killed = false;
                                    gameInformation.Chaos.Herald.Take = false;
                                    gameInformation.Chaos.BaronKill = false;
                                }
                            }

                        }


                        //Check if player are dead when herald buff
                        if (gameInformation.Order.HelderKill)
                        {
                            int countChampNotBuffed = 0;
                            foreach (var summoner in gameInformation.Order.Summoners)
                            {
                                if (summoner.HelderBuff)
                                {
                                    if (summoner.IsDead)
                                    {
                                        summoner.HelderBuff = false;
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
                                gameInformation.Order.HelderKill = false;
                                //Buff timer 0
                                Pages.InGame.TimerControl.buffHelder = 0;
                            }
                            if (Pages.InGame.TimerControl.buffHelder == 0)
                            {
                                gameInformation.Order.HelderKill = false;
                            }
                        }
                        else
                        {
                            int countChampNotBuffed = 0;
                            foreach (var summoner in gameInformation.Chaos.Summoners)
                            {
                                if (summoner.HelderBuff)
                                {
                                    if (summoner.IsDead)
                                    {
                                        summoner.HelderBuff = false;
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
                                gameInformation.Chaos.HelderKill = false;
                                //Buff timer 0
                                Pages.InGame.TimerControl.buffHelder = 0;
                            }
                            if (Pages.InGame.TimerControl.buffHelder == 0)
                            {
                                gameInformation.Chaos.HelderKill = false;
                            }
                        }

                        //Check if player are dead when baron buff
                        if (gameInformation.Order.BaronKill)
                        {
                            int countChampNotBuffed = 0;
                            foreach (var summoner in gameInformation.Order.Summoners)
                            {
                                if (summoner.HelderBuff)
                                {
                                    if (summoner.IsDead)
                                    {
                                        summoner.HelderBuff = false;
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
                                if (summoner.HelderBuff)
                                {
                                    if (summoner.IsDead)
                                    {
                                        summoner.HelderBuff = false;
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

                        liveEvent = false;
                    }
                    else if (content.Contains("length") && content.Contains("paused") && content.Contains("seeking") && content.Contains("speed") && content.Contains("time")) //is playBack 
                    {

                        if (initTimerGame)
                        {
                            //Init timer game start
                            Pages.InGame.TimerControl.InitTimerGameStart();
                            initTimerGame = false;
                        }
                        playBack = JsonConvert.DeserializeObject(content);
                        bool paused = (bool)playBack.paused;
                        if (paused)
                        {
                            Pages.InGame.TimerControl.Pause();
                        }
                        else
                        {
                            if (!Pages.InGame.TimerControl.Enabled())
                            {
                                Pages.InGame.TimerControl.Start();
                            }
                        }

                        double speed = (double)playBack.speed;
                        if (Pages.InGame.TimerControl.generalTimer.Interval != speed * 1000)
                        {
                            Pages.InGame.TimerControl.Interval(1000 / speed);
                        }

                        liveEvent = false;
                    }
                    else
                    {
                        liveEvent = true;
                    }
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.WARN, "ReadData()", "Error deserialize player list, possible not playerList" + e);
                    liveEvent = true;
                }
                if (liveEvent)
                {
                    try
                    {
                        string tempsContent = "[\n" + content.Replace("}", "},") + "]";
                        liveEventContent = JsonConvert.DeserializeObject(tempsContent);
                        foreach (var events in liveEventContent)
                        {
                            string eventname = events.eventname;
                            if (eventname == null)
                            {
                                eventname = "";
                            }
                            if (eventname.Equals("OnKillDragon_Spectator"))
                            {
                                string other = events.other;
                                if (other.Equals("SRU_Dragon_Elder"))
                                {
                                    //Run timer next helder
                                    Pages.InGame.TimerControl.nextHelder = 360;
                                    //Run timer buff helder
                                    Pages.InGame.TimerControl.buffHelder = 150;

                                    string sourceTeam = events.sourceTeam;
                                    if (sourceTeam.Equals("order"))
                                    {
                                        gameInformation.Order.HelderKill = true;
                                        foreach (var summoner in gameInformation.Order.Summoners)
                                        {
                                            if (!summoner.IsDead)//Not dead he win helder dragon buff
                                            {
                                                summoner.HelderBuff = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        gameInformation.Chaos.HelderKill = true;
                                        foreach (var summoner in gameInformation.Chaos.Summoners)
                                        {
                                            if (!summoner.IsDead)//Not dead he win helder dragon buff
                                            {
                                                summoner.HelderBuff = true;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string sourceTeam = events.sourceTeam;
                                    if (sourceTeam.Equals("Order"))
                                    {
                                        Console.WriteLine("add");
                                        gameInformation.Order.Drakes.Add((string)events.other);
                                    }
                                    else if (sourceTeam.Equals("Chaos"))
                                    {
                                        Console.WriteLine("add");
                                        gameInformation.Chaos.Drakes.Add((string)events.other);
                                    }

                                    //Run timer next drake
                                    if (gameInformation.Order.Drakes.Count == 4 || gameInformation.Chaos.Drakes.Count == 4)
                                    {
                                        Pages.InGame.TimerControl.nextHelder = 360;
                                    }
                                    else
                                    {
                                        Pages.InGame.TimerControl.nextDrake = 300;
                                    }
                                }
                            }
                            else if (eventname.Equals("OnKillWorm_Spectator"))
                            {
                                //Run timer next baron
                                Pages.InGame.TimerControl.nextBaron = 360;
                                //Run timer buff
                                Pages.InGame.TimerControl.buffBaron = 210;

                                string sourceTeam = events.sourceTeam;
                                if (sourceTeam.Equals("order"))
                                {
                                    gameInformation.Order.BaronKill = true;
                                    foreach (var summoner in gameInformation.Order.Summoners)
                                    {
                                        if (!summoner.IsDead)//Not dead he win Baron buff
                                        {
                                            summoner.BaronBuff = true;
                                        }
                                    }
                                }
                                else
                                {
                                    gameInformation.Chaos.BaronKill = true;
                                    foreach (var summoner in gameInformation.Chaos.Summoners)
                                    {
                                        if (!summoner.IsDead)//Not dead he win Baron buff
                                        {
                                            summoner.BaronBuff = true;
                                        }
                                    }
                                }
                            }
                            else if (eventname.Equals("OnNeutralMinionKill"))
                            {
                                string other = events.other;
                                if (other.Contains("SRU_RiftHerald"))
                                {
                                    //Run timer next herald if timer not 13:45
                                    double gameTime = playBack.time; //voir pour récupérer le gameTime autre part
                                    DateTime timeTemps = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                                    timeTemps = timeTemps.AddSeconds(gameTime);

                                    if (timeTemps.Minute >= 13 && timeTemps.Second >= 45)
                                    {
                                        Pages.InGame.TimerControl.nextHerald = 0;
                                    }
                                    else
                                    {
                                        Pages.InGame.TimerControl.nextHerald = 480;
                                    }

                                    string sourceTeam = events.sourceTeam;
                                    if (sourceTeam.Equals("order"))
                                    {
                                        gameInformation.Order.Herald.Killed = true;
                                        gameInformation.Order.Herald.Take = false;
                                    }
                                    else
                                    {
                                        gameInformation.Chaos.Herald.Killed = true;
                                        gameInformation.Chaos.Herald
                                            .Take = false;
                                    }
                                }
                            }
                            else if (eventname.Equals("OnMinionKill"))
                            {
                                string other = events.other;
                                if (other.Equals("Rift Herald Relic"))
                                {
                                    //Run timer buff herald
                                    Pages.InGame.TimerControl.buffHerald = 240;

                                    string sourceTeam = events.sourceTeam;
                                    if (sourceTeam.Equals("order"))
                                    {
                                        gameInformation.Order.Herald.Take = true;
                                    }
                                    else
                                    {
                                        gameInformation.Chaos.Herald.Take = true;
                                    }
                                }
                            }
                            else if (eventname.Equals("OnSummonRiftHerald"))
                            {
                                Pages.InGame.TimerControl.buffHerald = 0;
                                string sourceTeam = events.sourceTeam;
                                if (sourceTeam.Equals("order"))
                                {
                                    gameInformation.Order.Herald.Killed = false;
                                }
                                else
                                {
                                    gameInformation.Chaos.Herald.Killed = false;
                                }
                            }
                            //else if (eventname.Equals("OnDampenerDie"))
                            //{
                            //    string sourceTeam = events.sourceTeam;
                            //    string  source = events.source;
                            //    if (sourceTeam.Equals("order"))
                            //    {
                            //        if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibOrderTop = 300;
                            //        }
                            //        else if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibOrderMid = 300;
                            //        }
                            //        else if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibOrderBot = 300;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibChaosTop = 300;
                            //        }
                            //        else if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibChaosMid = 300;
                            //        }
                            //        else if (source.Equals(""))
                            //        {
                            //            Pages.InGame.TimerControl.inhibChaosBot = 300;
                            //        }
                            //    }
                            //}
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.log(LoggingLevel.WARN, "ReadData()", "Error deserialize live event, possible not live event");
                    }
                }
            }
        }

        public class GameInformation
        {
            public double TimeStamp { get; set; }
            public Team Order { get; set; }
            public Team Chaos { get; set; }
            public GameInformation()
            {
                Order = new();
                Chaos = new();
            }
        }

        public class Team
        {
            public List<Summoner> Summoners { get; set; }
            public List<string> Drakes { get; set; }
            public bool HelderKill { get; set; }
            public Herald Herald { get; set; }
            public bool BaronKill { get; set; }
            public Inhib Inhib { get; set; }
            public Team()
            {
                Summoners = new();
                Drakes = new();
                Herald = new();
                Inhib = new();
            }
        }

        public class Summoner
        {
            public string ChampionName { get; set; }
            public bool IsDead { get; set; }
            public List<Items> Items { get; set; }
            public Levels Levels { get; set; }
            public string SummonerName { get; set; }
            public int PositionIndice { get; set; } //Position in allgamedata for display in function of position
            public bool HelderBuff { get; set; }
            public bool BaronBuff { get; set; }
            public Summoner()
            {
                Items = new();
                Levels = new();
            }
        }

        public class Items
        {
            public int ItemID { get; set; }
            public bool ToShow { get; set; }
        }

        public class Levels
        {
            public int Level { get; set; }
            public int PreviousLevel { get; set; }
            public bool ToShow { get; set; }
        }

        public class Herald
        {
            public bool Killed { get; set; }
            public bool Take { get; set; }
        }
        public class Inhib
        {
            public bool TopKilled { get; set; }
            public bool MidKilled { get; set; }
            public bool BotKilled { get; set; }
        }
    }
}
