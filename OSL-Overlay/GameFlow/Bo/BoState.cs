using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;

namespace OSL_Overlay.GameFlow.Bo
{
    /// <summary>
    /// Bo management
    /// </summary>
    public class BoState
    {
        /// <summary>
        /// Blue side Bo info
        /// </summary>
        public BoInfo BlueInfo { get; set; } = new();
        /// <summary>
        /// Red side Bo info
        /// </summary>
        public BoInfo RedInfo { get; set; } = new();
        /// <summary>
        /// Champ select state to update Bo info
        /// </summary>
        private readonly ChampSelectState ChampState;
        /// <summary>
        /// End game state to update Bo info
        /// </summary>
        private readonly EndGameState EndGameState;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="champSelectState"></param>
        /// <param name="endGameState"></param>
        public BoState(ChampSelectState champSelectState, EndGameState endGameState)
        {
            ChampState = champSelectState;
            EndGameState = endGameState;
        }

        public event Action? OnChange;

        public void NotifyChanged() => OnChange?.Invoke();

        /// <summary>
        /// Update Bo info in champ select and end game
        /// </summary>
        public void UpdateBlueBo()
        {
            ChampState.UpdateInfoBo(BlueInfo, "blue-side");
            EndGameState.UpdateInfoBo(BlueInfo, "blue-side");
            NotifyChanged();
        }

        /// <summary>
        /// Update Bo info in champ select and end game
        /// </summary>
        public void UpdateRedBo()
        {
            ChampState.UpdateInfoBo(RedInfo, "red-side");
            EndGameState.UpdateInfoBo(RedInfo, "red-side");
            NotifyChanged();
        }

        /// <summary>
        /// Reset Blue Bo info in champ select and end game
        /// </summary>
        public void ResetBlueBo()
        {
            BlueInfo.Text = "";
            BlueInfo.NbGames = 0;
            BlueInfo.Win = 0;
            ChampState.UpdateInfoBo(BlueInfo, "blue-side");
            EndGameState.UpdateInfoBo(BlueInfo, "blue-side");
            NotifyChanged();
        }

        /// <summary>
        /// Reset Red Bo info in champ select and end game
        /// </summary>
        public void ResetRedBo()
        {
            RedInfo.Text = "";
            RedInfo.NbGames = 0;
            RedInfo.Win = 0;
            ChampState.UpdateInfoBo(RedInfo, "red-side");
            EndGameState.UpdateInfoBo(RedInfo, "red-side");
            NotifyChanged();
        }

        /// <summary>
        /// Swap Blue and Red Bo info in champ select and end game
        /// </summary>
        public void SwapBo()
        {
            (RedInfo, BlueInfo) = (BlueInfo, RedInfo);
            UpdateBlueBo();
            UpdateRedBo();
        }
    }
}
