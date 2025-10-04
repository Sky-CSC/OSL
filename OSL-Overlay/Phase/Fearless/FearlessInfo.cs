using OSL_Overlay.Phase.Common;
using OSL_RGDP.Schema.Riot;

namespace OSL_Overlay.Phase.Fearless
{
    public class FearlessInfo
    {
        public Text Text { get; set; }
        public string Background { get; set; }
        public Line Line { get; set; }
        public string Border { get; set; }
        public List<Champion> Champions { get; set; }
        public FearlessInfo()
        {
            Text = new Text();
            Background = string.Empty;
            Line = new Line();
            Border = string.Empty;
            Champions = [];
        }
    }

    public class Line
    {
        public string Background { get; set; }
        public string Border { get; set; }
        public Line()
        {
            Background = string.Empty;
            Border = string.Empty;
        }
    }

    public class Champion
    {
        public string Image { get; set; }
        public string Border { get; set; }
        public Lane Lane { get; set; }
        public string Greyscale { get; set; }
        public Cross Cross { get; set; }
        public Champion()
        {
            Image = string.Empty;
            Border = string.Empty;
            Lane = new Lane();
            Greyscale = string.Empty;
            Cross = new Cross();
        }
        public Champion(string image)
        {
            Image = image;
            Border = string.Empty;
            Lane = new Lane();
            Greyscale = string.Empty;
            Cross = new Cross();
        }
    }

    public class Lane {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Border { get; set; }
        public Lane()
        {
            Name = string.Empty;
            Image = string.Empty;
            Border = string.Empty;
        }
    }
}
