using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

using System.ComponentModel.DataAnnotations;

namespace OSL_Server.Pages
{
    /// <summary>
    /// Champ Select Page
    /// </summary>
    public partial class ChampSelectPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");

        //For display color picker
        public static string colorPickerOverlay1 = "hidden";
        public static string colorPickerOverlay2 = "hidden";
        public static string colorPickerOverlay3 = "hidden";
        public static string colorPickerOverlay4 = "hidden";
        public static string colorValue = "#0000";

        /// <summary>
        /// Text and value for display color, information on champ select view 1
        /// </summary>
        public class TextValueOverlayView1
        {

            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? BlueSideTeamName { get; set; }

            [StringLength(30, ErrorMessage = "Name is too long (30 character limit).")]
            public string? BlueTeamSubtext { get; set; }

            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? RedSideTeamName { get; set; }

            [StringLength(30, ErrorMessage = "Name is too long (30 character limit).")]
            public string? RedTeamSubtext { get; set; }

            public bool OverlayBackground { get; set; } = true;
            public bool DisplaySummonerSpell { get; set; } = false;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideTimerBorderColor { get; set; } = 5;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideBorderColor { get; set; } = 5;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideTimerBorderColor { get; set; } = 5;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideBorderColor { get; set; } = 5;

            public static void BlueSideTeamNameSubmit()
            {
                ChampSelectView1Page.formatingData.BlueSideTeamName = textValueOverlayView1.BlueSideTeamName;
            }

            public static void BlueSideTeamSubtextSubmit()
            {
                ChampSelectView1Page.formatingData.BlueTeamSubtext = textValueOverlayView1.BlueTeamSubtext;
            }
            public static void RedSideTeamNameSubmit()
            {
                ChampSelectView1Page.formatingData.RedSideTeamName = textValueOverlayView1.RedSideTeamName;
            }
            public static void RedSideTeamSubtextSubmit()
            {
                ChampSelectView1Page.formatingData.RedTeamSubtext = textValueOverlayView1.RedTeamSubtext;
            }

            public static void SwitchSideRedBlue()
            {
                string tempsBlueSideTeamNameView1 = ChampSelectView1Page.formatingData.BlueSideTeamName;
                string tempsRedSideTeamNameView1 = ChampSelectView1Page.formatingData.RedSideTeamName;
                string tempsBlueTeamSubtextView1 = ChampSelectView1Page.formatingData.BlueTeamSubtext;
                string tempsRedTeamSubtextView1 = ChampSelectView1Page.formatingData.RedTeamSubtext;
                string tempsTextValueOverlayView1BlueSideTeamName1View1 = textValueOverlayView1.BlueSideTeamName;
                string tempsTextValueOverlayView1RedSideTeamName1View1 = textValueOverlayView1.RedSideTeamName;
                string tempsTextValueOverlayView1BlueTeamSubtextView1 = textValueOverlayView1.BlueTeamSubtext;
                string tempsTextValueOverlayView1RedTeamSubtextView1 = textValueOverlayView1.RedTeamSubtext;
                ChampSelectView1Page.formatingData.BlueSideTeamName = tempsRedSideTeamNameView1;
                ChampSelectView1Page.formatingData.RedSideTeamName = tempsBlueSideTeamNameView1;
                ChampSelectView1Page.formatingData.BlueTeamSubtext = tempsRedTeamSubtextView1;
                ChampSelectView1Page.formatingData.RedTeamSubtext = tempsBlueTeamSubtextView1;
                textValueOverlayView1.BlueSideTeamName = tempsTextValueOverlayView1RedSideTeamName1View1;
                textValueOverlayView1.RedSideTeamName = tempsTextValueOverlayView1BlueSideTeamName1View1;
                textValueOverlayView1.BlueTeamSubtext = tempsTextValueOverlayView1RedTeamSubtextView1;
                textValueOverlayView1.RedTeamSubtext = tempsTextValueOverlayView1BlueTeamSubtextView1;
            }

            public static void OverlayBackgroundSubmit()
            {

            }

            public static void DisplaySummonerSpellSubmit()
            {

            }

            public static void BlueSideTimerBorderColorSubmit()
            {
                ChampSelectView1Page.formatingData.BlueSideTimerBorderColor = textValueOverlayView1.BlueSideTimerBorderColor.ToString() + "px solid " + BlueSideTimerBorderColorNotSet;
            }

            public static void BlueSideBorderColorSubmit()
            {
                ChampSelectView1Page.formatingData.BlueSideBorderColor = textValueOverlayView1.BlueSideBorderColor.ToString() + "px solid " + BlueSideBorderColorNotSet;
            }

            public static void RedSideTimerBorderColorSubmit()
            {
                ChampSelectView1Page.formatingData.RedSideTimerBorderColor = textValueOverlayView1.RedSideTimerBorderColor.ToString() + "px solid " + RedSideTimerBorderColorNotSet;
            }

            public static void RedSideBorderColorSubmit()
            {
                ChampSelectView1Page.formatingData.RedSideBorderColor = textValueOverlayView1.RedSideBorderColor.ToString() + "px solid " + RedSideBorderColorNotSet;
            }

            public static string TempsBlueSideTimerBorderColor()
            {
                string[] tempsColor = ChampSelectView1Page.formatingData.BlueSideTimerBorderColor.Split(" ");
                return tempsColor[2];
            }

            public static string TempsBlueSideBorderColor()
            {
                string[] tempsColor = ChampSelectView1Page.formatingData.BlueSideBorderColor.Split(" ");
                return tempsColor[2];
            }

            public static string TempsRedSideTimerBorderColor()
            {
                string[] tempsColor = ChampSelectView1Page.formatingData.RedSideTimerBorderColor.Split(" ");
                return tempsColor[2];
            }

            public static string TempsRedSideBorderColor()
            {
                string[] tempsColor = ChampSelectView1Page.formatingData.RedSideBorderColor.Split(" ");
                return tempsColor[2];
            }

            public static void SetBlueTeamNameColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueTeamNameColor = colorValue;
                }
            }
            public static void SetBlueTeamSubtextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueTeamSubtextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueTeamSubtextColor = colorValue;
                }
            }

            public static void SetBlueSideTexteColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueSideTexteColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueSideTexteColor = colorValue;
                }
            }

            public static void SetBlueSideBackgroudColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueSideBackgroudColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueSideBackgroudColor = colorValue;
                }
            }
            public static void SetBlueSideTimerBackgroudColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueSideTimerBackgroudColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueSideTimerBackgroudColor = colorValue;
                }
            }
            public static void SetBlueSideTimerTexteColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BlueSideTimerTexteColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BlueSideTimerTexteColor = colorValue;
                }
            }
            public static void SetRedTeamNameColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedTeamNameColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedTeamNameColor = colorValue;
                }
            }

            public static void SetRedTeamSubtextColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedTeamSubtextColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedTeamSubtextColor = colorValue;
                }
            }

            public static void SetRedSideTexteColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedSideTexteColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedSideTexteColor = colorValue;
                }
            }

            public static void SetRedSideBackgroudColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedSideBackgroudColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedSideBackgroudColor = colorValue;
                }
            }

            public static void SetRedSideTimerBackgroudColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedSideTimerBackgroudColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedSideTimerBackgroudColor = colorValue;
                }
            }

            public static void SetRedSideTimerTexteColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.RedSideTimerTexteColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.RedSideTimerTexteColor = colorValue;
                }
            }

            public static void SetBanBackgroundColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = ChampSelectView1Page.formatingData.BanBackgroundColor;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    ChampSelectView1Page.formatingData.BanBackgroundColor = colorValue;
                }
            }

            public static string BlueSideBorderColorNotSet = ChampSelectView1Page.formatingData.BlueSideBorderColor.Split(" ")[2];
            public static void SetBlueSideBorderColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = ChampSelectView1Page.formatingData.BlueSideBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    BlueSideBorderColorNotSet = colorValue;
                }
            }

            public static string RedSideBorderColorNotSet = ChampSelectView1Page.formatingData.RedSideBorderColor.Split(" ")[2];
            public static void SetRedSideBorderColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = ChampSelectView1Page.formatingData.BlueSideBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    RedSideBorderColorNotSet = colorValue;
                }
            }

            public static string BlueSideTimerBorderColorNotSet = ChampSelectView1Page.formatingData.BlueSideTimerBorderColor.Split(" ")[2];
            public static void SetBlueSideTimerBorderColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = ChampSelectView1Page.formatingData.BlueSideTimerBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    BlueSideTimerBorderColorNotSet = colorValue;
                }
            }

            public static string RedSideTimerBorderColorNotSet = ChampSelectView1Page.formatingData.RedSideTimerBorderColor.Split(" ")[2];
            public static void SetRedSideTimerBorderColor()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    string[] tempsBorderColor = ChampSelectView1Page.formatingData.BlueSideTimerBorderColor.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    RedSideTimerBorderColorNotSet = colorValue;
                }
            }
        }

        /// <summary>
        /// Text and value for display color, information on champ select view 2
        /// </summary>
        public class TextValueOverlayView2
        {
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? BlueSideTeamName { get; set; }

            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? RedSideTeamName { get; set; }

            public bool EnableTimer { get; set; } = true;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int KeystonePickColorDeg { get; set; } = 150;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent2 { get; set; } = 100;


            public static void BlueSideTeamNameSubmit()
            {
                ChampSelectView2Page.formatingData.BlueSideTeamName = textValueOverlayView2.BlueSideTeamName;
            }

            public static void RedSideTeamNameSubmit()
            {
                ChampSelectView2Page.formatingData.RedSideTeamName = textValueOverlayView2.RedSideTeamName;
            }

            public static void SwitchSideRedBlue()
            {
                string tempsBlueSideTeamNameView2 = ChampSelectView2Page.formatingData.BlueSideTeamName;
                string tempsRedSideTeamNameView2 = ChampSelectView2Page.formatingData.RedSideTeamName;
                string tempsOverlayTextBlueSideTeamNameView2 = textValueOverlayView2.BlueSideTeamName;
                string tempsOverlayTextRedSideTeamNameView2 = textValueOverlayView2.RedSideTeamName;
                ChampSelectView2Page.formatingData.BlueSideTeamName = tempsRedSideTeamNameView2;
                ChampSelectView2Page.formatingData.RedSideTeamName = tempsBlueSideTeamNameView2;
                textValueOverlayView2.BlueSideTeamName = tempsOverlayTextRedSideTeamNameView2;
                textValueOverlayView2.RedSideTeamName = tempsOverlayTextBlueSideTeamNameView2;
            }

            public static void TimerSubmit()
            {

            }

            public static void KeystonePickColorSubmit()
            {
                ChampSelectView2Page.formatingData.KeystonePickColorDeg = textValueOverlayView2.KeystonePickColorDeg.ToString();
                ChampSelectView2Page.formatingData.KeystonePickColorPercent1 = textValueOverlayView2.KeystonePickColorPercent1.ToString();
                ChampSelectView2Page.formatingData.KeystonePickColorPercent2 = textValueOverlayView2.KeystonePickColorPercent2.ToString();
                ChampSelectView2Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView2Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView2Page.formatingData.KeystonePickColor1} {ChampSelectView2Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView2Page.formatingData.KeystonePickColor2} {ChampSelectView2Page.formatingData.KeystonePickColorPercent2}%)";
            }

            public static void SetTimerBackground()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.TimerBackground;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.TimerBackground = colorValue;
                }
            }

            public static void SetTimerBlue()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.TimerBlue;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.TimerBlue = colorValue;
                    ChampSelectView2Page.formatingData.TimerEnd = "linear-gradient(90deg, " + ChampSelectView2Page.formatingData.TimerBlue + " 0%, " + ChampSelectView2Page.formatingData.TimerRed + " 100%)";

                }
            }

            public static void SetTimerRed()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.TimerRed;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.TimerRed = colorValue;
                    ChampSelectView2Page.formatingData.TimerEnd = "linear-gradient(90deg, " + ChampSelectView2Page.formatingData.TimerBlue + " 0%, " + ChampSelectView2Page.formatingData.TimerRed + " 100%)";
                }
            }

            public static void SetBlueSideBackgroud()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BlueSideBackgroud;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BlueSideBackgroud = colorValue;
                    ChampSelectView2Page.formatingData.BlueSideBlink = "radial-gradient(ellipse, rgba(0, 0, 0, 0) 25%, " + ChampSelectView2Page.formatingData.BlueSideBackgroud + ")";
                }
            }
            public static void SetBlueSideSummoner()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BlueSideSummoner;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BlueSideSummoner = colorValue;
                }
            }
            public static void SetBlueSideBackgroudSummonerPick()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPick = colorValue;
                }
            }
            public static void SetBlueSideBackgroudSummonerPickEnd()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BlueSideBackgroudSummonerPickEnd = colorValue;
                }
            }
            public static void SetBlueSideTeamNameColor()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BlueSideTeamNameColor;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BlueSideTeamNameColor = colorValue;
                }
            }

            public static void SetKeystoneColor1()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.KeystonePickColor1;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.KeystonePickColor1 = colorValue;
                    ChampSelectView2Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView2Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView2Page.formatingData.KeystonePickColor1} {ChampSelectView2Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView2Page.formatingData.KeystonePickColor2} {ChampSelectView2Page.formatingData.KeystonePickColorPercent2}%)";
                }
            }

            public static void SetKeystoneColor2()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.KeystonePickColor2;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.KeystonePickColor2 = colorValue;
                    ChampSelectView2Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView2Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView2Page.formatingData.KeystonePickColor1} {ChampSelectView2Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView2Page.formatingData.KeystonePickColor2} {ChampSelectView2Page.formatingData.KeystonePickColorPercent2}%)";
                }
            }

            public static void SetRedSideBackgroud()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.RedSideBackgroud;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.RedSideBackgroud = colorValue;
                    ChampSelectView2Page.formatingData.RedSideBlink = "radial-gradient(ellipse, rgba(0, 0, 0, 0) 25%, " + ChampSelectView2Page.formatingData.RedSideBackgroud + ")";
                }
            }
            public static void SetRedSideSummoner()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.RedSideSummoner;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.RedSideSummoner = colorValue;
                }
            }
            public static void SetRedSideBackgroudSummonerPick()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPick = colorValue;
                }
            }
            public static void SetRedSideBackgroudSummonerPickEnd()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.RedSideBackgroudSummonerPickEnd = colorValue;
                }
            }
            public static void SetRedSideTeamNameColor()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.RedSideTeamNameColor;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.RedSideTeamNameColor = colorValue;
                }
            }

            public static void SetBanBackgroundColor()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = ChampSelectView2Page.formatingData.BanBackgroundColor;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    ChampSelectView2Page.formatingData.BanBackgroundColor = colorValue;
                }
            }
        }

        /// <summary>
        /// Text and value for display color, information on champ select view 3
        /// </summary>
        public class TextValueOverlayView3
        {
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? BlueSideTeamName { get; set; }

            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? RedSideTeamName { get; set; }

            public bool EnableTimer { get; set; } = true;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int KeystonePickColorDeg { get; set; } = 150;

            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent2 { get; set; } = 100;

            public static void BlueSideTeamNameSubmit()
            {
                ChampSelectView3Page.formatingData.BlueSideTeamName = textValueOverlayView3.BlueSideTeamName;
            }

            public static void RedSideTeamNameSubmit()
            {
                ChampSelectView3Page.formatingData.RedSideTeamName = textValueOverlayView3.RedSideTeamName;
            }

            public static void SwitchSideRedBlue()
            {
                string tempsBlueSideTeamName = ChampSelectView3Page.formatingData.BlueSideTeamName;
                string tempsRedSideTeamName = ChampSelectView3Page.formatingData.RedSideTeamName;
                string tempsOverlayTextBlueSideTeamName = textValueOverlayView3.BlueSideTeamName;
                string tempsOverlayTextRedSideTeamName = textValueOverlayView3.RedSideTeamName;
                ChampSelectView3Page.formatingData.BlueSideTeamName = tempsRedSideTeamName;
                ChampSelectView3Page.formatingData.RedSideTeamName = tempsBlueSideTeamName;
                textValueOverlayView3.BlueSideTeamName = tempsOverlayTextRedSideTeamName;
                textValueOverlayView3.RedSideTeamName = tempsOverlayTextBlueSideTeamName;
            }

            public static void KeystonePickColorSubmit()
            {
                ChampSelectView3Page.formatingData.KeystonePickColorDeg = textValueOverlayView3.KeystonePickColorDeg.ToString();
                ChampSelectView3Page.formatingData.KeystonePickColorPercent1 = textValueOverlayView3.KeystonePickColorPercent1.ToString();
                ChampSelectView3Page.formatingData.KeystonePickColorPercent2 = textValueOverlayView3.KeystonePickColorPercent2.ToString();
                ChampSelectView3Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView3Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView3Page.formatingData.KeystonePickColor1} {ChampSelectView3Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView3Page.formatingData.KeystonePickColor2} {ChampSelectView3Page.formatingData.KeystonePickColorPercent2}%)";
            }

            public static void TimerSubmit()
            {

            }

            public static void SetTimerBackground()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.TimerBackground;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.TimerBackground = colorValue;
                }
            }

            public static void SetTimerBlue()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.TimerBlue;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.TimerBlue = colorValue;
                    ChampSelectView3Page.formatingData.TimerEnd = "linear-gradient(90deg, " + ChampSelectView3Page.formatingData.TimerBlue + " 0%, " + ChampSelectView3Page.formatingData.TimerRed + " 100%)";

                }
            }

            public static void SetTimerRed()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.TimerRed;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.TimerRed = colorValue;
                    ChampSelectView3Page.formatingData.TimerEnd = "linear-gradient(90deg, " + ChampSelectView3Page.formatingData.TimerBlue + " 0%, " + ChampSelectView3Page.formatingData.TimerRed + " 100%)";
                }
            }

            public static void SetBlueSideBackgroud()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BlueSideBackgroud;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BlueSideBackgroud = colorValue;
                }
            }
            public static void SetBlueSideSummoner()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BlueSideSummoner;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BlueSideSummoner = colorValue;
                }
            }
            public static void SetBlueSideBackgroudSummonerPick()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPick = colorValue;
                }
            }
            public static void SetBlueSideBackgroudSummonerPickEnd()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BlueSideBackgroudSummonerPickEnd = colorValue;
                }
            }

            public static void SetBlueSideTeamNameColor()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BlueSideTeamNameColor;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BlueSideTeamNameColor = colorValue;
                }
            }

            public static void SetKeystoneColor1()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.KeystonePickColor1;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.KeystonePickColor1 = colorValue;
                    ChampSelectView3Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView3Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView3Page.formatingData.KeystonePickColor1} {ChampSelectView3Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView3Page.formatingData.KeystonePickColor2} {ChampSelectView3Page.formatingData.KeystonePickColorPercent2}%)";
                }
            }

            public static void SetKeystoneColor2()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.KeystonePickColor2;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.KeystonePickColor2 = colorValue;
                    ChampSelectView3Page.formatingData.KeystonePickColor = $"linear-gradient({ChampSelectView3Page.formatingData.KeystonePickColorDeg}deg, {ChampSelectView3Page.formatingData.KeystonePickColor1} {ChampSelectView3Page.formatingData.KeystonePickColorPercent1}%, {ChampSelectView3Page.formatingData.KeystonePickColor2} {ChampSelectView3Page.formatingData.KeystonePickColorPercent2}%)";
                }
            }

            public static void SetRedSideBackgroud()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.RedSideBackgroud;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.RedSideBackgroud = colorValue;
                }
            }
            public static void SetRedSideSummoner()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.RedSideSummoner;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.RedSideSummoner = colorValue;
                }
            }
            public static void SetRedSideBackgroudSummonerPick()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPick = colorValue;
                }
            }
            public static void SetRedSideBackgroudSummonerPickEnd()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.RedSideBackgroudSummonerPickEnd = colorValue;
                }
            }
            public static void SetRedSideTeamNameColor()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.RedSideTeamNameColor;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.RedSideTeamNameColor = colorValue;
                }
            }
            public static void SetBanBackgroundColor()
            {
                if (colorPickerOverlay3.Equals("hidden"))
                {
                    colorPickerOverlay3 = "visible";
                    colorValue = ChampSelectView3Page.formatingData.BanBackgroundColor;
                }
                else
                {
                    colorPickerOverlay3 = "hidden";
                    ChampSelectView3Page.formatingData.BanBackgroundColor = colorValue;
                }
            }
        }

        /// <summary>
        /// Text and value for display color, information on champ select view 4
        /// </summary>
        public class TextValueOverlayView4
        {
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? BlueSideTeamName { get; set; }

            [StringLength(15, ErrorMessage = "Name is too long (15 character limit).")]
            public string? BlueSideTeamNameSubtext { get; set; }

            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? RedSideTeamName { get; set; }

            [StringLength(15, ErrorMessage = "Name is too long (15 character limit).")]
            public string? RedSideTeamNameSubtext { get; set; }

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BorderTop { get; set; } = 5;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BorderBottomPixel { get; set; } = 5;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int BackgroudGradientDeg { get; set; } = 150;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroudGradientPercent1 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int BackgroudGradientPercent2 { get; set; } = 100;

            public bool EnableForegroundBackground { get; set; } = true;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideBorderColorBan { get; set; } = 2;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideBorderColorPick { get; set; } = 2;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideBorderColorBan { get; set; } = 2;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideBorderColorPick { get; set; } = 2;

            public static void BlueSideTeamNameSubmit()
            {
                ChampSelectView4Page.formatingData.BlueSideTeamName = textValueOverlayView4.BlueSideTeamName;
            }

            public static void RedSideTeamNameSubmit()
            {
                ChampSelectView4Page.formatingData.RedSideTeamName = textValueOverlayView4.RedSideTeamName;
            }

            public static void BlueSideTeamNameSubtextSubmit()
            {
                ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext = textValueOverlayView4.BlueSideTeamNameSubtext;
            }

            public static void RedSideTeamNameSubtextSubmit()
            {
                ChampSelectView4Page.formatingData.RedSideTeamNameSubtext = textValueOverlayView4.RedSideTeamNameSubtext;
            }

            public static void SwitchSideRedBlue()
            {
                string tempsBlueSideTeamName = ChampSelectView4Page.formatingData.BlueSideTeamName;
                string tempsRedSideTeamName = ChampSelectView4Page.formatingData.RedSideTeamName;
                string tempsBlueTeamSubtext = ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext;
                string tempsRedTeamSubtext = ChampSelectView4Page.formatingData.RedSideTeamNameSubtext;
                string tempsOverlayTextBlueSideTeamName = textValueOverlayView4.BlueSideTeamName;
                string tempsOverlayTextRedSideTeamName = textValueOverlayView4.RedSideTeamName;
                string tempsOverlayTextBlueTeamSubtext = textValueOverlayView4.BlueSideTeamNameSubtext;
                string tempsOverlayTextRedTeamSubtext = textValueOverlayView4.RedSideTeamNameSubtext;
                ChampSelectView4Page.formatingData.BlueSideTeamName = tempsRedSideTeamName;
                ChampSelectView4Page.formatingData.RedSideTeamName = tempsBlueSideTeamName;
                ChampSelectView4Page.formatingData.BlueSideTeamNameSubtext = tempsRedTeamSubtext;
                ChampSelectView4Page.formatingData.RedSideTeamNameSubtext = tempsBlueTeamSubtext;
                textValueOverlayView4.BlueSideTeamName = tempsOverlayTextRedSideTeamName;
                textValueOverlayView4.RedSideTeamName = tempsOverlayTextBlueSideTeamName;
                textValueOverlayView4.BlueSideTeamNameSubtext = tempsOverlayTextRedTeamSubtext;
                textValueOverlayView4.RedSideTeamNameSubtext = tempsOverlayTextBlueTeamSubtext;
            }

            public static void OverlayForegoundSubmit()
            {

            }

            public static void BackgroudGradientView4()
            {
                ChampSelectView4Page.formatingData.BackgroudGradientDeg = textValueOverlayView4.BackgroudGradientDeg.ToString();
                ChampSelectView4Page.formatingData.BackgroudGradientPercent1 = textValueOverlayView4.BackgroudGradientPercent1.ToString();
                ChampSelectView4Page.formatingData.BackgroudGradientPercent2 = textValueOverlayView4.BackgroudGradientPercent2.ToString();
                ChampSelectView4Page.formatingData.BackgroudGradient = $"linear-gradient({ChampSelectView4Page.formatingData.BackgroudGradientDeg}deg, {ChampSelectView4Page.formatingData.BackgroudGradientColor1} {ChampSelectView4Page.formatingData.BackgroudGradientPercent1}%, {ChampSelectView4Page.formatingData.BackgroudGradientColor2} {ChampSelectView4Page.formatingData.BackgroudGradientPercent2}%)";
            }

            public static void BorderBottomPixelSubmit()
            {
                ChampSelectView4Page.formatingData.BorderBottomPixel = textValueOverlayView4.BorderBottomPixel.ToString() + "px solid";
            }

            public static void BorderTopSubmit()
            {
                ChampSelectView4Page.formatingData.BorderTop = textValueOverlayView4.BorderTop.ToString() + "px solid " + BorderTopNotSet;
            }
            public static void BlueSideBorderColorBanSubmit()
            {
                ChampSelectView4Page.formatingData.BlueSideBorderColorBan = textValueOverlayView4.BlueSideBorderColorBan.ToString() + "px solid " + BlueSideBorderColorBanNotSet;
            }
            public static void RedSideBorderColorBanSubmit()
            {
                ChampSelectView4Page.formatingData.RedSideBorderColorBan = textValueOverlayView4.RedSideBorderColorBan.ToString() + "px solid " + RedSideBorderColorBanNotSet;
            }
            public static void BlueSideBorderColorPickSubmit()
            {
                ChampSelectView4Page.formatingData.BlueSideBorderColorPick = textValueOverlayView4.BlueSideBorderColorPick.ToString() + "px solid " + BlueSideBorderColorPickNotSet;
            }
            public static void RedSideBorderColorPickSubmit()
            {
                ChampSelectView4Page.formatingData.RedSideBorderColorPick = textValueOverlayView4.RedSideBorderColorPick.ToString() + "px solid " + RedSideBorderColorPickNotSet;
            }

            public static string TempsBorderTop()
            {
                string[] tempsColor = ChampSelectView4Page.formatingData.BorderTop.Split(" ");
                return tempsColor[2];
            }

            public static string TempsBlueSideBorderColorBan()
            {
                string[] tempsColor = ChampSelectView4Page.formatingData.BlueSideBorderColorBan.Split(" ");
                return tempsColor[2];
            }
            public static string TempsRedSideBorderColorBan()
            {
                string[] tempsColor = ChampSelectView4Page.formatingData.RedSideBorderColorBan.Split(" ");
                return tempsColor[2];
            }
            public static string TempsBlueSideBorderColorPick()
            {
                string[] tempsColor = ChampSelectView4Page.formatingData.BlueSideBorderColorPick.Split(" ");
                return tempsColor[2];
            }
            public static string TempsRedSideBorderColorPick()
            {
                string[] tempsColor = ChampSelectView4Page.formatingData.RedSideBorderColorPick.Split(" ");
                return tempsColor[2];
            }

            public static void SetBlueSideColorText()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BlueSideColorText;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BlueSideColorText = colorValue;
                }
            }
            public static void SetBlueSideColorSubText()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BlueSideColorSubText;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BlueSideColorSubText = colorValue;
                }
            }
            public static void SetBlueSideColorTextBan()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BlueSideColorTextBan;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BlueSideColorTextBan = colorValue;
                }
            }

            public static void SetBlueSideColorTextPick()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BlueSideColorTextPick;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BlueSideColorTextPick = colorValue;
                }
            }
            public static void SetRedSideColorText()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.RedSideColorText;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.RedSideColorText = colorValue;
                }
            }
            public static void SetRedSideColorSubText()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.RedSideColorSubText;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.RedSideColorSubText = colorValue;
                }
            }
            public static void SetRedSideColorTextBan()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.RedSideColorTextBan;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.RedSideColorTextBan = colorValue;
                }
            }

            public static void SetRedSideColorTextPick()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.RedSideColorTextPick;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.RedSideColorTextPick = colorValue;
                }
            }
            public static string BorderTopNotSet = ChampSelectView4Page.formatingData.BorderTop.Split(" ")[2];
            public static void SetBorderTop()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    string[] tempsBorderColor = ChampSelectView4Page.formatingData.BorderTop.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    BorderTopNotSet = colorValue;
                }
            }

            public static string BlueSideBorderColorBanNotSet = ChampSelectView4Page.formatingData.BlueSideBorderColorBan.Split(" ")[2];
            public static void SetBlueSideBorderColorBan()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    string[] tempsBorderColor = ChampSelectView4Page.formatingData.BlueSideBorderColorBan.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    BlueSideBorderColorBanNotSet = colorValue;
                }
            }
            public static string RedSideBorderColorBanNotSet = ChampSelectView4Page.formatingData.RedSideBorderColorBan.Split(" ")[2];
            public static void SetRedSideBorderColorBan()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    string[] tempsBorderColor = ChampSelectView4Page.formatingData.RedSideBorderColorBan.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    RedSideBorderColorBanNotSet = colorValue;
                }
            }
            public static string BlueSideBorderColorPickNotSet = ChampSelectView4Page.formatingData.BlueSideBorderColorPick.Split(" ")[2];
            public static void SetBlueSideBorderColorPick()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    string[] tempsBorderColor = ChampSelectView4Page.formatingData.BlueSideBorderColorPick.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    BlueSideBorderColorPickNotSet = colorValue;
                }
            }
            public static string RedSideBorderColorPickNotSet = ChampSelectView4Page.formatingData.RedSideBorderColorPick.Split(" ")[2];
            public static void SetRedSideBorderColorPick()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    string[] tempsBorderColor = ChampSelectView4Page.formatingData.RedSideBorderColorPick.Split(" ");
                    colorValue = tempsBorderColor[2];
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    RedSideBorderColorPickNotSet = colorValue;
                }
            }

            public static void SetBackgroudGradientColor1()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BackgroudGradientColor1;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BackgroudGradientColor1 = colorValue;
                    ChampSelectView4Page.formatingData.BackgroudGradient = $"linear-gradient({ChampSelectView4Page.formatingData.BackgroudGradientDeg}deg, {ChampSelectView4Page.formatingData.BackgroudGradientColor1} {ChampSelectView4Page.formatingData.BackgroudGradientPercent1}%, {ChampSelectView4Page.formatingData.BackgroudGradientColor2} {ChampSelectView4Page.formatingData.BackgroudGradientPercent2}%)";
                }
            }

            public static void SetBackgroudGradientColor2()
            {
                if (colorPickerOverlay4.Equals("hidden"))
                {
                    colorPickerOverlay4 = "visible";
                    colorValue = ChampSelectView4Page.formatingData.BackgroudGradientColor2;
                }
                else
                {
                    colorPickerOverlay4 = "hidden";
                    ChampSelectView4Page.formatingData.BackgroudGradientColor2 = colorValue;
                    ChampSelectView4Page.formatingData.BackgroudGradient = $"linear-gradient({ChampSelectView4Page.formatingData.BackgroudGradientDeg}deg, {ChampSelectView4Page.formatingData.BackgroudGradientColor1} {ChampSelectView4Page.formatingData.BackgroudGradientPercent1}%, {ChampSelectView4Page.formatingData.BackgroudGradientColor2} {ChampSelectView4Page.formatingData.BackgroudGradientPercent2}%)";
                }
            }
        }

        /// <summary>
        /// structure of overlay view for enable or disable text and change color
        /// </summary>
        private struct OverlayViewEnableOrDisable
        {
            public string text { get; set; }
            public string color { get; set; }

            public OverlayViewEnableOrDisable()
            {
                text = "";
                color = "";
            }

        }

        private OverlayViewEnableOrDisable overlayView1Button = new OverlayViewEnableOrDisable();
        private OverlayViewEnableOrDisable overlayView2Button = new OverlayViewEnableOrDisable();
        private OverlayViewEnableOrDisable overlayView3Button = new OverlayViewEnableOrDisable();
        private OverlayViewEnableOrDisable overlayView4Button = new OverlayViewEnableOrDisable();

        /// <summary>
        /// Load text and color enable or disable overlays
        /// </summary>
        private void LoadTextEnableOrDisableOverlays()
        {
            TextColorEnableOrDisableOverlayView1();
            TextColorEnableOrDisableOverlayView2();
            TextColorEnableOrDisableOverlayView3();
            TextColorEnableOrDisableOverlayView4();
        }

        /// <summary>
        /// Overlay view 1 change text and color
        /// </summary>
        private void TextColorEnableOrDisableOverlayView1()
        {
            if (ChampSelectView1Page.overlayLoaded == true)
            {
                overlayView1Button.text = "Disable";
                overlayView1Button.color = "#be1e37";
            }
            else
            {
                overlayView1Button.text = "Enable";
                overlayView1Button.color = "#0b849e";
            }
        }

        /// <summary>
        /// Overlay view 2 change text and color
        /// </summary>
        private void TextColorEnableOrDisableOverlayView2()
        {
            if (ChampSelectView2Page.overlayLoaded == true)
            {
                overlayView2Button.text = "Disable";
                overlayView2Button.color = "#be1e37";
            }
            else
            {
                overlayView2Button.text = "Enable";
                overlayView2Button.color = "#0b849e";
            }
        }
        /// <summary>
        /// Overlay view 3 change text and color
        /// </summary>
        private void TextColorEnableOrDisableOverlayView3()
        {
            if (ChampSelectView3Page.overlayLoaded == true)
            {
                overlayView3Button.text = "Disable";
                overlayView3Button.color = "#be1e37";
            }
            else
            {
                overlayView3Button.text = "Enable";
                overlayView3Button.color = "#0b849e";
            }
        }
        /// <summary>
        /// Overlay view 4 change text and color
        /// </summary>
        private void TextColorEnableOrDisableOverlayView4()
        {
            if (ChampSelectView4Page.overlayLoaded == true)
            {
                overlayView4Button.text = "Disable";
                overlayView4Button.color = "#be1e37";
            }
            else
            {
                overlayView4Button.text = "Enable";
                overlayView4Button.color = "#0b849e";
            }
        }
    }
}
