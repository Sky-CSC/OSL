﻿using OSL_Common.System.Logging;
using OSL_Common.System.SSLCertificate;
using System.Net;


namespace OSL_ReplayApi
{
    /// <summary>
    /// Get information of Replay API give by League of Legends Client
    /// </summary>
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

        /// <summary>
        /// List of url
        /// </summary>
        public class Url
        {
            public static readonly string replaygame = "/replay/game"; //Information about the game client process.
            public static readonly string liveclientdataallgamedata = "/liveclientdata/allgamedata"; //All game data
            public static readonly string liveclientdataplayerlist = "/liveclientdata/playerlist"; //Information about summoners
            public static readonly string liveclientdataeventdata = "/liveclientdata/eventdata"; //Information about summoners
            public static readonly string replayplayback = "/replay/playback"; //Time, Pause information

        }
    }
}
