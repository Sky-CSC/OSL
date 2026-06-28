using OSL_Utils;
using System.Diagnostics;

namespace OSL_Lcu
{
    /// <summary>
    /// Data for connect to LCU API
    /// </summary>
    internal class LockFile
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger _logger = new("LockFile");

        /// <summary>
        /// League client process name
        /// </summary>
        public string? ProcessName;

        /// <summary>
        /// League client process id
        /// </summary>
        public int ProcessId;

        /// <summary>
        /// Port of LCU API
        /// </summary>
        public int Port;

        /// <summary>
        /// Password of LCU API
        /// </summary>
        public string? Password;

        /// <summary>
        /// Type of protocol (http/https)
        /// </summary>
        public string? Protocol;

        /// <summary>
        /// Get data from lockfile file in League Client directory
        /// </summary>
        /// <param name="processName">League Client process name</param>
        public LockFile(string processName)
        {
            //Find League of Legends process
            Process[] processes = Process.GetProcessesByName(processName);
            //Set League of Legends process path
            string? leagueClientPath = processes.Length > 0 ? processes[0].MainModule?.FileName : string.Empty;
            if (string.IsNullOrEmpty(leagueClientPath))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(LockFile), $"Process {processName} not found");
                return;
            }
            _logger.Log(LoggingLevel.INFO, nameof(LockFile), $"Process {processName} found at {leagueClientPath}");
            //Set League of Legends lockFile
            string lockFilePath = OSL_Utils.Path.GetDirectoryName(leagueClientPath) + "/lockfile";
            //Read lockFile data and set properties
            string[] lockFileData = OSL_Utils.File.ReadIfRestricted(lockFilePath)?.Split(':') ?? [];
            ProcessName = lockFileData.Length > 0 ? lockFileData[0] : string.Empty;
            ProcessId = lockFileData.Length > 1 ? int.Parse(lockFileData[1]) : 0;
            Port = lockFileData.Length > 2 ? int.Parse(lockFileData[2]) : 0;
            Password = lockFileData.Length > 3 ? lockFileData[3] : string.Empty;
            Protocol = lockFileData.Length > 4 ? lockFileData[4] : string.Empty;
        }
    }
}
