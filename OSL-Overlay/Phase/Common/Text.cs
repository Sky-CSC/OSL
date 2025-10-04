namespace OSL_Overlay.Phase.Common
{
    public class Text
    {
        public string Txt { get; set; }
        public string Font { get; set; }
        public string Color { get; set; }
        public string Background { get; set; }
        public string Border { get; set; }
        public string Align { get; set; }

        public Text(string text, string font, string color)
        {
            Txt = text;
            Font = font;
            Color = color;
            Background = string.Empty;
            Border = string.Empty;
            Align = string.Empty;
        }

        public Text(string text, string font, string color, string background, string border, string align)
        {
            Txt = text;
            Font = font;
            Color = color;
            Background = background;
            Border = border;
            Align = align;
        }
        public Text(string background, string border)
        {
            Txt = string.Empty;
            Font = string.Empty;
            Color = string.Empty;
            Background = background;
            Border = border;
            Align = string.Empty;
        }
        public Text()
        {
            Txt = string.Empty;
            Font = string.Empty;
            Color = string.Empty;
            Background = string.Empty;
            Border = string.Empty;
            Align = string.Empty;
        }
    }
}
