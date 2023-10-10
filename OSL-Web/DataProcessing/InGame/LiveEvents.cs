using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OSL_Common.System.Logging;

namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        public static void LiveEvents(string content)
        {
            try
            {
                _logger.log(LoggingLevel.INFO, "LiveEvents()", "In LiveEvents");
                string tempsContent = "[\n" + content.Replace("}", "},") + "]";
                liveEventContent = JsonConvert.DeserializeObject(tempsContent);
                foreach (var events in liveEventContent)
                {
                    string eventname = events.eventname;
                    if (eventname != null)
                    {
                        if (eventname.Equals("OnKillDragon_Spectator"))
                        {
                            OnKillDragon_Spectator(events);
                        }
                        else if (eventname.Equals("OnKillWorm_Spectator"))
                        {
                            OnKillWorm_Spectator(events);
                        }
                        else if (eventname.Equals("OnNeutralMinionKill"))
                        {
                            OnNeutralMinionKill(events);
                        }
                        else if (eventname.Equals("OnMinionKill"))
                        {
                            OnMinionKill(events);
                        }
                        else if (eventname.Equals("OnSummonRiftHerald"))
                        {
                            OnSummonRiftHerald(events);
                        }
                        //else if (eventname.Equals("OnDampenerDie"))
                        //{
                        //    OnDampenerDie(events);
                        //}
                    }
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "LiveEvents()", "Error deserialize live event, possible not live event");
            }
        }

        public static void OnKillDragon_Spectator(dynamic events)
        {
            try
            {
                string other = events.other;
                if (other.Equals("SRU_Dragon_Elder"))
                {
                    //Run timer next elder
                    Pages.InGame.TimerControl.nextElder = 360;
                    //Run timer buff elder
                    Pages.InGame.TimerControl.buffElder = 150;

                    string sourceTeam = events.sourceTeam;
                    if (sourceTeam.Equals("Order"))
                    {
                        gameInformation.Order.ElderKill = true;
                        foreach (var summoner in gameInformation.Order.Summoners)
                        {
                            if (!summoner.IsDead)//Not dead he win elder dragon buff
                            {
                                summoner.ElderBuff = true;
                            }
                        }
                    }
                    else
                    {
                        gameInformation.Chaos.ElderKill = true;
                        foreach (var summoner in gameInformation.Chaos.Summoners)
                        {
                            if (!summoner.IsDead)//Not dead he win elder dragon buff
                            {
                                summoner.ElderBuff = true;
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
                        Pages.InGame.TimerControl.nextElder = 360;
                    }
                    else
                    {
                        Pages.InGame.TimerControl.nextDrake = 300;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "OnKillDragon_Spectator()", "Error deserialize OnKillDragon_Spectator, possible not OnKillDragon_Spectator");
            }
        }

        public static void OnKillWorm_Spectator(dynamic events)
        {
            try
            {
                //Run timer next baron
                Pages.InGame.TimerControl.nextBaron = 360;
                //Run timer buff
                Pages.InGame.TimerControl.buffBaron = 180;

                string sourceTeam = events.sourceTeam;
                if (sourceTeam.Equals("Order"))
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
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "OnKillWorm_Spectator()", "Error deserialize OnKillWorm_Spectator, possible not OnKillWorm_Spectator");
            }
        }
        public static void OnNeutralMinionKill(dynamic events)
        {
            try
            {
                string other = events.other;
                if (other.Contains("SRU_RiftHerald"))
                {
                    //Run timer next herald if timer not 13:45
                    double gameTime = playBack.time; //voir pour récupérer le gameTime autre part
                    DateTime timeTemps = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    timeTemps = timeTemps.AddSeconds(gameTime);
                    if ((timeTemps.Minute == 13 && timeTemps.Second >= 45) || timeTemps.Minute > 13)
                    {
                        Pages.InGame.TimerControl.nextHerald = -1;
                    }
                    else
                    {
                        Pages.InGame.TimerControl.nextHerald = 360;
                    }

                    string sourceTeam = events.sourceTeam;
                    if (sourceTeam.Equals("Order"))
                    {
                        gameInformation.Order.Herald.Killed = true;
                        gameInformation.Order.Herald.Take = false;
                    }
                    else
                    {
                        gameInformation.Chaos.Herald.Killed = true;
                        gameInformation.Chaos.Herald.Take = false;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "OnNeutralMinionKill()", "Error deserialize SRU_RiftHerald, possible not SRU_RiftHerald");
            }
        }

        public static void OnMinionKill(dynamic events)
        {
            try
            {
                string other = events.other;
                if (other.Equals("Rift Herald Relic"))
                {
                    //Run timer buff herald
                    Pages.InGame.TimerControl.buffHerald = 240;

                    string sourceTeam = events.sourceTeam;
                    if (sourceTeam.Equals("Order"))
                    {
                        gameInformation.Order.Herald.Take = true;
                    }
                    else
                    {
                        gameInformation.Chaos.Herald.Take = true;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "OnMinionKill()", "Error deserialize Rift Herald Relic, possible not Rift Herald Relic");
            }
        }

        public static void OnSummonRiftHerald(dynamic events)
        {
            try
            {
                Pages.InGame.TimerControl.buffHerald = 0;
                string sourceTeam = events.sourceTeam;
                if (sourceTeam.Equals("Order"))
                {
                    gameInformation.Order.Herald.Killed = false;
                }
                else
                {
                    gameInformation.Chaos.Herald.Killed = false;
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "OnSummonRiftHerald()", "Error deserialize OnSummonRiftHerald, possible not OnSummonRiftHerald");
            }
        }

        //public static void OnDampenerDie(dynamic events)
        //{
        //    try
        //    {
        //        string sourceTeam = events.sourceTeam;
        //        string source = events.source;
        //        if (sourceTeam.Equals("order"))
        //        {
        //            if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibOrderTop = 300;
        //            }
        //            else if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibOrderMid = 300;
        //            }
        //            else if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibOrderBot = 300;
        //            }
        //        }
        //        else
        //        {
        //            if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibChaosTop = 300;
        //            }
        //            else if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibChaosMid = 300;
        //            }
        //            else if (source.Equals(""))
        //            {
        //                Pages.InGame.TimerControl.inhibChaosBot = 300;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.log(LoggingLevel.WARN, "OnDampenerDie()", "Error deserialize OnDampenerDie, possible not OnDampenerDie");
        //    }
        //}
    }
}
