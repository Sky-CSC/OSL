using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_Web.Pages.InGame;

namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        public static int eventID = 0;

        public static bool LiveClientDataEventData(string content)
        {
            try
            {
                if (content.Contains("\"Events\":")) //is playerlist
                {
                    _logger.log(LoggingLevel.INFO, "LiveClientDataEventData()", "In LiveClientDataEventData");
                    allEventData = JsonConvert.DeserializeObject(content);

                    List<dynamic> allEvents = new();
                    allEvents = allEventData.Events.ToObject<List<dynamic>>();

                    while (eventID < allEvents.Count())
                    {
                        Console.WriteLine(eventID);
                        string eventName = (string)allEvents[eventID].EventName;
                        if (eventName.Contains("InhibKilled"))
                        {
                            InhibitorKillEvent(allEvents[eventID]);
                        }
                        if (eventName.Contains("InhibRespawned"))
                        {
                            InhibitorRespawnEvent(allEvents[eventID]);
                        }
                        eventID++;
                    }

                    return true;
                }
                _logger.log(LoggingLevel.WARN, "LiveClientDataEventData()", "Not LiveClientDataEventData");
                return false;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.WARN, "LiveClientDataEventData()", "Error deserialize LiveClientDataEventData, possible not LiveClientDataEventData" + e);
                return false;
            }
        }

        public static void InhibitorKillEvent(dynamic eventData)
        {
            string inhibKilled = (string)eventData.InhibKilled;
            if (inhibKilled.Contains("Barracks_T1_L1"))
            {
                if (!gameInformation.Order.Inhib.TopKilled)
                {
                    gameInformation.Order.Inhib.TopKilled = true;
                    TimerControl.inhibOrderTop = 300;
                }
            }
            else if (inhibKilled.Contains("Barracks_T1_C1"))
            {
                if (!gameInformation.Order.Inhib.MidKilled)
                {
                    gameInformation.Order.Inhib.MidKilled = true;
                    TimerControl.inhibOrderMid = 300;
                }
            }
            else if (inhibKilled.Contains("Barracks_T1_R1"))
            {
                if (!gameInformation.Order.Inhib.BotKilled)
                {
                    gameInformation.Order.Inhib.BotKilled = true;
                    TimerControl.inhibOrderBot = 300;
                }
            }
            else if (inhibKilled.Contains("Barracks_T2_L1"))
            {
                if (!gameInformation.Chaos.Inhib.TopKilled)
                {
                    gameInformation.Chaos.Inhib.TopKilled = true;
                    TimerControl.inhibChaosTop = 300;
                }
            }
            else if (inhibKilled.Contains("Barracks_T2_C1"))
            {
                if (!gameInformation.Chaos.Inhib.MidKilled)
                {
                    gameInformation.Chaos.Inhib.MidKilled = true;
                    TimerControl.inhibChaosMid = 300;
                }
            }
            else if (inhibKilled.Contains("Barracks_T2_R1"))
            {
                if (!gameInformation.Chaos.Inhib.BotKilled)
                {
                    gameInformation.Chaos.Inhib.BotKilled = true;
                    TimerControl.inhibChaosBot = 300;
                }
            }
        }

        public static void InhibitorRespawnEvent(dynamic eventData)
        {
            string inhibRespawned = (string)eventData.InhibRespawned;
            if (inhibRespawned.Contains("Barracks_T1_L1"))
            {
                if (gameInformation.Order.Inhib.TopKilled)
                {
                    gameInformation.Order.Inhib.TopKilled = false;
                    TimerControl.inhibOrderTop = 0;
                }
            }
            else if (inhibRespawned.Contains("Barracks_T1_C1"))
            {
                if (gameInformation.Order.Inhib.MidKilled)
                {
                    gameInformation.Order.Inhib.MidKilled = false;
                    TimerControl.inhibOrderMid = 0;
                }
            }
            else if (inhibRespawned.Contains("Barracks_T1_R1"))
            {
                if (gameInformation.Order.Inhib.BotKilled)
                {
                    gameInformation.Order.Inhib.BotKilled = false;
                    TimerControl.inhibOrderBot = 0;
                }
            }
            else if (inhibRespawned.Contains("Barracks_T2_L1"))
            {
                if (gameInformation.Chaos.Inhib.TopKilled)
                {
                    gameInformation.Chaos.Inhib.TopKilled = false;
                    TimerControl.inhibChaosTop = 0;
                }
            }
            else if (inhibRespawned.Contains("Barracks_T2_C1"))
            {
                if (gameInformation.Chaos.Inhib.MidKilled)
                {
                    gameInformation.Chaos.Inhib.MidKilled = false;
                    TimerControl.inhibChaosMid = 0;
                }
            }
            else if (inhibRespawned.Contains("Barracks_T2_R1"))
            {
                if (gameInformation.Chaos.Inhib.BotKilled)
                {
                    gameInformation.Chaos.Inhib.BotKilled = false;
                    TimerControl.inhibChaosBot = 0;
                }
            }
        }
    }
}
