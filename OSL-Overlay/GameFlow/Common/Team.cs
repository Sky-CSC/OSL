using OSL_Overlay.GameFlow.Bo;

namespace OSL_Overlay.GameFlow.Common
{
    /// <summary>
    /// Team schema
    /// </summary>
    public class Team
    {
        public string Side { get; set; }
        public bool ShowLogo { get; set; }
        public Image Logo { get; set; }
        public bool ShowName { get; set; }
        public Text Name { get; set; }
        public bool ShowTag { get; set; }
        public Text Tag { get; set; }
        public BoGraphic BoGraphic { get; set; }
        public Team()
        {
            Side = string.Empty;
            ShowLogo = true;
            Logo = new();
            ShowName = false;
            Name = new();
            ShowTag = true;
            Tag = new();
            BoGraphic = new();
        }
    }
}
