namespace OSL_Overlay.Phase.Bo
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
}
