using OSL_CDragon;
using OSL_Lcu.Schema.Lcu;

namespace OSL_Overlay.Phase.ChampSelect
{
    public class ChampSelectState
    {
        public ChampSelectInfo Info { get; private set; } = new(true);
        public string FileStyle { get; set; } = string.Empty;

        private readonly CDragon _cdragon;

        public event Action? OnChange;

        private ChampSelectSession _session;
        private bool IsFirstRun { get; set; } = true;
        public bool CustomPlayerName { get; set; } = false;

        public ChampSelectState(CDragon cdragon)
        {
            _cdragon = cdragon;
        }

        public void ManageSession(ChampSelectSession session)
        {
            _session = session;

            if (IsFirstRun) {
                InitInfo(session);
                IsFirstRun = false;
            }
            // Update player names
            UpdatePlayerNames(session);

            // Update champion pick
            UpdateChampionPick(session);

            // Update champion pick in progress
            UpdateChampionPickInProgress(session);

            // Update champion bans
            UpdateChampionBans(session);

            // Update champion bans in progress
            UpdateChampionBansInProgress(session);

            // Update timers phase
            TimerPhase(session);

            NotifyStateChanged();
        }

        private void InitInfo(ChampSelectSession session)
        {
            int nbBluePlayers = session.MyTeam.Count;
            int nbRedPlayers = session.TheirTeam.Count;
            int nbBlueBans = 5;
            int nbRedBans = 5;

            Info = new ChampSelectInfo(nbBluePlayers, nbRedPlayers, nbBlueBans, nbRedBans);

            // TODO: Get css default information
        }

        private void UpdatePlayerNames(ChampSelectSession session)
        {
            if (CustomPlayerName)
            {
                //TODO: Get player names from config
            }
            else
            {
                foreach (var (player, index) in session.MyTeam.Select((value, idx) => (value, idx)))
                {
                    Info.BlueTeam.Picks[index].Name.Txt = player.GameName;
                }
                foreach (var (player, index) in session.TheirTeam.Select((value, idx) => (value, idx)))
                {
                    Info.RedTeam.Picks[index].Name.Txt = player.GameName;
                }
            }
        }

        private void UpdateChampionPick(ChampSelectSession session)
        {
            foreach (var (player, index) in session.MyTeam.Select((value, idx) => (value, idx)))
            {
                if (player.ChampionId != 0)
                {
                    Info.BlueTeam.Picks[index].BackgroundImage = _cdragon.GetChampionSplash(player.ChampionId);
                    Info.BlueTeam.Picks[index].IsPicking = false;
                }
            }

            foreach (var (player, index) in session.TheirTeam.Select((value, idx) => (value, idx)))
            {
                if (player.ChampionId != 0)
                {
                    Info.RedTeam.Picks[index].BackgroundImage = _cdragon.GetChampionSplash(player.ChampionId);
                    Info.RedTeam.Picks[index].IsPicking = false;
                }
            }
        }

        private void UpdateChampionPickInProgress(ChampSelectSession session)
        {
            foreach (var contain in session.Actions)
            {
                foreach (var action in contain)
                {
                    if (action.Type == "pick" && action.IsInProgress)
                    {
                        if (action.IsAllyAction)
                        {
                            Info.BlueTeam.Picks[(int)action.ActorCellId].BackgroundImage = _cdragon.GetChampionSplash(action.ChampionId);
                            Info.BlueTeam.Picks[(int)action.ActorCellId].IsPicking = true;
                            UpdateTimer("blue", 25);
                        }
                        else if (!action.IsAllyAction)
                        {
                            Info.RedTeam.Picks[(int)action.ActorCellId - 5].BackgroundImage = _cdragon.GetChampionSplash(action.ChampionId);
                            Info.RedTeam.Picks[(int)action.ActorCellId - 5].IsPicking = true;
                            UpdateTimer("red", 25);
                        }
                    }
                }
            }
        }

        private void UpdateChampionBans(ChampSelectSession session)
        {
            foreach (var (ban, index) in session.Bans.MyTeamBans.Select((value, idx) => (value, idx)))
            {
                Info.BlueTeam.Bans[index].BackgroundImage = _cdragon.GetChampionSquare(ban);
                Info.BlueTeam.Bans[index].IsCompleted = true;
                Info.BlueTeam.Bans[index].IsBanning = false;
            }
            foreach (var (ban, index) in session.Bans.TheirTeamBans.Select((value, idx) => (value, idx)))
            {
                Info.RedTeam.Bans[index].BackgroundImage = _cdragon.GetChampionSquare(ban);
                Info.RedTeam.Bans[index].IsCompleted = true;
                Info.RedTeam.Bans[index].IsBanning = false;
            }
        }

        private void UpdateChampionBansInProgress(ChampSelectSession session)
        {
            foreach (var contain in session.Actions)
            {
                foreach (var action in contain)
                {
                    if (action.Type == "ban" && action.IsInProgress)
                    {
                        if (action.IsAllyAction)
                        {
                            Info.BlueTeam.Bans[(int)action.ActorCellId].BackgroundImage = _cdragon.GetChampionSquare(action.ChampionId);
                            Info.BlueTeam.Bans[(int)action.ActorCellId].IsBanning = true;
                            UpdateTimer("blue", 25);
                        }
                        else if (!action.IsAllyAction)
                        {
                            Info.RedTeam.Bans[(int)action.ActorCellId - 5].BackgroundImage = _cdragon.GetChampionSquare(action.ChampionId);
                            Info.RedTeam.Bans[(int)action.ActorCellId - 5].IsBanning = true;
                            UpdateTimer("red", 25);
                        }
                    }
                }
            }
        }

        private void TimerPhase(ChampSelectSession session)
        {
            switch (session.Timer.Phase)
            {
                case "PLANNING":
                    Info.Phase.Txt = "Planning";
                    UpdateTimer("common", 30);
                    break;
                case "BAN_PICK":
                    Info.Phase.Txt = "Ban & Pick";
                    break;
                case "FINALIZATION":
                    Info.Phase.Txt = "Finalization";
                    UpdateTimer("common", 60);
                    break;
                case "GAME_STARTING":
                    Info.Phase.Txt = "Game Starting";
                    UpdateTimer("common", 130);
                    break;
                default:
                    Info.Phase.Txt = "Unknown Phase";
                    UpdateTimer("common", 0);
                    break;
            }
        }

        private void UpdateTimer(string side, int duration)
        {
            switch (side)
            {
                case "blue":
                    Info.BlueTeam.Timer.Show = true;
                    Info.RedTeam.Timer.Show = false;
                    Info.CommonTimer.Show = false;
                    Info.BlueTeam.Timer.Duration = duration;
                    break;
                case "red":
                    Info.RedTeam.Timer.Show = true;
                    Info.BlueTeam.Timer.Show = true;
                    Info.CommonTimer.Show = false;
                    Info.RedTeam.Timer.Duration = duration;
                    break;
                case "common":
                    Info.CommonTimer.Show = true;
                    Info.BlueTeam.Timer.Show = false;
                    Info.RedTeam.Timer.Show = false;
                    Info.CommonTimer.Duration = duration;
                    break;
                default:
                    Info.BlueTeam.Timer.Show = false;
                    Info.RedTeam.Timer.Show = false;
                    Info.CommonTimer.Show = false;
                    break;
            }
        }

        public void UpdateInfoCss(ChampSelectInfo info)
        {
            Info = info;
            if (_session != null)
                ManageSession(_session);
            NotifyStateChanged();
        }

        public void CssChange()
        {
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
