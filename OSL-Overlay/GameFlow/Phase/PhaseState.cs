using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;

namespace OSL_Overlay.GameFlow.Phase
{
    /// <summary>
    /// Phase management
    /// </summary>
    public class PhaseState
    {
        /// <summary>
        /// Phase information
        /// </summary>
        public PhaseInfo Info { get; private set; } = new();
        /// <summary>
        /// Champ select state
        /// </summary>
        private readonly ChampSelectState _champSelectState;
        private readonly EndGameState _endGameState;

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="champSelectState"></param>
        public PhaseState(ChampSelectState champSelectState, EndGameState endGameState)
        {
            _champSelectState = champSelectState;
            _endGameState = endGameState;
            Info.Phase.Txt = "Swiss Group - Round 1";
            Info.Event.Txt = "2026 OSL 2.0.0";
            Info.Date.Txt = "03 Juill";
            _champSelectState.UpdateInfoPhase(Info);
            _endGameState.UpdateInfoPhase(Info);
        }

        public void NotifyChanged() => OnChange?.Invoke();

        /// <summary>
        /// Update phase text
        /// </summary>
        /// <param name="text"></param>
        public void UpdatePhaseText(string text)
        {
            Info.Phase.Txt = text;
            _champSelectState.UpdateInfoPhase(Info);
            _endGameState.UpdateInfoPhase(Info);
            NotifyChanged();
        }
        public void UpdateEventText(string text)
        {
            Info.Event.Txt = text;
            _champSelectState.UpdateInfoPhase(Info);
            _endGameState.UpdateInfoPhase(Info);
            NotifyChanged();
        }
        public void UpdateDateText(string text)
        {
            Info.Date.Txt = text;
            _champSelectState.UpdateInfoPhase(Info);
            _endGameState.UpdateInfoPhase(Info);
            NotifyChanged();
        }
    }
}
