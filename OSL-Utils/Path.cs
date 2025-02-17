namespace OSL_Utils
{
    public static class Path
    {
        public static string Combine(params string[] paths)
        {
            string combinedPath = System.IO.Path.Combine(paths);
            return combinedPath.Replace(System.IO.Path.DirectorySeparatorChar, '/');
        }
    }
}
