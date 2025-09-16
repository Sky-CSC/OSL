using OSL_Lcu.Schema.Lcu;

namespace OSL_Overlay.Phase.ChampSelect
{
    public class ChampSelectInfo
    {
        public Team BlueTeam { get; set; }
        public Team RedTeam { get; set; }
        public string TeamsBackground { get; set; }
        public Patch Patch { get; set; }
        public Timer CommonTimer { get; set; }
        public Text Phase { get; set; }
        public Text Vs { get; set; }
    }

    public class Team
    {
        public string Side { get; set; }
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

    }
    public class Ban
    {
        public string BackgroundImage { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsBanning { get; set; }
        public string BlinkColor { get; set; }
        public bool IsCompleted { get; set; }
        public string CrossImage { get; set; }
    }

    public class Coach
    {
        public bool Show { get; set; }
        public Text Info { get; set; }
    }

    public class Patch
    {
        public string BackgroundColor { get; set; }
        public Text PatchInfo { get; set; }
        public Text Version { get; set; }
    }

    public class Timer
    {
        public bool Show { get; set; }
        public int Duration { get; set; }
        public string Direction { get; set; }
        public string BarColor { get; set; }
        public string FillColor { get; set; }
    }

    public class Pick
    {
        public string BackgroundImage { get; set; }
        public bool ShowLane { get; set; }
        public string LaneImage { get; set; }
        public bool ShowSummonerSpells { get; set; }
        public string Spell1 { get; set; }
        public string Spell2 { get; set; }
        public bool IsPicking { get; set; }
        public string BlinkColor { get; set; }
        public Text Name { get; set; }
        public Text Action { get; set; }
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
    }

    public class BoGraphic
    {
        public bool Show { get; set; }
        public int NbMatchForWin { get; set; }
        public int NbWin { get; set; }
        public Text Win { get; set; }
        public Text Undef { get; set; }
    }

    public class Display
    {
        public bool Show { get; set; }
        public string Info { get; set; }
    }
}
