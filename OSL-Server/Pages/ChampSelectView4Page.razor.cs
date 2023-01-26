using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.Configuration;

namespace OSL_Server.Pages
{
    /// <summary>
    /// Champ Select View4 Page
    /// </summary>
    public partial class ChampSelectView4Page
    {
        private static OSLLogger _logger = new OSLLogger("ChampSelectView4Page");

        public static bool overlayLoaded = false;

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        /// <summary>
        /// Formating Data
        /// </summary>
        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BorderBottomPixel { get; set; }
            public string BorderTop { get; set; }
            public string BackgroudGradient { get; set; }
            public string BackgroudGradientDeg { get; set; }
            public string BackgroudGradientColor1 { get; set; }
            public string BackgroudGradientPercent1 { get; set; }
            public string BackgroudGradientColor2 { get; set; }
            public string BackgroudGradientPercent2 { get; set; }
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

        ////Personalisation Patch and Region
        //public static string DefaultPatch = "latest";
        //public static string DefaultRegion = "fr_fr";
        //public static string BorderBottomPixel = "5px solid";
        //public static string BorderBottomPixelSave = "5px solid";
        //public static string BorderTop = "5px solid #FFFF00";
        //public static string BorderTopSave = "5px solid #FFFF00";
        //public static string BackgroudGradient = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        //public static string BackgroudGradientDeg = "150";
        //public static string BackgroudGradientColor1 = "#0b849e";
        //public static string BackgroudGradientPercent1 = "0";
        //public static string BackgroudGradientColor2 = "#be1e37";
        //public static string BackgroudGradientPercent2 = "100";
        //public static string BackgroudGradientDegSave = "150";
        //public static string BackgroudGradientColor1Save = "#0b849e";
        //public static string BackgroudGradientPercent1Save = "0";
        //public static string BackgroudGradientColor2Save = "#be1e37";
        //public static string BackgroudGradientPercent2Save = "100";
        //public static string BackgroudGradientSave = "linear-gradient(150deg, #0b849e 0%, #be1e37 100%)";
        //public static string OverlayColorBackgroudGradient = "linear-gradient( to right, rgba(0, 0, 0, 0.83) 0%, rgba(0, 0, 0, 0.72) 50%, rgba(0, 0, 0, 0.83) 100% )";
        //public static string OverlayColorBackgroudGradientSave = "linear-gradient( to right, rgba(0, 0, 0, 0.83) 0%, rgba(0, 0, 0, 0.72) 50%, rgba(0, 0, 0, 0.83) 100% )";


        ////Personalisation Blue Side
        //public static string BlueSideBorderColorPick = "2px solid #0b849e";
        //public static string BlueSideBorderColorPickSave = "2px solid #0b849e";
        //public static string BlueSideBorderColorBan = "2px solid #0b849e";
        //public static string BlueSideBorderColorBanSave = "2px solid #0b849e";
        //public static string BlueSideTeamName = "";
        //public static string BlueSideTeamNameSave = "";
        //public static string BlueSideTeamNameSubtext = "";
        //public static string BlueSideTeamNameSubtextSave = "";
        //public static string BlueSideBanText = "BANS";
        //public static string BlueSideBanTextSave = "BANS";
        //public static string BlueSidePickText = "PICK";
        //public static string BlueSidePickTextSave = "PICK";
        //public static string BlueSideColorText = "#0b849e";
        //public static string BlueSideColorTextSave = "#0b849e";
        //public static string BlueSideColorSubText = "#0b849e";
        //public static string BlueSideColorSubTextSave = "#0b849e";
        //public static string BlueSideColorTextBan = "#0b849e";
        //public static string BlueSideColorTextBanSave = "#0b849e";
        //public static string BlueSideColorTextPick = "#0b849e";
        //public static string BlueSideColorTextPickSave = "#0b849e";

        ////Personalisation Red Side
        //public static string RedSideBorderColorPick = "2px solid #be1e37";
        //public static string RedSideBorderColorPickSave = "2px solid #be1e37";
        //public static string RedSideBorderColorBan = "2px solid #be1e37";
        //public static string RedSideBorderColorBanSave = "2px solid #be1e37";
        //public static string RedSideTeamName = "";
        //public static string RedSideTeamNameSave = "";
        //public static string RedSideTeamNameSubtext = "";
        //public static string RedSideTeamNameSubtextSave = "";
        //public static string RedSideBanText = "BANS";
        //public static string RedSideBanTextSave = "BANS";
        //public static string RedSidePickText = "PICK";
        //public static string RedSidePickTextSave = "PICK";
        //public static string RedSideColorText = "#be1e37";
        //public static string RedSideColorTextSave = "#be1e37";
        //public static string RedSideColorSubText = "#be1e37";
        //public static string RedSideColorSubTextSave = "#be1e37";
        //public static string RedSideColorTextBan = "#be1e37";
        //public static string RedSideColorTextBanSave = "#be1e37";
        //public static string RedSideColorTextPick = "#be1e37";
        //public static string RedSideColorTextPickSave = "#be1e37";

        //public class ChampSelect
        //{
        //    public string DefaultPatch { get; set; }
        //    public string DefaultRegion { get; set; }
        //    public string BorderBottomPixel { get; set; }
        //    public string BorderTop { get; set; }
        //    public string BackgroudGradient { get; set; }
        //    public string OverlayColorBackgroudGradient { get; set; }
        //    public string BlueSideBorderColorPick { get; set; }
        //    public string BlueSideBorderColorBan { get; set; }
        //    public string BlueSideTeamName { get; set; }
        //    public string BlueSideTeamNameSubtext { get; set; }
        //    public string BlueSideBanText { get; set; }
        //    public string BlueSidePickText { get; set; }
        //    public string BlueSideColorText { get; set; }
        //    public string BlueSideColorSubText { get; set; }
        //    public string BlueSideColorTextBan { get; set; }
        //    public string BlueSideColorTextPick { get; set; }
        //    public string RedSideBorderColorPick { get; set; }
        //    public string RedSideBorderColorBan { get; set; }
        //    public string RedSideTeamName { get; set; }
        //    public string RedSideTeamNameSubtext { get; set; }
        //    public string RedSideBanText { get; set; }
        //    public string RedSidePickText { get; set; }
        //    public string RedSideColorText { get; set; }
        //    public string RedSideColorSubText { get; set; }
        //    public string RedSideColorTextBan { get; set; }
        //    public string RedSideColorTextPick { get; set; }
        //}


        /// <summary>
        /// Enable or disable overlay view
        /// </summary>
        public static void EnableOrDisableOverlayView()
        {
            if (overlayLoaded == false)
            {
                overlayLoaded = true;
            }
            else
            {
                overlayLoaded = false;
            }
        }

        /// <summary>
        /// Load default datat champ select
        /// </summary>
        public static void ResetColor()
        {
            Config.LoadFormatingDataConfigChampSelectView4();
        }

        /// <summary>
        /// Return if picture exist
        /// </summary>
        /// <param name="picture">visible or hidden for css display</param>
        /// <returns></returns>
        private static string PictureExist(string picture)
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

        /// <summary>
        /// Url default square of champion
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private string DefaultSquare(int numBan)
        {
            return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{numBan}/default-square.png";
        }

        /// <summary>
        /// Champion ID
        /// </summary>
        /// <param name="index">index of summoner</param>
        /// <param name="team">team side</param>
        /// <returns></returns>
        private static string GetChampId(int index, int team)
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
            return $"../assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{champId}/Skins/{champId * 1000}/{champId * 1000}_Splashe.jpg";
        }
    }
}
