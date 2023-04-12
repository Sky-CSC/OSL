using OSL_Common.System.Logging;

namespace OSL_Common.System.FileManager
{
    /// <summary>
    /// Manage file in local
    /// </summary>
    public class FileManagerLocal
    {
        private static Logger _logger = new ("FileManagerLocal");

        /// <summary>
        /// Creates a new file in the local file system
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath);
                    _logger.log(LoggingLevel.INFO, "CreateFile", $"File create : {filePath}");
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    _logger.log(LoggingLevel.ERROR, "CreateFile", ex.Message);
                }
            }
        }
        /// <summary>
        /// Deletes a file in the local file system
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    _logger.log(LoggingLevel.INFO, "DeleteFile", $"File delete : {filePath}");
                }
                catch (Exception ex)
                {
                    _logger.log(LoggingLevel.ERROR, "DeleteFile", ex.Message);
                }
            }
        }

        /// <summary>
        /// Rewrite data in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static void RewrittenFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
                _logger.log(LoggingLevel.INFO, "RewrittenFile", $"File write : {filePath}");

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "RewrittenFile", ex.Message);
            }
        }
        /// <summary>
        /// Write data in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static void WriteInFile(string filePath, string content)
        {

            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                _logger.log(LoggingLevel.ERROR, "WriteInFile()", ex.Message);
            }
        }
        /// <summary>
        /// Read data in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadInFile(string filePath)
        {
            string content = "";
            try
            {
                content = File.ReadAllText(filePath);
                _logger.log(LoggingLevel.INFO, "ReadInFile", $"File read : {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadInFile()", e.Message);
            }
            return content;
        }

        /// <summary>
        /// Read data on file
        /// </summary>
        /// <param name="path">Path of file</param>
        /// <returns>Data of file contenf</returns>
        public static string ReadFilePath(string path)
        {
            string data = "";
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    data = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadFilePath()", e.Message);
            }
            return data;
        }

        /// <summary>
        /// Read in file if is use by an other application (lockfile)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string RestrictedAccess(string filePath)
        {
            string content = "";
            try
            {
                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var reader = new StreamReader(fileStream);
                content = reader.ReadLine();
                _logger.log(LoggingLevel.INFO, "ReadInFile()", $"File read : {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadInFile()", e.Message);
            }
            return content;
        }
    }
}

