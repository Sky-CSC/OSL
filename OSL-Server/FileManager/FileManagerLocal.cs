using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using OSL_Server;
using OSL_Server.Configuration;
using OSL_Server.DataLoader.CDragon;

namespace OSL_Server.FileManager
{
    /// <summary>
    /// Manage file in local
    /// </summary>
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
                _logger.log(LoggingLevel.ERROR, "WriteInFile", ex.Message);
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
                if(DateTime.Compare(defaultTime, directory.CreationTime) <= 0)
                {
                    defaultTime = directory.CreationTime;
                    latestDirectory = directory;
                }
            }
        }
        return latestDirectory.Name;
    }

    public static string championDirectory;
    public static string itemsDirectory;
    public static string summonerSpellsDirectory;
    public static string perksDirectory;

    /// <summary>
    /// Directory Init Data CDragon for save locally
    /// </summary>
    /// <param name="numPatch"></param>
    /// <param name="region"></param>
    public static void DirectoryInitDataCDragon(string numPatch, string region)
    {
        championDirectory = "./wwwroot/assets/" + numPatch + "/" + region + "/" + "Champions" + "/";
        itemsDirectory = "./wwwroot/assets/" + numPatch + "/" + region + "/" + "Items" + "/";
        summonerSpellsDirectory = "./wwwroot/assets/" + numPatch + "/" + region + "/" + "SummonerSpells" + "/";
        perksDirectory = "./wwwroot/assets/" + numPatch + "/" + region + "/" + "Perks" + "/";
        CreateDirectory(championDirectory);
        CreateDirectory(itemsDirectory);
        CreateDirectory(summonerSpellsDirectory);
        CreateDirectory(perksDirectory);
    }
}

