using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSL_Client;

namespace OSL_Client.FileManager
{
    public class FileManagerLocal
    {
        private static OSLLogger _logger = new OSLLogger("FileManagerLocal");
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
                    _logger.log(LoggingLevel.INFO, "CreateFile()", $"File create : {filePath}");
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    _logger.log(LoggingLevel.ERROR, "CreateFile()", ex.Message);
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
                    _logger.log(LoggingLevel.INFO, "DeleteFile()", $"File delete : {filePath}");
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    _logger.log(LoggingLevel.ERROR, "DeleteFile()", ex.Message);
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
                _logger.log(LoggingLevel.INFO, "RewrittenFile()", $"File write : {filePath}");

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "RewrittenFile()", ex.Message);
            }
        }
        /// <summary>
        /// Write data in file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static void WriteInFile(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(content);
                        sw.Close();
                        sw.Dispose();
                    }
                    _logger.log(LoggingLevel.INFO, "WriteInFile()", $"File write : {filePath}");
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    _logger.log(LoggingLevel.ERROR, "WriteInFile()", ex.Message);
                }
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
                _logger.log(LoggingLevel.INFO, "ReadInFile()", $"File read : {filePath}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReadInFile()", e.Message);
            }
            return content;
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

public class DirectoryManagerLocal
{
    private static OSLLogger _logger = new("DirectoryManagerLocal");
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
                _logger.log(LoggingLevel.INFO, "CreateDirectory()", $"Directory create : {directoryPath}");
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "CreateDirectory()", ex.Message);
            }
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
                _logger.log(LoggingLevel.INFO, "DeleteDirectory()", $"Directory delete : {directoryPath}");
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "DeleteDirectory()", ex.Message);
            }
        }
    }
}

