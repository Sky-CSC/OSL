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
            public string? WinText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? LoseText { get; set; }
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

            public string? TextAssist { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextBarracksKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextChampionsKilled {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextGoldEarned {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestCriticalStrike {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestKillingSpree {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestMultiKill {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLevel {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtPlayer {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtToChampions {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageTaken {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMinionsKilled {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextNumDeaths {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtPlayer {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtToChampions {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageTaken {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealt {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToBuildings {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToChampions {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToObjectives {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToTurrets {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageSelfMitigated {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageShieldedOnTeammates {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageTaken {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHeal {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHealOnTeammates {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalTimeCrowdControlDealt {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtPlayer {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtToChampions {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageTaken {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTurretsKilled {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextVisionScore {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardKilled {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardPlaced {get;set;}
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string ValueStats { get; set; } = "TOTAL_DAMAGE_DEALT_TO_CHAMPIONS";

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

            public static void WinTextSubmit()
            {
                EndGameView1Page.formatingData.WinText = textValueOverlayView1.WinText;
            }
            public static void LoseTextSubmit()
            {
                EndGameView1Page.formatingData.LoseText = textValueOverlayView1.LoseText;
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

            public static void ValueStatsSubmit()
            {
                if (textValueOverlayView1.ValueStats.Equals("ASSISTS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextAssist;
                    EndGameView1Page.formatingData.ASSISTS = true;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("BARRACKS_KILLED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextBarracksKilled;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("CHAMPIONS_KILLED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextChampionsKilled;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("GOLD_EARNED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextGoldEarned;
                    EndGameView1Page.formatingData.GOLD_EARNED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("LARGEST_CRITICAL_STRIKE"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextLargestCriticalStrike;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("LARGEST_KILLING_SPREE"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextLargestKillingSpree;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("LARGEST_MULTI_KILL"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextLargestMultiKill;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("LEVEL"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextLevel;
                    EndGameView1Page.formatingData.LEVEL = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("MAGIC_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextMagicDamageDealtPlayer;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextMagicDamageDealtToChampions;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("MAGIC_DAMAGE_TAKEN"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextMagicDamageTaken;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("MINIONS_KILLED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextMinionsKilled;
                    EndGameView1Page.formatingData.MINIONS_KILLED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("NUM_DEATHS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextNumDeaths;
                    EndGameView1Page.formatingData.NUM_DEATHS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextPhysicalDamageDealtPlayer;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextPhysicalDamageDealtToChampions;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("PHYSICAL_DAMAGE_TAKEN"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextPhysicalDamageTaken;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_DEALT"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageDealt;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_BUILDINGS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageDealtToBuildings;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageDealtToChampions;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_OBJECTIVES"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageDealtToObjectives;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_TURRETS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageDealtToTurrets;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_SELF_MITIGATED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageSelfMitigated;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageShieldedOnTeammates;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_DAMAGE_TAKEN"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalDamageTaken;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_HEAL"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalHeal;
                    EndGameView1Page.formatingData.TOTAL_HEAL = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_HEAL_ON_TEAMMATES"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalHealOnTeammates;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TOTAL_TIME_CROWD_CONTROL_DEALT"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTotalTimeCrowdControlDealt;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TRUE_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTrueDamageDealtPlayer;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TRUE_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTrueDamageDealtToChampions;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TRUE_DAMAGE_TAKEN"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTrueDamageTaken;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("TURRETS_KILLED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextTurretsKilled;
                    EndGameView1Page.formatingData.TURRETS_KILLED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("VISION_SCORE"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextVisionScore;
                    EndGameView1Page.formatingData.VISION_SCORE = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("WARD_KILLED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextWardKilled;
                    EndGameView1Page.formatingData.WARD_KILLED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView1.ValueStats.Equals("WARD_PLACED"))
                {
                    EndGameView1Page.formatingData.ChampionInfoText = EndGameView1Page.formatingData.TextWardPlaced;
                    EndGameView1Page.formatingData.WARD_PLACED = true;
                    EndGameView1Page.formatingData.ASSISTS = false;
                    EndGameView1Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView1Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView1Page.formatingData.GOLD_EARNED = false;
                    EndGameView1Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView1Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView1Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView1Page.formatingData.LEVEL = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.MINIONS_KILLED = false;
                    EndGameView1Page.formatingData.NUM_DEATHS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL = false;
                    EndGameView1Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView1Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView1Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView1Page.formatingData.TURRETS_KILLED = false;
                    EndGameView1Page.formatingData.VISION_SCORE = false;
                    EndGameView1Page.formatingData.WARD_KILLED = false;
                }
            }
            public static void TextAssistSubmit()
            {
                EndGameView1Page.formatingData.TextAssist = textValueOverlayView1.TextAssist;
            }

            public static void TextBarracksKilledSubmit()
            {
                EndGameView1Page.formatingData.TextBarracksKilled = textValueOverlayView1.TextBarracksKilled;
            }
            public static void TextChampionsKilledSubmit()
            {
                EndGameView1Page.formatingData.TextChampionsKilled = textValueOverlayView1.TextChampionsKilled;
            }
            public static void TextGoldEarnedSubmit()
            {
                EndGameView1Page.formatingData.TextGoldEarned = textValueOverlayView1.TextGoldEarned;
            }
            public static void TextLargestCriticalStrikeSubmit()
            {
                EndGameView1Page.formatingData.TextLargestCriticalStrike = textValueOverlayView1.TextLargestCriticalStrike;
            }
            public static void TextLargestKillingSpreeSubmit()
            {
                EndGameView1Page.formatingData.TextLargestKillingSpree = textValueOverlayView1.TextLargestKillingSpree;
            }
            public static void TextLargestMultiKillSubmit()
            {
                EndGameView1Page.formatingData.TextLargestMultiKill = textValueOverlayView1.TextLargestMultiKill;
            }
            public static void TextLevelSubmit()
            {
                EndGameView1Page.formatingData.TextLevel = textValueOverlayView1.TextLevel;
            }
            public static void TextMagicDamageDealtPlayerSubmit()
            {
                EndGameView1Page.formatingData.TextMagicDamageDealtPlayer = textValueOverlayView1.TextMagicDamageDealtPlayer;
            }
            public static void TextMagicDamageDealtToChampionsSubmit()
            {
                EndGameView1Page.formatingData.TextMagicDamageDealtToChampions = textValueOverlayView1.TextMagicDamageDealtToChampions;
            }
            public static void TextMagicDamageTakenSubmit()
            {
                EndGameView1Page.formatingData.TextMagicDamageTaken = textValueOverlayView1.TextMagicDamageTaken;
            }
            public static void TextMinionsKilledSubmit()
            {
                EndGameView1Page.formatingData.TextMinionsKilled = textValueOverlayView1.TextMinionsKilled;
            }
            public static void TextNumDeathsSubmit()
            {
                EndGameView1Page.formatingData.TextNumDeaths = textValueOverlayView1.TextNumDeaths;
            }
            public static void TextPhysicalDamageDealtPlayerSubmit()
            {
                EndGameView1Page.formatingData.TextPhysicalDamageDealtPlayer = textValueOverlayView1.TextPhysicalDamageDealtPlayer;
            }
            public static void TextPhysicalDamageDealtToChampionsSubmit()
            {
                EndGameView1Page.formatingData.TextPhysicalDamageDealtToChampions = textValueOverlayView1.TextPhysicalDamageDealtToChampions;
            }
            public static void TextPhysicalDamageTakenSubmit()
            {
                EndGameView1Page.formatingData.TextPhysicalDamageTaken = textValueOverlayView1.TextPhysicalDamageTaken;
            }
            public static void TextTotalDamageDealtSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageDealt = textValueOverlayView1.TextTotalDamageDealt;
            }
            public static void TextTotalDamageDealtToBuildingsSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageDealtToBuildings = textValueOverlayView1.TextTotalDamageDealtToBuildings;
            }
            public static void TextTotalDamageDealtToChampionsSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageDealtToChampions = textValueOverlayView1.TextTotalDamageDealtToChampions;
            }
            public static void TextTotalDamageDealtToObjectivesSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageDealtToObjectives = textValueOverlayView1.TextTotalDamageDealtToObjectives;
            }
            public static void TextTotalDamageDealtToTurretsSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageDealtToTurrets = textValueOverlayView1.TextTotalDamageDealtToTurrets;
            }
            public static void TextTotalDamageSelfMitigatedSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageSelfMitigated = textValueOverlayView1.TextTotalDamageSelfMitigated;
            }
            public static void TextTotalDamageShieldedOnTeammatesSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageShieldedOnTeammates = textValueOverlayView1.TextTotalDamageShieldedOnTeammates;
            }
            public static void TextTotalDamageTakenSubmit()
            {
                EndGameView1Page.formatingData.TextTotalDamageTaken = textValueOverlayView1.TextTotalDamageTaken;
            }
            public static void TextTotalHealSubmit()
            {
                EndGameView1Page.formatingData.TextTotalHeal = textValueOverlayView1.TextTotalHeal;
            }
            public static void TextTotalHealOnTeammatesSubmit()
            {
                EndGameView1Page.formatingData.TextTotalHealOnTeammates = textValueOverlayView1.TextTotalHealOnTeammates;
            }
            public static void TextTotalTimeCrowdControlDealtSubmit()
            {
                EndGameView1Page.formatingData.TextTotalTimeCrowdControlDealt = textValueOverlayView1.TextTotalTimeCrowdControlDealt;
            }
            public static void TextTrueDamageDealtPlayerSubmit()
            {
                EndGameView1Page.formatingData.TextTrueDamageDealtPlayer = textValueOverlayView1.TextTrueDamageDealtPlayer;
            }
            public static void TextTrueDamageDealtToChampionsSubmit()
            {
                EndGameView1Page.formatingData.TextTrueDamageDealtToChampions = textValueOverlayView1.TextTrueDamageDealtToChampions;
            }
            public static void TextTrueDamageTakenSubmit()
            {
                EndGameView1Page.formatingData.TextTrueDamageTaken = textValueOverlayView1.TextTrueDamageTaken;
            }
            public static void TextTurretsKilledSubmit()
            {
                EndGameView1Page.formatingData.TextTurretsKilled = textValueOverlayView1.TextTurretsKilled;
            }
            public static void TextVisionScoreSubmit()
            {
                EndGameView1Page.formatingData.TextVisionScore = textValueOverlayView1.TextVisionScore;
            }
            public static void TextWardKilledSubmit()
            {
                EndGameView1Page.formatingData.TextWardKilled = textValueOverlayView1.TextWardKilled;
            }
            public static void TextWardPlacedSubmit()
            {
                EndGameView1Page.formatingData.TextWardPlaced = textValueOverlayView1.TextWardPlaced;
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
            public string? WinText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? LoseText { get; set; }
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
            public string? TextAssist { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextBarracksKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextChampionsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextGoldEarned { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestCriticalStrike { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestKillingSpree { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestMultiKill { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLevel { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMinionsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextNumDeaths { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealt { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToBuildings { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToObjectives { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToTurrets { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageSelfMitigated { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageShieldedOnTeammates { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHeal { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHealOnTeammates { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalTimeCrowdControlDealt { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTurretsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextVisionScore { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardPlaced { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string ValueStats { get; set; } = "TOTAL_DAMAGE_DEALT_TO_CHAMPIONS";

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

            public static void WinTextSubmit()
            {
                EndGameView2Page.formatingData.WinText = textValueOverlayView2.WinText;
            }
            public static void LoseTextSubmit()
            {
                EndGameView2Page.formatingData.LoseText = textValueOverlayView2.LoseText;
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


            public static void ValueStatsSubmit()
            {
                if (textValueOverlayView2.ValueStats.Equals("ASSISTS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextAssist;
                    EndGameView2Page.formatingData.ASSISTS = true;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("BARRACKS_KILLED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextBarracksKilled;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("CHAMPIONS_KILLED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextChampionsKilled;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("GOLD_EARNED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextGoldEarned;
                    EndGameView2Page.formatingData.GOLD_EARNED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("LARGEST_CRITICAL_STRIKE"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextLargestCriticalStrike;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("LARGEST_KILLING_SPREE"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextLargestKillingSpree;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("LARGEST_MULTI_KILL"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextLargestMultiKill;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("LEVEL"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextLevel;
                    EndGameView2Page.formatingData.LEVEL = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("MAGIC_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextMagicDamageDealtPlayer;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextMagicDamageDealtToChampions;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("MAGIC_DAMAGE_TAKEN"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextMagicDamageTaken;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("MINIONS_KILLED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextMinionsKilled;
                    EndGameView2Page.formatingData.MINIONS_KILLED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("NUM_DEATHS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextNumDeaths;
                    EndGameView2Page.formatingData.NUM_DEATHS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextPhysicalDamageDealtPlayer;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextPhysicalDamageDealtToChampions;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("PHYSICAL_DAMAGE_TAKEN"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextPhysicalDamageTaken;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_DEALT"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageDealt;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_BUILDINGS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageDealtToBuildings;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageDealtToChampions;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_OBJECTIVES"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageDealtToObjectives;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_TURRETS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageDealtToTurrets;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_SELF_MITIGATED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageSelfMitigated;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageShieldedOnTeammates;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_DAMAGE_TAKEN"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalDamageTaken;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_HEAL"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalHeal;
                    EndGameView2Page.formatingData.TOTAL_HEAL = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_HEAL_ON_TEAMMATES"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalHealOnTeammates;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TOTAL_TIME_CROWD_CONTROL_DEALT"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTotalTimeCrowdControlDealt;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TRUE_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTrueDamageDealtPlayer;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TRUE_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTrueDamageDealtToChampions;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TRUE_DAMAGE_TAKEN"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTrueDamageTaken;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("TURRETS_KILLED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextTurretsKilled;
                    EndGameView2Page.formatingData.TURRETS_KILLED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("VISION_SCORE"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextVisionScore;
                    EndGameView2Page.formatingData.VISION_SCORE = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("WARD_KILLED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextWardKilled;
                    EndGameView2Page.formatingData.WARD_KILLED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView2.ValueStats.Equals("WARD_PLACED"))
                {
                    EndGameView2Page.formatingData.ChampionInfoText = EndGameView2Page.formatingData.TextWardPlaced;
                    EndGameView2Page.formatingData.WARD_PLACED = true;
                    EndGameView2Page.formatingData.ASSISTS = false;
                    EndGameView2Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView2Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView2Page.formatingData.GOLD_EARNED = false;
                    EndGameView2Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView2Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView2Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView2Page.formatingData.LEVEL = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.MINIONS_KILLED = false;
                    EndGameView2Page.formatingData.NUM_DEATHS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL = false;
                    EndGameView2Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView2Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView2Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView2Page.formatingData.TURRETS_KILLED = false;
                    EndGameView2Page.formatingData.VISION_SCORE = false;
                    EndGameView2Page.formatingData.WARD_KILLED = false;
                }
            }
            public static void TextAssistSubmit()
            {
                EndGameView2Page.formatingData.TextAssist = textValueOverlayView2.TextAssist;
            }

            public static void TextBarracksKilledSubmit()
            {
                EndGameView2Page.formatingData.TextBarracksKilled = textValueOverlayView2.TextBarracksKilled;
            }
            public static void TextChampionsKilledSubmit()
            {
                EndGameView2Page.formatingData.TextChampionsKilled = textValueOverlayView2.TextChampionsKilled;
            }
            public static void TextGoldEarnedSubmit()
            {
                EndGameView2Page.formatingData.TextGoldEarned = textValueOverlayView2.TextGoldEarned;
            }
            public static void TextLargestCriticalStrikeSubmit()
            {
                EndGameView2Page.formatingData.TextLargestCriticalStrike = textValueOverlayView2.TextLargestCriticalStrike;
            }
            public static void TextLargestKillingSpreeSubmit()
            {
                EndGameView2Page.formatingData.TextLargestKillingSpree = textValueOverlayView2.TextLargestKillingSpree;
            }
            public static void TextLargestMultiKillSubmit()
            {
                EndGameView2Page.formatingData.TextLargestMultiKill = textValueOverlayView2.TextLargestMultiKill;
            }
            public static void TextLevelSubmit()
            {
                EndGameView2Page.formatingData.TextLevel = textValueOverlayView2.TextLevel;
            }
            public static void TextMagicDamageDealtPlayerSubmit()
            {
                EndGameView2Page.formatingData.TextMagicDamageDealtPlayer = textValueOverlayView2.TextMagicDamageDealtPlayer;
            }
            public static void TextMagicDamageDealtToChampionsSubmit()
            {
                EndGameView2Page.formatingData.TextMagicDamageDealtToChampions = textValueOverlayView2.TextMagicDamageDealtToChampions;
            }
            public static void TextMagicDamageTakenSubmit()
            {
                EndGameView2Page.formatingData.TextMagicDamageTaken = textValueOverlayView2.TextMagicDamageTaken;
            }
            public static void TextMinionsKilledSubmit()
            {
                EndGameView2Page.formatingData.TextMinionsKilled = textValueOverlayView2.TextMinionsKilled;
            }
            public static void TextNumDeathsSubmit()
            {
                EndGameView2Page.formatingData.TextNumDeaths = textValueOverlayView2.TextNumDeaths;
            }
            public static void TextPhysicalDamageDealtPlayerSubmit()
            {
                EndGameView2Page.formatingData.TextPhysicalDamageDealtPlayer = textValueOverlayView2.TextPhysicalDamageDealtPlayer;
            }
            public static void TextPhysicalDamageDealtToChampionsSubmit()
            {
                EndGameView2Page.formatingData.TextPhysicalDamageDealtToChampions = textValueOverlayView2.TextPhysicalDamageDealtToChampions;
            }
            public static void TextPhysicalDamageTakenSubmit()
            {
                EndGameView2Page.formatingData.TextPhysicalDamageTaken = textValueOverlayView2.TextPhysicalDamageTaken;
            }
            public static void TextTotalDamageDealtSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageDealt = textValueOverlayView2.TextTotalDamageDealt;
            }
            public static void TextTotalDamageDealtToBuildingsSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageDealtToBuildings = textValueOverlayView2.TextTotalDamageDealtToBuildings;
            }
            public static void TextTotalDamageDealtToChampionsSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageDealtToChampions = textValueOverlayView2.TextTotalDamageDealtToChampions;
            }
            public static void TextTotalDamageDealtToObjectivesSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageDealtToObjectives = textValueOverlayView2.TextTotalDamageDealtToObjectives;
            }
            public static void TextTotalDamageDealtToTurretsSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageDealtToTurrets = textValueOverlayView2.TextTotalDamageDealtToTurrets;
            }
            public static void TextTotalDamageSelfMitigatedSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageSelfMitigated = textValueOverlayView2.TextTotalDamageSelfMitigated;
            }
            public static void TextTotalDamageShieldedOnTeammatesSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageShieldedOnTeammates = textValueOverlayView2.TextTotalDamageShieldedOnTeammates;
            }
            public static void TextTotalDamageTakenSubmit()
            {
                EndGameView2Page.formatingData.TextTotalDamageTaken = textValueOverlayView2.TextTotalDamageTaken;
            }
            public static void TextTotalHealSubmit()
            {
                EndGameView2Page.formatingData.TextTotalHeal = textValueOverlayView2.TextTotalHeal;
            }
            public static void TextTotalHealOnTeammatesSubmit()
            {
                EndGameView2Page.formatingData.TextTotalHealOnTeammates = textValueOverlayView2.TextTotalHealOnTeammates;
            }
            public static void TextTotalTimeCrowdControlDealtSubmit()
            {
                EndGameView2Page.formatingData.TextTotalTimeCrowdControlDealt = textValueOverlayView2.TextTotalTimeCrowdControlDealt;
            }
            public static void TextTrueDamageDealtPlayerSubmit()
            {
                EndGameView2Page.formatingData.TextTrueDamageDealtPlayer = textValueOverlayView2.TextTrueDamageDealtPlayer;
            }
            public static void TextTrueDamageDealtToChampionsSubmit()
            {
                EndGameView2Page.formatingData.TextTrueDamageDealtToChampions = textValueOverlayView2.TextTrueDamageDealtToChampions;
            }
            public static void TextTrueDamageTakenSubmit()
            {
                EndGameView2Page.formatingData.TextTrueDamageTaken = textValueOverlayView2.TextTrueDamageTaken;
            }
            public static void TextTurretsKilledSubmit()
            {
                EndGameView2Page.formatingData.TextTurretsKilled = textValueOverlayView2.TextTurretsKilled;
            }
            public static void TextVisionScoreSubmit()
            {
                EndGameView2Page.formatingData.TextVisionScore = textValueOverlayView2.TextVisionScore;
            }
            public static void TextWardKilledSubmit()
            {
                EndGameView2Page.formatingData.TextWardKilled = textValueOverlayView2.TextWardKilled;
            }
            public static void TextWardPlacedSubmit()
            {
                EndGameView2Page.formatingData.TextWardPlaced = textValueOverlayView2.TextWardPlaced;
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
            public string? WinText { get; set; }
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? LoseText { get; set; }
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
            public string? TextAssist { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextBarracksKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextChampionsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextGoldEarned { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestCriticalStrike { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestKillingSpree { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLargestMultiKill { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextLevel { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMagicDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextMinionsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextNumDeaths { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextPhysicalDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealt { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToBuildings { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToObjectives { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageDealtToTurrets { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageSelfMitigated { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageShieldedOnTeammates { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHeal { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalHealOnTeammates { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTotalTimeCrowdControlDealt { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtPlayer { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageDealtToChampions { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTrueDamageTaken { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextTurretsKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextVisionScore { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardKilled { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string? TextWardPlaced { get; set; }
            [StringLength(40, ErrorMessage = "Text is too long (40 character limit).")]
            public string ValueStats { get; set; } = "TOTAL_DAMAGE_DEALT_TO_CHAMPIONS";


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

            public static void WinTextSubmit()
            {
                EndGameView3Page.formatingData.WinText = textValueOverlayView3.WinText;
            }
            public static void LoseTextSubmit()
            {
                EndGameView3Page.formatingData.LoseText = textValueOverlayView3.LoseText;
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

            public static void ValueStatsSubmit()
            {
                if (textValueOverlayView3.ValueStats.Equals("ASSISTS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextAssist;
                    EndGameView3Page.formatingData.ASSISTS = true;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("BARRACKS_KILLED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextBarracksKilled;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("CHAMPIONS_KILLED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextChampionsKilled;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("GOLD_EARNED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextGoldEarned;
                    EndGameView3Page.formatingData.GOLD_EARNED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("LARGEST_CRITICAL_STRIKE"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextLargestCriticalStrike;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("LARGEST_KILLING_SPREE"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextLargestKillingSpree;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("LARGEST_MULTI_KILL"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextLargestMultiKill;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("LEVEL"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextLevel;
                    EndGameView3Page.formatingData.LEVEL = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("MAGIC_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextMagicDamageDealtPlayer;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextMagicDamageDealtToChampions;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("MAGIC_DAMAGE_TAKEN"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextMagicDamageTaken;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("MINIONS_KILLED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextMinionsKilled;
                    EndGameView3Page.formatingData.MINIONS_KILLED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("NUM_DEATHS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextNumDeaths;
                    EndGameView3Page.formatingData.NUM_DEATHS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextPhysicalDamageDealtPlayer;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextPhysicalDamageDealtToChampions;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("PHYSICAL_DAMAGE_TAKEN"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextPhysicalDamageTaken;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_DEALT"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageDealt;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_BUILDINGS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageDealtToBuildings;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageDealtToChampions;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_OBJECTIVES"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageDealtToObjectives;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_DEALT_TO_TURRETS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageDealtToTurrets;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_SELF_MITIGATED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageSelfMitigated;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageShieldedOnTeammates;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_DAMAGE_TAKEN"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalDamageTaken;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_HEAL"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalHeal;
                    EndGameView3Page.formatingData.TOTAL_HEAL = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_HEAL_ON_TEAMMATES"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalHealOnTeammates;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TOTAL_TIME_CROWD_CONTROL_DEALT"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTotalTimeCrowdControlDealt;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TRUE_DAMAGE_DEALT_PLAYER"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTrueDamageDealtPlayer;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TRUE_DAMAGE_DEALT_TO_CHAMPIONS"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTrueDamageDealtToChampions;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TRUE_DAMAGE_TAKEN"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTrueDamageTaken;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("TURRETS_KILLED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextTurretsKilled;
                    EndGameView3Page.formatingData.TURRETS_KILLED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("VISION_SCORE"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextVisionScore;
                    EndGameView3Page.formatingData.VISION_SCORE = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("WARD_KILLED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextWardKilled;
                    EndGameView3Page.formatingData.WARD_KILLED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_PLACED = false;
                }
                else if (textValueOverlayView3.ValueStats.Equals("WARD_PLACED"))
                {
                    EndGameView3Page.formatingData.ChampionInfoText = EndGameView3Page.formatingData.TextWardPlaced;
                    EndGameView3Page.formatingData.WARD_PLACED = true;
                    EndGameView3Page.formatingData.ASSISTS = false;
                    EndGameView3Page.formatingData.BARRACKS_KILLED = false;
                    EndGameView3Page.formatingData.CHAMPIONS_KILLED = false;
                    EndGameView3Page.formatingData.GOLD_EARNED = false;
                    EndGameView3Page.formatingData.LARGEST_CRITICAL_STRIKE = false;
                    EndGameView3Page.formatingData.LARGEST_KILLING_SPREE = false;
                    EndGameView3Page.formatingData.LARGEST_MULTI_KILL = false;
                    EndGameView3Page.formatingData.LEVEL = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.MAGIC_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.MINIONS_KILLED = false;
                    EndGameView3Page.formatingData.NUM_DEATHS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.PHYSICAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_BUILDINGS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_OBJECTIVES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_DEALT_TO_TURRETS = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SELF_MITIGATED = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_SHIELDED_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL = false;
                    EndGameView3Page.formatingData.TOTAL_HEAL_ON_TEAMMATES = false;
                    EndGameView3Page.formatingData.TOTAL_TIME_CROWD_CONTROL_DEALT = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_PLAYER = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_DEALT_TO_CHAMPIONS = false;
                    EndGameView3Page.formatingData.TRUE_DAMAGE_TAKEN = false;
                    EndGameView3Page.formatingData.TURRETS_KILLED = false;
                    EndGameView3Page.formatingData.VISION_SCORE = false;
                    EndGameView3Page.formatingData.WARD_KILLED = false;
                }
            }
            public static void TextAssistSubmit()
            {
                EndGameView3Page.formatingData.TextAssist = textValueOverlayView3.TextAssist;
            }

            public static void TextBarracksKilledSubmit()
            {
                EndGameView3Page.formatingData.TextBarracksKilled = textValueOverlayView3.TextBarracksKilled;
            }
            public static void TextChampionsKilledSubmit()
            {
                EndGameView3Page.formatingData.TextChampionsKilled = textValueOverlayView3.TextChampionsKilled;
            }
            public static void TextGoldEarnedSubmit()
            {
                EndGameView3Page.formatingData.TextGoldEarned = textValueOverlayView3.TextGoldEarned;
            }
            public static void TextLargestCriticalStrikeSubmit()
            {
                EndGameView3Page.formatingData.TextLargestCriticalStrike = textValueOverlayView3.TextLargestCriticalStrike;
            }
            public static void TextLargestKillingSpreeSubmit()
            {
                EndGameView3Page.formatingData.TextLargestKillingSpree = textValueOverlayView3.TextLargestKillingSpree;
            }
            public static void TextLargestMultiKillSubmit()
            {
                EndGameView3Page.formatingData.TextLargestMultiKill = textValueOverlayView3.TextLargestMultiKill;
            }
            public static void TextLevelSubmit()
            {
                EndGameView3Page.formatingData.TextLevel = textValueOverlayView3.TextLevel;
            }
            public static void TextMagicDamageDealtPlayerSubmit()
            {
                EndGameView3Page.formatingData.TextMagicDamageDealtPlayer = textValueOverlayView3.TextMagicDamageDealtPlayer;
            }
            public static void TextMagicDamageDealtToChampionsSubmit()
            {
                EndGameView3Page.formatingData.TextMagicDamageDealtToChampions = textValueOverlayView3.TextMagicDamageDealtToChampions;
            }
            public static void TextMagicDamageTakenSubmit()
            {
                EndGameView3Page.formatingData.TextMagicDamageTaken = textValueOverlayView3.TextMagicDamageTaken;
            }
            public static void TextMinionsKilledSubmit()
            {
                EndGameView3Page.formatingData.TextMinionsKilled = textValueOverlayView3.TextMinionsKilled;
            }
            public static void TextNumDeathsSubmit()
            {
                EndGameView3Page.formatingData.TextNumDeaths = textValueOverlayView3.TextNumDeaths;
            }
            public static void TextPhysicalDamageDealtPlayerSubmit()
            {
                EndGameView3Page.formatingData.TextPhysicalDamageDealtPlayer = textValueOverlayView3.TextPhysicalDamageDealtPlayer;
            }
            public static void TextPhysicalDamageDealtToChampionsSubmit()
            {
                EndGameView3Page.formatingData.TextPhysicalDamageDealtToChampions = textValueOverlayView3.TextPhysicalDamageDealtToChampions;
            }
            public static void TextPhysicalDamageTakenSubmit()
            {
                EndGameView3Page.formatingData.TextPhysicalDamageTaken = textValueOverlayView3.TextPhysicalDamageTaken;
            }
            public static void TextTotalDamageDealtSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageDealt = textValueOverlayView3.TextTotalDamageDealt;
            }
            public static void TextTotalDamageDealtToBuildingsSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageDealtToBuildings = textValueOverlayView3.TextTotalDamageDealtToBuildings;
            }
            public static void TextTotalDamageDealtToChampionsSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageDealtToChampions = textValueOverlayView3.TextTotalDamageDealtToChampions;
            }
            public static void TextTotalDamageDealtToObjectivesSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageDealtToObjectives = textValueOverlayView3.TextTotalDamageDealtToObjectives;
            }
            public static void TextTotalDamageDealtToTurretsSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageDealtToTurrets = textValueOverlayView3.TextTotalDamageDealtToTurrets;
            }
            public static void TextTotalDamageSelfMitigatedSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageSelfMitigated = textValueOverlayView3.TextTotalDamageSelfMitigated;
            }
            public static void TextTotalDamageShieldedOnTeammatesSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageShieldedOnTeammates = textValueOverlayView3.TextTotalDamageShieldedOnTeammates;
            }
            public static void TextTotalDamageTakenSubmit()
            {
                EndGameView3Page.formatingData.TextTotalDamageTaken = textValueOverlayView3.TextTotalDamageTaken;
            }
            public static void TextTotalHealSubmit()
            {
                EndGameView3Page.formatingData.TextTotalHeal = textValueOverlayView3.TextTotalHeal;
            }
            public static void TextTotalHealOnTeammatesSubmit()
            {
                EndGameView3Page.formatingData.TextTotalHealOnTeammates = textValueOverlayView3.TextTotalHealOnTeammates;
            }
            public static void TextTotalTimeCrowdControlDealtSubmit()
            {
                EndGameView3Page.formatingData.TextTotalTimeCrowdControlDealt = textValueOverlayView3.TextTotalTimeCrowdControlDealt;
            }
            public static void TextTrueDamageDealtPlayerSubmit()
            {
                EndGameView3Page.formatingData.TextTrueDamageDealtPlayer = textValueOverlayView3.TextTrueDamageDealtPlayer;
            }
            public static void TextTrueDamageDealtToChampionsSubmit()
            {
                EndGameView3Page.formatingData.TextTrueDamageDealtToChampions = textValueOverlayView3.TextTrueDamageDealtToChampions;
            }
            public static void TextTrueDamageTakenSubmit()
            {
                EndGameView3Page.formatingData.TextTrueDamageTaken = textValueOverlayView3.TextTrueDamageTaken;
            }
            public static void TextTurretsKilledSubmit()
            {
                EndGameView3Page.formatingData.TextTurretsKilled = textValueOverlayView3.TextTurretsKilled;
            }
            public static void TextVisionScoreSubmit()
            {
                EndGameView3Page.formatingData.TextVisionScore = textValueOverlayView3.TextVisionScore;
            }
            public static void TextWardKilledSubmit()
            {
                EndGameView3Page.formatingData.TextWardKilled = textValueOverlayView3.TextWardKilled;
            }
            public static void TextWardPlacedSubmit()
            {
                EndGameView3Page.formatingData.TextWardPlaced = textValueOverlayView3.TextWardPlaced;
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
