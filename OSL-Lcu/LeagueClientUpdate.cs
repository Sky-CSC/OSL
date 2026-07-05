using OSL_Utils;
using System.Net.Http.Headers;
using System.Text;

namespace OSL_Lcu
{
    /// <summary>
    /// Managements of request for connect to LCU API
    /// </summary>
    /// <param name="LeagueClientProcessName">League process</param>
    public class LeagueClientUpdate(string LeagueClientProcessName)
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger _logger = new("LeagueClientUpdate");

        /// <summary>
        /// Lock file data
        /// </summary>
        private readonly LockFile _lockFile = new(LeagueClientProcessName);

        /// <summary>
        /// LCU API request 
        /// </summary>
        /// <param name="RequestName">Path of request</param>
        /// <returns>Data of request</returns>
        public string? Request(string RequestName)
        {
            try
            {
                string urlRequest = $"{_lockFile.Protocol}://127.0.0.1:{_lockFile.Port}{RequestName}";
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlRequest);
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.Headers.Add("Host", $"127.0.0.1:{_lockFile.Port}");
                httpRequest.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{_lockFile.Password}"))}");

                var response = Download.GetResponseSelfSigned(httpRequest).Result;
                _logger.Log(LoggingLevel.INFO, nameof(Request), $"Request {urlRequest} succesful");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Request), $"Request {RequestName} failed: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// LCU API async request
        /// </summary>
        /// <param name="RequestName">Path of request</param>
        /// <returns>Data of request</returns>
        public async Task<string?> RequestAsync(string RequestName)
        {
            try
            {
                string urlRequest = $"{_lockFile.Protocol}://127.0.0.1:{_lockFile.Port}{RequestName}";

                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using var client = new HttpClient(handler, disposeHandler: true);
                using var request = new HttpRequestMessage(HttpMethod.Get, urlRequest);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Host = $"127.0.0.1:{_lockFile.Port}";
                var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{_lockFile.Password}"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                _logger.Log(LoggingLevel.INFO, nameof(RequestAsync), $"Request {urlRequest} successful");
                return content;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(RequestAsync), $"Request {RequestName} failed: {e.Message}");
                return null;
            }
        }
    }
}
