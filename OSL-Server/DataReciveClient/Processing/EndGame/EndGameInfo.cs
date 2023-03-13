using Newtonsoft.Json;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.DataLoader.WebApiRiot;
//using OSL_Server.DataReciveClient.Processing.ChampSelect;
using System.Linq;
using System.Reflection.Emit;
using static MudBlazor.CategoryTypes;
using static OSL_Server.DataReciveClient.Processing.EndGame.EndGameInfo;

namespace OSL_Server.DataReciveClient.Processing.EndGame
{
    public class EndGameInfo
    {
        private static OSLLogger _logger = new OSLLogger("EndGameInfo");
        public static InfoEndGame infoEndGame = new();
        public static dynamic jsonContentEndOfMatch = null;
        public static dynamic jsonContentMatch = null;
        public static dynamic jsonContentTimeline = null;
        public static void EndGame(string content)
        {
            infoEndGame = new();
            //Console.WriteLine(content);
            jsonContentEndOfMatch = JsonConvert.DeserializeObject(content);
            Int64 gameId = jsonContentEndOfMatch.gameId;
            string urlMatch = Match_V5.Matches(gameId);
            string dataMatch = WebApiRiot.RequestWebApiRiot(urlMatch);
            jsonContentMatch = JsonConvert.DeserializeObject(dataMatch);
            string urlTimeline = Match_V5.Timeline(gameId);
            string dataTimeline = WebApiRiot.RequestWebApiRiot(urlTimeline);
            jsonContentTimeline = JsonConvert.DeserializeObject(dataTimeline);


            //Console.WriteLine(jsonContent.teams);
            //foreach (var teams in jsonContent.teams)
            //{
            //    foreach (var players in teams.players)
            //    {
            //        Console.WriteLine("championName " + players.championName);
            //        Console.WriteLine("ASSISTS " + players.stats.ASSISTS);
            //        Console.WriteLine("CHAMPIONS_KILLED " + players.stats.CHAMPIONS_KILLED);
            //        Console.WriteLine("NUM_DEATHS " + players.stats.NUM_DEATHS);
            //        Console.WriteLine("GOLD_EARNED " + players.stats.GOLD_EARNED);
            //        Console.WriteLine("LEVEL " + players.stats.LEVEL);
            //        Console.WriteLine("MINIONS_KILLED " + players.stats.MINIONS_KILLED);
            //        Console.WriteLine("TOTAL_DAMAGE_DEALT " + players.stats.TOTAL_DAMAGE_DEALT);
            //        Console.WriteLine("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS " + players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS);
            //        Console.WriteLine("summonerName " + players.summonerName);
            //        Console.WriteLine("teamId " + players.teamId);
            //    }
            //}
            //Console.WriteLine(jsonContent.gameId);
            //foreach (var teams in jsonContentEndOfMatch.teams)
            //{
            //    foreach (var player in teams.players)
            //    {
            //        Stats stats = new();
            //        stats.kill = ;
            //        stats.deaths = ;
            //        stats.assist = ;
            //        stats.gold = ;
            //        stats.level = ;
            //        stats.farm = ;
            //        stats.damageDeal = ;
            //        stats.damageDealToBuildings = ;
            //        stats.damageDealToChampions = ;
            //        stats.damageDealToObjectives = ;
            //        stats.damageDealToTurrets = ;
            //        stats.trueDamageDealToChampion = ;
            //        stats.physicalDamageDealToChampion = ;
            //        stats.magicDamageDealToChampion = ;
            //        stats.damageSelftMitigated = ;
            //        stats.heal = ;
            //        stats.damageTaken = ;
            //        stats.visionScore = ;
            //        infoEndGame.summonerInfos.Add(new SummonerInfo()
            //        {
            //            teamId = jsonContentEndOfMatch.teamId,
            //            championName = jsonContentEndOfMatch.championName,
            //            summonerName = jsonContentEndOfMatch.summonerName,
            //            championSquarePortraitPath = jsonContentEndOfMatch.championSquarePortraitPath,
            //            items = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(jsonContentEndOfMatch.items)),
            //            stats = stats,
            //        });
            //    }
            //}




            //Console.WriteLine(jsonContentTimeline.metadata.matchId);

            //int nbDragonKill = 0;
            //int HEXTECH_DRAGON = 0;
            //int WATER_DRAGON = 0;
            //int FIRE_DRAGON = 0;
            //int CLOUD_DRAGON = 0;
            //int CHEMTECH_DRAGON = 0;
            //int MONTAIN_DRAGON = 0;

            //int ELDER_DRAGON = 0;
            //int RIFTHERALD = 0;
            //int BARON_NASHOR = 0;
            //Console.WriteLine(jsonContentTimeline.info.frames[8].events[2].monsterSubType);
            //Console.WriteLine(jsonContentTimeline.info.frames[8].events[2].monsterType);
            //Console.WriteLine(jsonContentTimeline.info.frames[8].events[0]);
            //Console.WriteLine(jsonContentTimeline.info.frames[13].events[3]);
            //foreach (var frames in jsonContentTimeline.info.frames)
            //{
            //    foreach (var events in frames.events)
            //    {
            //        //Console.WriteLine(events);
            //        try
            //        {
            //            string monsterSubType = events.monsterSubType;
            //            string monsterType = events.monsterType;
            //            //string monsterType = events.monsterType;
            //            if (monsterSubType != null && monsterSubType.Equals("HEXTECH_DRAGON"))
            //            {
            //                HEXTECH_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("WATER_DRAGON"))
            //            {
            //                WATER_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("FIRE_DRAGON"))
            //            {
            //                FIRE_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("CLOUD_DRAGON"))
            //            {
            //                CLOUD_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("CHEMTECH_DRAGON"))
            //            {
            //                CHEMTECH_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("MONTAIN_DRAGON"))
            //            {
            //                MONTAIN_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterSubType != null && monsterSubType.Equals("ELDER_DRAGON"))
            //            {
            //                ELDER_DRAGON++;
            //                Console.WriteLine(monsterSubType);
            //            }
            //            if (monsterType != null && monsterType.Equals("RIFTHERALD"))
            //            {
            //                RIFTHERALD++;
            //                Console.WriteLine(monsterType);
            //            }
            //            if (monsterType != null && monsterType.Equals("BARON_NASHOR"))
            //            {
            //                BARON_NASHOR++;
            //                Console.WriteLine(monsterType);
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            //_logger.log(LoggingLevel.ERROR, "EndGame()", $"{e.Message}");
            //        }
            //    }
            //}
            //Console.WriteLine("HEXTECH_DRAGON : " + HEXTECH_DRAGON);
            //Console.WriteLine("WATER_DRAGON : " + WATER_DRAGON);
            //Console.WriteLine("FIRE_DRAGON : " + FIRE_DRAGON);
            //Console.WriteLine("CLOUD_DRAGON : " + CLOUD_DRAGON);
            //Console.WriteLine("CHEMTECH_DRAGON : " + CHEMTECH_DRAGON);
            //Console.WriteLine("MONTAIN_DRAGON : " + MONTAIN_DRAGON);
            //Console.WriteLine("ELDER_DRAGON : " + ELDER_DRAGON);
            //Console.WriteLine("RIFTHERALD : " + RIFTHERALD);
            //Console.WriteLine("BARON_NASHOR : " + BARON_NASHOR);

            //Console.WriteLine(jsonContentTimeline.info.frames[0]);
            //Console.WriteLine(JsonConvert.SerializeObject(jsonContentTimeline.info.frames[0]));
            //foreach (var events in jsonContentTimeline.info.frames)
            //{
            //    foreach (var inEvents in events.events)
            //    {
            //        Console.WriteLine("##############Avant##############");
            //        Console.WriteLine(inEvents);
            //        Console.WriteLine("##############Après##############");
            //        try
            //        {
            //            string monsterSubType = inEvents.monsterType;
            //            if (monsterSubType.Equals("DRAGON"))
            //            {
            //                nbDragonKill++;
            //            }
            //            Console.WriteLine(events.monsterSubType);
            //        }
            //        catch (Exception e)
            //        {
            //            //_logger.log(LoggingLevel.ERROR, "EndGame()", $"{e.Message}");
            //        }
            //    }
            //}
            //Console.WriteLine(nbDragonKill);
        }

        public class InfoEndGame
        {
            public List<SummonerInfo> summonerInfos { get; set; }
            public List<Events> events { get; set; }
            public List<Bans> bans { get; set; }
            public string gameLength { get; set; }
        }

        public class SummonerInfo
        {
            public int teamId { get; set; }
            public string championName { get; set; }
            public string summonerName { get; set; }
            public string championSquarePortraitPath { get; set; } //For id champ
            public List<int> items { get; set; }
            public Stats stats { get; set; }
        }

        public class Stats
        {
            public int kill { get; set; }
            public int deaths { get; set; }
            public int assist { get; set; }
            public int gold { get; set; }
            public int level { get; set; }
            public int farm { get; set; }
            public int damageDeal { get; set; }
            public int damageDealToBuildings { get; set; }
            public int damageDealToChampions { get; set; }
            public int damageDealToObjectives { get; set; }
            public int damageDealToTurrets { get; set; }
            public int trueDamageDealToChampion { get; set; }
            public int physicalDamageDealToChampion { get; set; }
            public int magicDamageDealToChampion { get; set; }
            public int damageSelftMitigated { get; set; }
            public int heal { get; set; }
            public int damageTaken { get; set; }
            public int visionScore { get; set; }
        }

        public class Events
        {
            public int killerTeamId { get; set; }
            public string monsterSubType { get; set; }
            public string monsterType { get; set; }

        }

        public class Bans
        {
            public int championId { get; set; }
            public int pickTurn { get; set; }
        }
    }
}
