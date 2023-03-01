using Newtonsoft.Json;
using OSL_Server.DataLoader.WebApiRiot;

namespace OSL_Server.Pages.Runes
{
    public partial class RunesTopPage
    {
        private static OSLLogger _logger = new OSLLogger("RunesView1Page");

        public static string Yolo(string summonerName = "Sky csc")
        {
            dynamic jsonSummonerName = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Summoner_V4.ByName(summonerName)));
            string id = jsonSummonerName.id;
            Console.WriteLine(id);
            string letout = "";
            if (WebApiRiot.RequestWebApiRiot(Spectator_V4.BySummoner(id)) != null)
            {
                dynamic jsonStectator = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Spectator_V4.BySummoner(id)));
                Console.WriteLine(jsonStectator);
                //foreach (var participants in jsonStectator.participants)
                //{
                //    letout += participants.perks;
                //}
                //dynamic jsonPerks = jsonStectator.participants[0].perks;

                return letout;
            }
            return "c'est vide";
        }

        //public static string GetPerks(string id)
        //{
        //    dynamic jsonStectator = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Spectator_V4.BySummoner(id));

        //}
    }
}
