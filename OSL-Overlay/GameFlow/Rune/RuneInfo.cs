using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.Rune
{
    public class RuneInfo
    {
        public string BackgroundImage { get; set; }
        public string BackgroundColor { get; set; }
        public string Border { get; set; }
        public Text Title { get; set; }
        public List<Player> BlueTeam { get; set; }
        public List<Player> RedTeam { get; set; }
        public RuneInfo()
        {
            BackgroundImage = string.Empty;
            BackgroundColor = string.Empty;
            Border = string.Empty;
            Title = new();
            BlueTeam = [];
            for (int i = 0; i < 5; i++)
                BlueTeam.Add(new Player());
            RedTeam = [];
            for (int i = 0; i < 5; i++)
                RedTeam.Add(new Player());
        }
    }

    public class Player
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Text Name { get; set; }
        public Image Avatar { get; set; }
        public Image LaneImage { get; set; }
        public Lane Position { get; set; }
        public Runes Runes { get; set; }
        public Player()
        {
            Background = string.Empty;
            Border = string.Empty;
            Name = new();
            Avatar = new();
            LaneImage = new();
            Position = Lane.None;
            Runes = new();
        }

    }

    public class Runes
    {
        public Image Keystone { get; set; }
        public List<Image> Primary { get; set; }
        public List<Image> Secondary { get; set; }
        public StatPerks StatPerks { get; set; }
        public Runes()
        {
            Keystone = new();
            Primary = [];
            for (int i = 0; i < 3; i++)
                Primary.Add(new Image());
            Secondary = [];
            for (int i = 0; i < 2; i++)
                Secondary.Add(new Image());
            StatPerks = new();
        }
    }

    public class StatPerks
    {
        public Image Defense { get; set; }
        public Image Flex { get; set; }
        public Image Offense { get; set; }
        public StatPerks()
        {
            Defense = new();
            Flex = new();
            Offense = new();
        }
    }

    public enum Lane
    {
        None,
        Top,
        Mid,
        Jungle,
        Adc,
        Supp
    }
}
