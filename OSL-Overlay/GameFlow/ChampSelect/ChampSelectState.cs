using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Lcu.Schema.Lcu;
using OSL_Overlay.GameFlow.Bo;
using OSL_Overlay.GameFlow.EndGame;
using OSL_Overlay.GameFlow.Patch;
using OSL_Overlay.GameFlow.Phase;
using OSL_Overlay.GameFlow.Team;
using OSL_Overlay.GameFlow.Vs;

namespace OSL_Overlay.GameFlow.ChampSelect
{
    /// <summary>
    /// Champion Select management
    /// </summary>
    public class ChampSelectState
    {
        /// <summary>
        /// Champion Select information
        /// </summary>
        public ChampSelectInfo Info { get; private set; } = new(true);

        /// <summary>
        /// Blue team player names customization
        /// </summary>
        public List<Lane> BlueTeamNames = [];
        /// <summary>
        /// Red team player names customization
        /// </summary>
        public List<Lane> RedTeamNames = [];
        /// <summary>
        /// Blue team saved player names from LCU
        /// </summary>
        public List<string> SavedBlueTeamNames = Enumerable.Repeat<string?>(null, 5).ToList();
        /// <summary>
        /// Red team saved player names from LCU
        /// </summary>
        public List<string> SavedRedTeamNames = Enumerable.Repeat<string?>(null, 5).ToList();

        /// <summary>
        /// CDRagon instance
        /// </summary>
        private readonly CDragon _cdragon;

        public event Action? OnChange;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cdragon"></param>
        public ChampSelectState(CDragon cdragon)
        {
            _cdragon = cdragon;
            // Load default data for initialization
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

        /// <summary>
        /// Update data from LCU session
        /// </summary>
        /// <param name="session"></param>
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

            // TODO : Try to get info for set runes

            NotifyStateChanged();
        }

        /// <summary>
        /// Update player names from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Update champion pick from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Update champion pick in progress from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Update champion bans from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Update champion bans in progress from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Dictionaries to map pick turns to ban indices for blue team
        /// </summary>
        private static readonly Dictionary<int, int> BluePickTurn = new()
        {
            { 1, 0 },
            { 3, 1 },
            { 5, 2 },
            { 8, 3 },
            { 10, 4 }
        };

        /// <summary>
        /// Dictionaries to map pick turns to ban indices for red team
        /// </summary>
        private static readonly Dictionary<int, int> RedPickTurn = new()
        {
            { 2, 0 },
            { 4, 1 },
            { 6, 2 },
            { 7, 3 },
            { 9, 4 }
        };

        /// <summary>
        /// Update timer phase from LCU session
        /// </summary>
        /// <param name="session"></param>
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

        /// <summary>
        /// Update timer display
        /// </summary>
        /// <param name="side"></param>
        /// <param name="duration"></param>
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
                    Info.BlueTeam.Timer.Show = false;
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

        /// <summary>
        /// Update blue team information
        /// </summary>
        /// <param name="info"></param>
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

        /// <summary>
        /// Update red team information
        /// </summary>
        /// <param name="info"></param>
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

        /// <summary>
        /// Update best of information
        /// </summary>
        /// <param name="bo"></param>
        /// <param name="side"></param>
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

        /// <summary>
        /// Update patch information
        /// </summary>
        /// <param name="patch"></param>
        public void UpdateInfoPatch(PatchInfo patch)
        {
            Info.Patch.PatchInfo.Txt = patch.Text;
            Info.Patch.Version.Txt = patch.Version;
            NotifyStateChanged();
        }

        /// <summary>
        /// Update phase information
        /// </summary>
        /// <param name="phase"></param>
        public void UpdateInfoPhase(PhaseInfo phase)
        {
            Info.PhaseInfo.Phase.Txt = phase.Phase.Txt;
            Info.PhaseInfo.Event.Txt = phase.Event.Txt;
            Info.PhaseInfo.Date.Txt = phase.Date.Txt;
            NotifyStateChanged();
        }

        /// <summary>
        /// Update versus information
        /// </summary>
        /// <param name="phase"></param>
        public void UpdateInfoVs(VsInfo phase)
        {
            Info.Vs.Txt = phase.Text;
            NotifyStateChanged();
        }

        public void NotifyStateChanged() => OnChange?.Invoke();
    }

    /// <summary>
    /// Champion Select extensions
    /// </summary>
    public static class ChampSelectStateExtensions
    {
        /// <summary>
        /// Clone ChampSelectInfo object
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ChampSelectInfo CloneInfo(this ChampSelectInfo source)
        {
            var json = JsonConvert.SerializeObject(source);
            var settings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            var clone = JsonConvert.DeserializeObject<ChampSelectInfo>(json, settings);
            return clone ?? new ChampSelectInfo();
        }
    }
}
