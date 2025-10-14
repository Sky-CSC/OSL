using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.EndGame
{

    public class EndGameInfo
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public TimerTeamHeadband TimerTeamsHeadband { get; set; }
        public GameStat GameStats { get; set; }
        public ChampionStat ChampionStats { get; set; }
        public Ban Bans { get; set; }
        public Gold Golds { get; set; }
        public EndGameInfo()
        {
            Background = string.Empty;
            Border = string.Empty;
            TimerTeamsHeadband = new();
            GameStats = new();
            ChampionStats = new();
            Bans = new();
            Golds = new();
        }

        public class TimerTeamHeadband
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public Text Timer { get; set; }
            public Text WinText { get; set; }
            public Text LossText { get; set; }
            public Team BlueTeam { get; set; }
            public Team RedTeam { get; set; }
            public TimerTeamHeadband()
            {
                Background = string.Empty;
                Border = string.Empty;
                Title = new();
                Timer = new();
                WinText = new();
                LossText = new();
                BlueTeam = new();
                RedTeam = new();
            }
        }

        public class Team : Common.Team
        {
            public bool Win { get; set; }
            public Team()
            {
                Win = false;
            }
        }

        public class GameStat
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public StatText Kda { get; set; }
            public StatText Golds { get; set; }
            public StatText Towers { get; set; }
            public StatImage VoidGrubs { get; set; }
            public StatImage Herald { get; set; }
            public StatImage Atakhan { get; set; }
            public StatDrakeImage Drakes { get; set; }
            public StatImage Elders { get; set; }
            public StatImage Barons { get; set; }
            public GameStat()
            {
                Background = string.Empty;
                Border = string.Empty;
                Title = new();
                Kda = new();
                Golds = new();
                Towers = new();
                VoidGrubs = new();
                Herald = new();
                Atakhan = new();
                Drakes = new();
                Elders = new();
                Barons = new();
            }
        }

        public class StatText
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public Text BlueTeam { get; set; }
            public Text RedTeam { get; set; }
            public StatText()
            {
                Background = string.Empty;
                Border = string.Empty;
                Title = new();
                BlueTeam = new();
                RedTeam = new();
            }

        }
        public class StatImage
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public string NbBlueTeam { get; set; }
            public string NbRedTeam { get; set; }
            public Image Image { get; set; }
            public StatImage()
            {
                Title = new();
                NbBlueTeam = string.Empty;
                NbRedTeam = string.Empty;
                Image = new();
            }

        }

        public class StatDrakeImage
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public StatImage Air { get; set; }
            public StatImage Chemtech { get; set; }
            public StatImage Earth { get; set; }
            public StatImage Fire { get; set; }
            public StatImage Hextech { get; set; }
            public StatImage Water { get; set; }
            public StatDrakeImage()
            {
                Title = new();
                Air = new();
                Chemtech = new();
                Earth = new();
                Fire = new();
                Hextech = new();
                Water = new();
            }
        }

        public class ChampionStat
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public List<Player> BlueTeam { get; set; }
            public List<Player> RedTeam { get; set; }
            public ChampionStat()
            {
                Background = string.Empty;
                Border = string.Empty;
                Title = new();
                BlueTeam = [];
                for (int i = 0; i < 5; i++)
                {
                    BlueTeam.Add(new());
                }
                RedTeam = [];
                for (int i = 0; i < 5; i++)
                {
                    RedTeam.Add(new());
                }
            }
        }

        public class Player
        {
            public Image Image { get; set; }
            public Text Name { get; set; }
            public Text Stat { get; set; } // No forget to convert Stat.Txt is > 10000 with 1k
            public Bar Bar { get; set; }
            public Player()
            {
                Image = new();
                Name = new();
                Stat = new();
                Bar = new();
            }
        }

        public class Bar
        {
            public string Backgournd { get; set; }
            public string Border { get; set; } //Size of bar is calculated by Stat.Txt
            public Bar()
            {
                Backgournd = string.Empty;
                Border = string.Empty;
            }
        }

        public class Ban
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public List<Image> BlueTeam { get; set; }
            public List<Image> RedTeam { get; set; }
            public Ban()
            {
                Background = string.Empty;
                Border = string.Empty;
                Title = new();
                BlueTeam = [];
                for (int i = 0; i < 5; i++)
                {
                    BlueTeam.Add(new());
                }
                RedTeam = [];
                for (int i = 0; i < 5; i++)
                {
                    RedTeam.Add(new());
                }
            }
        }

        public class Gold
        {
            public string Background { get; set; }
            public string Border { get; set; }
            public Text Title { get; set; }
            public string BlueGoldsColor { get; set; }
            public Text BlueText { get; set; }
            public string RedGoldsColor { get; set; }
            public Text RedText { get; set; }
            public string CommonGoldsColor { get; set; }
            public Text CommonText { get; set; }
            public string GoldLinkColor { get; set; }
            public string BackgroundChartColor { get; set; }
            public List<Event> Events { get; set; } // Gold, tower, inhib, drakes, herald, elder, baron, athakan 
            public Gold()
            {
                Background = string.Empty;
                Border = string.Empty ;
                Title = new();
                BlueGoldsColor = string.Empty;
                BlueText = new();
                RedGoldsColor = string.Empty;
                RedText = new();
                CommonGoldsColor = string.Empty;
                CommonText = new();
                GoldLinkColor = string.Empty;
                BackgroundChartColor = string.Empty;
                Events = [];
            }
        }

        public class Event
        {
            public string Type { get; set; }
            public int TeamId { get; set; }
            public long Timetamps { get; set; }
            public Image Image { get; set; }
            public int Value{ get; set; }
            public Event()
            {
                Type = string.Empty;
                TeamId = 100;
                Timetamps = 0;
                Image = new();
                Value = 0;
            }
            public Event(string type, int teamId, long timetamps)
            {
                Type = type;
                TeamId = teamId;
                Timetamps = timetamps;
                Image = new();
                Value = 0;
            }
            public Event(string type, int teamId, long timetamps, int value)
            {
                Type = type;
                TeamId = teamId;
                Timetamps = timetamps;
                Image = new();
                Value = value;
            }
        }
    }




    //public class EndGameInfo
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public Timer Timer { get; set; }
    //    public GameData GameData { get; set; }
    //    public EndGameInfo()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        Timer = new Timer();
    //        GameData = new GameData();
    //    }
    //}

    //public class Timer
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public Text Text { get; set; }
    //    public Text Time { get; set; }
    //    public Text Win { get; set; }
    //    public Text Loss { get; set; }
    //    public Team BlueSide { get; set; }
    //    public Team RedSide { get; set; }
    //    public Timer()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        Text = new();
    //        Time = new();
    //        Win = new();
    //        Loss = new();
    //        BlueSide = new Team();
    //        RedSide = new Team();
    //    }
    //}

    //public class Team
    //{
    //    public bool Win { get; set; }
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public bool ShowLogo { get; set; }
    //    public Image Logo { get; set; }
    //    public bool ShowName { get; set; }
    //    public Text Name { get; set; }
    //    public bool ShowTag { get; set; }
    //    public Text Tag { get; set; }
    //    public BoGraphic BoGraphic { get; set; }
    //    public Team()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        ShowLogo = false;
    //        Logo = new();
    //        ShowName = false;
    //        Name = new();
    //        ShowTag = false;
    //        Tag = new();
    //        BoGraphic = new();
    //    }
    //}

    //public class GameData
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public GameStats GameStats { get; set; }
    //    public Bans Bans { get; set; }
    //    public Total Total { get; set; }
    //    public Golds Golds { get; set; }
    //    public List<Events> Events { get; set; }
    //    public GameData()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        GameStats = new GameStats();
    //        Bans = new Bans();
    //        Total = new Total();
    //        Golds = new Golds();
    //        Events = [];
    //    }
    //}
    //public class GameStats
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public Text Title { get; set; }
    //    public Stat Kda { get; set; }
    //    public Stat Kills { get; set; }
    //    public Stat Deaths { get; set; }
    //    public Stat Assists { get; set; }
    //    public Stat Golds { get; set; }
    //    public Stat Towers { get; set; }
    //    public Stat VoidGrubs { get; set; }
    //    public Stat Herald { get; set; }
    //    public Stat Dragon { get; set; }
    //    public Stat Air { get; set; }
    //    public Stat Chemtech { get; set; }
    //    public Stat Earth { get; set; }
    //    public Stat Fire { get; set; }
    //    public Stat Hextech { get; set; }
    //    public Stat Water { get; set; }
    //    public Stat Atakhan { get; set; }
    //    public Stat Elders { get; set; }
    //    public Stat Barons { get; set; }
    //    public GameStats()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        Title = new();
    //        Kda = new();
    //        Kills = new();
    //        Deaths = new();
    //        Assists = new();
    //        Golds = new();
    //        Towers = new();
    //        VoidGrubs = new();
    //        Herald = new();
    //        Dragon = new();
    //        Air = new();
    //        Chemtech = new();
    //        Earth = new();
    //        Fire = new();
    //        Hextech = new();
    //        Water = new();
    //        Atakhan = new();
    //        Elders = new();
    //        Barons = new();
    //    }
    //}

    //public class Stat
    //{
    //    public Text Name { get; set; }
    //    public bool ShowText { get; set; }
    //    public bool ShowImages { get; set; }
    //    public Text BlueTeam { get; set; }
    //    public Text RedTeam { get; set; }
    //    public Image BlueTeamImages { get; set; }
    //    public Image RedTeamImages { get; set; }
    //    public Stat()
    //    {
    //        Name = new();
    //        ShowText = true;
    //        ShowImages = false;
    //        BlueTeam = new();
    //        RedTeam = new();
    //        BlueTeamImages = new();
    //        RedTeamImages = new();
    //    }
    //}
    //public class StatText
    //{
    //    public Text Title { get; set; }
    //    public Text BlueTeam { get; set; }
    //    public Text RedTeam { get; set; }
    //    public StatText()
    //    {
    //        Title = new();
    //        BlueTeam = new();
    //        RedTeam = new();
    //    }
    //}

    //public class StatImage
    //{
    //    public Text Title { get; set; }
    //    public string BlueTeam { get; set; }
    //    public string RedTeam { get; set; }
    //    public Image BlueTeamImages { get; set; }
    //    public Image RedTeamImages { get; set; }
    //    public StatImage()
    //    {
    //        Title = new();
    //        BlueTeam = string.Empty;
    //        RedTeam = string.Empty;
    //        BlueTeamImages = new();
    //        RedTeamImages = new();
    //    }
    //}

    //public class Bans
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public Text Title { get; set; }
    //    public List<Image> BlueTeam { get; set; }
    //    public List<Image> RedTeam { get; set; }
    //    public Bans()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        Title = new();
    //        BlueTeam = [];
    //        RedTeam = [];
    //    }
    //}

    //public class Total
    //{
    //    public string Background { get; set; }
    //    public string Border { get; set; }
    //    public Text Title { get; set; }
    //    public List<Player> BlueTeam { get; set; }
    //    public List<Player> RedTeam { get; set; }
    //    public Total()
    //    {
    //        Background = string.Empty;
    //        Border = string.Empty;
    //        Title = new();
    //        BlueTeam = [];
    //        for (int i = 0; i < 5; i++)
    //        {
    //            BlueTeam.Add(new());
    //        }
    //        RedTeam = [];
    //        for (int i = 0; i < 5; i++)
    //        {
    //            RedTeam.Add(new());
    //        }
    //    }
    //}

    //public class Player
    //{
    //    public string Background { get; set; }
    //    public string Boarder { get; set; }
    //    public Image ChampionImage { get; set; }
    //    public Text PlayerName { get; set; }
    //    public Text Value { get; set; }
    //    public Bar Bar { get; set; }
    //    public Player()
    //    {
    //        Background = string.Empty;
    //        Boarder = string.Empty;
    //        ChampionImage = new();
    //        PlayerName = new();
    //        Value = new();
    //        Bar = new();
    //    }
    //}

    //public class Bar
    //{
    //    public string Background { get; set; }
    //    public string Boarder { get; set; }
    //    public string Size { get; set; }
    //    public Bar()
    //    {
    //        Background = string.Empty;
    //        Boarder = string.Empty;
    //        Size = string.Empty;
    //    }
    //}

    //public class Golds
    //{
    //    public string Background { get; set; }
    //    public string Boarder { get; set; }
    //    public Text Title { get; set; }
    //    public string BlueGoldColor { get; set; }
    //    public string RedGoldColor { get; set; }
    //    public string BlueGoldTextColor { get; set; }
    //    public string RedGoldTextColor { get; set; }
    //    public string CommonGoldTextColor { get; set; }
    //    public List<GoldDifference> GoldDifference { get; set; }

    //    public Golds()
    //    {
    //        Background = string.Empty;
    //        Boarder = string.Empty;
    //        Title = new();
    //        BlueGoldColor = string.Empty;
    //        RedGoldColor = string.Empty;
    //        BlueGoldTextColor = string.Empty;
    //        RedGoldTextColor = string.Empty;
    //        CommonGoldTextColor = string.Empty;
    //        GoldDifference = new List<GoldDifference>();
    //    }
    //}

    //public class Events
    //{
    //    public Image Icon { get; set; }
    //    public string Type { get; set; }
    //    public int Side { get; set; }
    //    public long Time { get; set; }
    //    public Events()
    //    {
    //        Icon = new();
    //        Type = string.Empty;
    //        Side = 0;
    //        Time = 0;
    //    }
    //}
    //public class GoldDifference
    //{
    //    public int Gold { get; set; }
    //    public int Time { get; set; }
    //    public GoldDifference()
    //    {
    //        Gold = 0;
    //        Time = 0;
    //    }
    //}
}
