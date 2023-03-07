using Newtonsoft.Json;

namespace OSL_Server.DataReciveClient.Processing.EndGame
{
    public class EndGameInfo
    {
        public static void EndGame(string content)
        {
            //Console.WriteLine(content);
            dynamic jsonContent = JsonConvert.DeserializeObject(content);
            //Console.WriteLine(jsonContent.teams);
            foreach (var teams in jsonContent.teams)
            {
                foreach (var players in teams.players)
                {
                    Console.WriteLine("championName " + players.championName);
                    Console.WriteLine("ASSISTS " + players.stats.ASSISTS);
                    Console.WriteLine("CHAMPIONS_KILLED " + players.stats.CHAMPIONS_KILLED);
                    Console.WriteLine("NUM_DEATHS " + players.stats.NUM_DEATHS);
                    Console.WriteLine("GOLD_EARNED " + players.stats.GOLD_EARNED);
                    Console.WriteLine("LEVEL " + players.stats.LEVEL);
                    Console.WriteLine("MINIONS_KILLED " + players.stats.MINIONS_KILLED);
                    Console.WriteLine("TOTAL_DAMAGE_DEALT " + players.stats.TOTAL_DAMAGE_DEALT);
                    Console.WriteLine("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS " + players.stats.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS);
                    Console.WriteLine("summonerName " + players.summonerName);
                    Console.WriteLine("teamId " + players.teamId);
                }
            }
        }
    }
}
