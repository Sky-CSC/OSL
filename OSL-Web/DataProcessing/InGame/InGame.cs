using OSL_Common.System.Logging;


namespace OSL_Web.DataProcessing
{
    public partial class InGame
    {
        private static Logger _logger = new("InGame");
        public static bool initTimerGame = true;
        public static dynamic allPlayerList = null;
        public static dynamic playBack = null;
        public static dynamic liveEventContent = null;
        public static GameInformation gameInformation = new();
        public static void ReadData(string content)
        {
            if (!GameFlowSession(content))
            {
                if (!LiveClientDataPlayerList(content))
                {
                    if (!ReplayPlayBack(content))
                    {
                        LiveEvents(content);
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
