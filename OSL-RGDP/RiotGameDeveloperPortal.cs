using OSL_RGDP.Schema;
using OSL_Utils;

namespace OSL_RGDP
{
    /// <summary>
    /// Riot Game Developer Portal api. Account, Match and Spectator information.
    /// </summary>
    /// <param name="info">Info for download informations</param>
    public class RiotGameDeveloperPortal(Info info)
    {
        /// <summary>
        /// Account information.
        /// </summary>
        public AccountV1 Account { get; } = new AccountV1(info);
        /// <summary>
        /// Match information.
        /// </summary>
        public MatchV5 Match { get; } = new MatchV5(info);
        /// <summary>
        /// Spectator game information.
        /// </summary>
        public SpectatorV5 Spectator { get; } = new SpectatorV5(info);
    }

    /// <summary>
    /// Request data from the API.
    /// </summary>
    internal static class RgdpApi
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger _logger = new("ApiRequest");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// Request data from the API.
        /// </summary>
        /// <param name="region">Region or rooting used</param>
        /// <param name="urlRequest">Url</param>
        /// <param name="info">Info used for complete the request</param>
        /// <returns>Data returned by request</returns>
        internal static string? Request(Info info, string urlRequest)
        {
            try
            {
                urlRequest = $"{info.Https}{info.Routing}{info.Domain}{urlRequest}";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlRequest);
                httpRequest.Headers.Add("X-Riot-Token", info.ApiKey);
                var response = _download.GetResponse(httpRequest).Result;
                _logger.Log(LoggingLevel.INFO, "Request()", $"Request {urlRequest} succesful");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Request()", $"Error request {urlRequest} : {e.Message}");
                return null;
            }
        }
    }
}
