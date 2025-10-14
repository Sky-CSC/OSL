using OSL_Overlay.GameFlow.ChampSelect;

namespace OSL_Overlay.GameFlow.Vs
{
    /// <summary>
    /// Management of text VS
    /// </summary>
    public class VsState
    {
        /// <summary>
        /// Curent vs info
        /// </summary>
        public VsInfo Info { get; private set; } = new();
        /// <summary>
        /// Champ select process
        /// </summary>
        private readonly ChampSelectState _champSelectState;

        public event Action? OnChange;

        /// <summary>
        /// Vs state init
        /// </summary>
        /// <param name="champSelectState"></param>
        public VsState(ChampSelectState champSelectState)
        {
            _champSelectState = champSelectState;
            Info.Text = "VS";
            _champSelectState.UpdateInfoVs(Info);
        }

        public void NotifyChanged() => OnChange?.Invoke();

        /// <summary>
        /// Update vs text
        /// </summary>
        /// <param name="text"></param>
        public void UpdateText(string text)
        {
            Info.Text = text;
            _champSelectState.UpdateInfoVs(Info);
            NotifyChanged();
        }
    }
}
