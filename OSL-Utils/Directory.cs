namespace OSL_Utils
{
    /// <summary>
    /// Provides methods for manipulating directories.
    /// </summary>
    public static class Directory
    {
        /// <summary>
        /// Logger for the class.
        /// </summary>
        private static readonly Logger _logger = new("Directory");

        /// <summary>
        /// Create a directory.
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True if direcotry is created</returns>
        public static bool Create(string path)
        {
            try
            {
                System.IO.Directory.CreateDirectory(path);
                _logger.Log(LoggingLevel.INFO, "Create()", $"Directory {path} created successfully");
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Create()", $"Directory {path} not created : {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Check if a directory exist.
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>True if directory exist</returns>
        public static bool Exist(string path)
        {
            try
            {
                bool exist = System.IO.Directory.Exists(path);
                _logger.Log(LoggingLevel.INFO, "Exist()", $"Directory {path} exist : {exist}");
                return exist;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Exist()", $"Directory {path} not found : {e.Message}");
                return false;
            }
        }
    }
}
