using BlazorColorPicker;
using OSL_Server.Pages.ChampSelect;
using OSL_Server.Pages.Runes;
using System.ComponentModel.DataAnnotations;

namespace OSL_Server.Pages.EndGame
{
    public partial class EndGamePage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        public static string colorPickerOverlay1 = "hidden";
        public static string colorValue = "#0000";

        public class TextValueOverlayView1
        {
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarBlueTeamName { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarRedTeamName { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? TopBarTimerText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? ChampionInfoText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? GoldDiffText { get; set; }

            public bool TopBarGradiant { get; set; } = true;
            public bool ChampionInfoGradiant { get; set; } = true;
            public bool BansGradiant { get; set; } = true;
            public bool GlobalStatsGradiant { get; set; } = true;
            public bool GoldDiffGradiant { get; set; } = true;

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

            public static void TopBarBlueTeamNameSubmit()
            {
                EndGameView1Page.formatingData.TopBarBlueTeamName = textValueOverlayView1.TopBarBlueTeamName;
            }
            public static void TopBarRedTeamNameSubmit()
            {
                EndGameView1Page.formatingData.TopBarRedTeamName = textValueOverlayView1.TopBarRedTeamName;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsTopBarBlueTeamName = EndGameView1Page.formatingData.TopBarBlueTeamName;
                string tempsTopBarRedTeamName = EndGameView1Page.formatingData.TopBarRedTeamName;
                string tempsRextValueOverlayView1TopBarBlueTeamName = textValueOverlayView1.TopBarBlueTeamName;
                string tempsRextValueOverlayView1TopBarRedTeamName = textValueOverlayView1.TopBarRedTeamName;
                EndGameView1Page.formatingData.TopBarBlueTeamName = tempsTopBarRedTeamName;
                EndGameView1Page.formatingData.TopBarRedTeamName = tempsTopBarBlueTeamName;
                textValueOverlayView1.TopBarBlueTeamName = tempsRextValueOverlayView1TopBarRedTeamName;
                textValueOverlayView1.TopBarRedTeamName = tempsRextValueOverlayView1TopBarBlueTeamName;
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

            public static void TopBarBackgroundColorSubmit()
            {
                EndGameView1Page.formatingData.TopBarBackgroundColorDeg = textValueOverlayView1.TopBarBackgroundColorDeg.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColorPercent1 = textValueOverlayView1.TopBarBackgroundColorPercent1.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColorPercent2 = textValueOverlayView1.TopBarBackgroundColorPercent2.ToString();
                EndGameView1Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView1Page.formatingData.TopBarBackgroundColorColor1} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView1Page.formatingData.TopBarBackgroundColorColor2} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent2}%)";
            }

            public static void SetTopBarBackgroundColorColor1()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.TopBarBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.TopBarBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.TopBarBackgroundColorDeg}deg, {EndGameView1Page.formatingData.TopBarBackgroundColorColor1} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent1}%, {EndGameView1Page.formatingData.TopBarBackgroundColorColor2} {EndGameView1Page.formatingData.TopBarBackgroundColorPercent2}%)";
                }
            }
            public static void SetTopBarBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.TopBarBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    TopBarBorderColorNotSet = colorValue;
                }
            }

            public static void SetTopBarBlueTeamNameColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarBlueTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.TopBarBlueTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarRedTeamNameColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarRedTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.TopBarRedTeamNameColor = colorValue;
                }
            }
            public static void SetTopBarTimerTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarTimerTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.TopBarTimerTextColor = colorValue;
                }
            }
            public static void SetTopBarTimerColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.TopBarTimerColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.ChampionInfoBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.ChampionInfoBackgroundColorDeg}deg, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor1} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent1}%, {EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2} {EndGameView1Page.formatingData.ChampionInfoBackgroundColorPercent2}%)";
                }
            }
            public static void SetChampionInfoBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.ChampionInfoBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampionInfoBorderColorNotSet = colorValue;
                }
            }
            public static void SetChampionInfoTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoTextColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueBarColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBlueBarColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBlueBarColor = colorValue;
                }
            }
            public static void SetChampionInfoBlueDegaTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoBlueDegaTextColor = colorValue;
                }
            }
            public static void SetChampionInfoRedBarColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoRedBarColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.ChampionInfoRedBarColor = colorValue;
                }
            }
            public static void SetChampionInfoRedDegaTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.ChampionInfoRedDegaTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.BansBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.BansBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.BansBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.BansBackgroundColorDeg}deg, {EndGameView1Page.formatingData.BansBackgroundColorColor1} {EndGameView1Page.formatingData.BansBackgroundColorPercent1}%, {EndGameView1Page.formatingData.BansBackgroundColorColor2} {EndGameView1Page.formatingData.BansBackgroundColorPercent2}%)";
                }
            }
            public static void SetBansBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.BansBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.BansBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    BansBorderColorNotSet = colorValue;
                }
            }

            public static void SetBansTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.BansTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.GlobalStatsBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GlobalStatsBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor1} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2} {EndGameView1Page.formatingData.GlobalStatsBackgroundColorPercent2}%)";
                }
            }
            public static void SetGlobalStatsBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.GlobalStatsBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    GlobalStatsBorderColorNotSet = colorValue;
                }
            }
            public static void SetGlobalStatsTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsBlueTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsBlueTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.GlobalStatsBlueTextColor = colorValue;
                }
            }

            public static void SetGlobalStatsRedTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GlobalStatsRedTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1 = colorValue;
                    EndGameView1Page.formatingData.GoldDiffBackgroundColor = $"linear-gradient({EndGameView1Page.formatingData.GoldDiffBackgroundColorDeg}deg, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor1} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent1}%, {EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2} {EndGameView1Page.formatingData.GoldDiffBackgroundColorPercent2}%)";
                }
            }
            public static void SetGoldDiffBackgroundColorColor2()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffBackgroundColorColor2;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
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
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = EndGameView1Page.formatingData.GoldDiffBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    GoldDiffBorderColorNotSet = colorValue;
                }
            }
            public static void SetGoldDiffTextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = EndGameView1Page.formatingData.GoldDiffTextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    EndGameView1Page.formatingData.GoldDiffTextColor = colorValue;
                }
            }
        }

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
    }
}
