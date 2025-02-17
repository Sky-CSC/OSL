using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Utils
{
    public static class File
    {
        private static readonly Logger _logger = new("File");

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
