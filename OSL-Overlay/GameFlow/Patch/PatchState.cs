using OSL_CDragon;
using OSL_Overlay.GameFlow.ChampSelect;

namespace OSL_Overlay.GameFlow.Patch
{
    public class PatchState
    {
        public PatchInfo Info { get; private set; } = new();
        private readonly CDragon _cdragon;
        private readonly ChampSelectState _champSelectState;

        public event Action? OnChange;
        public PatchState(CDragon cdragon, ChampSelectState champSelectState)
        {
            _cdragon = cdragon;
            _champSelectState = champSelectState;
            Info.Text = "Patch";
            Info.Version = _cdragon.GetPatchVersion();
            _champSelectState.UpdateInfoPatch(Info);
        }

        public void NotifyChanged() => OnChange?.Invoke();

        public void UpdateText(string text)
        {
            Info.Text = text;
            _champSelectState.UpdateInfoPatch(Info);
            NotifyChanged();
        }

        public void UpdatePatch(string version)
        {
            Info.Version = version;
            _champSelectState.UpdateInfoPatch(Info);
            NotifyChanged();
        }
    }
}
