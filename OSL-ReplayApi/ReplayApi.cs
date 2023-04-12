using OSL_Common.System.Logging;
using OSL_Common.System.SSLCertificate;
using System.Net;


namespace OSL_ReplayApi
{
    public class ReplayApi
    {
        private static Logger _logger = new("ReplayApi");

        /// <summary>
        /// http request for replay API
        /// </summary>
        /// <param name="nameRequest">URL request</param>
        /// <returns></returns>
        public static string Request(string nameRequest, int riotPort)
        {
            SSL.BypassSSL();
            string httpsLocalHost = "https://127.0.0.1" + ":" + riotPort + nameRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientReplayAPI", "Request to " + httpsLocalHost + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientReplayAPI", "Request to " + httpsLocalHost + " failed, " + e.Message);
                return null;
            }
        }

        public class Url
        {
            public static readonly string replaygame = "/replay/game"; //Information about the game client process.
        }
    }
}
