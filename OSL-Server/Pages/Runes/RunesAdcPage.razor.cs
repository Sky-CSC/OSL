using Newtonsoft.Json;
using OSL_Server.Configuration;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.DataLoader.WebApiRiot;

namespace OSL_Server.Pages.Runes
{
    public partial class RunesAdcPage
    {
        private static OSLLogger _logger = new OSLLogger("RunesAdcPage");

        //Data for display color, texte, picture on web page
        public static FormatingData formatingData = new();

        public class FormatingData
        {
            public string DefaultPatch { get; set; }
            public string DefaultRegion { get; set; }
            public string BackgroudGradient { get; set; }
            public string BackgroudGradientDeg { get; set; }
            public string BackgroudGradientColor1 { get; set; }
            public string BackgroudGradientPercent1 { get; set; }
            public string BackgroudGradientColor2 { get; set; }
            public string BackgroudGradientPercent2 { get; set; }
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
            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(obj => obj.Name == formatingData.DefaultPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(obj => obj.Name == formatingData.DefaultRegion);
            int indexPerks = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.Perks.FindIndex(obj => obj.Id == perksId);
            return CDragon.dataCDragon.Patch[0].Region[0].RegionContent.Perks[indexPerks].IconPath;
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
            Config.LoadFormatingDataConfigRunesAdcPage();
        }

    }
}
