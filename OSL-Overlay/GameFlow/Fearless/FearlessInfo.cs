using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.Fearless
{
    public class FearlessInfo
    {
        public string IdMatch { get; set; }
        public Text Text { get; set; }
        public string Background { get; set; }
        public Line Line { get; set; }
        public string Border { get; set; }
        public List<Champion> Champions { get; set; }
        public FearlessInfo()
        {
            IdMatch = string.Empty;
            Text = new Text();
            Background = string.Empty;
            Line = new Line();
            Border = string.Empty;
            Champions = [];
        }

        public FearlessInfo Clone()
        {
            return new FearlessInfo
            {
                IdMatch = this.IdMatch,
                Text = this.Text.CLone(),
                Background = this.Background,
                Line = this.Line.Clone(),
                Border = this.Border,
                Champions = this.Champions
            };
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

        public Line Clone()
        {
            return new Line
            {
                Background = this.Background,
                Border = this.Border
            };
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
        public Champion Clone()
        {
            return new Champion
            {
                Image = this.Image,
                Border = this.Border,
                Lane = this.Lane.Clone(),
                Greyscale = this.Greyscale,
                Cross = this.Cross.Clone()
            };
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

        public Lane Clone()
        {
            return new Lane
            {
                Name = this.Name,
                Image = this.Image,
                Border = this.Border
            };
        }
    }
}
