namespace OSL_Utils
{
    /// <summary>
    /// Provides methods for manipulating paths.
    /// </summary>
    public static class Path
    {
        /// <summary>
        /// Logger for the class.
        /// </summary>
        private static readonly Logger _logger = new("File");

        /// <summary>
        /// Combines two or more strings into a path and replace \ by /.
        /// </summary>
        /// <param name="paths">List of path</param>
        /// <returns>Combined path with /</returns>
        public static string Combine(params string[] paths)
        {
            string combinedPath = System.IO.Path.Combine(paths);
            return combinedPath.Replace(System.IO.Path.DirectorySeparatorChar, '/');
        }

        /// <summary>
        /// Get the directory name of a path and replace \ by /.
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns>Path with /</returns>
        public static string GetDirectoryName(string path)
        {
            if (path != null)
            {
                string? directoryName = System.IO.Path.GetDirectoryName(path);
                if (directoryName != null)
                {
                    _logger.Log(LoggingLevel.DEBUG, "GetDirectoryName()", $"Directory name is valid for path: {path}");
                    return directoryName.Replace(System.IO.Path.DirectorySeparatorChar, '/');
                }
            }
            _logger.Log(LoggingLevel.DEBUG, "GetDirectoryName()", $"Directory name is empty for path: {path}");
            return "";
        }

        /// <summary>
        /// Remove a prefix path to a path, and remove / if is th first caracter
        /// </summary>
        /// <param name="path">The full path</param>
        /// <param name="wwwRootPath">Path to remove</param>
        /// <returns></returns>
        public static string ToWebPath(string path, string wwwRootPath)
        {
            if (string.IsNullOrWhiteSpace(path))
                return "";
            if (string.IsNullOrWhiteSpace(wwwRootPath))
                return path;

            string fullAbsolute = System.IO.Path.GetFullPath(path);
            string fullRoot = System.IO.Path.GetFullPath(wwwRootPath);

            string relative = System.IO.Path.GetRelativePath(fullRoot, fullAbsolute);

            return relative.Replace("\\", "/").TrimStart('/');
        }
    }
}
