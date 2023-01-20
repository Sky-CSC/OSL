using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Pages
{
    /// <summary>
    /// Champ Select View4 Page
    /// </summary>
    public partial class ChampSelectView4Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView4Page");

        public static bool overlayLoaded = false;

        //Personalisation Patch and Region
        public static string DefaultPatch = "latest";
        public static string DefaultRegion = "fr_fr";
        public static string BorderBottomPixel = "5px solid";
        public static string BorderBottomPixelSave = "5px solid";
        public static string BorderTop = "5px solid #FFFF00";
        public static string BorderTopSave = "5px solid #FFFF00";
        public static string BackgroudGradient = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        public static string BackgroudGradientDeg = "150";
        public static string BackgroudGradientColor1 = "#0b849e";
        public static string BackgroudGradientPercent1 = "0";
        public static string BackgroudGradientColor2 = "#be1e37";
        public static string BackgroudGradientPercent2 = "100";
        public static string BackgroudGradientDegSave = "150";
        public static string BackgroudGradientColor1Save = "#0b849e";
        public static string BackgroudGradientPercent1Save = "0";
        public static string BackgroudGradientColor2Save = "#be1e37";
        public static string BackgroudGradientPercent2Save = "100";
        public static string BackgroudGradientSave = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        public static string OverlayColorBackgroudGradient = "linear-gradient( to right, rgba(0, 0, 0, 0.83) 0%, rgba(0, 0, 0, 0.72) 50%, rgba(0, 0, 0, 0.83) 100% )";
        public static string OverlayColorBackgroudGradientSave = "linear-gradient( to right, rgba(0, 0, 0, 0.83) 0%, rgba(0, 0, 0, 0.72) 50%, rgba(0, 0, 0, 0.83) 100% )";


        //Personalisation Blue Side
        public static string BlueSideBorderColorPick = "2px solid #0b849e";
        public static string BlueSideBorderColorPickSave = "2px solid #0b849e";
        public static string BlueSideBorderColorBan = "2px solid #0b849e";
        public static string BlueSideBorderColorBanSave = "2px solid #0b849e";
        public static string BlueSideTeamName = "";
        public static string BlueSideTeamNameSave = "";
        public static string BlueSideTeamNameSubtext = "";
        public static string BlueSideTeamNameSubtextSave = "";
        public static string BlueSideBanText = "BANS";
        public static string BlueSideBanTextSave = "BANS";
        public static string BlueSidePickText = "PICK";
        public static string BlueSidePickTextSave = "PICK";
        public static string BlueSideColorText = "#0b849e";
        public static string BlueSideColorTextSave = "#0b849e";
        public static string BlueSideColorSubText = "#0b849e";
        public static string BlueSideColorSubTextSave = "#0b849e";
        public static string BlueSideColorTextBan = "#0b849e";
        public static string BlueSideColorTextBanSave = "#0b849e";
        public static string BlueSideColorTextPick = "#0b849e";
        public static string BlueSideColorTextPickSave = "#0b849e";

        //Personalisation Red Side
        public static string RedSideBorderColorPick = "2px solid #be1e37";
        public static string RedSideBorderColorPickSave = "2px solid #be1e37";
        public static string RedSideBorderColorBan = "2px solid #be1e37";
        public static string RedSideBorderColorBanSave = "2px solid #be1e37";
        public static string RedSideTeamName = "";
        public static string RedSideTeamNameSave = "";
        public static string RedSideTeamNameSubtext = "";
        public static string RedSideTeamNameSubtextSave = "";
        public static string RedSideBanText = "BANS";
        public static string RedSideBanTextSave = "BANS";
        public static string RedSidePickText = "PICK";
        public static string RedSidePickTextSave = "PICK";
        public static string RedSideColorText = "#be1e37";
        public static string RedSideColorTextSave = "#be1e37";
        public static string RedSideColorSubText = "#be1e37";
        public static string RedSideColorSubTextSave = "#be1e37";
        public static string RedSideColorTextBan = "#be1e37";
        public static string RedSideColorTextBanSave = "#be1e37";
        public static string RedSideColorTextPick = "#be1e37";
        public static string RedSideColorTextPickSave = "#be1e37";

        public class ChampSelect
        {
            public string BorderBottomPixel { get; set; }
            public string BorderTop { get; set; }
            public string BackgroudGradient { get; set; }
            public string OverlayColorBackgroudGradient { get; set; }
            public string BlueSideBorderColorPick { get; set; }
            public string BlueSideBorderColorBan { get; set; }
            public string BlueSideTeamName { get; set; }
            public string BlueSideTeamNameSubtext { get; set; }
            public string BlueSideBanText { get; set; }
            public string BlueSidePickText { get; set; }
            public string BlueSideColorText { get; set; }
            public string BlueSideColorSubText { get; set; }
            public string BlueSideColorTextBan { get; set; }
            public string BlueSideColorTextPick { get; set; }
            public string RedSideBorderColorPick { get; set; }
            public string RedSideBorderColorBan { get; set; }
            public string RedSideTeamName { get; set; }
            public string RedSideTeamNameSubtext { get; set; }
            public string RedSideBanText { get; set; }
            public string RedSidePickText { get; set; }
            public string RedSideColorText { get; set; }
            public string RedSideColorSubText { get; set; }
            public string RedSideColorTextBan { get; set; }
            public string RedSideColorTextPick { get; set; }
        }
        public static void ResetColor()
        {
            BorderBottomPixel = BorderBottomPixelSave;
            BorderTop = BorderTopSave;
            BackgroudGradient = BackgroudGradientSave;
            OverlayColorBackgroudGradient = OverlayColorBackgroudGradientSave;
            BlueSideBorderColorPick = BlueSideBorderColorPickSave;
            BlueSideBorderColorBan = BlueSideBorderColorBanSave;
            BlueSideTeamName = BlueSideTeamNameSave;
            BlueSideTeamNameSubtext = BlueSideTeamNameSubtextSave;
            BlueSideBanText = BlueSideBanTextSave;
            BlueSidePickText = BlueSidePickTextSave;
            BlueSideColorText = BlueSideColorTextSave;
            BlueSideColorSubText = BlueSideColorSubTextSave;
            BlueSideColorTextBan = BlueSideColorTextBanSave;
            BlueSideColorTextPick = BlueSideColorTextPickSave;
            RedSideBorderColorPick = RedSideBorderColorPickSave;
            RedSideBorderColorBan = RedSideBorderColorBanSave;
            RedSideTeamName = RedSideTeamNameSave;
            RedSideTeamNameSubtext = RedSideTeamNameSubtextSave;
            RedSideBanText = RedSideBanTextSave;
            RedSidePickText = RedSidePickTextSave;
            RedSideColorText = RedSideColorTextSave;
            RedSideColorSubText = RedSideColorSubTextSave;
            RedSideColorTextBan = RedSideColorTextBanSave;
            RedSideColorTextPick = RedSideColorTextPickSave;
            BackgroudGradientDeg = BackgroudGradientDegSave;
            BackgroudGradientColor1 = BackgroudGradientColor1Save;
            BackgroudGradientPercent1 = BackgroudGradientPercent1Save;
            BackgroudGradientColor2 = BackgroudGradientColor2Save;
            BackgroudGradientPercent2 = BackgroudGradientPercent2Save;
        }

        public static void SetBlueSideColorText()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BlueSideColorText;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideColorText = ChampSelectPage.colorValue;
            }
        }
        public static void SetBlueSideColorSubText()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BlueSideColorSubText;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideColorSubText = ChampSelectPage.colorValue;
            }
        }
        public static void SetBlueSideColorTextBan()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BlueSideColorTextBan;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideColorTextBan = ChampSelectPage.colorValue;
            }
        }
        
        public static void SetBlueSideColorTextPick()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BlueSideColorTextPick;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideColorTextPick = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideColorText()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = RedSideColorText;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                RedSideColorText = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideColorSubText()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue =RedSideColorSubText;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
               RedSideColorSubText = ChampSelectPage.colorValue;
            }
        }
        public static void SetRedSideColorTextBan()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue =RedSideColorTextBan;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
               RedSideColorTextBan = ChampSelectPage.colorValue;
            }
        }

        public static void SetRedSideColorTextPick()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue =RedSideColorTextPick;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
               RedSideColorTextPick = ChampSelectPage.colorValue;
            }
        }
        public static string BorderTopNotSet = BorderTop.Split(" ")[2];
        public static void SetBorderTop()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                string[] tempsBorderColor = BorderTop.Split(" ");
                ChampSelectPage.colorValue = tempsBorderColor[2];
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BorderTopNotSet = ChampSelectPage.colorValue;
            }
        }

        public static string BlueSideBorderColorBanNotSet = BlueSideBorderColorBan.Split(" ")[2];
        public static void SetBlueSideBorderColorBan()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                string[] tempsBorderColor = BlueSideBorderColorBan.Split(" ");
                ChampSelectPage.colorValue = tempsBorderColor[2];
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideBorderColorBanNotSet = ChampSelectPage.colorValue;
            }
        }
        public static string RedSideBorderColorBanNotSet = RedSideBorderColorBan.Split(" ")[2];
        public static void SetRedSideBorderColorBan()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                string[] tempsBorderColor = RedSideBorderColorBan.Split(" ");
                ChampSelectPage.colorValue = tempsBorderColor[2];
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                RedSideBorderColorBanNotSet = ChampSelectPage.colorValue;
            }
        }
        public static string BlueSideBorderColorPickNotSet = BlueSideBorderColorPick.Split(" ")[2];
        public static void SetBlueSideBorderColorPick()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                string[] tempsBorderColor = BlueSideBorderColorPick.Split(" ");
                ChampSelectPage.colorValue = tempsBorderColor[2];
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BlueSideBorderColorPickNotSet = ChampSelectPage.colorValue;
            }
        }
        public static string RedSideBorderColorPickNotSet = RedSideBorderColorPick.Split(" ")[2];
        public static void SetRedSideBorderColorPick()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                string[] tempsBorderColor = RedSideBorderColorPick.Split(" ");
                ChampSelectPage.colorValue = tempsBorderColor[2];
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                RedSideBorderColorPickNotSet = ChampSelectPage.colorValue;
            }
        }

        public static void SetBackgroudGradientColor1()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BackgroudGradientColor1;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BackgroudGradientColor1 = ChampSelectPage.colorValue;
                BackgroudGradient = $"linear-gradient({BackgroudGradientDeg}deg, {BackgroudGradientColor1} {BackgroudGradientPercent1}%, {BackgroudGradientColor2} {BackgroudGradientPercent2}%)";
            }
        }

        public static void SetBackgroudGradientColor2()
        {
            if (ChampSelectPage.ColorPickerOverlay4.Equals("hidden"))
            {
                ChampSelectPage.ColorPickerOverlay4 = "visible";
                ChampSelectPage.colorValue = BackgroudGradientColor2;
            }
            else
            {
                ChampSelectPage.ColorPickerOverlay4 = "hidden";
                BackgroudGradientColor2 = ChampSelectPage.colorValue;
                BackgroudGradient = $"linear-gradient({BackgroudGradientDeg}deg, {BackgroudGradientColor1} {BackgroudGradientPercent1}%, {BackgroudGradientColor2} {BackgroudGradientPercent2}%)";
            }
        }

        //public static void SetBlueSideTeamNameColor()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = BlueSideTeamNameColor;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        BlueSideTeamNameColor = ChampSelectPage.colorValue;
        //    }
        //}

        //public static void SetKeystoneColor1()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = KeystonePickColor1;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        KeystonePickColor1 = ChampSelectPage.colorValue;
        //        KeystonePickColor = $"linear-gradient({KeystonePickColorDeg}deg, {KeystonePickColor1} {KeystonePickColorPercent1}%, {KeystonePickColor2} {KeystonePickColorPercent2}%)";
        //    }
        //}

        //public static void SetKeystoneColor2()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = KeystonePickColor2;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        KeystonePickColor2 = ChampSelectPage.colorValue;
        //        KeystonePickColor = $"linear-gradient({KeystonePickColorDeg}deg, {KeystonePickColor1} {KeystonePickColorPercent1}%, {KeystonePickColor2} {KeystonePickColorPercent2}%)";
        //    }
        //}

        //public static void SetRedSideBackgroud()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = RedSideBackgroud;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        RedSideBackgroud = ChampSelectPage.colorValue;
        //    }
        //}
        //public static void SetRedSideSummoner()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = RedSideSummoner;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        RedSideSummoner = ChampSelectPage.colorValue;
        //    }
        //}
        //public static void SetRedSideBackgroudSummonerPick()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = RedSideBackgroudSummonerPick;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        RedSideBackgroudSummonerPick = ChampSelectPage.colorValue;
        //    }
        //}
        //public static void SetRedSideBackgroudSummonerPickEnd()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = RedSideBackgroudSummonerPickEnd;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        RedSideBackgroudSummonerPickEnd = ChampSelectPage.colorValue;
        //    }
        //}
        //public static void SetRedSideTeamNameColor()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = RedSideTeamNameColor;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        RedSideTeamNameColor = ChampSelectPage.colorValue;
        //    }
        //}
        //public static void SetBanBackgroundColor()
        //{
        //    if (ChampSelectPage.ColorPickerOverlay3.Equals("hidden"))
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "visible";
        //        ChampSelectPage.colorValue = BanBackgroundColor;
        //    }
        //    else
        //    {
        //        ChampSelectPage.ColorPickerOverlay3 = "hidden";
        //        BanBackgroundColor = ChampSelectPage.colorValue;
        //    }
        //}

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

        private string DefaultSquare(int numBan)
        {
            return $"../assets/{DefaultPatch}/{DefaultRegion}/Champions/{numBan}/default-square.png";
        }

        private string GetChampId(int index, int team)
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
            return $"../assets/{DefaultPatch}/{DefaultRegion}/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
