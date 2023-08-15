using static OSL_WebApiRiot.WebApiRiot.WebApiRiot;

namespace OSL_WebApiRiot.WebApiRiot
{
    /// <summary>
    /// Get information from match
    /// </summary>
    public class Match_V5
    {
        //private static string httpsUrl = "https://";
        //public static string rooting = "europe";
        //private static string pathUrlApiRiot = ".api.riotgames.com";

        /// <summary>
        /// Get list of match by puuid
        /// </summary>
        /// <param name="puuid"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="queue"></param>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string ByPuuid(string puuid, long startTime = -1, long endTime = -1, int queue = -1, string type = "", int start = -1, int count = -1)
        {
            string buildUrl = $"{httpsUrl}{rooting}{pathUrlApiRiot}/lol/match/v5/matches/by-puuid/{puuid}/ids?";
            if (startTime != -1)
            {
                buildUrl += $"startTime={startTime}&";
            }
            if (endTime != -1)
            {
                buildUrl += $"endTime={endTime}&";
            }
            if (queue != -1)
            {
                buildUrl += $"queue={queue}&";
            }
            if (type != "")
            {
                buildUrl += $"type={type}&";
            }
            if (start != -1)
            {
                buildUrl += $"start={start}&";
            }
            if (count != -1)
            {
                buildUrl += $"count={count}";
            }

            return buildUrl;
        }

        /// <summary>
        /// Get information of specific match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public static string Matches(Int64 matchId)
        {
            return $"{httpsUrl}{rooting}{pathUrlApiRiot}/lol/match/v5/matches/{region.ToUpper()}_{matchId}";
        }

        /// <summary>
        /// Get timeline of specific match
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public static string Timeline(Int64 matchId)
        {
            return $"{httpsUrl}{rooting}{pathUrlApiRiot}/lol/match/v5/matches/{region.ToUpper()}_{matchId}/timeline";
        }
    }
}
