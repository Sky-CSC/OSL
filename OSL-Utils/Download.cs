namespace OSL_Utils
{
    /// <summary>
    /// Download data from the internet.
    /// </summary>
    public class Download
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Download");

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient = new();

        /// <summary>
        /// Download a string from a URL.
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>String read</returns>
        public async Task<string?> StringAsync(Uri url)
        {
            try
            {
                string response = await _httpClient.GetStringAsync(url);
                _logger.Log(LoggingLevel.INFO, "StringAsync()", $"Data from {url} download successfully");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "StringAsync()", $"{url} not downloaded : {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Download a byte array from a URL.
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Bytes read</returns>
        public async Task<byte[]?> FileAsync(Uri url)
        {
            try
            {
                byte[] response = await _httpClient.GetByteArrayAsync(url);
                _logger.Log(LoggingLevel.INFO, "FileAsync()", $"Data from {url} download successfully");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "FileAsync()", $"{url} not downloaded : {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Download and save a file from a URL.
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="directory">Path to save file</param>
        /// <param name="fileName">File name</param>
        /// <returns>Path of downloaded file</returns>
        public string DownloadFile(Uri url, string directory, string fileName)
        {
            byte[]? data = FileAsync(url).Result;
            if (data != null)
            {
                try
                {
                    string filePath = Path.Combine(directory, $"{fileName}");
                    // Create directory if not exist, if already exist, do nothing
                    Directory.Create(directory);
                    File.Write(filePath, data);
                    _logger.Log(LoggingLevel.INFO, "DownloadFile()", $"File {fileName} downloaded");
                    return filePath;

                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, "DownloadFile()", $"File {fileName} not downloaded : {e.Message}");
                }
            }
            _logger.Log(LoggingLevel.ERROR, "DownloadFile()", $"File {fileName} not downloaded");
            return "";
        }

        /// <summary>
        /// Get the response from a request.
        /// </summary>
        /// <param name="httpRequestMessage">Http resquest</param>
        /// <returns>Response or null if no response evalable</returns>
        public async Task<string?> GetResponse(HttpRequestMessage httpRequestMessage)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                _logger.Log(LoggingLevel.INFO, "GetResponse()", $"Response : {httpRequestMessage.RequestUri} succesful");
                return content;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "GetResponse()", $"Error : {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get the response from a request, accepting self-signed SSL certificates (e.g., LeagueClient API).
        /// </summary>
        /// <param name="httpRequestMessage">Http request</param>
        /// <returns>Response content or null if an error occurred</returns>
        public static async Task<string?> GetResponseSelfSigned(HttpRequestMessage httpRequestMessage)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using var httpClient = new HttpClient(handler);

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                string content = await httpResponseMessage.Content.ReadAsStringAsync();

                _logger.Log(LoggingLevel.INFO, "GetResponse()", $"Response: {httpRequestMessage.RequestUri} successful");

                _logger.Log(LoggingLevel.ERROR, "GetResponse()", $"StatusCode: {httpResponseMessage.StatusCode}");
                _logger.Log(LoggingLevel.ERROR, "GetResponse()", $"Headers: {httpResponseMessage.Headers}");

                return content;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "GetResponse()", $"Error: {e.Message}");
                return null;
            }
        }
    }
}
