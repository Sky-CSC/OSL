using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Pages
{
    public partial class ChampSelectView1Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView1Page");

        public static bool overlayLoaded = false;

        //Personalisation Patch and Region
        public static string DefaultPatch = "latest";
        public static string DefaultRegion = "fr_fr";

        //Personalisation Blue side
        public static string BlueSideTeamName = "";
        public static string BlueSideTeamNameSave = "";
        public static string BlueTeamSubtext = "";
        public static string BlueTeamSubtextSave = "";
        public static string BlueTeamNameColor = "#ffffff";
        public static string BlueTeamNameColorSave = "#ffffff";
        public static string BlueTeamSubtextColor = "#ffffff";
        public static string BlueTeamSubtextColorSave = "#ffffff";
        public static string BlueLogo = "";
        public static string BlueLogoSave = "";
        public static string BlueSideTexteColor = "#ffffff";
        public static string BlueSideTexteColorSave = "#ffffff";
        public static string BlueSideBackgroudColor = "#0b849e";
        public static string BlueSideBackgroudColorSave = "#0b849e";
        public static string BlueSideBorderColor = "5px solid yellow";
        public static string BlueSideBorderColorSave = "5px solid yellow";
        public static string BlueSideTimerBackgroudColor = "#0b849e";
        public static string BlueSideTimerBackgroudColorSave = "#0b849e";
        public static string BlueSideTimerBorderColor = "5px solid blue";
        public static string BlueSideTimerBorderColorSave = "5px solid blue";
        public static string BlueSideTimerTexteColor = "#ffffff";
        public static string BlueSideTimerTexteColorSave = "#ffffff";

        //Personalisation Red side
        public static string RedSideTeamName = "";
        public static string RedSideTeamNameSave = "";
        public static string RedTeamSubtext = "";
        public static string RedTeamSubtextSave = "";
        public static string RedTeamNameColor = "#ffffff";
        public static string RedTeamNameColorSave = "#ffffff";
        public static string RedTeamSubtextColor = "#ffffff";
        public static string RedTeamSubtextColorSave = "#ffffff";
        public static string RedLogo = "";
        public static string RedLogoSave = "";
        public static string RedSideTexteColor = "#ffffff";
        public static string RedSideTexteColorSave = "#ffffff";
        public static string RedSideBackgroudColor = "#be1e37";
        public static string RedSideBackgroudColorSave = "#be1e37";
        public static string RedSideBorderColor = "5px solid yellow";
        public static string RedSideBorderColorSave = "5px solid yellow";
        public static string RedSideTimerBackgroudColor = "#be1e37";
        public static string RedSideTimerBackgroudColorSave = "#be1e37";
        public static string RedSideTimerBorderColor = "5px solid red";
        public static string RedSideTimerBorderColorSave = "5px solid red";
        public static string RedSideTimerTexteColor = "#ffffff";
        public static string RedSideTimerTexteColorSave = "#ffffff";

        //Personalisation Ban
        public static string BanBackgroundPicture = "../assets/champselect/banning-1.png";
        public static string BanBackgroundPictureSave = "../assets/champselect/banning-1.png";
        public static string BanOverlayPicture = "../assets/champselect/ban-completed-2.png";
        public static string BanOverlayPictureSave = "../assets/champselect/ban-completed-2.png";
        public static string BanBackgroundColor = "#010a13";
        public static string BanBackgroundColorSave = "#010a13";

        //Personalisation Background
        public static string OverlayBackground = "../assets/champselect/backgroud-view-1.png";
        public static string OverlayBackgroundSave = "../assets/champselect/backgroud-view-1.png";

        public class ChampSelect
        {
            public string BlueTeamName { get; set; }
            public string BlueTeamSubtext { get; set; }
            public string BlueTeamNameColor { get; set; }
            public string BlueTeamSubtextColor { get; set; }
            public string BlueLogo { get; set; }
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BlueSideTexteColor { get; set; }
            public string BlueSideBackgroudColor { get; set; }
            public string BlueSideBorderColor { get; set; }
            public string BlueSideTimerBackgroudColor { get; set; }
            public string ColorBlueSideTimerBorder { get; set; }
            public string ColorBlueSideTimerTexte { get; set; }
            public string RedTeamName { get; set; }
            public string RedTeamSubtext { get; set; }
            public string ColorRedTeamName { get; set; }
            public string ColorRedTeamSubtext { get; set; }
            public string RedLogo { get; set; }
            public string ColorRedSideTexte { get; set; }
            public string ColorRedSideBackgroud { get; set; }
            public string ColorRedSideBorder { get; set; }
            public string ColorRedSideTimerBackgroud { get; set; }
            public string ColorRedSideTimerBorder { get; set; }
            public string ColorRedSideTimerTexte { get; set; }
            public string BanBackgroundPicture { get; set; }
            public string BanOverlayPicture { get; set; }
            public string BanBackgroundColor { get; set; }
            public string OverlayBackground { get; set; }
        }

        public static void ResetColor()
        {
            BlueSideTeamName = BlueSideTeamNameSave;
            BlueTeamSubtext = BlueTeamSubtextSave;
            BlueTeamNameColor = BlueTeamNameColorSave;
            BlueTeamSubtextColor = BlueTeamSubtextColorSave;
            BlueLogo = BlueLogoSave;
            BlueSideTexteColor = BlueSideTexteColorSave;
            BlueSideBackgroudColor = BlueSideBackgroudColorSave;
            BlueSideBorderColor = BlueSideBorderColorSave;
            BlueSideTimerBackgroudColor = BlueSideTimerBackgroudColorSave;
            BlueSideTimerBorderColor = BlueSideTimerBorderColorSave;
            BlueSideTimerTexteColor = BlueSideTimerTexteColorSave;
            RedSideTeamName = RedSideTeamNameSave;
            RedTeamSubtext = RedTeamSubtextSave;
            RedTeamNameColor = RedTeamNameColorSave;
            RedTeamSubtextColor = RedTeamSubtextColorSave;
            RedLogo = RedLogoSave;
            RedSideTexteColor = RedSideTexteColorSave;
            RedSideBackgroudColor = RedSideBackgroudColorSave;
            RedSideBorderColor = RedSideBorderColorSave;
            RedSideTimerBackgroudColor = RedSideTimerBackgroudColorSave;
            RedSideTimerBorderColor = RedSideTimerBorderColorSave;
            RedSideTimerTexteColor = RedSideTimerTexteColorSave;
            BanBackgroundPicture = BanBackgroundPictureSave;
            BanOverlayPicture = BanOverlayPictureSave;
            BanBackgroundColor = BanBackgroundColorSave;
            OverlayBackground = OverlayBackgroundSave;
        }

        public static void SetBlueTeamNameColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueTeamNameColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueTeamNameColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }
        public static void SetBlueTeamSubtextColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueTeamSubtextColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueTeamSubtextColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetBlueSideTexteColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueSideTexteColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueSideTexteColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetBlueSideBackgroudColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueSideBackgroudColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueSideBackgroudColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }
        public static void SetBlueSideTimerBackgroudColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueSideTimerBackgroudColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueSideTimerBackgroudColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }
        public static void SetBlueSideTimerTexteColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BlueSideTimerTexteColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BlueSideTimerTexteColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }
        public static void SetRedTeamNameColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedTeamNameColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedTeamNameColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetRedTeamSubtextColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedTeamSubtextColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedTeamSubtextColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetRedSideTexteColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedSideTexteColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedSideTexteColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetRedSideBackgroudColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedSideBackgroudColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedSideBackgroudColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetRedSideTimerBackgroudColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedSideTimerBackgroudColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedSideTimerBackgroudColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetRedSideTimerTexteColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = RedSideTimerTexteColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                RedSideTimerTexteColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }

        public static void SetBanBackgroundColor()
        {
            if (ChampSelectPage.ColorPickerOverlay1.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay1 = "visible";
                ChampSelectPage.colorValue = BanBackgroundColor;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay1 = "hidden";
                BanBackgroundColor = ChampSelectPage.colorValue;
            }
            //StateHasChanged();
        }




        public static void UpdateTimer(int timer, int reset)
        {
            //DateTime date1 = DateTime.Now;
            //Console.WriteLine("seconde : " + date1.ToString("m:ss"));
            timePhase = timer;
        }

        private string PictureExist(string picture)
        {
            if (File.Exists(picture))
            {
                return "visible";
            }
            else
            {
                return "hidden";
            }
        }

        private int SideInProgress()
        {
            foreach (var action in ChampSelectInfo.session.Actions)
            {
                foreach (var inaction in action)
                {
                    if (inaction.IsInProgress == true)
                    {
                        if (inaction.ActorCellId == 0 || inaction.ActorCellId == 1 || inaction.ActorCellId == 2 || inaction.ActorCellId == 3 || inaction.ActorCellId == 4)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }

        private string DefaultSquare(int index, int team)
        {
            if (team == 1)
            {
                return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.MyTeamBans[index]}/default-square.png";
            }
            else
            {
                return $"../assets/12.12/fr_fr/Champions/{ChampSelectInfo.session.Bans.TheirTeamBans[index]}/default-square.png";
            }
        }

        private int champDefaultSkinNumber(int index, int team)
        {
            if (team == 1)
            {
                return ChampSelectInfo.session.Bans.MyTeamBans[index] * 1000;
            }
            else
            {
                return ChampSelectInfo.session.Bans.TheirTeamBans[index] * 1000;
            }
        }

        private string getCurentAction(int index, int team)
        {
            //Console.WriteLine("getCurentAction");
            int cellId;
            if (team == 1)
            {
                cellId = ChampSelectInfo.session.MyTeam[index].CellId;
            }
            else
            {
                cellId = ChampSelectInfo.session.TheirTeam[index].CellId;
            }
            foreach (var action in ChampSelectInfo.session.Actions)
            {
                foreach (var inaction in action)
                {
                    if (inaction.ActorCellId == cellId)
                    {
                        if (inaction.Completed == false && inaction.IsInProgress == true)
                        {
                            if (inaction.Type.Equals("pick"))
                            {
                                return "Picking";
                            }
                            else if (inaction.Type.Equals("ban"))
                            {
                                return "Banning";
                            }
                        }
                    }
                }
            }
            return "";
        }

        private string getSummonerName(int index, int team)
        {
            if (team == 1)
            {
                return ChampSelectInfo.session.MyTeam[index].SummonerName;
            }
            else
            {
                return ChampSelectInfo.session.TheirTeam[index].SummonerName;
            }
        }

        private string getSpell(int index, int team, int numSpell)
        {
            ulong spellId;
            if (numSpell == 1)
            {
                if (team == 1)
                {
                    spellId = ChampSelectInfo.session.MyTeam[index].Spell1Id;
                }
                else
                {
                    spellId = ChampSelectInfo.session.TheirTeam[index].Spell1Id;
                }
            }
            else
            {
                if (team == 1)
                {
                    spellId = ChampSelectInfo.session.MyTeam[index].Spell2Id;
                }
                else
                {
                    spellId = ChampSelectInfo.session.TheirTeam[index].Spell2Id;
                }
            }
            if (spellId > 100 || spellId == 0)
            {
                return "../assets/12.12/fr_fr/SummonerSpells/54.png";
            }
            return $"../assets/12.12/fr_fr/SummonerSpells/{spellId}.png";
        }

        private string getChampId(int index, int team)
        {
            int champId, cellId;
            if (team == 1)
            {
                champId = ChampSelectInfo.session.MyTeam[index].ChampionId;
                cellId = ChampSelectInfo.session.MyTeam[index].CellId;
            }
            else
            {
                champId = ChampSelectInfo.session.TheirTeam[index].ChampionId;
                cellId = ChampSelectInfo.session.TheirTeam[index].CellId;
            }

            if (champId == 0)
            {
                foreach (var action in ChampSelectInfo.session.Actions)
                {
                    foreach (var inaction in action)
                    {
                        if (inaction.ActorCellId == cellId)
                        {
                            if (inaction.Type.Equals("pick"))
                            {
                                if (inaction.Completed == false)
                                {
                                    champId = inaction.ChampionId;
                                }
                            }
                        }
                    }
                }
            }
            return $"../assets/12.12/fr_fr/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
