using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_Web.Pages.ChampSelect;

namespace OSL_Web.DataProcessing
{
    public class ChampSelect
    {
        private static Logger _logger = new("ChampSelect");
        public static Session session;
        public static Session previousSession;
        public static bool alreadyLastPhase = false;

        /// <summary>
        /// Recive champ select information, regulation of timer on overlay
        /// </summary>
        /// <param name="content"></param>
        public static void ReadData(string content)
        {
            previousSession = session;
            session = ChampSelectProcessingDataRecive(content);
            bool sameTurn = false;
            bool actionInProgress = false;
            _logger.log(LoggingLevel.INFO, "InChampSelect()", $"alreadyLastPhase {alreadyLastPhase}");

            if (session.Timer.Phase.Equals("GAME_STARTING"))
            {
                TimeControl.phaseTimer.Stop();
                TimeControl.DecreasingTimerChapSelect(180);
                TimeControl.phaseTimerFast.Stop();
                TimeControl.DecreasingTimerChapSelectFast(1750, 103);
                TimeControl.phaseTimerView3.Stop();
                TimeControl.DecreasingTimerChapSelectView3(1920, 94);
                //Get runes
                string summonerName = session.MyTeam[0].SummonerName;
                if (summonerName.Equals("Bot"))
                {
                    summonerName = session.TheirTeam[0].SummonerName;
                }
                Runes.GetPerksInformation(summonerName);
            }
            else
            {
                foreach (var tabActions in session.Actions)
                {
                    foreach (var actions in tabActions)
                    {
                        if (actions.IsInProgress)
                        {
                            actionInProgress = true;
                            alreadyLastPhase = false;
                            if (actions.Type.Equals("ban") || actions.Type.Equals("pick"))
                            {
                                if (previousSession != null)
                                {
                                    foreach (var tabActionsPrevious in previousSession.Actions)
                                    {
                                        foreach (var actionsPrevious in tabActionsPrevious)
                                        {
                                            if (actionsPrevious.Id == actions.Id && !actionsPrevious.Completed && actionsPrevious.IsInProgress == actions.IsInProgress)
                                            {
                                                sameTurn = true;
                                            }
                                        }
                                    }
                                    if (!sameTurn)
                                    {
                                        TimeControl.phaseTimer.Stop();
                                        TimeControl.DecreasingTimerChapSelect(27);
                                        TimeControl.phaseTimerFast.Stop();
                                        TimeControl.DecreasingTimerChapSelectFast(1750, 1);
                                        TimeControl.phaseTimerView3.Stop();
                                        TimeControl.DecreasingTimerChapSelectView3(1920, 1);
                                    }
                                }
                                else
                                {
                                    TimeControl.phaseTimer.Stop();
                                    TimeControl.DecreasingTimerChapSelect(27);
                                    TimeControl.phaseTimerFast.Stop();
                                    TimeControl.DecreasingTimerChapSelectFast(1750, 1);
                                    TimeControl.phaseTimerView3.Stop();
                                    TimeControl.DecreasingTimerChapSelectView3(1920, 1);
                                }
                            }
                        }
                    }
                }

                if (!actionInProgress && !alreadyLastPhase)
                {
                    TimeControl.phaseTimer.Stop();
                    TimeControl.DecreasingTimerChapSelect(59);
                    TimeControl.phaseTimerFast.Stop();
                    TimeControl.DecreasingTimerChapSelectFast(1750, 34);
                    TimeControl.phaseTimerView3.Stop();
                    TimeControl.DecreasingTimerChapSelectView3(1920, 31);
                    alreadyLastPhase = true;
                }
            }
        }

        /// <summary>
        /// Write in a session the content of data recive by the client for make a 
        /// post traitment of him and make display
        /// </summary>
        /// <param name="champSelectDataRecive"></param>
        /// <returns></returns>
        public static Session ChampSelectProcessingDataRecive(string champSelectDataRecive)
        {
            dynamic jsonContentMetadata = JsonConvert.DeserializeObject(champSelectDataRecive);
            Session session = new();

            for (int i = 0; i < jsonContentMetadata.actions.Count; i++)
            {
                List<Actions> actionI = new();
                for (int j = 0; j < jsonContentMetadata.actions[i].Count; j++)
                {
                    Actions actionJ = new();
                    actionJ.ActorCellId = jsonContentMetadata.actions[i][j].actorCellId;
                    actionJ.ChampionId = jsonContentMetadata.actions[i][j].championId;
                    actionJ.Completed = jsonContentMetadata.actions[i][j].completed;
                    actionJ.Id = jsonContentMetadata.actions[i][j].id;
                    actionJ.IsInProgress = jsonContentMetadata.actions[i][j].isInProgress;
                    actionJ.PickTurn = jsonContentMetadata.actions[i][j].pickTurn;
                    actionJ.Type = jsonContentMetadata.actions[i][j].type;
                    actionI.Insert(j, actionJ);
                }
                session.Actions.Insert(i, actionI);
            }

            for (int i = 0; i < jsonContentMetadata.bans.myTeamBans.Count; i++)
            {
                int ban = jsonContentMetadata.bans.myTeamBans[i];
                session.Bans.MyTeamBans.Insert(i, ban);
            }
            for (int i = 0; i < jsonContentMetadata.bans.theirTeamBans.Count; i++)
            {
                int ban = jsonContentMetadata.bans.theirTeamBans[i];
                session.Bans.TheirTeamBans.Insert(i, ban);
            }

            for (int i = 0; i < jsonContentMetadata.myTeam.Count; i++)
            {
                Team team = new();
                team.CellId = jsonContentMetadata.myTeam[i].cellId;
                team.ChampionId = jsonContentMetadata.myTeam[i].championId;
                team.Spell1Id = jsonContentMetadata.myTeam[i].spell1Id;
                team.Spell2Id = jsonContentMetadata.myTeam[i].spell2Id;
                team.SummonerId = jsonContentMetadata.myTeam[i].summonerId;
                team.SummonerName = jsonContentMetadata.myTeam[i].summonerName;
                team.TeamNum = jsonContentMetadata.myTeam[i].team;
                session.MyTeam.Insert(i, team);
            }

            for (int i = 0; i < jsonContentMetadata.theirTeam.Count; i++)
            {
                Team team = new();
                team.CellId = jsonContentMetadata.theirTeam[i].cellId;
                team.ChampionId = jsonContentMetadata.theirTeam[i].championId;
                team.Spell1Id = jsonContentMetadata.theirTeam[i].spell1Id;
                team.Spell2Id = jsonContentMetadata.theirTeam[i].spell2Id;
                team.SummonerId = jsonContentMetadata.theirTeam[i].summonerId;
                team.SummonerName = jsonContentMetadata.theirTeam[i].summonerName;
                team.TeamNum = jsonContentMetadata.theirTeam[i].team;
                session.TheirTeam.Insert(i, team);
            }

            Timer time = new();
            time.AdjustedTimeLeftInPhase = jsonContentMetadata.timer.adjustedTimeLeftInPhase;
            time.InternalNowInEpochMs = jsonContentMetadata.timer.internalNowInEpochMs;
            time.Phase = jsonContentMetadata.timer.phase;
            time.TotalTimeInPhase = jsonContentMetadata.timer.totalTimeInPhase;
            session.Timer = time;
            session.Timer.AdjustedTimeLeftInPhaseInSec = ConvertTimer(time);

            return session;
        }

        /// <summary>
        /// Convert time of <see cref="Timer"/> 
        /// </summary>
        /// <param name="timer"></param>
        /// <returns></returns>
        public static long ConvertTimer(Timer timer)
        {
            var startOfPhase = timer.InternalNowInEpochMs;
            var expectedEndOfPhase = startOfPhase + timer.AdjustedTimeLeftInPhase;

            var countDown = expectedEndOfPhase - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var countDownSec = (int)Math.Floor((double)(countDown / 1000));

            if (countDownSec < 0)
                return 0;

            return countDownSec;
        }

        /// <summary>
        /// Session json
        /// </summary>
        public class Session
        {
            public List<List<Actions>> Actions { get; set; }
            public Bans Bans { get; set; }
            public List<Team> MyTeam { get; set; }
            public List<Team> TheirTeam { get; set; }
            public Timer Timer { get; set; }
            public Session()
            {
                Actions = new List<List<Actions>>();
                Bans = new Bans();
                MyTeam = new List<Team>();
                TheirTeam = new List<Team>();
                Timer = new Timer();
            }
        }

        /// <summary>
        /// Actions json
        /// </summary>
        public class Actions
        {
            public int ActorCellId { get; set; }
            public int ChampionId { get; set; }
            public bool Completed { get; set; }
            public int Id { get; set; }
            public bool IsInProgress { get; set; }
            public int PickTurn { get; set; }
            public string Type { get; set; }
        }

        /// <summary>
        /// Bans json
        /// </summary>
        public class Bans
        {
            public List<int> MyTeamBans { get; set; }
            public List<int> TheirTeamBans { get; set; }
            public Bans()
            {
                MyTeamBans = new List<int>();
                TheirTeamBans = new List<int>();
            }
        }

        /// <summary>
        /// Team json
        /// </summary>
        public class Team
        {
            public int CellId { get; set; }
            public int ChampionId { get; set; }
            public ulong Spell1Id { get; set; }
            public ulong Spell2Id { get; set; }
            public ulong SummonerId { get; set; }
            public string SummonerName { get; set; }
            public int TeamNum { get; set; } //Team number
        }

        /// <summary>
        /// Timer json
        /// </summary>
        public class Timer
        {
            public int AdjustedTimeLeftInPhase { get; set; }
            public long AdjustedTimeLeftInPhaseInSec { get; set; } //Time in sec
            public long InternalNowInEpochMs { get; set; }
            public string Phase { get; set; }
            public int TotalTimeInPhase { get; set; }
        }
    }
}
