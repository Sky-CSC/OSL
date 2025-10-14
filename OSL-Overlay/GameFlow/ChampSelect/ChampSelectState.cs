using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Lcu.Schema.Lcu;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.Patch;
using OSL_Overlay.GameFlow.Phase;
using OSL_Overlay.GameFlow.Team;
using OSL_Overlay.GameFlow.Vs;

namespace OSL_Overlay.GameFlow.ChampSelect
{
    public class ChampSelectState
    {
        public ChampSelectInfo Info { get; private set; } = new(true);

        public List<GameFlow.Team.Lane> BlueTeamNames = [];
        public List<GameFlow.Team.Lane> RedTeamNames = [];
        public List<string> SavedBlueTeamNames = Enumerable.Repeat<string?>(null, 5).ToList();
        public List<string> SavedRedTeamNames = Enumerable.Repeat<string?>(null, 5).ToList();

        private readonly CDragon _cdragon;

        public event Action? OnChange;

        public bool CustomPlayerName { get; set; } = false;

        public ChampSelectState(CDragon cdragon)
        {
            _cdragon = cdragon;
            // Load file for testing
            ChampSelectSession session = null;
            string filePathMatch = "./GameFlow/ChampSelect/Session.json";
            if (File.Exists(filePathMatch))
            {
                string json = File.ReadAllText(filePathMatch);
                session = JsonConvert.DeserializeObject<ChampSelectSession>(json);
            }

            if (session != null)
                ManageSession(session);
        }

        public void ManageSession(ChampSelectSession session)
        {
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

        private void UpdatePlayerNames(ChampSelectSession session)
        {
            foreach (var (player, index) in session.MyTeam.Select((value, idx) => (value, idx)))
            {
                if (BlueTeamNames.Count > index && BlueTeamNames[index].ShowCustomName)
                {
                    Info.BlueTeam.Picks[index].Name.Txt = BlueTeamNames[index].Name;
                }
                else
                    Info.BlueTeam.Picks[index].Name.Txt = player.GameName;
                SavedBlueTeamNames[index] = player.GameName;
            }

            foreach (var (player, index) in session.TheirTeam.Select((value, idx) => (value, idx)))
            {
                if (RedTeamNames.Count > index && RedTeamNames[index].ShowCustomName)
                {
                    Info.RedTeam.Picks[index].Name.Txt = RedTeamNames[index].Name;
                }
                else
                    Info.RedTeam.Picks[index].Name.Txt = player.GameName;
                SavedRedTeamNames[index] = player.GameName;
            }
        }

        private void UpdateChampionPick(ChampSelectSession session)
        {
            foreach (var (player, index) in session.MyTeam.Select((value, idx) => (value, idx)))
            {
                Info.BlueTeam.Picks[index].ChampionImage = _cdragon.GetChampionSplash(player.ChampionId);
                Info.BlueTeam.Picks[index].IsPicking = false;
            }

            foreach (var (player, index) in session.TheirTeam.Select((value, idx) => (value, idx)))
            {
                Info.RedTeam.Picks[index].ChampionImage = _cdragon.GetChampionSplash(player.ChampionId);
                Info.RedTeam.Picks[index].IsPicking = false;
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
            int nbBlueBan = 0;
            foreach (var (ban, index) in session.Bans.MyTeamBans.Select((value, idx) => (value, idx)))
            {
                Info.BlueTeam.Bans[index].ChampionImage = _cdragon.GetChampionSquare(ban);
                Info.BlueTeam.Bans[index].IsCompleted = true;
                Info.BlueTeam.Bans[index].IsBanning = false;
                nbBlueBan++;
            }
            for (int i = nbBlueBan; i < 5; i++)
            {
                Info.BlueTeam.Bans[i].ChampionImage = _cdragon.GetChampionSquare(0);
                Info.BlueTeam.Bans[i].IsCompleted = false;
                Info.BlueTeam.Bans[i].IsBanning = false;
            }
            int nbRedBan = 0;
            foreach (var (ban, index) in session.Bans.TheirTeamBans.Select((value, idx) => (value, idx)))
            {
                Info.RedTeam.Bans[index].ChampionImage = _cdragon.GetChampionSquare(ban);
                Info.RedTeam.Bans[index].IsCompleted = true;
                Info.RedTeam.Bans[index].IsBanning = false;
                nbRedBan++;
            }
            for (int i = nbRedBan; i < 5; i++)
            {
                Info.RedTeam.Bans[i].ChampionImage = _cdragon.GetChampionSquare(0);
                Info.RedTeam.Bans[i].IsCompleted = false;
                Info.RedTeam.Bans[i].IsBanning = false;
            }
        }

        private void UpdateChampionBansInProgress(ChampSelectSession session)
        {
            foreach (var contain in session.Actions)
            {
                foreach (var action in contain)
                {
                    if (action.Type == "ban")
                    {
                        if (action.IsInProgress)
                        {

                            if (action.IsAllyAction) // 1 3 5 8 10
                            {
                                Info.BlueTeam.Bans[BluePickTurn.GetValueOrDefault(action.PickTurn)].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
                                Info.BlueTeam.Bans[BluePickTurn.GetValueOrDefault(action.PickTurn)].IsBanning = true;
                                UpdateTimer("blue", 25);
                            }
                            else // 2 4 6 7 9
                            {
                                Info.RedTeam.Bans[RedPickTurn.GetValueOrDefault(action.PickTurn)].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
                                Info.RedTeam.Bans[RedPickTurn.GetValueOrDefault(action.PickTurn)].IsBanning = true;
                                UpdateTimer("red", 25);
                            }
                        }
                        else if (action.Completed)
                        {
                            if (action.IsAllyAction)
                            {
                                Info.BlueTeam.Bans[BluePickTurn.GetValueOrDefault(action.PickTurn)].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
                                Info.BlueTeam.Bans[BluePickTurn.GetValueOrDefault(action.PickTurn)].IsCompleted = true;
                                Info.BlueTeam.Bans[BluePickTurn.GetValueOrDefault(action.PickTurn)].IsBanning = false;
                            }
                            else
                            {
                                Info.RedTeam.Bans[RedPickTurn.GetValueOrDefault(action.PickTurn)].ChampionImage = _cdragon.GetChampionSquare(action.ChampionId);
                                Info.RedTeam.Bans[RedPickTurn.GetValueOrDefault(action.PickTurn)].IsCompleted = true;
                                Info.RedTeam.Bans[RedPickTurn.GetValueOrDefault(action.PickTurn)].IsBanning = false;
                            }
                        }
                    }
                }
            }
        }

        // Mapping des tours de ban vers l’index pour chaque équipe
        private static readonly Dictionary<int, int> BluePickTurn = new()
        {
            { 1, 0 },
            { 3, 1 },
            { 5, 2 },
            { 8, 3 },
            { 10, 4 }
        };

        private static readonly Dictionary<int, int> RedPickTurn = new()
        {
            { 2, 0 },
            { 4, 1 },
            { 6, 2 },
            { 7, 3 },
            { 9, 4 }
        };


        private void TimerPhase(ChampSelectSession session)
        {
            switch (session.Timer.Phase)
            {
                case "PLANNING":
                    //Info.Phase.Txt = "Planning";
                    UpdateTimer("common", 30);
                    break;
                case "BAN_PICK":
                    //Info.Phase.Txt = "Ban & Pick";
                    break;
                case "FINALIZATION":
                    //Info.Phase.Txt = "Finalization";
                    UpdateTimer("common", 60);
                    break;
                case "GAME_STARTING":
                    //Info.Phase.Txt = "Game Starting";
                    UpdateTimer("common", 130);
                    break;
                default:
                    //Info.Phase.Txt = "Unknown Phase";
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

        public void UpdateBlueTeamInfo(TeamInfo info)
        {
            Info.BlueTeam.Name.Txt = info.Name;
            Info.BlueTeam.Tag.Txt = info.Tag;
            Info.BlueTeam.Coach.Name.Txt = info.Coach;
            Info.BlueTeam.Logo = new(info.Logo);

            List<Lane> lanes = new List<Lane>
            {
                info.Top,
                info.Jungle,
                info.Mid,
                info.Adc,
                info.Supp
            };

            BlueTeamNames = lanes;

            for (int i = 0; i < Info.BlueTeam.Picks.Count && i < lanes.Count && i < SavedBlueTeamNames.Count; i++)
            {
                if (lanes[i].ShowCustomName)
                    Info.BlueTeam.Picks[i].Name.Txt = lanes[i].Name;
                else
                    Info.BlueTeam.Picks[i].Name.Txt = SavedBlueTeamNames[i];
                Info.BlueTeam.Picks[i].PlayerImage = lanes[i].Image;
            }
            NotifyStateChanged();
        }

        public void UpdateRedTeamInfo(TeamInfo info)
        {
            Info.RedTeam.Name.Txt = info.Name;
            Info.RedTeam.Tag.Txt = info.Tag;
            Info.RedTeam.Coach.Name.Txt = info.Coach;
            Info.RedTeam.Logo = new(info.Logo);

            List<Lane> lanes = new List<Lane>
            {
                info.Top,
                info.Jungle,
                info.Mid,
                info.Adc,
                info.Supp
            };

            RedTeamNames = lanes;

            for (int i = 0; i < Info.RedTeam.Picks.Count && i < lanes.Count && i < SavedRedTeamNames.Count; i++)
            {
                if (lanes[i].ShowCustomName)
                    Info.RedTeam.Picks[i].Name.Txt = lanes[i].Name;
                else
                    Info.RedTeam.Picks[i].Name.Txt = SavedRedTeamNames[i];
                Info.RedTeam.Picks[i].PlayerImage = lanes[i].Image;
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

        public void UpdateInfoPatch(PatchInfo patch)
        {
            Info.Patch.PatchInfo.Txt = patch.Text;
            Info.Patch.Version.Txt = patch.Version;
            NotifyStateChanged();
        }

        public void UpdateInfoPhase(PhaseInfo phase)
        {
            Info.Phase.Txt = phase.Text;
            NotifyStateChanged();
        }

        public void UpdateInfoVs(VsInfo phase)
        {
            Info.Vs.Txt = phase.Text;
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnChange?.Invoke();
    }

    public static class ChampSelectStateExtensions
    {
        public static ChampSelectInfo CloneInfo(this ChampSelectInfo source)
        {
            var json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<ChampSelectInfo>(json) ?? new ChampSelectInfo();
        }
    }
}
