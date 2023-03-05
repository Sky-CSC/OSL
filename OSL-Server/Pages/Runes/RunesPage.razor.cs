using Newtonsoft.Json;
using OSL_Server.DataLoader.WebApiRiot;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.FileManager;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OSL_Server.Pages.Runes
{
    public partial class RunesPage
    {
        private static OSLLogger _logger = new OSLLogger("RunesPage");

        public static List<InfoForPerks> summonerPerksList = new();

        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
        }

        public static void CreateSummonerPerksList(string summonerName)
        {
            try
            {
                summonerPerksList = new();
                //dynamic jsonSummonerInformation = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Summoner_V4.ByName(summonerName)));
                //string summonerId = jsonSummonerInformation.id;
                string contentInfoPerks = FileManagerLocal.ReadInFile("C:\\Users\\Sky\\Documents\\GitHub\\OSL\\OSL-Client\\DiversData\\perks.json");
                //dynamic jsonStectatorInfo = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Spectator_V4.BySummoner(summonerId)));
                dynamic jsonStectatorInfo = JsonConvert.DeserializeObject(contentInfoPerks);
                //foreach (InfoForPerks participants in jsonStectatorInfo.participants)
                foreach (var participants in jsonStectatorInfo.participants)
                {
                    //Console.WriteLine(participants);
                    //Console.WriteLine(participants.perks);
                    //String testString = JsonConvert.SerializeObject(participants.perks);
                    //Console.WriteLine(testString);
                    //Perks test = JsonConvert.DeserializeObject<Perks>(testString);
                    //Console.WriteLine(test.perkStyle);
                    summonerPerksList.Add(new InfoForPerks()
                    {
                        TeamId = participants.teamId,
                        Lane = Lanes.None,
                        ChampionId = participants.championId,
                        SummonerName = participants.summonerName,
                        Perks = JsonConvert.DeserializeObject<Perks>(JsonConvert.SerializeObject(participants.perks)),
                        //Perks = test,
                        //Perks = new Perks()
                        //{
                        //    PerkIds = participants.perks.perkIds,
                        //    PerkStyle = participants.perks.perkStyle,
                        //    PerkSubStyle = participants.perks.perkSubStyle

                        //},
                    });
                }
                foreach (var info in summonerPerksList)
                {
                    Console.WriteLine(info.SummonerName);
                }
                _logger.log(LoggingLevel.INFO, "CreateSummonerPerksList()", $"summonerPerksList created and completed");

            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "CreateSummonerPerksList()", $"summonerPerksList Error {e.Message}");
            }
        }

        public static void ResetLanes()
        {
            foreach (var info in summonerPerksList)
            {
                info.Lane = Lanes.None;
            }
            laneSelectionSummoner1.lanes = Lanes.None;
            laneSelectionSummoner2.lanes = Lanes.None;
            laneSelectionSummoner3.lanes = Lanes.None;
            laneSelectionSummoner4.lanes = Lanes.None;
            laneSelectionSummoner5.lanes = Lanes.None;
            laneSelectionSummoner6.lanes = Lanes.None;
            laneSelectionSummoner7.lanes = Lanes.None;
            laneSelectionSummoner8.lanes = Lanes.None;
            laneSelectionSummoner9.lanes = Lanes.None;
            laneSelectionSummoner10.lanes = Lanes.None;
        }

        /// <summary>
        /// Return champion picture path
        /// </summary>
        /// <param name="champId"></param>
        /// <returns></returns>
        public static string GetChampionPicturePath(int champId)
        {
            return $"./assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{champId}/default-square.png";
        }

        public class InfoForPerks
        {
            public int TeamId { get; set; }
            public Lanes Lane { get; set; }
            public int ChampionId { get; set; }
            public string SummonerName { get; set; }
            public Perks Perks { get; set; }
        }

        public class Perks
        {
            public List<int> perkIds { get; set; }
            public int perkStyle { get; set; }
            public int perkSubStyle { get; set; }
        }

        public enum Lanes
        {
            None,
            Top,
            Mid,
            Jungle,
            ADC,
            Support
        }

        public class LaneInfo
        {
            public Lanes lanes { get; set; }
        }
    }
}
