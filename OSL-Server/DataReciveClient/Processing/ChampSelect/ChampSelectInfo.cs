using Newtonsoft.Json;
using OSL_Server.FileManager;
using OSL_Server.Pages;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNet.SignalR.Client.Http;
using System.Diagnostics;

namespace OSL_Server.DataReciveClient.Processing.ChampSelect
{
    public class ChampSelectInfo
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectInfo");
        public static Session session;
        public static void InChampSelect(string content)
        {
            session = ChampSelectProcessingDataRecive(content);
            int time = session.Timer.AdjustedTimeLeftInPhase;
            int timer = (int)TimeSpan.FromMilliseconds((double)time).TotalSeconds;
            ChampSelectView1Page.UpdateTimer(timer, 0);
            ChampSelectView2Page.UpdateTimer(timer, 0);
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
    }

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

    public class Actions
    {
        public int ActorCellId { get; set; }
        public int ChampionId { get; set; }
        public bool Completed { get; set; }
        public bool IsInProgress { get; set; }
        public int PickTurn { get; set; }
        public string Type { get; set; }
    }

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

    public class Team
    {
        public int CellId { get; set; }
        public int ChampionId { get; set; }
        public ulong Spell1Id { get; set; }
        public ulong Spell2Id { get; set; }
        public ulong SummonerId { get; set; }
        public string SummonerName { get; set; }
    }

    public class Timer
    {
        public int AdjustedTimeLeftInPhase { get; set; }
        public long AdjustedTimeLeftInPhaseInSec { get; set; } //Time in sec
        public long InternalNowInEpochMs { get; set; }
        public string Phase { get; set; }
        public int TotalTimeInPhase { get; set; }
    }
}
