using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OSL_Client.RiotApp.API.Replay.UrlRequest;

namespace OSL_Client.RiotApp.API.Replay
{
    /// <summary>
    /// Replay Api
    /// </summary>
    internal class ReplayApi
    {
        private static OSLLogger _logger = new OSLLogger("ReplayApi");
        /// <summary>
        /// Game alrady end, but he is watch
        /// </summary>
        /// <returns></returns>
        public static string GameEndButReplay()
        {
            string replayCheck = ApiRequest.RequestGameClientReplayAPI(replaygame);
            if (replayCheck == null)
            {
                _logger.log(LoggingLevel.ERROR, "GameEndReplay()", "Not game replay started");
                return null;
            }
            else {
                _logger.log(LoggingLevel.INFO, "GameEndReplay()", "Game replay started");
                return replayCheck;
            }
        }
    }
    /// <summary>
    /// URL replay api
    /// </summary>
    public class UrlRequest
    {
        public static readonly string replaygame = "/replay/game"; //Information about the game client process.
    }
}
