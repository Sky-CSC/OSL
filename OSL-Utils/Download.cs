using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="url"></param>
        /// <returns></returns>
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
    }
}
