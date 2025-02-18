namespace OSL_Utils
{
    /// <summary>
    /// Provides methods for manipulating paths.
    /// </summary>
    public static class Path
    {
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
                    return directoryName.Replace(System.IO.Path.DirectorySeparatorChar, '/');
                }
            }
            return "";
        }
    }
}
