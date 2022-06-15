using System.Net;

namespace OSL_Server.Download
{
    public class Download
    {
        private static OSLLogger _logger = new OSLLogger("Download");
        public static int downloadAllFile;
        public static int errorDownloadAllFile;
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

        //public static void DownloadFileAsync(Uri url, string filePath)
        //{
        private static readonly HttpClient _httpClient = new HttpClient();

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
            //try
            //{
            //HttpClient httpClient = new HttpClient();
            //        private static readonly
            //httpClient.DownloadFileAsync(url, filePath);
            //byte[] response = await httpClient.GetByteArrayAsync(url);
            //File.WriteAllBytes(filePath, response);
            //_logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"File download from {url}");
            //return response;
            //}
            //catch (Exception e)
            //{
            //    _logger.log(LoggingLevel.ERROR, "DownloadFileAsync()", $"Error download from {url}");
            //    //return null;
            //}
            //}
        }
    }
}
