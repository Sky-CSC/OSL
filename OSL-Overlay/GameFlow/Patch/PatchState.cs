using OSL_CDragon;
using OSL_Overlay.GameFlow.ChampSelect;

namespace OSL_Overlay.GameFlow.Patch
{
    /// <summary>
    /// Patch management
    /// </summary>
    public class PatchState
    {
        /// <summary>
        /// Patch information
        /// </summary>
        public PatchInfo Info { get; private set; } = new();
        /// <summary>
        /// CDragon instance
        /// </summary>
        private readonly CDragon _cdragon;
        /// <summary>
        /// Champ select instance
        /// </summary>
        private readonly ChampSelectState _champSelectState;

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cdragon"></param>
        /// <param name="champSelectState"></param>
        public PatchState(CDragon cdragon, ChampSelectState champSelectState)
        {
            _cdragon = cdragon;
            _champSelectState = champSelectState;
            Info.Text = "Patch";
            Info.Version = _cdragon.GetPatchVersion();
            _champSelectState.UpdateInfoPatch(Info);
        }

        public void NotifyChanged() => OnChange?.Invoke();

        /// <summary>
        /// Update the patch text
        /// </summary>
        /// <param name="text"></param>
        public void UpdateText(string text)
        {
            Info.Text = text;
            _champSelectState.UpdateInfoPatch(Info);
            NotifyChanged();
        }

        /// <summary>
        /// Update the patch version
        /// </summary>
        /// <param name="version"></param>
        public void UpdatePatch(string version)
        {
            Info.Version = version;
            _champSelectState.UpdateInfoPatch(Info);
            NotifyChanged();
        }
    }
}
