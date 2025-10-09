using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.Bo
{
    public class BoInfo
    {
        public int NbGames { get; set; }
        public string Text { get; set; }
        public int Win { get; set; }
        public BoInfo()
        {
            NbGames = 0;
            Text = string.Empty;
            Win = 0;
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
}
