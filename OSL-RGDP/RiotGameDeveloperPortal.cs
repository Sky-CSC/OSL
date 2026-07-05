using Newtonsoft.Json;
using OSL_RGDP.Schema;
using OSL_Utils;

namespace OSL_RGDP
{
    /// <summary>
    /// Provide access to Riot Games Developer Portal API.
    /// </summary>
    /// <remarks>The API is documented at https://developer.riotgames.com/docs/lol</remarks>
    /// <param name="config">Information for connect to API</param>
    public class RiotGameDeveloperPortal(RiotGameDeveloperPortalConfig config)
    {
        /// <summary>
        /// Account information.
        /// </summary>
        public AccountV1 Account { get; } = new AccountV1(config);
        /// <summary>
        /// Match information.
        /// </summary>
        public MatchV5 Match { get; } = new MatchV5(config);
        /// <summary>
        /// Spectator game information.
        /// </summary>
        public SpectatorV5 Spectator { get; } = new SpectatorV5(config);
        /// <summary>
        /// Status information.
        /// </summary>
        public StatusV4 Status { get; } = new StatusV4(config);
    }

    /// <summary>
    /// Managements of request for connect to Riot Games Developer Portal API
    /// </summary>
    /// <remarks>The API is documented at https://developer.riotgames.com/docs/lol</remarks>
    internal static class RgdpApi
    {
        /// <summary>
        /// A static instance of the <see cref="Logger"/> class used for logging messages related to the
        /// <c>WebSocketClient</c>.
        /// </summary>
        /// <remarks>This logger is initialized with the name "ApiRequest" to categorize log
        /// messages. It is intended for internal use within the class and is not exposed to external
        /// consumers.</remarks>
        private static readonly Logger _logger = new("ApiRequest");

        /// <summary>
        /// Manages downloading data from the internet.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// Request to Riot Games Developer Portal API.
        /// </summary>
        /// <param name="config">Configuration setings</param>
        /// <param name="urlRequest">Url to retrieve data</param>
        /// <returns>Response data</returns>
        internal static string? Request(RiotGameDeveloperPortalConfig config, string urlRequest)
        {
            try
            {
                urlRequest = $"{config.Https}{config.Routing}{config.Domain}{urlRequest}";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlRequest);
                httpRequest.Headers.Add("X-Riot-Token", config.ApiKey);
                var response = _download.GetResponse(httpRequest).Result;
                _logger.Log(LoggingLevel.INFO, nameof(Request), $"Request {urlRequest} succesful");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Request), $"Error request {urlRequest} : {e.Message}");
                return null;
            }
        }
    }
}
