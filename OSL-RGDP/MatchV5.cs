using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_RGDP.Schema.Riot;
using static OSL_RGDP.RgdpApi;

namespace OSL_RGDP
{
    /// <summary>
    /// Provides methods for interacting with the Riot Games Match V5 API, including retrieving match details,
    /// timelines, and match lists for a specific player.
    /// </summary>
    /// <remarks>This class is designed to facilitate communication with the Riot Games Developer Portal's
    /// Match V5 API. It allows users to retrieve match information by match ID, fetch timelines for matches, and query
    /// a list of match IDs for a specific player based on various filters such as time range, queue type, and match
    /// type.</remarks>
    public class MatchV5
    {
        /// <summary>
        /// Represents the information associated with this instance.
        /// </summary>
        /// <remarks>This field is read-only and is intended to store metadata or configuration details
        /// relevant to the containing class. It cannot be modified after initialization.</remarks>
        private readonly RiotGameDeveloperPortalConfig _config;

        /// <summary>
        /// Initialize a new instance of the <see cref="MatchV5"/> class with the specified information.
        /// </summary>
        /// <remarks>The <paramref name="config"/> parameter must not be null. The <see
        /// cref="RiotGameDeveloperPortalConfig.Routing"/> property is automatically set to the value of <see cref="RiotGameDeveloperPortalConfig.Continent"/> during
        /// initialization.</remarks>
        /// <param name="config">The account information used to initialize the instance. The <see cref="RiotGameDeveloperPortalConfig.Routing"/> property will be set
        /// to the value of <see cref="RiotGameDeveloperPortalConfig.Continent"/>.</param>
        public MatchV5(RiotGameDeveloperPortalConfig config)
        {
            _config = config;
            // Routing is the continent not the region
            _config.Routing = _config.Continent;
        }

        /// <summary>
        /// Retrieves match information based on the provided match PUUID.
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
            string? data = Request(_config, buildUrl);
            if (data == null)
            {
                return [];
            }
            return JsonConvert.DeserializeObject<List<string>>(data);
        }

        /// <summary>
        /// Retrieve match information by match ID. The match ID is a 64-bit integer.
        /// </summary>
        /// <remarks>This method fetches detailed information about a specific match using its unique match ID.</remarks>
        /// <param name="matchId">The id of match</param>
        /// <returns>An <see cref="MatchDto"/> object containing detailed information about the match, or null if the match could not be found or an error occurred during the request.</returns>
        public MatchDto? Match(Int64 matchId)
        {
            string? data = Request(_config, $"/lol/match/v5/matches/{matchId}");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<MatchDto>(data);
        }

        /// <summary>
        /// Retrieve the timeline of a match by match ID. The match ID is a 64-bit integer.
        /// </summary>
        /// <remarks>This method fetches the timeline data for a specific match, which includes detailed event information that occurred during the match.</remarks>
        /// <param name="matchId">The id of match</param>
        /// <returns>An <see cref="TimelineDto"/> object containing the timeline of the match, or null if the timeline could not be found or an error occurred during the request.</returns>
        public TimelineDto? Timeline(Int64 matchId)
        {
            string? data = Request(_config, $"/lol/match/v5/matches/{matchId}/timeline");
            if (data == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<TimelineDto>(data);
        }
    }
}
