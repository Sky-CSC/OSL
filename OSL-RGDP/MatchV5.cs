using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Match information.
    /// </summary>
    public class MatchV5
    {
        /// <summary>
        /// Information for make request to Riot Game Developer Portal
        /// </summary>
        private readonly Info _info;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">Information for download information</param>
        public MatchV5(Info info)
        {
            _info = info;
            // Routing is the continent not the region
            _info.Routing = _info.Continent;
        }

        /// <summary>
        /// Get the match information by match id.
        /// </summary>
        /// <param name="puuid">Puuid</param>
        /// <param name="startTime">Epoch timestamp in seconds. The matchlist started storing timestamps on June 16th, 2021. Any matches played before June 16th, 2021 won't be included in the results if the startTime filter is set.</param>
        /// <param name="endTime">Epoch timestamp in seconds.</param>
        /// <param name="queue">Filter the list of match ids by a specific queue id. This filter is mutually inclusive of the type filter meaning any match ids returned must match both the queue and type filters.</param>
        /// <param name="type">Filter the list of match ids by the type of match. This filter is mutually inclusive of the queue filter meaning any match ids returned must match both the queue and type filters.</param>
        /// <param name="start">Defaults to 0. Start index.</param>
        /// <param name="count">Defaults to 20. Valid values: 0 to 100. Number of match ids to return.</param>
        /// <returns>List of matchs of a player</returns>
        public List<string>? ByPuuid(string puuid, long startTime = -1, long endTime = -1, int queue = -1, string type = "", int start = -1, int count = -1)
        {
            string buildUrl = $"/lol/match/v5/matches/by-puuid/{puuid}/ids?";
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
            string? data = Request(_info, buildUrl);
            if (data == null)
            {
                return [];
            }
            return JsonConvert.DeserializeObject<List<string>>(data);
        }

        /// <summary>
        /// Get the match information by match id. The timeline give all information of the match.
        /// </summary>
        /// <param name="matchId">Id of match</param>
        /// <returns>Match information</returns>
        public MatchDto Timeline(Int64 matchId)
        {
            string? data = Request(_info, $"/lol/match/v5/matches/{_info.Region.ToUpper()}_{matchId}");
            if (data == null)
            {
                return new MatchDto();
            }
            return JsonConvert.DeserializeObject<MatchDto>(data);
        }
    }
}
