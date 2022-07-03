using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OSL_Server;

namespace OSL_Server.FileManager
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
                    //throw new Exception(ex.Message);
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
            //if (File.Exists(filePath))
            //{
            try
            {
                //using (StreamWriter sw = File.AppendText(filePath))
                //{
                //    sw.WriteLine(content);
                //    sw.Close();
                //    sw.Dispose();
                //}
                //_logger.log(LoggingLevel.INFO, "WriteInFile", $"File write : {filePath}");
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "WriteInFile", ex.Message);
                //}
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
                _logger.log(LoggingLevel.ERROR, "ReadInFile", e.Message);
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

            }
            return data;
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
                //_logger.log(LoggingLevel.INFO, "CreateDirectory", $"Directory create : {directoryPath}");
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "CreateDirectory", $"Error creation directory {ex.Message}");
            }
        }
        else
        {
            //_logger.log(LoggingLevel.INFO, "CreateDirectory", $"Already created : {directoryPath}");
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
                //throw new Exception(ex.Message);
                _logger.log(LoggingLevel.ERROR, "DeleteDirectory", ex.Message);
            }
        }
    }

    public static void DirectoryInitDataCDragon(string numPatch, string region)
    {
        string championDirectory = "./" + numPatch + "/" + region + "/" + "Champions" + "/";
        string itemsDirectory = "./" + numPatch + "/" + region + "/" + "Items" + "/";
        string summonerSpellsDirectory = "./" + numPatch + "/" + region + "/" + "SummonerSpells" + "/";
        string perksDirectory = "./" + numPatch + "/" + region + "/" + "Perks" + "/";
        CreateDirectory(championDirectory);
        CreateDirectory(itemsDirectory);
        CreateDirectory(summonerSpellsDirectory);
        CreateDirectory(perksDirectory);
    }
}

