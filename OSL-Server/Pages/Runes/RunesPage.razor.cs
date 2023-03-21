using Newtonsoft.Json;
using OSL_Server.DataLoader.WebApiRiot;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.FileManager;
using OSL_Server.Pages.ChampSelect;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static OSL_Server.Pages.ChampSelect.ChampSelectPage;

namespace OSL_Server.Pages.Runes
{
    public partial class RunesPage
    {
        private static OSLLogger _logger = new OSLLogger("RunesPage");

        public static string colorPicker = "hidden";
        public static string colorValue = "#0000";

        public static List<InfoForPerks> summonerPerksList = new();

        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
        }

        public static void CreateSummonerPerksListV2(string content)
        {
            try
            {
                summonerPerksList = new();
                dynamic jsonSessionInfo = JsonConvert.DeserializeObject(content);
                //Console.WriteLine(jsonSessionInfo.gameData.teamOne[0].gameCustomization.perks);
                //string temps = jsonSessionInfo.gameData.teamOne[0].gameCustomization.perks;
                //dynamic temps2 = JsonConvert.DeserializeObject<Perks>(temps);
                //Console.WriteLine(temps2.perkIds[0]);

                foreach (var player in jsonSessionInfo.gameData.teamOne)
                {
                    summonerPerksList.Add(new InfoForPerks()
                    {
                        TeamId = 100,
                        Lane = GetLane(Convert.ToString(player.selectedPosition)),
                        ChampionId = player.championId,
                        SummonerName = player.summonerName,
                        //Perks = JsonConvert.DeserializeObject<Perks>(JsonConvert.SerializeObject(player.gameCustomization.perks)),
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
                        //Perks = JsonConvert.DeserializeObject<Perks>(JsonConvert.SerializeObject(player.gameCustomization.perks)),
                        Perks = JsonConvert.DeserializeObject<Perks>(Convert.ToString(player.gameCustomization.perks)),
                    });
                }

                //foreach (var info in summonerPerksList)
                //{
                //    Console.WriteLine(info.Lane);
                //}
                _logger.log(LoggingLevel.INFO, "CreateSummonerPerksListV2()", $"summonerPerksList created and completed");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "CreateSummonerPerksListV2()", $"summonerPerksList Error {e.Message}");
            }
        }

        private static Lanes GetLane(string lane)
        {
            //Console.WriteLine(lane);
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

        public static void CreateSummonerPerksList(string summonerName)
        {
            try
            {
                summonerPerksList = new();
                dynamic jsonSummonerInformation = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Summoner_V4.ByName(summonerName)));
                string summonerId = jsonSummonerInformation.id;
                //string contentInfoPerks = FileManagerLocal.ReadInFile("C:\\Users\\Sky\\Documents\\GitHub\\OSL\\OSL-Client\\DiversData\\perks.json");
                dynamic jsonStectatorInfo = JsonConvert.DeserializeObject(WebApiRiot.RequestWebApiRiot(Spectator_V4.BySummoner(summonerId)));
                //dynamic jsonStectatorInfo = JsonConvert.DeserializeObject(contentInfoPerks);
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

        /// <summary>
        /// structure of overlay view for enable or disable text and change color
        /// </summary>
        private struct OverlayViewDisokayOrHide
        {
            public string text { get; set; }
            public string color { get; set; }

            public OverlayViewDisokayOrHide()
            {
                text = "";
                color = "";
            }

            public OverlayViewDisokayOrHide(string text, string color)
            {
                this.text = text;
                this.color = color;
            }
        }

        private OverlayViewDisokayOrHide overlayButton = new("display", "#008000");

        private string displayContent = "none";
        private void HideOrDisplayContent()
        {
            if (displayContent.Equals("none"))
            {
                overlayButton.text = "hide";
                overlayButton.color = "#be1e37";
                displayContent = "content";
            }
            else
            {
                overlayButton.text = "display";
                overlayButton.color = "#008000";
                displayContent = "none";
            }
        }

        private void ResetColor()
        {
            RunesAdcPage.ResetColor();
            RunesAdcSuppPage.ResetColor();
            RunesJunglePage.ResetColor();
            RunesMidPage.ResetColor();
            RunesTopPage.ResetColor();
            RunesSuppPage.ResetColor();
            RunesAllPage.ResetColor();
        }

        public class Overlay
        {
            public bool BackgroundPicture { get; set; } = true;

            public static void BackgroundPictureSubmit()
            {
            }

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BackgroudGradientDeg { get; set; } = 150;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroudGradientPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroudGradientPercent2 { get; set; } = 100;
            public static void BackgroudGradientSubmit()
            {
                RunesAdcPage.formatingData.BackgroudGradientDeg = overlay.BackgroudGradientDeg.ToString();
                RunesAdcPage.formatingData.BackgroudGradientPercent1 = overlay.BackgroudGradientPercent1.ToString();
                RunesAdcPage.formatingData.BackgroudGradientPercent2 = overlay.BackgroudGradientPercent2.ToString();
                RunesAdcPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesAdcSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesJunglePage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesMidPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesTopPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                RunesAllPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
            }

            public static void SetBackgroudGradientColor1()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.BackgroudGradientColor1;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.BackgroudGradientColor1 = colorValue;
                    RunesAdcPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesAdcSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesJunglePage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesMidPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesTopPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesAllPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                }
            }

            public static void SetBackgroudGradientColor2()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.BackgroudGradientColor2;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.BackgroudGradientColor2 = colorValue;
                    RunesAdcPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesAdcSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesJunglePage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesMidPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesSuppPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesTopPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                    RunesAllPage.formatingData.BackgroudGradient = $"linear-gradient({RunesAdcPage.formatingData.BackgroudGradientDeg}deg, {RunesAdcPage.formatingData.BackgroudGradientColor1} {RunesAdcPage.formatingData.BackgroudGradientPercent1}%, {RunesAdcPage.formatingData.BackgroudGradientColor2} {RunesAdcPage.formatingData.BackgroudGradientPercent2}%)";
                }
            }

            public bool ForegroundBackground { get; set; } = true;

            public static void ForegroundBackgroundSubmit()
            {

            }

            public static void SetBlueSideColorTextSummoner()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.BlueSideColorTextSummoner;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesAdcSuppPage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesJunglePage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesMidPage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesSuppPage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesTopPage.formatingData.BlueSideColorTextSummoner = colorValue;
                    RunesAllPage.formatingData.BlueSideColorTextSummoner = colorValue;
                }
            }

            public static void SetRedSideColorTextSummoner()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.RedSideColorTextSummoner;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesAdcSuppPage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesJunglePage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesMidPage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesSuppPage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesTopPage.formatingData.RedSideColorTextSummoner = colorValue;
                    RunesAllPage.formatingData.RedSideColorTextSummoner = colorValue;
                }
            }

            public static void SetBlueSideColorSeparationBar()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.BlueSideColorSeparationBar;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesAdcSuppPage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesJunglePage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesMidPage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesSuppPage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesTopPage.formatingData.BlueSideColorSeparationBar = colorValue;
                    RunesAllPage.formatingData.BlueSideColorSeparationBar = colorValue;
                }
            }

            public static void SetRedSideColorSeparationBar()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    colorValue = RunesAdcPage.formatingData.RedSideColorSeparationBar;
                }
                else
                {
                    colorPicker = "hidden";
                    RunesAdcPage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesAdcSuppPage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesJunglePage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesMidPage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesSuppPage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesTopPage.formatingData.RedSideColorSeparationBar = colorValue;
                    RunesAllPage.formatingData.RedSideColorSeparationBar = colorValue;
                }
            }


            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideColorBorderChampion { get; set; } = 2;
            public static string BlueSideColorBorderChampionNotSet = RunesAdcPage.formatingData.BlueSideColorBorderChampion.Split(" ")[2];
            public static void BlueSideColorBorderChampionSubmit()
            {
                RunesAdcPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesAdcSuppPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesJunglePage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesMidPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesSuppPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesTopPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
                RunesAllPage.formatingData.BlueSideColorBorderChampion = overlay.BlueSideColorBorderChampion.ToString() + "px solid " + BlueSideColorBorderChampionNotSet;
            }

            public static string TempsBlueSideColorBorderChampion()
            {
                string[] tempsColor = RunesAdcPage.formatingData.BlueSideColorBorderChampion.Split(" ");
                return tempsColor[2];
            }

            public static void SetBlueSideColorBorderChampion()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    string[] tempsBorderColor = RunesAdcPage.formatingData.BlueSideColorBorderChampion.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPicker = "hidden";
                    BlueSideColorBorderChampionNotSet = colorValue;
                }
            }

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideColorBorderChampion { get; set; } = 2;
            public static string RedSideColorBorderChampionNotSet = RunesAdcPage.formatingData.RedSideColorBorderChampion.Split(" ")[2];
            public static void RedSideColorBorderChampionSubmit()
            {
                RunesAdcPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesAdcSuppPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesJunglePage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesMidPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesSuppPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesTopPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
                RunesAllPage.formatingData.RedSideColorBorderChampion = overlay.RedSideColorBorderChampion.ToString() + "px solid " + RedSideColorBorderChampionNotSet;
            }

            public static string TempsRedSideColorBorderChampion()
            {
                string[] tempsColor = RunesAdcPage.formatingData.RedSideColorBorderChampion.Split(" ");
                return tempsColor[2];
            }

            public static void SetRedSideColorBorderChampion()
            {
                if (colorPicker.Equals("hidden"))
                {
                    colorPicker = "visible";
                    string[] tempsBorderColor = RunesAdcPage.formatingData.RedSideColorBorderChampion.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPicker = "hidden";
                    RedSideColorBorderChampionNotSet = colorValue;
                }
            }
        }
    }
}
