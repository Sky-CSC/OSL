namespace OSL_Overlay.GameFlow.Common
{
    /// <summary>
    /// Image schema
    /// </summary>
    public class Image
    {
        public string Path { get; set; }
        public string Background { get; set; }
        public string Border { get; set; }
        public Image()
        {
            Path = string.Empty;
            Background = string.Empty;
            Border = string.Empty;
        }
        public Image(string path)
        {
            Path = path;
            Background = string.Empty;
            Border = string.Empty;
        }

        public Image(string path, string background)
        {
            Path = path;
            Background = background;
            Border = string.Empty;
        }

        public Image(string path, string background = "", string border = "")
        {
            Path = path;
            Background = background;
            Border = border;
        }
    }
}
