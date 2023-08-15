using OSL_Common.System.Logging;
using System.Net;

namespace OSL_WebApiRiot.WebApiRiot
{
    /// <summary>
    /// Connect and get data from web riot api.
    /// </summary>
    public class WebApiRiot
    {
        private static Logger _logger = new("WebApiRiot");
        public static string apiKey;
        public static string region = "euw1";
        public static string rooting = "europe";
        public static string httpsUrl = "https://";
        public static string pathUrlApiRiot = ".api.riotgames.com";

        /// <summary>
        /// http request to web api riot
        /// </summary>
        /// <param name="urlRequest"></param>
        /// <returns></returns>
        public static string RequestWebApiRiot(string urlRequest)
        {
            string httpsWebApiRiot = urlRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsWebApiRiot);
                request.Headers["X-Riot-Token"] = apiKey;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientReplayAPI", "Request to " + httpsWebApiRiot + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientReplayAPI", "Request to " + httpsWebApiRiot + " failed, " + e.Message);
                return null;
            }
        }

        public static void SetRegion(string newRegion)
        {
            region = newRegion;
            SetRooting();
        }

        public static void SetRooting()
        {
            if (region.Equals("na1") || region.Equals("br1") || region.Equals("la1") || region.Equals("la2"))
            {
                rooting = "americas";
            }
            else if (region.Equals("kr") || region.Equals("jp1"))
            {
                rooting = "asia";
            }
            else if (region.Equals("eun1") || region.Equals("euw1") || region.Equals("tr1") || region.Equals("ru"))
            {
                rooting = "europe";
            }
            else if (region.Equals("oc1") || region.Equals("ph2") || region.Equals("sg2") || region.Equals("th2") || region.Equals("tw2") || region.Equals("vn2"))
            {
                rooting = "sea";
            }
        }

        public class ApiKeyScheme
        {
            public string apiKey { get; set; }
        }
    }
}
