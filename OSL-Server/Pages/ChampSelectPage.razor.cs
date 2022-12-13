using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

using System.ComponentModel.DataAnnotations;

namespace OSL_Server.Pages
{
    public partial class ChampSelectPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");
        public static string linkOverlayChampSelect = "";
        public static string champ = "./default-square.png";
        public static string champBan1;
        //private static void LinkGenerator()
        //{

        //    linkOverlayChampSelect = "tesmps";
        //}

        public static string ColorPickerOverlay1 = "hidden";
        public static string ColorPickerOverlay2 = "hidden";
        public static string ColorPickerOverlay3 = "hidden";
        public static string colorValue = "#0000";

        public class ChampSelectOverlayText
        {
            //[Required]
            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? BlueSideTeamName1 { get; set; }
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? BlueSideTeamName2 { get; set; }
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? BlueSideTeamName3 { get; set; }


            [StringLength(20, ErrorMessage = "Name is too long (20 character limit).")]
            public string? RedSideTeamName1 { get; set; }
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? RedSideTeamName2 { get; set; }
            [StringLength(11, ErrorMessage = "Name is too long (11 character limit).")]
            public string? RedSideTeamName3 { get; set; }


            [StringLength(30, ErrorMessage = "Name is too long (30 character limit).")]
            public string? BlueTeamSubtext { get; set; }
            [StringLength(30, ErrorMessage = "Name is too long (30 character limit).")]
            public string? RedTeamSubtext { get; set; }

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideBorderColor { get; set; } = 5;

            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int BlueSideTimerBorderColor { get; set; } = 5;
            [Required]
            [Range(0, 10, ErrorMessage = "Accommodation invalid (1-10).")]
            public int RedSideTimerBorderColor { get; set; } = 5;

            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int KeystonePickColorDeg2 { get; set; } = 150;
            [Required]
            [Range(-360, 360, ErrorMessage = "Accommodation invalid (-360-360).")]
            public int KeystonePickColorDeg3 { get; set; } = 150;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent12 { get; set; } = 0;
            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent13 { get; set; } = 0;

            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent22 { get; set; } = 100;
            [Required]
            [Range(0, 100, ErrorMessage = "Accommodation invalid (0-100).")]
            public int KeystonePickColorPercent23 { get; set; } = 100;

            public bool OverlayBackground { get; set; } = true;
            public bool DisplaySummonerSpell { get; set; } = false;
        }

        private string TempsBlueSideBorderColor()
        {
            string[] tempsBorderColor = ChampSelectView1Page.BlueSideBorderColor.Split(" ");
            return tempsBorderColor[2];
        }

        private string TempsRedSideBorderColor()
        {
            string[] tempsBorderColor = ChampSelectView1Page.RedSideBorderColor.Split(" ");
            return tempsBorderColor[2];
        }

        private string TempsBlueSideTimerBorderColor()
        {
            string[] tempsBorderColor = ChampSelectView1Page.BlueSideTimerBorderColor.Split(" ");
            return tempsBorderColor[2];
        }

        private string TempsRedSideTimerBorderColor()
        {
            string[] tempsBorderColor = ChampSelectView1Page.RedSideTimerBorderColor.Split(" ");
            return tempsBorderColor[2];
        }

        //private ExampleModel exampleModel = new();

        //private void GetBlueSideTeamName() {
        //    var saisie = 
        //}

        public static void DisplayInfo()
        {
            //Console.WriteLine(JsonConvert.SerializeObject(ChampSelectInfo.session, Formatting.Indented));
            //Console.WriteLine(ChampSelectInfo.session.Bans.MyTeamBans[0]);
            //if (ChampSelectInfo.session.Bans.MyTeamBans[0] == 432)
            //{
            //    Console.WriteLine(Directory.GetCurrentDirectory());
            //    champ = "../wwroot/assets/12.12/fr_fr/Champions/432/default-square.png";
            //    Console.WriteLine(File.Exists(champ));
            //}

            //foreach (var item in ChampSelectInfo.session.Bans.MyTeamBans)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach(var item in ChampSelectInfo.session.Bans.TheirTeamBans)
            //{
            //    Console.WriteLine(item);
            //}


            //foreach(var chamPick in ChampSelectInfo.session.MyTeam)
            //{

            //}
        }
        private string view1Enable = "";
        private string view1EnableColor = "";
        private string view2Enable = "";
        private string view2EnableColor = "";
        private string view3Enable = "";
        private string view3EnableColor = "";
        private void TexteOverlayView1()
        {
            if (ChampSelectView1Page.overlayLoaded == true)
            {
                view1Enable = "Disable";
                view1EnableColor = "#be1e37";
            }
            else
            {
                view1Enable = "Enable";
                view1EnableColor = "#0b849e";
            }
        }

        private void EnableOverlayView1()
        {
            if (ChampSelectView1Page.overlayLoaded == false)
            {
                ChampSelectView1Page.overlayLoaded = true;
            }
            else
            {
                ChampSelectView1Page.overlayLoaded = false;
            }
            //StateHasChanged();
        }

        private void TexteOverlayView2()
        {
            if (ChampSelectView2Page.overlayLoaded == true)
            {
                view2Enable = "Disable";
                view2EnableColor = "#be1e37";
            }
            else
            {
                view2Enable = "Enable";
                view2EnableColor = "#0b849e";
            }
        }

        private void EnableOverlayView2()
        {
            if (ChampSelectView2Page.overlayLoaded == false)
            {
                ChampSelectView2Page.overlayLoaded = true;
            }
            else
            {
                ChampSelectView2Page.overlayLoaded = false;
            }
            //StateHasChanged();
        }

        private void TexteOverlayView3()
        {
            if (ChampSelectView3Page.overlayLoaded == true)
            {
                view3Enable = "Disable";
                view3EnableColor = "#be1e37";
            }
            else
            {
                view3Enable = "Enable";
                view3EnableColor = "#0b849e";
            }
        }

        private void EnableOverlayView3()
        {
            if (ChampSelectView3Page.overlayLoaded == false)
            {
                ChampSelectView3Page.overlayLoaded = true;
            }
            else
            {
                ChampSelectView3Page.overlayLoaded = false;
            }
            //StateHasChanged();
        }
    }
}
