namespace OSL_Utils
{
    /// <summary>
    /// Provides methods for manipulating files.
    /// </summary>
    public static class File
    {
        /// <summary>
        /// Logger for the class.
        /// </summary>
        private static readonly Logger _logger = new("File");

        /// <summary>
        /// Write string content to a file.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="content">String to write</param>
        /// <returns>True if write is ok</returns>
        public static bool Write(string filePath, string content)
        {
            try
            {
                System.IO.File.WriteAllText(filePath, content);
                _logger.Log(LoggingLevel.DEBUG, "Write()", $"Data write in file {filePath} successfully");
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Write()", $"Data not write in file {filePath}, {e.Message}");
            }
            return false;
        }

        /// <summary>
        /// Write byte content to a file.
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <param name="content">Byte to write</param>
        /// <returns>True if write is ok</returns>
        public static bool Write(string filePath, byte[] content)
        {
            try
            {
                System.IO.File.WriteAllBytes(filePath, content);
                _logger.Log(LoggingLevel.DEBUG, "Write()", $"Data write un file {filePath} successfully");
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Write()", $"Data not write un file {filePath}, {e.Message}");
            }
            return false;
        }

        /// <summary>
        /// Read data from a file.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Content</returns>
        public static string? Read(string filePath)
        {
            try
            {
                string content = System.IO.File.ReadAllText(filePath);
                _logger.Log(LoggingLevel.DEBUG, "Read()", $"Data read from file {filePath} successfully");
                return content;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Read()", $"Data not read from file {filePath}, {e.Message}");
            }
            return null;
        }

        /// <summary>
        /// Read data from a file same is used by an other application.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>Content</returns>
        public static string? ReadIfRestricted(string filePath)
        {
            try
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var reader = new StreamReader(fileStream);
                string? content = reader.ReadLine();
                _logger.Log(LoggingLevel.DEBUG, "Read()", $"Data read from file {filePath} successfully");
                return content;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Read()", $"Data not read from file {filePath}, {e.Message}");
            }
            return null;
        }

        /// <summary>
        /// Check if a file exist.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>True if file exist</returns>
        public static bool Exist(string filePath)
        {
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    _logger.Log(LoggingLevel.DEBUG, "Exist()", $"File {filePath} exist");
                    return true;
                }
                _logger.Log(LoggingLevel.DEBUG, "Exist()", $"File {filePath} not exist");
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Exist()", $"File {filePath} not exist, {e.Message}");
            }
            return false;
        }

        /// <summary>
        /// Copy a file and return the destination file path.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destFile"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static string Copy(string sourceFile, string destFile, bool overwrite = false)
        {
            try
            {
                System.IO.File.Copy(sourceFile, destFile, overwrite);
                _logger.Log(LoggingLevel.DEBUG, "Copy()", $"File {sourceFile} copy to {destFile}");
                return destFile;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Copy()", $"File {sourceFile} not copy to {destFile}, {e.Message}");
                return "";
            }
        }
    }
}
