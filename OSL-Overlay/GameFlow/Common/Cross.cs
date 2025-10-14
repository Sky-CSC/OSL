namespace OSL_Overlay.GameFlow.Common
{
    public class Cross
    {
        public Image Image { get; set; }
        public string GraphicLineColor { get; set; }
        public string GraphicCrossColor { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Rotate { get; set; }
        public Cross()
        {
            Image = new();
            GraphicLineColor = string.Empty;
            GraphicCrossColor = string.Empty;
            Width = string.Empty;
            Height = string.Empty;
            Rotate = string.Empty;
        }

        public Cross Clone()
        {
            return new Cross
            {
                Image = this.Image,
                GraphicLineColor = this.GraphicLineColor,
                GraphicCrossColor = this.GraphicCrossColor,
                Width = this.Width,
                Height = this.Height,
                Rotate = this.Rotate
            };
        }
    }
}
