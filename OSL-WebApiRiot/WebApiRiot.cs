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

        public class ApiKeyScheme
        {
            public string apiKey { get; set; }
        }
    }
}
