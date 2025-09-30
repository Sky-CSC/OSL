using Newtonsoft.Json;
using OSL_CDragon;
using OSL_CDragon.Schema;
using OSL_Lcu.Schema.Lcu;
using OSL_Overlay.Phase.Bo;
using OSL_Overlay.Phase.Team;

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

            if (IsFirstRun)
            {
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
                    Info.BlueTeam.Picks[index].ChampionImage = _cdragon.GetChampionSplash(player.ChampionId);
                    Info.BlueTeam.Picks[index].IsPicking = false;
                }
            }

            foreach (var (player, index) in session.TheirTeam.Select((value, idx) => (value, idx)))
            {
                if (player.ChampionId != 0)
                {
                    Info.RedTeam.Picks[index].ChampionImage = _cdragon.GetChampionSplash(player.ChampionId);
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
                            Info.BlueTeam.Picks[(int)action.ActorCellId].ChampionImage = _cdragon.GetChampionSplash(action.ChampionId);
                            Info.BlueTeam.Picks[(int)action.ActorCellId].IsPicking = true;
                            UpdateTimer("blue", 25);
                        }
                        else if (!action.IsAllyAction)
                        {
                            Info.RedTeam.Picks[(int)action.ActorCellId - 5].ChampionImage = _cdragon.GetChampionSplash(action.ChampionId);
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
                Info.BlueTeam.Bans[index].ChampionImage = _cdragon.GetChampionSquare(ban);
                Info.BlueTeam.Bans[index].IsCompleted = true;
                Info.BlueTeam.Bans[index].IsBanning = false;
            }
            foreach (var (ban, index) in session.Bans.TheirTeamBans.Select((value, idx) => (value, idx)))
            {
                Info.RedTeam.Bans[index].ChampionImage = _cdragon.GetChampionSquare(ban);
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
                            Info.BlueTeam.Bans[(int)action.ActorCellId].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
                            Info.BlueTeam.Bans[(int)action.ActorCellId].IsBanning = true;
                            UpdateTimer("blue", 25);
                        }
                        else if (!action.IsAllyAction)
                        {
                            Info.RedTeam.Bans[(int)action.ActorCellId - 5].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
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

        public void UpdateInfoTeam(TeamInfo info, string side)
        {
            if (side == "blue-side")
            {
                Info.BlueTeam.Name.Txt = info.Name;
                Info.BlueTeam.Tag.Txt = info.Tag;
                Info.BlueTeam.Coach.Name.Txt = info.Coach;
                Info.BlueTeam.Logo = info.Logo;
                if (Info.BlueTeam.Picks.Count > 0)
                {
                    Info.BlueTeam.Picks[0].Name.Txt = info.Top.Name;
                    Info.BlueTeam.Picks[0].PlayerImage = info.Top.Image;
                }
                if (Info.BlueTeam.Picks.Count > 1)
                {
                    Info.BlueTeam.Picks[1].Name.Txt = info.Jungle.Name;
                    Info.BlueTeam.Picks[1].PlayerImage = info.Jungle.Image;
                }
                if (Info.BlueTeam.Picks.Count > 2)
                {
                    Info.BlueTeam.Picks[2].Name.Txt = info.Mid.Name;
                    Info.BlueTeam.Picks[2].PlayerImage = info.Mid.Image;
                }
                if (Info.BlueTeam.Picks.Count > 3)
                {
                    Info.BlueTeam.Picks[3].Name.Txt = info.Adc.Name;
                    Info.BlueTeam.Picks[3].PlayerImage = info.Adc.Image;
                }
                if (Info.BlueTeam.Picks.Count > 4)
                {
                    Info.BlueTeam.Picks[4].Name.Txt = info.Supp.Name;
                    Info.BlueTeam.Picks[4].PlayerImage = info.Supp.Image;
                }
            }
            else if (side == "red-side")
            {
                Info.RedTeam.Name.Txt = info.Name;
                Info.RedTeam.Tag.Txt = info.Tag;
                Info.RedTeam.Coach.Name.Txt = info.Coach;
                Info.RedTeam.Logo = info.Logo;
                if (Info.RedTeam.Picks.Count > 0)
                {
                    Info.RedTeam.Picks[0].Name.Txt = info.Top.Name;
                    Info.RedTeam.Picks[0].PlayerImage = info.Top.Image;
                }
                if (Info.RedTeam.Picks.Count > 1)
                {
                    Info.RedTeam.Picks[1].Name.Txt = info.Jungle.Name;
                    Info.RedTeam.Picks[1].PlayerImage = info.Jungle.Image;
                }
                if (Info.RedTeam.Picks.Count > 2)
                {
                    Info.RedTeam.Picks[2].Name.Txt = info.Mid.Name;
                    Info.RedTeam.Picks[2].PlayerImage = info.Mid.Image;
                }
                if (Info.RedTeam.Picks.Count > 3)
                {
                    Info.RedTeam.Picks[3].Name.Txt = info.Adc.Name;
                    Info.RedTeam.Picks[3].PlayerImage = info.Adc.Image;
                }
                if (Info.RedTeam.Picks.Count > 4)
                {
                    Info.RedTeam.Picks[4].Name.Txt = info.Supp.Name;
                    Info.RedTeam.Picks[4].PlayerImage = info.Supp.Image;
                }
            }
            NotifyStateChanged();
        }

        public void UpdateInfoBo(BoInfo bo, string side)
        {
            if (side == "blue-side")
            {
                Info.BlueTeam.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.BlueTeam.BoGraphic.NbWin = bo.Win;
                Info.BlueTeam.BoGraphic.Win.Txt = bo.Text;
            }
            if (side == "red-side")
            {
                Info.RedTeam.BoGraphic.NbMatchForWin = bo.NbGames;
                Info.RedTeam.BoGraphic.NbWin = bo.Win;
                Info.RedTeam.BoGraphic.Win.Txt = bo.Text;
            }
            NotifyStateChanged();
        }

        public void LoadStyle(string path)
        {
            // TODO: Load style
            string json = OSL_Utils.File.Read(path);
            var info = JsonConvert.DeserializeObject<ChampSelectInfo>(json);
            if (info != null)
            {
                UpdateInfoCss(info);
            }
        }

        public void SaveStyle(string path)
        {
            // TODO: Save style
            string json = JsonConvert.SerializeObject(Info, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
        }

        public void CssChange()
        {
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
