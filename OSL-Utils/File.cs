using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _logger.Log(LoggingLevel.INFO, "Write()", $"Data write un file {filePath} successfully");
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Write()", $"Data not write un file {filePath}, {e.Message}");
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
                _logger.Log(LoggingLevel.INFO, "Write()", $"Data write un file {filePath} successfully");
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
                _logger.Log(LoggingLevel.INFO, "Read()", $"Data read from file {filePath} successfully");
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
                    _logger.Log(LoggingLevel.INFO, "Exist()", $"File {filePath} exist");
                    return true;
                }
                _logger.Log(LoggingLevel.INFO, "Exist()", $"File {filePath} not exist");
            }
            catch (Exception e)
            {
                _logger.Log(LoggingLevel.ERROR, "Exist()", $"File {filePath} not exist, {e.Message}");
            }
            return false;
        }
    }
}
