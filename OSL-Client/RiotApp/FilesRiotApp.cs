using OSL_Client.Configuration;
using OSL_Client.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.RiotApp
{
    /// <summary>
    /// Files Riot App
    /// </summary>
    internal class FilesRiotApp
    {
        private static OSLLogger _logger = new OSLLogger("FilesRiotApp");

        /// <summary>
        /// Get informations content in lockfile
        /// </summary>
        public static bool LockFileCheck()
        {
            Config.lockFilePath = Config.leagueClientPath + "lockfile";
            if (File.Exists(Config.lockFilePath))
            {
                string lockFileContent = FileManagerLocal.RestrictedAccess(Config.lockFilePath);
                var splitLockFileContent = lockFileContent.Split(':');
                try
                {
                    Config.lockFileProcessId = int.Parse(splitLockFileContent[1]);
                    Config.lockFilePort = int.Parse(splitLockFileContent[2]);
                    Config.lockFilePassword = splitLockFileContent[3];
                    _logger.log(LoggingLevel.INFO, "LockFileChecker()", "Lock file found, process id: " + Config.lockFileProcessId + ", port: " + Config.lockFilePort + ", password: " + Config.lockFilePassword);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.log(LoggingLevel.ERROR, "LockFileChecker()", "Error parsing lock file: " + ex.Message);
                    return false;
                }
            }
            else
            {
                _logger.log(LoggingLevel.ERROR, "LockFileChecker()", $"LockFile not found : {Config.lockFilePath}");
                Thread.Sleep(5000);
                return LockFileCheck();
            }
        }
    }
}
