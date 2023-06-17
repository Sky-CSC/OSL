using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Common.System.Logging;


namespace OSL_Web.DataProcessing
{
    public class InGame
    {
        private static Logger _logger = new("InGame");
        public static bool firstCallPerks = false;
        public static bool initTimerGame = true;
        public static dynamic allGameData = null;
        public static dynamic playBack = null;
        public static bool liveEvent = false;
        public static dynamic liveEventContent = null;
        public static GameInformation gameInformation = new();
        public static void ReadData(string content)
        {
            //if (firstCallPerks)
            //{
            //    Runes.CreateSummonerPerksList(content);
            //    firstCallPerks = false;
            //}
            //Faire des fonctions pour valider si c'est telle ou tel type de donnée
            if (content.Contains("gameClients") && content.Contains("gameData") && content.Contains("gameDodge") && content.Contains("map") && content.Contains("phase"))
            {
                Runes.CreateSummonerPerksList(content);
            }
            else
            {
                try
                {
                    //If is json allGameData recive
                    if (content.Contains("activePlayer") && content.Contains("allPlayers") && content.Contains("events") && content.Contains("gameData"))
                    {
                        allGameData = JsonConvert.DeserializeObject(content);

                        //foreach (var data in allGameData)
                        //{
                        //    if (data.)
                        //    //Console.WriteLine(champion.championName);
                        //    foreach (var items in data.items)
                        //    {
                        //        //Console.WriteLine(items.itemID);
                        //    }
                        //    //Console.WriteLine(champion.level);
                        //}

                        //Check if player are dead when herald buff
                        if (gameInformation.Helder.Killed)
                        {
                            foreach (var player in allGameData.allPlayers)
                            {
                                string team = player.team;
                                if (team.Equals(gameInformation.Helder.Team.ToUpper()))
                                {
                                    if (player.isDead)
                                    {
                                        gameInformation.Helder.ChampionBuff[gameInformation.Helder.ChampionBuff.IndexOf(player.summonerName)].Buffed = false;
                                    }
                                }
                            }
                            int countChampNotBuffed = 0;
                            foreach (var buffed in gameInformation.Helder.ChampionBuff)
                            {
                                if (!buffed.Buffed)
                                {
                                    countChampNotBuffed++;
                                }
                            }
                            if (countChampNotBuffed == gameInformation.Helder.ChampionBuff.Count())
                            {
                                gameInformation.Helder.Killed = false;
                                //Buff timer 0
                                Pages.InGame.TimerControl.buffHelder = 0;
                            }
                        }

                        //Check if player are dead when baron buff
                        if (gameInformation.Baron.Killed)
                        {
                            foreach (var player in allGameData.allPlayers)
                            {
                                string team = player.team;
                                if (team.Equals(gameInformation.Baron.Team.ToUpper()))
                                {
                                    if (player.isDead)
                                    {
                                        gameInformation.Baron.ChampionBuff[gameInformation.Baron.ChampionBuff.IndexOf(player.summonerName)].Buffed = false;
                                    }
                                }
                            }
                            int countChampNotBuffed = 0;
                            foreach (var buffed in gameInformation.Baron.ChampionBuff)
                            {
                                if (!buffed.Buffed)
                                {
                                    countChampNotBuffed++;
                                }
                            }
                            if (countChampNotBuffed == gameInformation.Baron.ChampionBuff.Count())
                            {
                                gameInformation.Baron.Killed = false;
                                //Buff timer 0
                                Pages.InGame.TimerControl.buffBaron = 0;
                            }
                        }

                        liveEvent = false;
                    }
                    else if (content.Contains("length") && content.Contains("paused") && content.Contains("seeking") && content.Contains("speed") && content.Contains("time"))
                    {

                        if (initTimerGame)
                        {
                            //Init timer game start
                            Pages.InGame.TimerControl.InitTimerGameStart();
                            initTimerGame = false;
                        }

                        playBack = JsonConvert.DeserializeObject(content);
                        bool paused = playBack.paused;
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

                        float speed = playBack.speed;
                        Pages.InGame.TimerControl.Interval(1000/speed);

                        //if (speed == 0.25)
                        //{
                        //    Pages.InGame.TimerControl.Interval(4000);
                        //}
                        //else if (speed == 0.50)
                        //{
                        //    Pages.InGame.TimerControl.Interval(2000);
                        //}
                        //else if (speed == 1)
                        //{
                        //    Pages.InGame.TimerControl.Interval(1000);
                        //}
                        //else if (speed == 2)
                        //{
                        //    Pages.InGame.TimerControl.Interval(500);
                        //}
                        //else if (speed == 4)
                        //{
                        //    Pages.InGame.TimerControl.Interval(250);
                        //}
                        //else if (speed == 8)
                        //{
                        //    Pages.InGame.TimerControl.Interval(125);
                        //}

                        liveEvent = false;
                    }
                    else
                    {
                        liveEvent = true;
                    }
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.WARN, "ReadData()", "Error deserialize player list, possible not playerList");
                    liveEvent = true;
                }
                if (liveEvent)
                {
                    try
                    {
                        string tempsContent = "[\n" + content.Replace("}", "},") + "]";
                        //Console.WriteLine(tempsContent);
                        liveEventContent = JsonConvert.DeserializeObject(tempsContent);
                        foreach (var events in liveEventContent)
                        {
                            //Console.WriteLine(events.eventname);
                            string eventname = events.eventname;
                            if (eventname.Equals("OnKillDragon_Spectator"))
                            {
                                string other = events.other;
                                if (other.Equals("SRU_Dragon_Elder"))
                                {
                                    //Run timer next helder
                                    Pages.InGame.TimerControl.nextHelder = 360;
                                    //Run timer buff helder
                                    Pages.InGame.TimerControl.buffHelder = 150;

                                    Console.WriteLine(events.eventname);
                                    Console.WriteLine(events.other);
                                    Console.WriteLine(events.sourceTeam);
                                    gameInformation.Helder.Killed = true;
                                    string sourceTeam = events.sourceTeam;
                                    gameInformation.Helder.Team = sourceTeam;
                                    foreach (var player in allGameData.allPlayers)
                                    {
                                        string team = player.team;
                                        if (team.Equals(sourceTeam.ToUpper()))
                                        {
                                            ChampionBuff championBuff = new();
                                            championBuff.SummonerName = player.summonerName;
                                            if (!player.isDead)
                                            {
                                                championBuff.Buffed = true;
                                            }
                                            else
                                            {
                                                championBuff.Buffed = false;
                                            }
                                            gameInformation.Helder.ChampionBuff.Add(championBuff);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(events.eventname);
                                    Console.WriteLine(events.other);
                                    Console.WriteLine(events.sourceTeam);
                                    string sourceTeam = events.sourceTeam;
                                    if (sourceTeam.Equals("Order"))
                                    {
                                        gameInformation.Drake.Order.Add(events.other);
                                    }
                                    else if (sourceTeam.Equals("Chaos"))
                                    {
                                        gameInformation.Drake.Chaos.Add(events.other);
                                    }

                                    //Run timer next drake
                                    if (gameInformation.Drake.Order.Count == 4 || gameInformation.Drake.Chaos.Count == 4)
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

                                Console.WriteLine(events.eventname);
                                Console.WriteLine(events.other);
                                Console.WriteLine(events.sourceTeam);
                                foreach (var champion in allGameData)
                                {
                                    //Console.WriteLine(champion.championName);
                                    string team = champion.team;
                                    string sourceTeam = events.sourceTeam;
                                    sourceTeam = sourceTeam.ToUpper();
                                    if (team.Equals(sourceTeam))
                                    {
                                        bool isDead = champion.isDead;
                                        if (!isDead)
                                        {
                                            Console.WriteLine("Alive " + champion.championName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Dead " + champion.championName);
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
                                    double gameTime = allGameData.gameData.gameTime;
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

                                    Console.WriteLine(events.eventname);
                                    Console.WriteLine(events.other);
                                    Console.WriteLine(events.sourceTeam);
                                }
                            }
                            else if (eventname.Equals("OnMinionKill"))
                            {
                                string other = events.other;
                                if (other.Equals("Rift Herald Relic"))
                                {
                                    //Run timer buff herald
                                    Pages.InGame.TimerControl.buffHerald = 240;

                                    Console.WriteLine(events.eventname);
                                    Console.WriteLine(events.other);
                                    Console.WriteLine(events.otherTeam);
                                }
                            }
                            else if (eventname.Equals("OnSummonRiftHerald"))
                            {
                                Pages.InGame.TimerControl.buffHerald = 0;
                                Console.WriteLine(events.eventname);
                                Console.WriteLine(events.other);
                                Console.WriteLine(events.sourceTeam);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.log(LoggingLevel.WARN, "ReadData()", "Error deserialize live event, possible not live event");
                    }
                }
            }


            //Faire une liste d'objet qui se rempli et ce vide à chaque fois que les pages y accédent
            //Des que un event, item, level arrive, le inGame le consome et le supprime
            //La page met à jours ces donnée pour savoir ce qu'il y à en cours comme pour les drake par exemple
            //Récupérer avec le timer les LiveEvents pour savoir si ils ont déjà eu lieu ou pas

            //Pour les items si https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/fr_fr/v1/items.json
            //to est vide alors c'est le dernier item de ça branche

            //If ReplayApi create summoner list, update it 
            //Mettre à jours que si c'est différent du json reçu précédament (comme pour champ select dans l'idée)
            //Afficher les items quand acheté et les level up, pas en boucle 
            //Si la page n'as jamais chargé la liste il la charge et met un bool à false, plus dispo pour charger info


            //Pourquoi ne pas rajouter à allgamedata les true false pour les buff et aussi les drake
            //On ajoute un true false pour les buff dans allPlayers
            //On ajoute un catégorie drake avec les équipes et chacun les drake kill
        }

        public static void CreationGameInformation()
        {
            gameInformation.TimeStamp = 123.123;
            //gameInformation.Drake = new();
            //gameInformation.Drake.Order = new();
            //gameInformation.Drake.Chaos = new();
            gameInformation.Drake.Order.Add("Fire");
            gameInformation.Drake.Order.Add("Hextech");
            gameInformation.Drake.Order.Add("Air");
            gameInformation.Drake.Chaos.Add("Water");
            gameInformation.Drake.Chaos.Add("Chemtech");
            gameInformation.Drake.Chaos.Add("Earth");
            gameInformation.Helder.Killed = true;
            gameInformation.Helder.Team = "Chaos";
            //gameInformation.Helder.ChampionBuff = new();
            ChampionBuff temps = new();
            temps.SummonerName = "Sky";
            temps.Buffed = true;
            gameInformation.Helder.ChampionBuff.Add(temps);
            ChampionBuff temps2 = new();
            temps2.SummonerName = "Skynet";
            temps2.Buffed = false;
            gameInformation.Helder.ChampionBuff.Add(temps2);

            gameInformation.Baron.Killed = true;
            gameInformation.Baron.Team = "Chaos";
            //gameInformation.Baron.ChampionBuff = new();
            ChampionBuff temps3 = new();
            temps3.SummonerName = "Sky";
            temps3.Buffed = false;
            gameInformation.Baron.ChampionBuff.Add(temps3);
            ChampionBuff temps4 = new();
            temps4.SummonerName = "Skynet";
            temps4.Buffed = true;
            gameInformation.Baron.ChampionBuff.Add(temps4);

            gameInformation.Herald.Killed = true;
            gameInformation.Herald.Team = "order";
            gameInformation.Herald.Take = true;
            gameInformation.Herald.Launch = false;

            Console.WriteLine("TimeStamp");
            Console.WriteLine(gameInformation.TimeStamp);
            Console.WriteLine("\nDrake");
            foreach (var info in gameInformation.Drake.Order)
            {
                Console.WriteLine("Order" + info);
            }
            foreach (var info in gameInformation.Drake.Chaos)
            {
                Console.WriteLine("Chaos" + info);
            }
            Console.WriteLine("\nHelder");
            Console.WriteLine(gameInformation.Helder.Killed);
            Console.WriteLine(gameInformation.Helder.Team);
            foreach (var info in gameInformation.Helder.ChampionBuff)
            {
                Console.WriteLine(info.SummonerName);
                Console.WriteLine(info.Buffed);
            }
            Console.WriteLine("\nBaron");
            Console.WriteLine(gameInformation.Baron.Killed);
            Console.WriteLine(gameInformation.Baron.Team);
            foreach (var info in gameInformation.Baron.ChampionBuff)
            {
                Console.WriteLine(info.SummonerName);
                Console.WriteLine(info.Buffed);
            }
            Console.WriteLine("\nHerald");
            Console.WriteLine(gameInformation.Herald.Killed);
            Console.WriteLine(gameInformation.Herald.Team);
            Console.WriteLine(gameInformation.Herald.Take);
            Console.WriteLine(gameInformation.Herald.Launch);
        }

        public class GameInformation
        {
            public double TimeStamp { get; set; }
            public Drake Drake { get; set; }
            public Buff Helder { get; set; }
            public Buff Baron { get; set; }
            public Herald Herald { get; set; }
            public GameInformation()
            {
                Drake = new();
                Helder = new();
                Baron = new();
                Herald = new();
            }
        }

        public class Drake
        {
            public List<string> Order { get; set; }
            public List<string> Chaos { get; set; }
            public Drake()
            {
                Order = new();
                Chaos = new();
            }
        }

        public class Buff
        {
            public bool Killed { get; set; }
            public string Team { get; set; }
            public List<ChampionBuff> ChampionBuff { get; set; }
            public Buff()
            {
                ChampionBuff = new();
            }
        }

        public class ChampionBuff
        {
            public string SummonerName { get; set; }
            public bool Buffed { get; set; }
        }

        public class Herald
        {
            public bool Killed { get; set; }
            public string Team { get; set; }
            public bool Take { get; set; }
            public bool Launch { get; set; }
        }
    }
}
