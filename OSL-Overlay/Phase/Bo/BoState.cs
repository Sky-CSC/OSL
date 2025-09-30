using OSL_Overlay.Phase.ChampSelect;

namespace OSL_Overlay.Phase.Bo
{
    public class BoState
    {
        public BoInfo BlueInfo { get; set; } = new();
        public BoInfo RedInfo { get; set; } = new();

        private readonly ChampSelectState ChampState;

        public BoState(ChampSelectState state)
        {
            ChampState = state;
        }

        private IWebHostEnvironment Env { get; set; } = default!;

        public event Action? OnChange;

        public void NotifyChanged() => OnChange?.Invoke();

        //public void
        public void UpdateBlueBo()
        {
            ChampState.UpdateInfoBo(BlueInfo, "blue-side");
            NotifyChanged();
        }
        public void UpdateRedBo()
        {
            ChampState.UpdateInfoBo(RedInfo, "red-side");
            NotifyChanged();
        }

        public void ResetBlueBo()
        {
            BlueInfo.Text = "";
            BlueInfo.NbGames = 0;
            BlueInfo.Win = 0;
            ChampState.UpdateInfoBo(BlueInfo, "blue-side");
            NotifyChanged();
        }

        public void ResetRedBo()
        {
            RedInfo.Text = "";
            RedInfo.NbGames = 0;
            RedInfo.Win = 0;
            ChampState.UpdateInfoBo(RedInfo, "red-side");
            NotifyChanged();
        }

        public void SwapBo()
        {
            (RedInfo, BlueInfo) = (BlueInfo, RedInfo);
            UpdateBlueBo();
            UpdateRedBo();
        }
    }
}
