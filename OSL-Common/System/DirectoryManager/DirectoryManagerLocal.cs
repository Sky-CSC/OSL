using OSL_Common.System.Logging;

namespace OSL_Common.System.DirectoryManager
{
    public class DirectoryManagerLocal
    {
        private static Logger _logger = new("DirectoryManagerLocal");
        /// <summary>
        /// Creates a new directory in the local file system
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                    _logger.log(LoggingLevel.INFO, "CreateDirectory", $"Directory create : {directoryPath}");
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    _logger.log(LoggingLevel.ERROR, "CreateDirectory", $"Error creation directory {ex.Message}");
                }
            }
            else
            {
                _logger.log(LoggingLevel.INFO, "CreateDirectory", $"Already created : {directoryPath}");
            }
        }
        /// <summary>
        /// Deletes a directory in the local file system
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.Delete(directoryPath);
                    _logger.log(LoggingLevel.INFO, "DeleteDirectory", $"Directory delete : {directoryPath}");
                }
                catch (Exception ex)
                {
                    _logger.log(LoggingLevel.ERROR, "DeleteDirectory", ex.Message);
                }
            }
        }

        /// <summary>
        /// Check Directory
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static DirectoryInfo CheckDirectory(string directoryPath)
        {
            DirectoryInfo d = new DirectoryInfo(directoryPath);
            return d;
        }

        /// <summary>
        /// Check Existing Directory Patch
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static string CheckExistingDirectoryPatch(string directoryPath)
        {
            DirectoryInfo d = new DirectoryInfo(directoryPath);
            var allDirectory = d.EnumerateDirectories();
            DateTime defaultTime = new DateTime();
            DirectoryInfo latestDirectory = null;
            foreach (DirectoryInfo directory in allDirectory)
            {
                if (directory.Name.Contains("."))
                {
                    if (DateTime.Compare(defaultTime, directory.CreationTime) <= 0)
                    {
                        defaultTime = directory.CreationTime;
                        latestDirectory = directory;
                    }
                }
            }
            return latestDirectory.Name;
        }
    }
}

