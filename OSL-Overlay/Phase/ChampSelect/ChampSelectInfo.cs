namespace OSL_Overlay.Phase.ChampSelect
{
    public class ChampSelectInfo
    {
        public string Background { get; set; }
        public string TeamsBackground { get; set; }
        public Team BlueTeam { get; set; }
        public Team RedTeam { get; set; }
        public Patch Patch { get; set; }
        public Timer CommonTimer { get; set; }
        public Text Phase { get; set; }
        public Text Vs { get; set; }

        public ChampSelectInfo(int nbBluePlayers, int nbRedPlayers, int nbBlueBans, int nbRedBans)
        {
            BlueTeam = new(nbBluePlayers, nbBlueBans);
            RedTeam = new(nbRedPlayers, nbRedBans);
            Background = string.Empty;
            TeamsBackground = string.Empty;
            Patch = new();
            CommonTimer = new();
            Phase = new();
            Vs = new();
        }

        public ChampSelectInfo()
        {
            
        }

        public ChampSelectInfo(bool init)
        {
            if (init)
            {
                BlueTeam = new(5, 5);
                RedTeam = new(5, 5);
                Background = string.Empty;
                TeamsBackground = string.Empty;
                Patch = new();
                CommonTimer = new();
                Phase = new();
                Vs = new();
            }
        }
    }

    public class Team
    {
        public string Side { get; set; }
        public string Background { get; set; }
        public List<Ban> Bans { get; set; }
        public Coach Coach { get; set; }
        public Timer Timer { get; set; }
        public List<Pick> Picks { get; set; }
        public bool ShowLogo { get; set; }
        public string Logo { get; set; }
        public bool ShowName { get; set; }
        public Text Name { get; set; }
        public bool ShowTag { get; set; }
        public Text Tag { get; set; }
        public BoGraphic BoGraphic { get; set; }
        public Team(int nbPlayers, int nbBans)
        {
            Side = string.Empty;
            Background = string.Empty;
            Bans = new(nbBans);
            Bans = [];
            for (int i = 0; i < nbBans; i++)
            {
                Bans.Add(new());
            }
            Coach = new();
            Timer = new();
            Picks = [];
            for (int i = 0; i < nbPlayers; i++)
            {
                Picks.Add(new());
            }
            ShowLogo = false;
            Logo = string.Empty;
            ShowName = false;
            Name = new();
            ShowTag = false;
            Tag = new();
            BoGraphic = new();
        }

    }
    public class Ban
    {
        public string BanImage { get; set; }
        public string ChampionImage { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsBanning { get; set; }
        public string BlinkColor { get; set; }
        public string BorderBanning { get; set; }
        public bool IsCompleted { get; set; }
        public string Greyscale { get; set; }
        public string BorderCompleted{ get; set; }
        public string CrossImage { get; set; }
        public string LineCustom { get; set; }
        public string CrossCustom { get; set; }
        public Ban()
        {
            BanImage = string.Empty;
            ChampionImage = string.Empty;
            BackgroundColor = string.Empty;
            IsBanning = false;
            BorderBanning = string.Empty;
            BlinkColor = string.Empty;
            IsCompleted = false;
            BorderCompleted = string.Empty;
            Greyscale = string.Empty;
            CrossImage = string.Empty;
            LineCustom = string.Empty;
            CrossCustom = string.Empty;
        }
    }

    public class Coach
    {
        public bool Show { get; set; }
        public string Background { get; set; }
        public string Border { get; set; }
        public Text Text { get; set; }
        public Text Name { get; set; }
        public Coach()
        {
            Show = false;
            Background = string.Empty;
            Border = string.Empty;
            Text = new();
            Name = new();
        }
    }

    public class Patch
    {
        public bool Show { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public Text PatchInfo { get; set; }
        public Text Version { get; set; }
        public Patch()
        {
            Show = true;
            BackgroundColor = string.Empty;     
            BorderColor = string.Empty;
            PatchInfo = new();
            Version = new();
        }
    }

    public class Timer
    {
        public bool Show { get; set; }
        public int Duration { get; set; }
        public string Direction { get; set; }
        public string BarColor { get; set; }
        public string FillColor { get; set; }
        public Timer()
        {
            Show = false;
            Duration = 0;
            Direction = string.Empty;
            BarColor = string.Empty;
            FillColor = string.Empty;
        }
    }

    public class Pick
    {
        public string PlayerImage { get; set; }
        public string ChampionImage { get; set; }
        public string BorderImage { get; set; }
        public bool ShowLane { get; set; }
        public string LaneImage { get; set; }
        public bool ShowSummonerSpells { get; set; }
        public string Spell1 { get; set; }
        public string Spell2 { get; set; }
        public bool IsPicking { get; set; }
        public string BlinkColor { get; set; }
        public Text Name { get; set; }
        public Text Action { get; set; }

        public Pick()
        {
            PlayerImage = string.Empty;
            ChampionImage = string.Empty;
            BorderImage = string.Empty;
            ShowLane = true;
            LaneImage = string.Empty;
            ShowSummonerSpells = false;
            Spell1 = string.Empty;
            Spell2 = string.Empty;
            IsPicking = false;
            BlinkColor = string.Empty;
            Name = new();
            Action = new();
        }
    }

    public class Text
    {
        public string Txt { get; set; }
        public string Font { get; set; }
        public string Color { get; set; }
        public string Background { get; set; }
        public string Border { get; set; }

        public Text(string text, string font, string color)
        {
            Txt = text;
            Font = font;
            Color = color;
            Background = string.Empty;
            Border = string.Empty;
        }

        public Text(string text, string font, string color, string background, string border)
        {
            Txt = text;
            Font = font;
            Color = color;
            Background = background;
            Border = border;
        }
        public Text(string background, string border)
        {
            Txt = string.Empty;
            Font = string.Empty;
            Color = string.Empty;
            Background = background;
            Border = border;
        }
        public Text()
        {
            Txt = string.Empty;
            Font = string.Empty;
            Color = string.Empty;
            Background = string.Empty;
            Border = string.Empty;
        }
    }

    public class BoGraphic
    {
        public bool Show { get; set; }
        public int NbMatchForWin { get; set; }
        public int NbWin { get; set; }
        public Text Win { get; set; }
        public Text Undef { get; set; }
        public BoGraphic()
        {
            Show = false;
            NbMatchForWin = 0;
            NbWin = 0;
            Win = new();
            Undef = new();
        }
    }

    public class Display
    {
        public bool Show { get; set; }
        public string Info { get; set; }
    }
}
