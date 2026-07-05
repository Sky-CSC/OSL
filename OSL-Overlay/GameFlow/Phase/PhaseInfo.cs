using OSL_Overlay.GameFlow.Common;

namespace OSL_Overlay.GameFlow.Phase
{
    /// <summary>
    /// Phase information
    /// </summary>
    public class PhaseInfo
    {
        public Text Event { get; set; }
        public Text Phase { get; set; }
        public Text Date { get; set; }

        public PhaseInfo()
        {
            Event = new();
            Phase = new();
            Date = new();
        }
    }
}
