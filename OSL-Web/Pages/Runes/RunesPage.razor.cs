using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using OSL_Common.System.Logging;

namespace OSL_Web.Pages.Runes
{
    public partial class RunesPage
    {
        private static Logger _logger = new("RunesPage");

        public static string colorPicker = "hidden";
        public static string colorValue = "#0000";

        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
        }

        public static void ResetLanes()
        {
            foreach (var info in DataProcessing.Runes.summonerPerksList)
            {
                info.Lane = DataProcessing.Runes.Lanes.None;
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
