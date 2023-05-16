using OSL_Common.System.Logging;
using System.ComponentModel.DataAnnotations;

namespace OSL_Web.Pages.EndGame
{
    public partial class EndGamePage
    {
        private static Logger _logger = new("EndGamePage");

        public static string colorPickerOverlay1 = "hidden";
        public static string colorPickerOverlay1TimerBar = "hidden";
        public static string colorPickerOverlay1ChampInfo = "hidden";
        public static string colorPickerOverlay1Bans = "hidden";
        public static string colorPickerOverlay1GlobalStats = "hidden";
        public static string colorPickerOverlay1GoldDiff = "hidden";
        public static string colorValue = "#0000";

        public class TextValueOverlayView1
        {
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarBlueTeamName { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarRedTeamName { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarBlueTeamScore { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarRedTeamScore { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarTimerText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? ChampionInfoText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? GoldDiffText { get; set; }

            public bool BackgroundColor { get; set; } = true;
            public bool TopBarGradiant { get; set; } = true;
            public bool ChampionInfoGradiant { get; set; } = true;
            public bool BansGradiant { get; set; } = true;
            public bool GlobalStatsGradiant { get; set; } = true;
            public bool GoldDiffGradiant { get; set; } = true;


            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent2 { get; set; } = 100;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int TopBarBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int ChampionInfoBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BansBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GlobalStatsBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GoldDiffBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int TopBarBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int ChampionInfoBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BansBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GlobalStatsBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBarColor { get; set; } = 1;

            public static void TopBarBlueTeamNameSubmit()
            {
                EndGameView1Page.formatingData.TopBarBlueTeamName = textValueOverlayView1.TopBarBlueTeamName;
            }
            public static void TopBarRedTeamNameSubmit()
            {
                EndGameView1Page.formatingData.TopBarRedTeamName = textValueOverlayView1.TopBarRedTeamName;
            }
            public static void TopBarBlueTeamScoreSubmit()
            {
                EndGameView1Page.formatingData.TopBarBlueTeamScore = textValueOverlayView1.TopBarBlueTeamScore;
            }
            public static void TopBarRedTeamScoreSubmit()
            {
                EndGameView1Page.formatingData.TopBarRedTeamScore = textValueOverlayView1.TopBarRedTeamScore;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsTopBarBlueTeamName = EndGameView1Page.formatingData.TopBarBlueTeamName;
                string tempsTopBarBlueTeamScore = EndGameView1Page.formatingData.TopBarBlueTeamScore;
                string tempsTopBarRedTeamName = EndGameView1Page.formatingData.TopBarRedTeamName;
                string tempsTopBarRedTeamScore = EndGameView1Page.formatingData.TopBarRedTeamScore;
                string tempsRextValueOverlayView1TopBarBlueTeamName = textValueOverlayView1.TopBarBlueTeamName;
                string tempsRextValueOverlayView1TopBarBlueTeamScore = textValueOverlayView1.TopBarBlueTeamScore;
                string tempsRextValueOverlayView1TopBarRedTeamName = textValueOverlayView1.TopBarRedTeamName;
                string tempsRextValueOverlayView1TopBarRedTeamScore = textValueOverlayView1.TopBarRedTeamScore;
                EndGameView1Page.formatingData.TopBarBlueTeamName = tempsTopBarRedTeamName;
                EndGameView1Page.formatingData.TopBarBlueTeamScore = tempsTopBarRedTeamScore;
                EndGameView1Page.formatingData.TopBarRedTeamName = tempsTopBarBlueTeamName;
                EndGameView1Page.formatingData.TopBarRedTeamScore = tempsTopBarBlueTeamScore;
                textValueOverlayView1.TopBarBlueTeamName = tempsRextValueOverlayView1TopBarRedTeamName;
                textValueOverlayView1.TopBarBlueTeamScore = tempsRextValueOverlayView1TopBarRedTeamScore;
                textValueOverlayView1.TopBarRedTeamName = tempsRextValueOverlayView1TopBarBlueTeamName;
                textValueOverlayView1.TopBarRedTeamScore = tempsRextValueOverlayView1TopBarBlueTeamScore;
            }

            public static void TopBarGradiantSubmit()
            {
            }
            public static void ChampionInfoGradiantSubmit()
            {
            }
            public static void BansGradiantSubmit()
            {
            }
            public static void GlobalStatsGradiantSubmit()
            {
            }
            public static void GoldDiffGradiantSubmit()
            {
            }



            public static void BackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.BackgroundColorDeg = textValueOverlayView1.BackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.BackgroundColorPercent1 = textValueOverlayView1.BackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.BackgroundColorPercent2 = textValueOverlayView1.BackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BackgroundColorDeg}deg, {EndGameView1Page.formatingData.BackgroundColorColor1} {EndGameView1Page.formatingData.BackgroundColorPercent1}%, {EndGameView1Page.formatingData.BackgroundColorColor2} {EndGameView1Page.formatingData.BackgroundColorPercent2}%)";
            }

            public static void SetBackgroundColorColor1()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.BackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.BackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BackgroundColorDeg}deg, {EndGameView1Page.formatingData.BackgroundColorColor1} {EndGameView1Page.formatingData.BackgroundColorPercent1}%, {EndGameView1Page.formatingData.BackgroundColorColor2} {EndGameView1Page.formatingData.BackgroundColorPercent2}%)";
                }
            }
            public static void SetBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.BackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.BackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BackgroundColorDeg}deg, {EndGameView1Page.formatingData.BackgroundColorColor1} {EndGameView1Page.formatingData.BackgroundColorPercent1}%, {EndGameView1Page.formatingData.BackgroundColorColor2} {EndGameView1Page.formatingData.BackgroundColorPercent2}%)";
                }
            }

            public static void BackgroundColorEnableDisableSubmit()
            {

            }











            public static void TopBarBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.TopBarBackgroundColorDeg = textValueOverlayView1.TopBarBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColorPercent1 = textValueOverlayView1.TopBarBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColorPercent2 = textValueOverlayView1.TopBarBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView1Page.formatingData.TopBarBackgroundColorColor1} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView1Page.formatingData.TopBarBackgroundColorColor2} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent2}%)";
            }

            public static void SetTopBarBackgroundColorColor1()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView1Page.formatingData.TopBarBackgroundColorColor1} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView1Page.formatingData.TopBarBackgroundColorColor2} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }
            public static void SetTopBarBackgroundColorColor2()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarBackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView1Page.formatingData.TopBarBackgroundColorColor1} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView1Page.formatingData.TopBarBackgroundColorColor2} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }

            public static void TopBarBorderColorSubmit()
            {
                EndGameView1Page.formatingData.TopBarBorderColor = textValueOverlayView1.TopBarBorderColor.ToString() + "px solid " + TopBarBorderColorNotSet;
            }
            public static string TempsTopBarBorderColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.TopBarBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string TopBarBorderColorNotSet = EndGameView1Page.formatingData.TopBarBorderColor.Split(" ")[2];
            public static void SetTopBarBorderColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.TopBarBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    TopBarBorderColorNotSet = colorValue;
                }
            }

            public static void SetTopBarBlueTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBlueTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarBlueTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBlueTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarBlueTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBlueTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarBlueTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarRedTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarRedTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarRedTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarRedTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarRedTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarRedTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarTimerTextColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarTimerTextColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarTimerTextColor = colorValue;
                }
            }
            public static void SetTopBarTimerColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarTimerColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView1Page.formatingData.TopBarTimerColor = colorValue;
                }
            }












            public static void ChampionInfoBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg = textValueOverlayView1.ChampionInfoBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1 = textValueOverlayView1.ChampionInfoBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2 = textValueOverlayView1.ChampionInfoBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
            }

            public static void SetChampionInfoBackgroundColorColor1()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void SetChampionInfoBackgroundColorColor2()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void ChampionInfoBorderColorSubmit()
            {
                EndGameView1Page.formatingData.ChampionInfoBorderColor = textValueOverlayView1.ChampionInfoBorderColor.ToString() + "px solid " + ChampionInfoBorderColorNotSet;
            }
            public static string TempsChampionInfoBorderColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.ChampionInfoBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string ChampionInfoBorderColorNotSet = EndGameView1Page.formatingData.ChampionInfoBorderColor.Split(" ")[2];
            public static void SetChampionInfoBorderColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.ChampionInfoBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    ChampionInfoBorderColorNotSet = colorValue;
                }
            }
            public static void SetChampionInfoTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoTextColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBlueBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBlueBarColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor = colorValue;
                }
            }
            public static void SetChampionInfoRedBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoRedBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoRedBarColor = colorValue;
                }
            }
            public static void SetChampionInfoRedDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor = colorValue;
                }
            }










            public static void BansBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.BansBackgroundColorDeg = textValueOverlayView1.BansBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.BansBackgroundColorPercent1 = textValueOverlayView1.BansBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.BansBackgroundColorPercent2 = textValueOverlayView1.BansBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView1Page.formatingData.BansBackgroundColorColor1} {EndGameView1Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView1Page.formatingData.BansBackgroundColorColor2} {EndGameView1Page.formatingData.BansBackgroundColorPercent2}%)";
            }

            public static void SetBansBackgroundColorColor1()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView1Page.formatingData.BansBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView1Page.formatingData.BansBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView1Page.formatingData.BansBackgroundColorColor1} {EndGameView1Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView1Page.formatingData.BansBackgroundColorColor2} {EndGameView1Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void SetBansBackgroundColorColor2()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView1Page.formatingData.BansBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView1Page.formatingData.BansBackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView1Page.formatingData.BansBackgroundColorColor1} {EndGameView1Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView1Page.formatingData.BansBackgroundColorColor2} {EndGameView1Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void BansBorderColorSubmit()
            {
                EndGameView1Page.formatingData.BansBorderColor = textValueOverlayView1.BansBorderColor.ToString() + "px solid " + BansBorderColorNotSet;
            }
            public static string TempsBansBorderColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.BansBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string BansBorderColorNotSet = EndGameView1Page.formatingData.BansBorderColor.Split(" ")[2];
            public static void SetBansBorderColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.BansBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    BansBorderColorNotSet = colorValue;
                }
            }

            public static void SetBansTextColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView1Page.formatingData.BansTextColor;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView1Page.formatingData.BansTextColor = colorValue;
                }
            }
















            public static void GlobalStatsBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg = textValueOverlayView1.GlobalStatsBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1 = textValueOverlayView1.GlobalStatsBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2 = textValueOverlayView1.GlobalStatsBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
            }

            public static void SetGlobalStatsBackgroundColorColor1()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void SetGlobalStatsBackgroundColorColor2()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView1Page.formatingData.BansBackgroundColorColor1} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void GlobalStatsBorderColorSubmit()
            {
                EndGameView1Page.formatingData.GlobalStatsBorderColor = textValueOverlayView1.GlobalStatsBorderColor.ToString() + "px solid " + GlobalStatsBorderColorNotSet;
            }
            public static string TempsGlobalStatsBorderColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.GlobalStatsBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GlobalStatsBorderColorNotSet = EndGameView1Page.formatingData.GlobalStatsBorderColor.Split(" ")[2];
            public static void SetGlobalStatsBorderColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.GlobalStatsBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    GlobalStatsBorderColorNotSet = colorValue;
                }
            }
            public static void SetGlobalStatsTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsBlueTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBlueTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsBlueTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsRedTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsRedTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsRedTextColor = colorValue;
                }
            }







            public static void GoldDiffBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg = textValueOverlayView1.GoldDiffBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1 = textValueOverlayView1.GoldDiffBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2 = textValueOverlayView1.GoldDiffBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
            }

            public static void SetGoldDiffBackgroundColorColor1()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void SetGoldDiffBackgroundColorColor2()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2 = colorValue;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void GoldDiffBorderColorSubmit()
            {
                EndGameView1Page.formatingData.GoldDiffBorderColor = textValueOverlayView1.GoldDiffBorderColor.ToString() + "px solid " + GoldDiffBorderColorNotSet;
            }
            public static string TempsGoldDiffBorderColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.GoldDiffBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBorderColorNotSet = EndGameView1Page.formatingData.GoldDiffBorderColor.Split(" ")[2];
            public static void SetGoldDiffBorderColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.GoldDiffBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBorderColorNotSet = colorValue;
                }
            } 
            public static void GoldDiffBarColorSubmit()
            {
                EndGameView1Page.formatingData.GoldDiffBarColor = textValueOverlayView1.GoldDiffBarColor.ToString() + "px dashed " + GoldDiffBarColorNotSet;
            }
            public static string TempsGoldDiffBarColor()
            {
                string[] tempsColor = EndGameView1Page.formatingData.GoldDiffBarColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBarColorNotSet = EndGameView1Page.formatingData.GoldDiffBarColor.Split(" ")[2];
            public static void SetGoldDiffBarColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.GoldDiffBarColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBarColorNotSet = colorValue;
                }
            }
            public static void SetGoldDiffTextColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffTextColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffTextColor = colorValue;
                }
            }
            public static void SetGoldDiffBlueTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBlueTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffBlueTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffRedTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffRedTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffZeroTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffZeroTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffBluePointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBluePointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffBluePointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffRedPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffRedPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffZeroPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffZeroPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffStartEndPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffStartEndPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffStartEndPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffLinkPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffLinkPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView1Page.formatingData.GoldDiffLinkPointGoldColor = colorValue;
                }
            }
        }

        //view 2
        public class TextValueOverlayView2
        {
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarBlueTeamName { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarRedTeamName { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarBlueTeamScore { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarRedTeamScore { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarTimerText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? ChampionInfoText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? GoldDiffText { get; set; }

            public bool BackgroundColor { get; set; } = true;
            public bool TopBarGradiant { get; set; } = true;
            public bool ChampionInfoGradiant { get; set; } = true;
            public bool BansGradiant { get; set; } = true;
            public bool GlobalStatsGradiant { get; set; } = true;
            public bool GoldDiffGradiant { get; set; } = true;


            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent2 { get; set; } = 100;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int TopBarBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int ChampionInfoBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BansBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GlobalStatsBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GoldDiffBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int TopBarBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int ChampionInfoBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BansBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GlobalStatsBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBarColor { get; set; } = 1;

            public static void TopBarBlueTeamNameSubmit()
            {
                EndGameView2Page.formatingData.TopBarBlueTeamName = textValueOverlayView2.TopBarBlueTeamName;
            }
            public static void TopBarRedTeamNameSubmit()
            {
                EndGameView2Page.formatingData.TopBarRedTeamName = textValueOverlayView2.TopBarRedTeamName;
            }
            public static void TopBarBlueTeamScoreSubmit()
            {
                EndGameView2Page.formatingData.TopBarBlueTeamScore = textValueOverlayView2.TopBarBlueTeamScore;
            }
            public static void TopBarRedTeamScoreSubmit()
            {
                EndGameView2Page.formatingData.TopBarRedTeamScore = textValueOverlayView2.TopBarRedTeamScore;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsTopBarBlueTeamName = EndGameView2Page.formatingData.TopBarBlueTeamName;
                string tempsTopBarBlueTeamScore = EndGameView2Page.formatingData.TopBarBlueTeamScore;
                string tempsTopBarRedTeamName = EndGameView2Page.formatingData.TopBarRedTeamName;
                string tempsTopBarRedTeamScore = EndGameView2Page.formatingData.TopBarRedTeamScore;
                string tempsRextValueOverlayView2TopBarBlueTeamName = textValueOverlayView2.TopBarBlueTeamName;
                string tempsRextValueOverlayView2TopBarBlueTeamScore = textValueOverlayView2.TopBarBlueTeamScore;
                string tempsRextValueOverlayView2TopBarRedTeamName = textValueOverlayView2.TopBarRedTeamName;
                string tempsRextValueOverlayView2TopBarRedTeamScore = textValueOverlayView2.TopBarRedTeamScore;
                EndGameView2Page.formatingData.TopBarBlueTeamName = tempsTopBarRedTeamName;
                EndGameView2Page.formatingData.TopBarBlueTeamScore = tempsTopBarRedTeamScore;
                EndGameView2Page.formatingData.TopBarRedTeamName = tempsTopBarBlueTeamName;
                EndGameView2Page.formatingData.TopBarRedTeamScore = tempsTopBarBlueTeamScore;
                textValueOverlayView2.TopBarBlueTeamName = tempsRextValueOverlayView2TopBarRedTeamName;
                textValueOverlayView2.TopBarBlueTeamScore = tempsRextValueOverlayView2TopBarRedTeamScore;
                textValueOverlayView2.TopBarRedTeamName = tempsRextValueOverlayView2TopBarBlueTeamName;
                textValueOverlayView2.TopBarRedTeamScore = tempsRextValueOverlayView2TopBarBlueTeamScore;
            }

            public static void TopBarGradiantSubmit()
            {
            }
            public static void ChampionInfoGradiantSubmit()
            {
            }
            public static void BansGradiantSubmit()
            {
            }
            public static void GlobalStatsGradiantSubmit()
            {
            }
            public static void GoldDiffGradiantSubmit()
            {
            }



            public static void BackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.BackgroundColorDeg = textValueOverlayView2.BackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.BackgroundColorPercent1 = textValueOverlayView2.BackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.BackgroundColorPercent2 = textValueOverlayView2.BackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BackgroundColorDeg}deg, {EndGameView2Page.formatingData.BackgroundColorColor1} {EndGameView2Page.formatingData.BackgroundColorPercent1}%, {EndGameView2Page.formatingData.BackgroundColorColor2} {EndGameView2Page.formatingData.BackgroundColorPercent2}%)";
            }

            public static void SetBackgroundColorColor1()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView2Page.formatingData.BackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView2Page.formatingData.BackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BackgroundColorDeg}deg, {EndGameView2Page.formatingData.BackgroundColorColor1} {EndGameView2Page.formatingData.BackgroundColorPercent1}%, {EndGameView2Page.formatingData.BackgroundColorColor2} {EndGameView2Page.formatingData.BackgroundColorPercent2}%)";
                }
            }
            public static void SetBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView2Page.formatingData.BackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView2Page.formatingData.BackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BackgroundColorDeg}deg, {EndGameView2Page.formatingData.BackgroundColorColor1} {EndGameView2Page.formatingData.BackgroundColorPercent1}%, {EndGameView2Page.formatingData.BackgroundColorColor2} {EndGameView2Page.formatingData.BackgroundColorPercent2}%)";
                }
            }

            public static void BackgroundColorEnableDisableSubmit()
            {

            }











            public static void TopBarBackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.TopBarBackgroundColorDeg = textValueOverlayView2.TopBarBackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.TopBarBackgroundColorPercent1 = textValueOverlayView2.TopBarBackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.TopBarBackgroundColorPercent2 = textValueOverlayView2.TopBarBackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView2Page.formatingData.TopBarBackgroundColorColor1} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView2Page.formatingData.TopBarBackgroundColorColor2} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent2}%)";
            }

            public static void SetTopBarBackgroundColorColor1()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarBackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView2Page.formatingData.TopBarBackgroundColorColor1} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView2Page.formatingData.TopBarBackgroundColorColor2} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }
            public static void SetTopBarBackgroundColorColor2()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarBackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView2Page.formatingData.TopBarBackgroundColorColor1} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView2Page.formatingData.TopBarBackgroundColorColor2} {EndGameView2Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }

            public static void TopBarBorderColorSubmit()
            {
                EndGameView2Page.formatingData.TopBarBorderColor = textValueOverlayView2.TopBarBorderColor.ToString() + "px solid " + TopBarBorderColorNotSet;
            }
            public static string TempsTopBarBorderColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.TopBarBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string TopBarBorderColorNotSet = EndGameView2Page.formatingData.TopBarBorderColor.Split(" ")[2];
            public static void SetTopBarBorderColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.TopBarBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    TopBarBorderColorNotSet = colorValue;
                }
            }

            public static void SetTopBarBlueTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarBlueTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarBlueTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarBlueTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarBlueTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarBlueTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarBlueTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarRedTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarRedTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarRedTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarRedTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarRedTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarRedTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarTimerTextColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarTimerTextColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarTimerTextColor = colorValue;
                }
            }
            public static void SetTopBarTimerColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView2Page.formatingData.TopBarTimerColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView2Page.formatingData.TopBarTimerColor = colorValue;
                }
            }












            public static void ChampionInfoBackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg = textValueOverlayView2.ChampionInfoBackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1 = textValueOverlayView2.ChampionInfoBackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2 = textValueOverlayView2.ChampionInfoBackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
            }

            public static void SetChampionInfoBackgroundColorColor1()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void SetChampionInfoBackgroundColorColor2()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView2Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView2Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void ChampionInfoBorderColorSubmit()
            {
                EndGameView2Page.formatingData.ChampionInfoBorderColor = textValueOverlayView2.ChampionInfoBorderColor.ToString() + "px solid " + ChampionInfoBorderColorNotSet;
            }
            public static string TempsChampionInfoBorderColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.ChampionInfoBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string ChampionInfoBorderColorNotSet = EndGameView2Page.formatingData.ChampionInfoBorderColor.Split(" ")[2];
            public static void SetChampionInfoBorderColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.ChampionInfoBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    ChampionInfoBorderColorNotSet = colorValue;
                }
            }
            public static void SetChampionInfoTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoTextColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoBlueBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoBlueBarColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoBlueDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoBlueDegaTextColor = colorValue;
                }
            }
            public static void SetChampionInfoRedBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoRedBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoRedBarColor = colorValue;
                }
            }
            public static void SetChampionInfoRedDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView2Page.formatingData.ChampionInfoRedDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView2Page.formatingData.ChampionInfoRedDegaTextColor = colorValue;
                }
            }










            public static void BansBackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.BansBackgroundColorDeg = textValueOverlayView2.BansBackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.BansBackgroundColorPercent1 = textValueOverlayView2.BansBackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.BansBackgroundColorPercent2 = textValueOverlayView2.BansBackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView2Page.formatingData.BansBackgroundColorColor1} {EndGameView2Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView2Page.formatingData.BansBackgroundColorColor2} {EndGameView2Page.formatingData.BansBackgroundColorPercent2}%)";
            }

            public static void SetBansBackgroundColorColor1()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView2Page.formatingData.BansBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView2Page.formatingData.BansBackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView2Page.formatingData.BansBackgroundColorColor1} {EndGameView2Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView2Page.formatingData.BansBackgroundColorColor2} {EndGameView2Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void SetBansBackgroundColorColor2()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView2Page.formatingData.BansBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView2Page.formatingData.BansBackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView2Page.formatingData.BansBackgroundColorColor1} {EndGameView2Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView2Page.formatingData.BansBackgroundColorColor2} {EndGameView2Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void BansBorderColorSubmit()
            {
                EndGameView2Page.formatingData.BansBorderColor = textValueOverlayView2.BansBorderColor.ToString() + "px solid " + BansBorderColorNotSet;
            }
            public static string TempsBansBorderColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.BansBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string BansBorderColorNotSet = EndGameView2Page.formatingData.BansBorderColor.Split(" ")[2];
            public static void SetBansBorderColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.BansBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    BansBorderColorNotSet = colorValue;
                }
            }

            public static void SetBansTextColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView2Page.formatingData.BansTextColor;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView2Page.formatingData.BansTextColor = colorValue;
                }
            }
















            public static void GlobalStatsBackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg = textValueOverlayView2.GlobalStatsBackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1 = textValueOverlayView2.GlobalStatsBackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2 = textValueOverlayView2.GlobalStatsBackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
            }

            public static void SetGlobalStatsBackgroundColorColor1()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void SetGlobalStatsBackgroundColorColor2()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView2Page.formatingData.BansBackgroundColorColor1} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView2Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void GlobalStatsBorderColorSubmit()
            {
                EndGameView2Page.formatingData.GlobalStatsBorderColor = textValueOverlayView2.GlobalStatsBorderColor.ToString() + "px solid " + GlobalStatsBorderColorNotSet;
            }
            public static string TempsGlobalStatsBorderColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.GlobalStatsBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GlobalStatsBorderColorNotSet = EndGameView2Page.formatingData.GlobalStatsBorderColor.Split(" ")[2];
            public static void SetGlobalStatsBorderColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.GlobalStatsBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    GlobalStatsBorderColorNotSet = colorValue;
                }
            }
            public static void SetGlobalStatsTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView2Page.formatingData.GlobalStatsTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView2Page.formatingData.GlobalStatsTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsBlueTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView2Page.formatingData.GlobalStatsBlueTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView2Page.formatingData.GlobalStatsBlueTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsRedTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView2Page.formatingData.GlobalStatsRedTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView2Page.formatingData.GlobalStatsRedTextColor = colorValue;
                }
            }







            public static void GoldDiffBackgroundColorSubmit()
            {
                EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg = textValueOverlayView2.GoldDiffBackgroundColorDeg.ToString();
                EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1 = textValueOverlayView2.GoldDiffBackgroundColorPercent1.ToString();
                EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2 = textValueOverlayView2.GoldDiffBackgroundColorPercent2.ToString();
                EndGameView2Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
            }

            public static void SetGoldDiffBackgroundColorColor1()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1 = colorValue;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void SetGoldDiffBackgroundColorColor2()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2 = colorValue;
                    EndGameView2Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView2Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView2Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView2Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void GoldDiffBorderColorSubmit()
            {
                EndGameView2Page.formatingData.GoldDiffBorderColor = textValueOverlayView2.GoldDiffBorderColor.ToString() + "px solid " + GoldDiffBorderColorNotSet;
            }
            public static string TempsGoldDiffBorderColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.GoldDiffBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBorderColorNotSet = EndGameView2Page.formatingData.GoldDiffBorderColor.Split(" ")[2];
            public static void SetGoldDiffBorderColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.GoldDiffBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBorderColorNotSet = colorValue;
                }
            }
            public static void GoldDiffBarColorSubmit()
            {
                EndGameView2Page.formatingData.GoldDiffBarColor = textValueOverlayView2.GoldDiffBarColor.ToString() + "px dashed " + GoldDiffBarColorNotSet;
            }
            public static string TempsGoldDiffBarColor()
            {
                string[] tempsColor = EndGameView2Page.formatingData.GoldDiffBarColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBarColorNotSet = EndGameView2Page.formatingData.GoldDiffBarColor.Split(" ")[2];
            public static void SetGoldDiffBarColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView2Page.formatingData.GoldDiffBarColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBarColorNotSet = colorValue;
                }
            }
            public static void SetGoldDiffTextColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffTextColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffTextColor = colorValue;
                }
            }

            public static void SetGoldDiffBlueTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffBlueTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffBlueTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffRedTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffRedTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffZeroTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffZeroTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffBluePointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffBluePointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffBluePointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffRedPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffRedPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffZeroPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffZeroPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffStartEndPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffStartEndPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffStartEndPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffLinkPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView2Page.formatingData.GoldDiffLinkPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView2Page.formatingData.GoldDiffLinkPointGoldColor = colorValue;
                }
            }
        }

        //view 3
        public class TextValueOverlayView3
        {
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarBlueTeamName { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarRedTeamName { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarBlueTeamScore { get; set; }
            [StringLength(5, ErrorMessage = "Name is too long (5 character limit).")]
            public string? TopBarRedTeamScore { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarTimerText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? ChampionInfoText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? GoldDiffText { get; set; }

            public bool BackgroundColor { get; set; } = true;
            public bool TopBarGradiant { get; set; } = false;
            public bool ChampionInfoGradiant { get; set; } = false;
            public bool BansGradiant { get; set; } = false;
            public bool GlobalStatsGradiant { get; set; } = false;
            public bool GoldDiffGradiant { get; set; } = false;
            public bool TopBarBackground { get; set; } = false;
            public bool ChampionInfoBackground { get; set; } = false;
            public bool BansBackground { get; set; } = false;
            public bool GlobalStatsBackground { get; set; } = false;
            public bool GoldDiffBackground { get; set; } = false;


            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroundColorPercent2 { get; set; } = 100;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int TopBarBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int TopBarBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int ChampionInfoBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int ChampionInfoBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BansBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BansBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GlobalStatsBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GlobalStatsBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int GoldDiffBackgroundColorDeg { get; set; } = 90;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int GoldDiffBackgroundColorPercent2 { get; set; } = 100;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int TopBarBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int ChampionInfoBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BansBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GlobalStatsBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GlobalStatsSeparationColor { get; set; } = 2;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int GoldDiffBarColor { get; set; } = 1;


            public static void TopBarBlueTeamNameSubmit()
            {
                EndGameView3Page.formatingData.TopBarBlueTeamName = textValueOverlayView3.TopBarBlueTeamName;
            }
            public static void TopBarRedTeamNameSubmit()
            {
                EndGameView3Page.formatingData.TopBarRedTeamName = textValueOverlayView3.TopBarRedTeamName;
            }
            public static void TopBarBlueTeamScoreSubmit()
            {
                EndGameView3Page.formatingData.TopBarBlueTeamScore = textValueOverlayView3.TopBarBlueTeamScore;
            }
            public static void TopBarRedTeamScoreSubmit()
            {
                EndGameView3Page.formatingData.TopBarRedTeamScore = textValueOverlayView3.TopBarRedTeamScore;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsTopBarBlueTeamName = EndGameView3Page.formatingData.TopBarBlueTeamName;
                string tempsTopBarBlueTeamScore = EndGameView3Page.formatingData.TopBarBlueTeamScore;
                string tempsTopBarRedTeamName = EndGameView3Page.formatingData.TopBarRedTeamName;
                string tempsTopBarRedTeamScore = EndGameView3Page.formatingData.TopBarRedTeamScore;
                string tempsRextValueOverlayView3TopBarBlueTeamName = textValueOverlayView3.TopBarBlueTeamName;
                string tempsRextValueOverlayView3TopBarBlueTeamScore = textValueOverlayView3.TopBarBlueTeamScore;
                string tempsRextValueOverlayView3TopBarRedTeamName = textValueOverlayView3.TopBarRedTeamName;
                string tempsRextValueOverlayView3TopBarRedTeamScore = textValueOverlayView3.TopBarRedTeamScore;
                EndGameView3Page.formatingData.TopBarBlueTeamName = tempsTopBarRedTeamName;
                EndGameView3Page.formatingData.TopBarBlueTeamScore = tempsTopBarRedTeamScore;
                EndGameView3Page.formatingData.TopBarRedTeamName = tempsTopBarBlueTeamName;
                EndGameView3Page.formatingData.TopBarRedTeamScore = tempsTopBarBlueTeamScore;
                textValueOverlayView3.TopBarBlueTeamName = tempsRextValueOverlayView3TopBarRedTeamName;
                textValueOverlayView3.TopBarBlueTeamScore = tempsRextValueOverlayView3TopBarRedTeamScore;
                textValueOverlayView3.TopBarRedTeamName = tempsRextValueOverlayView3TopBarBlueTeamName;
                textValueOverlayView3.TopBarRedTeamScore = tempsRextValueOverlayView3TopBarBlueTeamScore;
            }

            public static void TopBarBackgroundSubmit()
            {
            }
            public static void ChampionInfoBackgroundSubmit()
            {
            }
            public static void BansBackgroundSubmit()
            {
            }
            public static void GlobalStatsBackgroundSubmit()
            {
            }
            public static void GoldDiffBackgroundSubmit()
            {
            }
            public static void TopBarGradiantSubmit()
            {
            }
            public static void ChampionInfoGradiantSubmit()
            {
            }
            public static void BansGradiantSubmit()
            {
            }
            public static void GlobalStatsGradiantSubmit()
            {
            }
            public static void GoldDiffGradiantSubmit()
            {
            }



            public static void BackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.BackgroundColorDeg = textValueOverlayView3.BackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.BackgroundColorPercent1 = textValueOverlayView3.BackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.BackgroundColorPercent2 = textValueOverlayView3.BackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BackgroundColorDeg}deg, {EndGameView3Page.formatingData.BackgroundColorColor1} {EndGameView3Page.formatingData.BackgroundColorPercent1}%, {EndGameView3Page.formatingData.BackgroundColorColor2} {EndGameView3Page.formatingData.BackgroundColorPercent2}%)";
            }

            public static void SetBackgroundColorColor1()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView3Page.formatingData.BackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView3Page.formatingData.BackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BackgroundColorDeg}deg, {EndGameView3Page.formatingData.BackgroundColorColor1} {EndGameView3Page.formatingData.BackgroundColorPercent1}%, {EndGameView3Page.formatingData.BackgroundColorColor2} {EndGameView3Page.formatingData.BackgroundColorPercent2}%)";
                }
            }
            public static void SetBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView3Page.formatingData.BackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView3Page.formatingData.BackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.BackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BackgroundColorDeg}deg, {EndGameView3Page.formatingData.BackgroundColorColor1} {EndGameView3Page.formatingData.BackgroundColorPercent1}%, {EndGameView3Page.formatingData.BackgroundColorColor2} {EndGameView3Page.formatingData.BackgroundColorPercent2}%)";
                }
            }

            public static void BackgroundColorEnableDisableSubmit()
            {

            }











            public static void TopBarBackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.TopBarBackgroundColorDeg = textValueOverlayView3.TopBarBackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.TopBarBackgroundColorPercent1 = textValueOverlayView3.TopBarBackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.TopBarBackgroundColorPercent2 = textValueOverlayView3.TopBarBackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView3Page.formatingData.TopBarBackgroundColorColor1} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView3Page.formatingData.TopBarBackgroundColorColor2} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent2}%)";
            }

            public static void SetTopBarBackgroundColorColor1()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarBackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView3Page.formatingData.TopBarBackgroundColorColor1} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView3Page.formatingData.TopBarBackgroundColorColor2} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }
            public static void SetTopBarBackgroundColorColor2()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarBackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView3Page.formatingData.TopBarBackgroundColorColor1} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView3Page.formatingData.TopBarBackgroundColorColor2} {EndGameView3Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }

            public static void TopBarBorderColorSubmit()
            {
                EndGameView3Page.formatingData.TopBarBorderColor = textValueOverlayView3.TopBarBorderColor.ToString() + "px solid " + TopBarBorderColorNotSet;
            }
            public static string TempsTopBarBorderColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.TopBarBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string TopBarBorderColorNotSet = EndGameView3Page.formatingData.TopBarBorderColor.Split(" ")[2];
            public static void SetTopBarBorderColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.TopBarBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    TopBarBorderColorNotSet = colorValue;
                }
            }

            public static void SetTopBarBlueTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarBlueTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarBlueTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarBlueTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarBlueTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarBlueTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarBlueTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarBlueTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamNameColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarRedTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarRedTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamWinLossColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarRedTeamWinLossColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarRedTeamWinLossColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamScoreColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarRedTeamScoreColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarRedTeamScoreColor = colorValue;
                }
            }
            public static void SetTopBarTimerTextColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarTimerTextColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarTimerTextColor = colorValue;
                }
            }
            public static void SetTopBarTimerColor()
            {
                if (colorPickerOverlay1TimerBar.Equals("hidden"))
                {
                    colorPickerOverlay1TimerBar = "visible";
                    colorValue = EndGameView3Page.formatingData.TopBarTimerColor;
                }
                else
                {
                    colorPickerOverlay1TimerBar = "hidden";
                    EndGameView3Page.formatingData.TopBarTimerColor = colorValue;
                }
            }












            public static void ChampionInfoBackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg = textValueOverlayView3.ChampionInfoBackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1 = textValueOverlayView3.ChampionInfoBackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2 = textValueOverlayView3.ChampionInfoBackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
            }

            public static void SetChampionInfoBackgroundColorColor1()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void SetChampionInfoBackgroundColorColor2()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView3Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView3Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void ChampionInfoBorderColorSubmit()
            {
                EndGameView3Page.formatingData.ChampionInfoBorderColor = textValueOverlayView3.ChampionInfoBorderColor.ToString() + "px solid " + ChampionInfoBorderColorNotSet;
            }
            public static string TempsChampionInfoBorderColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.ChampionInfoBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string ChampionInfoBorderColorNotSet = EndGameView3Page.formatingData.ChampionInfoBorderColor.Split(" ")[2];
            public static void SetChampionInfoBorderColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.ChampionInfoBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    ChampionInfoBorderColorNotSet = colorValue;
                }
            }
            public static void SetChampionInfoTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoTextColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoBlueBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoBlueBarColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoBlueDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoBlueDegaTextColor = colorValue;
                }
            }
            public static void SetChampionInfoRedBarColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoRedBarColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoRedBarColor = colorValue;
                }
            }
            public static void SetChampionInfoRedDegaTextColor()
            {
                if (colorPickerOverlay1ChampInfo.Equals("hidden"))
                {
                    colorPickerOverlay1ChampInfo = "visible";
                    colorValue = EndGameView3Page.formatingData.ChampionInfoRedDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1ChampInfo = "hidden";
                    EndGameView3Page.formatingData.ChampionInfoRedDegaTextColor = colorValue;
                }
            }










            public static void BansBackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.BansBackgroundColorDeg = textValueOverlayView3.BansBackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.BansBackgroundColorPercent1 = textValueOverlayView3.BansBackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.BansBackgroundColorPercent2 = textValueOverlayView3.BansBackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView3Page.formatingData.BansBackgroundColorColor1} {EndGameView3Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView3Page.formatingData.BansBackgroundColorColor2} {EndGameView3Page.formatingData.BansBackgroundColorPercent2}%)";
            }

            public static void SetBansBackgroundColorColor1()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView3Page.formatingData.BansBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView3Page.formatingData.BansBackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView3Page.formatingData.BansBackgroundColorColor1} {EndGameView3Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView3Page.formatingData.BansBackgroundColorColor2} {EndGameView3Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void SetBansBackgroundColorColor2()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView3Page.formatingData.BansBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView3Page.formatingData.BansBackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView3Page.formatingData.BansBackgroundColorColor1} {EndGameView3Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView3Page.formatingData.BansBackgroundColorColor2} {EndGameView3Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void BansBorderColorSubmit()
            {
                EndGameView3Page.formatingData.BansBorderColor = textValueOverlayView3.BansBorderColor.ToString() + "px solid " + BansBorderColorNotSet;
            }
            public static string TempsBansBorderColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.BansBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string BansBorderColorNotSet = EndGameView3Page.formatingData.BansBorderColor.Split(" ")[2];
            public static void SetBansBorderColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.BansBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    BansBorderColorNotSet = colorValue;
                }
            }

            public static void SetBansTextColor()
            {
                if (colorPickerOverlay1Bans.Equals("hidden"))
                {
                    colorPickerOverlay1Bans = "visible";
                    colorValue = EndGameView3Page.formatingData.BansTextColor;
                }
                else
                {
                    colorPickerOverlay1Bans = "hidden";
                    EndGameView3Page.formatingData.BansTextColor = colorValue;
                }
            }
















            public static void GlobalStatsBackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg = textValueOverlayView3.GlobalStatsBackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1 = textValueOverlayView3.GlobalStatsBackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2 = textValueOverlayView3.GlobalStatsBackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
            }

            public static void SetGlobalStatsBackgroundColorColor1()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void SetGlobalStatsBackgroundColorColor2()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView3Page.formatingData.BansBackgroundColorColor1} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView3Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void GlobalStatsBorderColorSubmit()
            {
                EndGameView3Page.formatingData.GlobalStatsBorderColor = textValueOverlayView3.GlobalStatsBorderColor.ToString() + "px solid " + GlobalStatsBorderColorNotSet;
            }
            public static string TempsGlobalStatsBorderColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.GlobalStatsBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GlobalStatsBorderColorNotSet = EndGameView3Page.formatingData.GlobalStatsBorderColor.Split(" ")[2];
            public static void SetGlobalStatsBorderColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.GlobalStatsBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    GlobalStatsBorderColorNotSet = colorValue;
                }
            }

            public static void GlobalStatsSeparationColorSubmit()
            {
                EndGameView3Page.formatingData.GlobalStatsSeparationColor = textValueOverlayView3.GlobalStatsSeparationColor.ToString() + "px solid " + GlobalStatsSeparationColorNotSet;
            }
            public static string TempsGlobalStatsSeparationColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.GlobalStatsSeparationColor.Split(" ");
                return tempsColor[2];
            }
            public static string GlobalStatsSeparationColorNotSet = EndGameView3Page.formatingData.GlobalStatsSeparationColor.Split(" ")[2];
            public static void SetGlobalStatsSeparationColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    string[] tempsSeparationColor = EndGameView3Page.formatingData.GlobalStatsSeparationColor.Split(" ");
                    colorValue = tempsSeparationColor[2];
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    GlobalStatsSeparationColorNotSet = colorValue;
                }
            }
            public static void SetGlobalStatsTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView3Page.formatingData.GlobalStatsTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView3Page.formatingData.GlobalStatsTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsBlueTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView3Page.formatingData.GlobalStatsBlueTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView3Page.formatingData.GlobalStatsBlueTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsRedTextColor()
            {
                if (colorPickerOverlay1GlobalStats.Equals("hidden"))
                {
                    colorPickerOverlay1GlobalStats = "visible";
                    colorValue = EndGameView3Page.formatingData.GlobalStatsRedTextColor;
                }
                else
                {
                    colorPickerOverlay1GlobalStats = "hidden";
                    EndGameView3Page.formatingData.GlobalStatsRedTextColor = colorValue;
                }
            }







            public static void GoldDiffBackgroundColorSubmit()
            {
                EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg = textValueOverlayView3.GoldDiffBackgroundColorDeg.ToString();
                EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1 = textValueOverlayView3.GoldDiffBackgroundColorPercent1.ToString();
                EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2 = textValueOverlayView3.GoldDiffBackgroundColorPercent2.ToString();
                EndGameView3Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
            }

            public static void SetGoldDiffBackgroundColorColor1()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1 = colorValue;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void SetGoldDiffBackgroundColorColor2()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2 = colorValue;
                    EndGameView3Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView3Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView3Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView3Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void GoldDiffBorderColorSubmit()
            {
                EndGameView3Page.formatingData.GoldDiffBorderColor = textValueOverlayView3.GoldDiffBorderColor.ToString() + "px solid " + GoldDiffBorderColorNotSet;
            }
            public static string TempsGoldDiffBorderColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.GoldDiffBorderColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBorderColorNotSet = EndGameView3Page.formatingData.GoldDiffBorderColor.Split(" ")[2];
            public static void SetGoldDiffBorderColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.GoldDiffBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBorderColorNotSet = colorValue;
                }
            }
            public static void SetGoldDiffTextColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffTextColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffTextColor = colorValue;
                }
            }
            public static void GoldDiffBarColorSubmit()
            {
                EndGameView3Page.formatingData.GoldDiffBarColor = textValueOverlayView3.GoldDiffBarColor.ToString() + "px dashed " + GoldDiffBarColorNotSet;
            }
            public static string TempsGoldDiffBarColor()
            {
                string[] tempsColor = EndGameView3Page.formatingData.GoldDiffBarColor.Split(" ");
                return tempsColor[2];
            }
            public static string GoldDiffBarColorNotSet = EndGameView3Page.formatingData.GoldDiffBarColor.Split(" ")[2];
            public static void SetGoldDiffBarColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    string[] tempsBorderColor = EndGameView3Page.formatingData.GoldDiffBarColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    GoldDiffBarColorNotSet = colorValue;
                }
            }
            public static void SetGoldDiffBlueTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffBlueTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffBlueTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffRedTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffRedTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroTextGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffZeroTextGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffZeroTextGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffBluePointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffBluePointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffBluePointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffRedPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffRedPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffRedPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffZeroPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffZeroPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffZeroPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffStartEndPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffStartEndPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffStartEndPointGoldColor = colorValue;
                }
            }
            public static void SetGoldDiffLinkPointGoldColor()
            {
                if (colorPickerOverlay1GoldDiff.Equals("hidden"))
                {
                    colorPickerOverlay1GoldDiff = "visible";
                    colorValue = EndGameView3Page.formatingData.GoldDiffLinkPointGoldColor;
                }
                else
                {
                    colorPickerOverlay1GoldDiff = "hidden";
                    EndGameView3Page.formatingData.GoldDiffLinkPointGoldColor = colorValue;
                }
            }
        }





        //
        private struct OverlayViewEnableOrDisable
        {
            public string text { get; set; }
            public string color { get; set; }

            public OverlayViewEnableOrDisable()
            {
                text = "";
                color = "";
            }

            public OverlayViewEnableOrDisable(string text, string color)
            {
                this.text = text;
                this.color = color;
            }

        }

        private OverlayViewEnableOrDisable displayContentView1Button = new("display", "#008000");
        private OverlayViewEnableOrDisable displayContentView2Button = new("display", "#008000");
        private OverlayViewEnableOrDisable displayContentView3Button = new("display", "#008000");

        private string displayContentView1 = "none";
        private void HideOrDisplayContentView1()
        {
            if (displayContentView1.Equals("none"))
            {
                displayContentView1Button.text = "hide";
                displayContentView1Button.color = "#be1e37";
                displayContentView1 = "content";
            }
            else
            {
                displayContentView1Button.text = "display";
                displayContentView1Button.color = "#008000";
                displayContentView1 = "none";
            }
        }

        private string displayContentView2 = "none";
        private void HideOrDisplayContentView2()
        {
            if (displayContentView2.Equals("none"))
            {
                displayContentView2Button.text = "hide";
                displayContentView2Button.color = "#be1e37";
                displayContentView2 = "content";
            }
            else
            {
                displayContentView2Button.text = "display";
                displayContentView2Button.color = "#008000";
                displayContentView2 = "none";
            }
        }
        private string displayContentView3 = "none";
        private void HideOrDisplayContentView3()
        {
            if (displayContentView3.Equals("none"))
            {
                displayContentView3Button.text = "hide";
                displayContentView3Button.color = "#be1e37";
                displayContentView3 = "content";
            }
            else
            {
                displayContentView3Button.text = "display";
                displayContentView3Button.color = "#008000";
                displayContentView3 = "none";
            }
        }

        public static void EnableAllGradiantView1()
        {
            textValueOverlayView1.TopBarGradiant = true;
            textValueOverlayView1.ChampionInfoGradiant = true;
            textValueOverlayView1.BansGradiant = true;
            textValueOverlayView1.GlobalStatsGradiant = true;
            textValueOverlayView1.GoldDiffGradiant = true;
        }
        public static void DisableAllGradiantView1()
        {
            textValueOverlayView1.TopBarGradiant = false;
            textValueOverlayView1.ChampionInfoGradiant = false;
            textValueOverlayView1.BansGradiant = false;
            textValueOverlayView1.GlobalStatsGradiant = false;
            textValueOverlayView1.GoldDiffGradiant = false;
        }

        public static void EnableAllGradiantView2()
        {
            textValueOverlayView2.TopBarGradiant = true;
            textValueOverlayView2.ChampionInfoGradiant = true;
            textValueOverlayView2.BansGradiant = true;
            textValueOverlayView2.GlobalStatsGradiant = true;
            textValueOverlayView2.GoldDiffGradiant = true;
        }
        public static void DisableAllGradiantView2()
        {
            textValueOverlayView2.TopBarGradiant = false;
            textValueOverlayView2.ChampionInfoGradiant = false;
            textValueOverlayView2.BansGradiant = false;
            textValueOverlayView2.GlobalStatsGradiant = false;
            textValueOverlayView2.GoldDiffGradiant = false;
        }
        public static void EnableAllGradiantView3()
        {
            textValueOverlayView3.TopBarGradiant = true;
            textValueOverlayView3.ChampionInfoGradiant = true;
            textValueOverlayView3.BansGradiant = true;
            textValueOverlayView3.GlobalStatsGradiant = true;
            textValueOverlayView3.GoldDiffGradiant = true;
        }
        public static void DisableAllGradiantView3()
        {
            textValueOverlayView3.TopBarGradiant = false;
            textValueOverlayView3.ChampionInfoGradiant = false;
            textValueOverlayView3.BansGradiant = false;
            textValueOverlayView3.GlobalStatsGradiant = false;
            textValueOverlayView3.GoldDiffGradiant = false;
        }
        public static void EnableAllBackgroundView3()
        {
            textValueOverlayView3.TopBarBackground = true;
            textValueOverlayView3.ChampionInfoBackground = true;
            textValueOverlayView3.BansBackground = true;
            textValueOverlayView3.GlobalStatsBackground = true;
            textValueOverlayView3.GoldDiffBackground = true;
        }
        public static void DisableAllBackgroundView3()
        {
            textValueOverlayView3.TopBarBackground = false;
            textValueOverlayView3.ChampionInfoBackground = false;
            textValueOverlayView3.BansBackground = false;
            textValueOverlayView3.GlobalStatsBackground = false;
            textValueOverlayView3.GoldDiffBackground = false;
        }
    }
}
