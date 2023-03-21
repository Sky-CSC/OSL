using OSL_Server.DataReciveClient.Processing.ChampSelect;
using OSL_Server.Configuration;

namespace OSL_Server.Pages.ChampSelect
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
