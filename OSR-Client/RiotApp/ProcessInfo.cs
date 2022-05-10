using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OSR_Client.RiotApp
{
    public class ProcessInfo
    {
        private static OSRLogger _logger = new OSRLogger("ProcessInfo");
        public static Process[] NameProcessInfo(string nameProcess)
        {
            try
            {
                Process[] localAll = Process.GetProcessesByName(nameProcess);
                if (localAll.Length > 0)
                {
                    _logger.log(LoggingLevel.INFO, "NameProcessInfo()", $"Found processes info with name {nameProcess}");
                    return localAll;
                }
                else {
                    _logger.log(LoggingLevel.ERROR, "NameProcessInfo()", $"Could not find processes info with name {nameProcess}");
                    return Array.Empty<Process>();
                }
            }
            catch
            {
                _logger.log(LoggingLevel.ERROR, "NameProcessInfo()", $"Could not find processes info with name {nameProcess}");
                return Array.Empty<Process>();
            }
        }

        public static Process IdProcessInfo(int idProcess)
        {
            try
            {
                Process localAll = Process.GetProcessById(idProcess);
                _logger.log(LoggingLevel.INFO, "NameProcessInfo()", $"Found processes ID with name {idProcess}");
                return localAll;
            }
            catch
            {
                _logger.log(LoggingLevel.ERROR, "NameProcessInfo()", $"Could not find processes ID with name {idProcess}");
                return null;
            }
        }
    }
}
