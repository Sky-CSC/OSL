using OSL_Common.System.Logging;
using System.ComponentModel.DataAnnotations;

namespace OSL_Web.Pages.InGame
{
    public partial class InGamePage
    {
        private static Logger _logger = new("InGamePage");

        public static string colorPickerOverlay1 = "hidden";
        public static string colorPickerOverlay1_1 = "hidden";
        public static string colorPickerOverlay2 = "hidden";
        public static string colorPickerOverlay3 = "hidden";
        public static string colorValue = "#0000";
        public class TextValueOverlayView1
        {
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? BlueTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? BlueTeamScoreText { get; set; }
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? RedTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? RedTeamScoreText { get; set; }

            public bool DisplayDragonTimer { get; set; } = true;

            public static void BlueTeamTextSubmit()
            {
                InGameView1Page.formatingData.BlueTeamText = textValueOverlayView1.BlueTeamText;
            }

            public static void BlueTeamScoreTextSubmit()
            {
                InGameView1Page.formatingData.BlueTeamScoreText = textValueOverlayView1.BlueTeamScoreText;
            }
            public static void RedTeamTextSubmit()
            {
                InGameView1Page.formatingData.RedTeamText = textValueOverlayView1.RedTeamText;
            }
            public static void RedTeamScoreTextSubmit()
            {
                InGameView1Page.formatingData.RedTeamScoreText = textValueOverlayView1.RedTeamScoreText;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsBlueTeamText = InGameView1Page.formatingData.BlueTeamText;
                string tempsBlueTeamScoreText = InGameView1Page.formatingData.BlueTeamScoreText;
                string tempsRedTeamText = InGameView1Page.formatingData.RedTeamText;
                string tempsRedTeamScoreText = InGameView1Page.formatingData.RedTeamScoreText;
                string tempsTextValueOverlayView1BlueTeamText = textValueOverlayView1.BlueTeamText;
                string tempsTextValueOverlayView1BlueTeamScoreText = textValueOverlayView1.BlueTeamScoreText;
                string tempsTextValueOverlayView1RedTeamText = textValueOverlayView1.RedTeamText;
                string tempsTextValueOverlayView1RedTeamScoreText = textValueOverlayView1.RedTeamScoreText;
                InGameView1Page.formatingData.BlueTeamText = tempsRedTeamText;
                InGameView1Page.formatingData.BlueTeamScoreText = tempsRedTeamScoreText;
                InGameView1Page.formatingData.RedTeamText = tempsBlueTeamText;
                InGameView1Page.formatingData.RedTeamScoreText = tempsBlueTeamScoreText;
                textValueOverlayView1.BlueTeamText = tempsTextValueOverlayView1RedTeamText;
                textValueOverlayView1.BlueTeamScoreText = tempsTextValueOverlayView1RedTeamScoreText;
                textValueOverlayView1.RedTeamText = tempsTextValueOverlayView1BlueTeamText;
                textValueOverlayView1.RedTeamScoreText = tempsTextValueOverlayView1BlueTeamScoreText;
            }

            public static void InputCheckboxSubmit()
            {

            }

            public static void SetColorBlueTeamScoreText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1Page.formatingData.ColorBlueTeamScoreText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1Page.formatingData.ColorBlueTeamScoreText = colorValue;
                }
            }

            public static void SetColorBlueTeamText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1Page.formatingData.ColorBlueTeamText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1Page.formatingData.ColorBlueTeamText = colorValue;
                }
            }

            public static void SetColorRedTeamScoreText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1Page.formatingData.ColorRedTeamScoreText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1Page.formatingData.ColorRedTeamScoreText = colorValue;
                }
            }

            public static void SetColorRedTeamText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1Page.formatingData.ColorRedTeamText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1Page.formatingData.ColorRedTeamText = colorValue;
                }
            }

        }

        public class TextValueOverlayView1_1
        {
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? BlueTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? BlueTeamScoreText { get; set; }
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? RedTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? RedTeamScoreText { get; set; }

            public bool DisplayDragonTimer { get; set; } = true;

            public static void BlueTeamTextSubmit()
            {
                InGameView1_1Page.formatingData.BlueTeamText = textValueOverlayView1_1.BlueTeamText;
            }

            public static void BlueTeamScoreTextSubmit()
            {
                InGameView1_1Page.formatingData.BlueTeamScoreText = textValueOverlayView1_1.BlueTeamScoreText;
            }
            public static void RedTeamTextSubmit()
            {
                InGameView1_1Page.formatingData.RedTeamText = textValueOverlayView1_1.RedTeamText;
            }
            public static void RedTeamScoreTextSubmit()
            {
                InGameView1_1Page.formatingData.RedTeamScoreText = textValueOverlayView1_1.RedTeamScoreText;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsBlueTeamText = InGameView1_1Page.formatingData.BlueTeamText;
                string tempsBlueTeamScoreText = InGameView1_1Page.formatingData.BlueTeamScoreText;
                string tempsRedTeamText = InGameView1_1Page.formatingData.RedTeamText;
                string tempsRedTeamScoreText = InGameView1_1Page.formatingData.RedTeamScoreText;
                string tempsTextValueOverlayView1_1BlueTeamText = textValueOverlayView1_1.BlueTeamText;
                string tempsTextValueOverlayView1_1BlueTeamScoreText = textValueOverlayView1_1.BlueTeamScoreText;
                string tempsTextValueOverlayView1_1RedTeamText = textValueOverlayView1_1.RedTeamText;
                string tempsTextValueOverlayView1_1RedTeamScoreText = textValueOverlayView1_1.RedTeamScoreText;
                InGameView1_1Page.formatingData.BlueTeamText = tempsRedTeamText;
                InGameView1_1Page.formatingData.BlueTeamScoreText = tempsRedTeamScoreText;
                InGameView1_1Page.formatingData.RedTeamText = tempsBlueTeamText;
                InGameView1_1Page.formatingData.RedTeamScoreText = tempsBlueTeamScoreText;
                textValueOverlayView1_1.BlueTeamText = tempsTextValueOverlayView1_1RedTeamText;
                textValueOverlayView1_1.BlueTeamScoreText = tempsTextValueOverlayView1_1RedTeamScoreText;
                textValueOverlayView1_1.RedTeamText = tempsTextValueOverlayView1_1BlueTeamText;
                textValueOverlayView1_1.RedTeamScoreText = tempsTextValueOverlayView1_1BlueTeamScoreText;
            }

            public static void InputCheckboxSubmit()
            {

            }

            public static void SetColorBlueTeamScoreText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1_1Page.formatingData.ColorBlueTeamScoreText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1_1Page.formatingData.ColorBlueTeamScoreText = colorValue;
                }
            }

            public static void SetColorBlueTeamText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1_1Page.formatingData.ColorBlueTeamText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1_1Page.formatingData.ColorBlueTeamText = colorValue;
                }
            }

            public static void SetColorRedTeamScoreText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1_1Page.formatingData.ColorRedTeamScoreText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1_1Page.formatingData.ColorRedTeamScoreText = colorValue;
                }
            }

            public static void SetColorRedTeamText()
            {
                if (colorPickerOverlay1.Equals("hidden"))
                {
                    colorPickerOverlay1 = "visible";
                    colorValue = InGameView1_1Page.formatingData.ColorRedTeamText;
                }
                else
                {
                    colorPickerOverlay1 = "hidden";
                    InGameView1_1Page.formatingData.ColorRedTeamText = colorValue;
                }
            }

        }

        public class TextValueOverlayView2
        {
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? BlueTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? BlueTeamScoreText { get; set; }
            [StringLength(37, ErrorMessage = "Name is too long (37 character limit).")]
            public string? RedTeamText { get; set; }
            [StringLength(7, ErrorMessage = "Name is too long (7 character limit).")]
            public string? RedTeamScoreText { get; set; }

            public bool DisplayDragonTimer { get; set; } = true;

            public static void BlueTeamTextSubmit()
            {
                InGameView2Page.formatingData.BlueTeamText = textValueOverlayView2.BlueTeamText;
            }

            public static void BlueTeamScoreTextSubmit()
            {
                InGameView2Page.formatingData.BlueTeamScoreText = textValueOverlayView2.BlueTeamScoreText;
            }
            public static void RedTeamTextSubmit()
            {
                InGameView2Page.formatingData.RedTeamText = textValueOverlayView2.RedTeamText;
            }
            public static void RedTeamScoreTextSubmit()
            {
                InGameView2Page.formatingData.RedTeamScoreText = textValueOverlayView2.RedTeamScoreText;
            }
            public static void SwitchSideRedBlue()
            {
                string tempsBlueTeamText = InGameView2Page.formatingData.BlueTeamText;
                string tempsBlueTeamScoreText = InGameView2Page.formatingData.BlueTeamScoreText;
                string tempsRedTeamText = InGameView2Page.formatingData.RedTeamText;
                string tempsRedTeamScoreText = InGameView2Page.formatingData.RedTeamScoreText;
                string tempsTextValueOverlayView2BlueTeamText = textValueOverlayView2.BlueTeamText;
                string tempsTextValueOverlayView2BlueTeamScoreText = textValueOverlayView2.BlueTeamScoreText;
                string tempsTextValueOverlayView2RedTeamText = textValueOverlayView2.RedTeamText;
                string tempsTextValueOverlayView2RedTeamScoreText = textValueOverlayView2.RedTeamScoreText;
                InGameView2Page.formatingData.BlueTeamText = tempsRedTeamText;
                InGameView2Page.formatingData.BlueTeamScoreText = tempsRedTeamScoreText;
                InGameView2Page.formatingData.RedTeamText = tempsBlueTeamText;
                InGameView2Page.formatingData.RedTeamScoreText = tempsBlueTeamScoreText;
                textValueOverlayView2.BlueTeamText = tempsTextValueOverlayView2RedTeamText;
                textValueOverlayView2.BlueTeamScoreText = tempsTextValueOverlayView2RedTeamScoreText;
                textValueOverlayView2.RedTeamText = tempsTextValueOverlayView2BlueTeamText;
                textValueOverlayView2.RedTeamScoreText = tempsTextValueOverlayView2BlueTeamScoreText;
            }

            public static void InputCheckboxSubmit()
            {

            }

            public static void SetColorBlueTeamScoreText()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = InGameView2Page.formatingData.ColorBlueTeamScoreText;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    InGameView2Page.formatingData.ColorBlueTeamScoreText = colorValue;
                }
            }

            public static void SetColorBlueTeamText()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = InGameView2Page.formatingData.ColorBlueTeamText;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    InGameView2Page.formatingData.ColorBlueTeamText = colorValue;
                }
            }

            public static void SetColorRedTeamScoreText()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = InGameView2Page.formatingData.ColorRedTeamScoreText;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    InGameView2Page.formatingData.ColorRedTeamScoreText = colorValue;
                }
            }

            public static void SetColorRedTeamText()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = InGameView2Page.formatingData.ColorRedTeamText;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    InGameView2Page.formatingData.ColorRedTeamText = colorValue;
                }
            }
        }
        public class TextValueOverlayView3
        {
            [StringLength(9, ErrorMessage = "Name is too long (9 character limit).")]
            public string? ReplayInfoText { get; set; }



            public static void ReplayInfoTextSubmit()
            {
                InGameView3Page.formatingData.ReplayInfoText = textValueOverlayView3.ReplayInfoText;
            }
            public static void SetColorReplayInfoText()
            {
                if (colorPickerOverlay2.Equals("hidden"))
                {
                    colorPickerOverlay2 = "visible";
                    colorValue = InGameView3Page.formatingData.ColorReplayInfoText;
                }
                else
                {
                    colorPickerOverlay2 = "hidden";
                    InGameView3Page.formatingData.ColorReplayInfoText = colorValue;
                }
            }

            public static void InputCheckboxSubmit()
            {

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
        private OverlayViewEnableOrDisable displayContentView1_1Button = new("display", "#008000");
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

        private string displayContentView1_1 = "none";
        private void HideOrDisplayContentView1_1()
        {
            if (displayContentView1_1.Equals("none"))
            {
                displayContentView1_1Button.text = "hide";
                displayContentView1_1Button.color = "#be1e37";
                displayContentView1_1 = "content";
            }
            else
            {
                displayContentView1_1Button.text = "display";
                displayContentView1_1Button.color = "#008000";
                displayContentView1_1 = "none";
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
    }
}
