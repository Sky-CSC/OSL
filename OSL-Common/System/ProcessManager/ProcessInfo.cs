using System.Diagnostics;

using OSL_Common.System.Logging;

namespace OSL_Common.System.ProcessManager
{
    /// <summary>
    /// Manage process
    /// </summary>
    public class ProcessInfo
    {
        private static Logger _logger = new("ProcessInfo");

        /// <summary>
        /// Get process information by name
        /// </summary>
        /// <param name="nameProcess"></param>
        /// <returns></returns>
        public static Process[] GetByName(string nameProcess)
        {
            try
            {
                Process[] localAll = Process.GetProcessesByName(nameProcess);
                if (localAll.Length > 0)
                {
                    _logger.log(LoggingLevel.INFO, "NameProcessInfo()", $"Found processes info with name {nameProcess}");
                    return localAll;
                }
                else
                {
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
        /// Get process information by ID
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
        public static Process GetById(int idProcess)
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
