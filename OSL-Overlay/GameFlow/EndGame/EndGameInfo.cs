using Microsoft.Extensions.Logging;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.EndGame
{
    public class EndGameInfo
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Timer Timer { get; set; }
        public GameData GameData { get; set; }
        public EndGameInfo()
        {
            Background = string.Empty;
            Border = string.Empty;
            Timer = new Timer();
            GameData = new GameData();
        }
    }

    public class Timer
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Text Text { get; set; }
        public Text Time { get; set; }
        public Text Win { get; set; }
        public Text Loss { get; set; }
        public Team BlueSide { get; set; }
        public Team RedSide { get; set; }
        public Timer()
        {
            Background = string.Empty;
            Border = string.Empty;
            Text = new();
            Time = new();
            Win = new();
            Loss = new();
            BlueSide = new Team();
            RedSide = new Team();
        }
    }

    public class Team
    {
        public bool Win { get; set; }
        public string Background { get; set; }
        public string Border { get; set; }
        public bool ShowLogo { get; set; }
        public Image Logo { get; set; }
        public bool ShowName { get; set; }
        public Text Name { get; set; }
        public bool ShowTag { get; set; }
        public Text Tag { get; set; }
        public BoGraphic BoGraphic { get; set; }
        public Team()
        {
            Background = string.Empty;
            Border = string.Empty;
            ShowLogo = false;
            Logo = new();
            ShowName = false;
            Name = new();
            ShowTag = false;
            Tag = new();
            BoGraphic = new();
        }
    }

    public class GameData
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public GameStats GameStats { get; set; }
        public Bans Bans { get; set; }
        public Total Total { get; set; }
        public Golds Golds { get; set; }
        public List<Events> Events { get; set; }
        public GameData()
        {
            Background = string.Empty;
            Border = string.Empty;
            GameStats = new GameStats();
            Bans = new Bans();
            Total = new Total();
            Golds = new Golds();
            Events = [];
        }
    }
    public class GameStats
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Text Title { get; set; }
        public Stat Kda { get; set; }
        public Stat Kills { get; set; }
        public Stat Deaths { get; set; }
        public Stat Assists { get; set; }
        public Stat Golds { get; set; }
        public Stat Towers { get; set; }
        public Stat VoidGrubs { get; set; }
        public Stat Heralds { get; set; }
        public Stat Dragon { get; set; }
        public Stat Air { get; set; }
        public Stat Chemtech { get; set; }
        public Stat Earth { get; set; }
        public Stat Fire { get; set; }
        public Stat Hextech { get; set; }
        public Stat Water { get; set; }
        public Stat Atakhan { get; set; }
        public Stat Elders { get; set; }
        public Stat Barons { get; set; }
        public GameStats()
        {
            Background = string.Empty;
            Border = string.Empty;
            Title = new();
            Kda = new();
            Kills = new();
            Deaths = new();
            Assists = new();
            Golds = new();
            Towers = new();
            VoidGrubs = new();
            Heralds = new();
            Dragon = new();
            Air = new();
            Chemtech = new();
            Earth = new();
            Fire = new();
            Hextech = new();
            Water = new();
            Atakhan = new();
            Elders = new();
            Barons = new();
        }
    }

    public class Stat
    {
        public Text Name { get; set; }
        public bool ShowText { get; set; }
        public bool ShowImages { get; set; }
        public Text BlueTeam { get; set; }
        public Text RedTeam { get; set; }
        public Image BlueTeamImages { get; set; }
        public Image RedTeamImages { get; set; }
        public Stat()
        {
            Name = new();
            ShowText = true;
            ShowImages = false;
            BlueTeam = new();
            RedTeam = new();
            BlueTeamImages = new();
            RedTeamImages = new();
        }
    }

    public class Bans
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public List<Image> BlueTeam { get; set; }
        public List<Image> RedTeam { get; set; }
        public Bans()
        {
            Background = string.Empty;
            Border = string.Empty;
            BlueTeam = [];
            RedTeam = [];
        }
    }

    public class Total
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Text Title { get; set; }
        public List<Player> BlueTeam { get; set; }
        public List<Player> RedTeam { get; set; }
        public Total()
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
        public string Background { get; set; }
        public string Boarder { get; set; }
        public Image ChampionImage { get; set; }
        public Text PlayerName { get; set; }
        public Text Value { get; set; }
        public Bar Bar { get; set; }
        public Player()
        {
            Background = string.Empty;
            Boarder = string.Empty;
            ChampionImage = new();
            PlayerName = new();
            Value = new();
            Bar = new();
        }
    }

    public class Bar
    {
        public string Background { get; set; }
        public string Boarder { get; set; }
        public string Size { get; set; }
        public Bar()
        {
            Background = string.Empty;
            Boarder = string.Empty;
            Size = string.Empty;
        }
    }

    public class Golds
    {
        public string Background { get; set; }
        public string Boarder { get; set; }
        public Text Title { get; set; }
        public string BlueGoldColor { get; set; }
        public string RedGoldColor { get; set; }
        public string BlueGoldTextColor { get; set; }
        public string RedGoldTextColor { get; set; }
        public string CommonGoldTextColor { get; set; }
        public List<GoldDifference> GoldDifference { get; set; }
        
        public Golds()
        {
            Background = string.Empty;
            Boarder = string.Empty;
            Title = new();
            BlueGoldColor = string.Empty;
            RedGoldColor = string.Empty;
            BlueGoldTextColor = string.Empty;
            RedGoldTextColor = string.Empty;
            CommonGoldTextColor = string.Empty;
            GoldDifference = new List<GoldDifference>();
        }
    }

    public class Events
    {
        public Image Icon { get; set; }
        public string Type { get; set; }
        public int Side { get; set; }
        public long Time { get; set; }
        public Events()
        {
            Icon = new();
            Type = string.Empty;
            Side = 0;
            Time = 0;
        }
    }
    public class GoldDifference
    {
        public int Gold { get; set; }
        public int Time { get; set; }
        public GoldDifference()
        {
            Gold = 0;
            Time = 0;
        }
    }
}
