using Newtonsoft.Json;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static OSL_Server.DataLoader.WebApiRiot.UrlRequest;

namespace OSL_Server.DataLoader.WebApiRiot
{
    /// <summary>
    /// Connect and get data from web riot api.
    /// </summary>
    public class WebApiRiot
    {
        private static OSLLogger _logger = new OSLLogger("WebApiRiot");
        private static string apiKey = "RGAPI-a7e5e402-934e-4440-a2f2-b78280a35a49";

        public static void GetResponseWebApiRiot()
        {
            //Console.WriteLine(RequestWebApiRiot(Summoner_V4.ByName("Sky csc")));
            //Console.WriteLine(RequestWebApiRiot(Summoner_V4.ByName("Skynet csc")));
            //Console.WriteLine(RequestWebApiRiot(Summoner_V4.ByName("Master Kyber")));
            //Console.WriteLine(RequestWebApiRiot(Match_V5.ByPuuid("r7ImkhxSkkUkO3MSLaJhHkJ-uNdDGc6mGb7TPDGCh3LBGvT-veaD1OjG1755pR2thiINuPcVB7HjwQ", start: 0, count:2)));
            //Console.WriteLine(RequestWebApiRiot(Match_V5.Matches("EUW1_6281337448")));
            dynamic jsonSummonerName = JsonConvert.DeserializeObject(RequestWebApiRiot(Summoner_V4.ByName("Sky csc")));
            //string puuid = jsonSummonerName.puuid;
            //dynamic jsonMatch = JsonConvert.DeserializeObject(RequestWebApiRiot(Match_V5.ByPuuid(puuid, start: 0, count: 50)));
            //int x = 0;
            //int y = 0;
            //foreach (string gameId in jsonMatch)
            //{
            //    dynamic jsonMatchInfo = JsonConvert.DeserializeObject(RequestWebApiRiot(Match_V5.Matches(gameId)));
            //    foreach (var participants in jsonMatchInfo.info.participants)
            //    {
            //        string participantsPuuid = participants.puuid;
            //        if (participantsPuuid.Equals(puuid))
            //        {
            //            Console.WriteLine(participants.championName);
            //            Console.WriteLine(participants.win);
            //            if (participants.win == true)
            //            {
            //                x++;
            //            }
            //            else
            //            {
            //                y++;
            //            }
            //        }
            //    }
            //}

            //Console.WriteLine("Win : " + x + " Lose : " + y);

            string id = jsonSummonerName.id;
            if (RequestWebApiRiot(Spectator_V4.BySummoner(id)) != null)
            {
                dynamic jsonStectator = JsonConvert.DeserializeObject(RequestWebApiRiot(Spectator_V4.BySummoner(id)));
            }
        }

        public static string RequestWebApiRiot(string urlRequest)
        {
            string httpsWebApiRiot = urlRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsWebApiRiot);
                request.Headers["X-Riot-Token"] = apiKey;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientReplayAPI", "Request to " + httpsWebApiRiot + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientReplayAPI", "Request to " + httpsWebApiRiot + " failed, " + e.Message);
                return null;
            }
        }



    }

    public class UrlRequest
    {
        public static readonly string lolSummonerV4SummonersByname = "/lol/summoner/v4/summoners/by-name/";
    }
}
