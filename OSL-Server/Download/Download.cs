using System.Net;

namespace OSL_Server.Download
{
    /// <summary>
    /// Download file
    /// </summary>
    public class Download
    {
        private static OSLLogger _logger = new OSLLogger("Download");
        public static int downloadAllFile;
        public static int errorDownloadAllFile;
        /// <summary>
        /// Download String Async
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> DownloadStringAsync(Uri url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string response = await httpClient.GetStringAsync(url);
                _logger.log(LoggingLevel.INFO, "DownloadStringAsync()", $"Information download from {url}");
                return response;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "DownloadStringAsync()", $"Error download from {url}");
                return null;
            }
        }

        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Download File Async
        /// </summary>
        /// <param name="url"></param>
        /// <param name="outputPath"></param>
        public static async void DownloadFileAsync(Uri url, string outputPath)
        {
            try
            {
                downloadAllFile++;
                byte[] fileBytes = await _httpClient.GetByteArrayAsync(url);
                File.WriteAllBytes(outputPath, fileBytes);
                downloadAllFile--;                
                _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"Information download from {url}");
            }
            catch (Exception e)
            {
                errorDownloadAllFile++;
                _logger.log(LoggingLevel.ERROR, "DownloadFileAsync()", $"Error download from {url} : {e.Message}");
            }
        }
    }
}
