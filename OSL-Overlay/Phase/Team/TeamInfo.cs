namespace OSL_Overlay.Phase.Team
{
    public class TeamInfo
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Coach { get; set; }
        public string Logo { get; set; }
        public Lane Top { get; set; }
        public Lane Jungle { get; set; }
        public Lane Mid { get; set; }
        public Lane Adc { get; set; }
        public Lane Supp { get; set; }
        public TeamInfo()
        {
            Name = string.Empty;
            Tag = string.Empty;
            Coach = string.Empty;
            Logo = string.Empty;
            Top = new();
            Jungle = new();
            Mid = new();
            Adc = new();
            Supp = new();
        }
    }

    public class Lane
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Lane()
        {
            Name = string.Empty;
            Image = string.Empty;
        }
    }
}
