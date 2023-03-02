using Newtonsoft.Json;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.DataLoader.WebApiRiot;

namespace OSL_Server.Pages.Runes
{
    public partial class RunesTopPage
    {
        private static OSLLogger _logger = new OSLLogger("RunesView1Page");

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }

        }

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

        public static string GetPerksIconPath(int perksId)
        {
            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(obj => obj.Name == formatingData.DefaultPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(obj => obj.Name == formatingData.DefaultRegion);
            int indexPerks = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Perks.FindIndex(obj => obj.Id == perksId);
            return CDragon.dataCDragon.Patch[0].Region[0].RegionContent.Perks[indexPerks].IconPath;
        }

        public static string GetChampionPicturePath(int champId)
        {
            return $"./assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{champId}/default-square.png";
        }
    }
}
