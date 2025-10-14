using OSL_Overlay.GameFlow.ChampSelect;

namespace OSL_Overlay.GameFlow.Phase
{
    public class PhaseState
    {
        public PhaseInfo Info { get; private set; } = new();
        private readonly ChampSelectState _champSelectState;

        public event Action? OnChange;
        public PhaseState(ChampSelectState champSelectState)
        {
            _champSelectState = champSelectState;
            Info.Text = "Swiss Group - Round 1";
            _champSelectState.UpdateInfoPhase(Info);
        }

        public void NotifyChanged() => OnChange?.Invoke();

        public void UpdateText(string text)
        {
            Info.Text = text;
            _champSelectState.UpdateInfoPhase(Info);
            NotifyChanged();
        }
    }
}
