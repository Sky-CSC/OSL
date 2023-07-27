using Newtonsoft.Json;
using OSL_CDragon;
using OSL_Common.System.Logging;
using OSL_Web.Configuration;
using OSL_WebApiRiot.WebApiRiot;

namespace OSL_Web.DataProcessing
{
    /// <summary>
    /// Configure region, rooting, locale and version for download or get the right information from CDragon or API
    /// </summary>
    public class LoLAppRooting
    {
        //public static string locale = "fr_fr";
        //public static string region = "euw1";
        //public static string rooting = "europe";
        //public static string patch = "latest";
        private static Logger _logger = new("");

        /// <summary>
        /// Read data contain information above locale, region, version of client
        /// </summary>
        /// <param name="content"></param>
        public static void ReadData(string content)
        {
            try
            {
                dynamic regionLocaleData = JsonConvert.DeserializeObject(content);

                string region = regionLocaleData.appContext.userRegion;
                region = region.ToLower();
                WebApiRiot.SetRegion(region);

                string locale = regionLocaleData.appContext.appLocale;
                locale = locale.Replace("-", "_").ToLower();
                CDragon.SetRegion(locale);

                string patch = regionLocaleData.appContext.appVersion;
                patch = patch.Remove(5);
                CDragon.SetPatch(patch);

                CDragon.DownloadAsyncWithCheck(patch, locale);
                Config.ReloadPagesView();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadData()", "Error set region, locale, rooting, version of game : " + e.Message);
                WebApiRiot.SetRegion("euw1");
                CDragon.SetRegion("fr_fr");
                CDragon.SetPatch("latest");
                CDragon.DownloadAsyncWithCheck("latest", "fr_fr");
                Config.ReloadPagesView();
            }
        }
    }
}
