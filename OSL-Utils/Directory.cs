using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Utils
{
    public static class Directory
    {
        private static readonly Logger _logger = new("Directory");

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
