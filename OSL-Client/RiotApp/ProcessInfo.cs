using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OSL_Client.RiotApp
{
    public class ProcessInfo
    {
        private static OSLLogger _logger = new OSLLogger("ProcessInfo");
        /// <summary>
        /// Gets the process info by name
        /// </summary>
        /// <param name="nameProcess"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets the process info by id
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
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
