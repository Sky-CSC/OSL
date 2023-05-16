using OSL_Common.System.Logging;

namespace OSL_Web.Pages.Runes
{
    public partial class RunesMidPage
    {
        private static Logger _logger = new("RunesMidPage");

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BackgroudGradient { get; set; }
            public string OverlayColorBackgroudGradient { get; set; }
            public string BlueSideColorTextSummoner{ get; set; }
            public string RedSideColorTextSummoner{ get; set; }
            public string BlueSideColorBorderChampion { get; set; }
            public string RedSideColorBorderChampion { get; set; }
            public string BlueSideColorSeparationBar{ get; set; }
            public string RedSideColorSeparationBar{ get; set; }
            public string BakgroundPicture{ get; set; }
            public string LanePicture{ get; set; }
        }

        /// <summary>
        /// Return path of perks icon
        /// </summary>
        /// <param name="perksId"></param>
        /// <returns></returns>
        public static string GetPerksIconPath(int perksId)
        {
            int indexPatch = OSL_CDragon.CDragon.dataCDragon.Patch.FindIndex(obj => obj.Name == formatingData.DefaultPatch);
            int indexRegion = OSL_CDragon.CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(obj => obj.Name == formatingData.DefaultRegion);
            int indexPerks = OSL_CDragon.CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Perks.FindIndex(obj => obj.Id == perksId);
            return OSL_CDragon.CDragon.dataCDragon.Patch[0].Region[0].RegionContent.Perks[indexPerks].IconPath;
        }

        /// <summary>
        /// Return champion picture path
        /// </summary>
        /// <param name="champId"></param>
        /// <returns></returns>
        public static string GetChampionPicturePath(int champId)
        {
            return $"./assets/{formatingData.DefaultPatch}/{formatingData.DefaultRegion}/Champions/{champId}/default-square.png";
        }

        /// <summary>
        /// Load default datat champ select
        /// </summary>
        public static void ResetColor()
        {
            Configuration.Overlay.Rune.View1.Mid.Config.LoadFormatingDataConfig();

        }
    }
}
