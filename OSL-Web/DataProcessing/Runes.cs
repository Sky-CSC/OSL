using Newtonsoft.Json;
using OSL_Common.System.Logging;
using OSL_WebApiRiot.WebApiRiot;

namespace OSL_Web.DataProcessing
{
    public class Runes
    {
        private static Logger _logger = new("Runes");
        public static List<InfoForPerks> summonerPerksList = new();

        public static void GetPerksInformation(string summonerName)
        {
            dynamic jsonSummoner = JsonConvert.DeserializeObject(Summoner_V4.ByName(summonerName));
            string id = jsonSummoner.id;
            dynamic jsonSpectator = JsonConvert.DeserializeObject(Spectator_V4.BySummoner(id));
            CreateSummonerPerksListSpectator(jsonSpectator);
        }

        public static void CreateSummonerPerksListSpectator(dynamic content)
        {
            summonerPerksList = new();
            foreach (var player in content.participants)
            {
                summonerPerksList.Add(new InfoForPerks()
                {
                    TeamId = player.teamId,
                    Lane = Lanes.None,
                    ChampionId = player.championId,
                    SummonerName = player.summonerName,
                    Perks = JsonConvert.DeserializeObject<Perks>(Convert.ToString(player.perks)),
                });
            }
        }

        public static void CreateSummonerPerksList(string content)
        {
            summonerPerksList = new();
            dynamic jsonSessionInfo = JsonConvert.DeserializeObject(content);

            foreach (var player in jsonSessionInfo.gameData.teamOne)
            {
                summonerPerksList.Add(new InfoForPerks()
                {
                    TeamId = 100,
                    Lane = GetLane(Convert.ToString(player.selectedPosition)),
                    ChampionId = player.championId,
                    SummonerName = player.summonerName,
                    Perks = JsonConvert.DeserializeObject<Perks>(Convert.ToString(player.gameCustomization.perks)),
                });
            }
            foreach (var player in jsonSessionInfo.gameData.teamTwo)
            {
                summonerPerksList.Add(new InfoForPerks()
                {
                    TeamId = 200,
                    Lane = GetLane(Convert.ToString(player.selectedPosition)),
                    ChampionId = player.championId,
                    SummonerName = player.summonerName,
                    Perks = JsonConvert.DeserializeObject<Perks>(Convert.ToString(player.gameCustomization.perks)),
                });
            }
        }

        private static Lanes GetLane(string lane)
        {
            try
            {
                if (lane != null)
                {
                    if (lane.Equals("TOP"))
                    {
                        return Lanes.Top;
                    }
                    else if (lane.Equals("BOTTOM"))
                    {
                        return Lanes.ADC;
                    }
                    else if (lane.Equals("MIDDLE"))
                    {
                        return Lanes.Mid;
                    }
                    else if (lane.Equals("UTILITY"))
                    {
                        return Lanes.Support;
                    }
                    else if (lane.Equals("JUNGLE"))
                    {
                        return Lanes.Jungle;
                    }
                }
                return Lanes.None;
            }
            catch (Exception e)
            {
                return Lanes.None;
            }
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
