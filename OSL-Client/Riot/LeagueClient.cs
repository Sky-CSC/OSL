using OSL_Client.Configuration;
using OSL_Common.System.FileManager;
using OSL_Common.System.Logging;
using OSL_Common.System.ProcessManager;
using System.Diagnostics;
using System.Text;

namespace OSL_Client.Riot
{
    public class LeagueClient
    {
        private static Logger _logger = new("LeagueClient");

        public static bool CheckLaunch()
        {
            Process[] localAll = ProcessInfo.GetByName(Config.leagueClientProcess);
            if (localAll.Length > 0)
            {
                try
                {
                    Config.leagueClientFullFilePath = localAll[0].MainModule.FileName;
                    string[] splitPath = Config.leagueClientFullFilePath.Split(localAll[0].MainModule.ModuleName);
                    Config.leagueClientPath = splitPath[0];
                    _logger.log(LoggingLevel.INFO, "CheckLaunch()", "Riot Launcher Path : " + Config.leagueClientPath);
                    return true;
                }
                catch (Exception)
                {
                    _logger.log(LoggingLevel.ERROR, "CheckLaunch()", "Riot Launcher Path not found");
                    return false;
                }
            }
            else
            {
                _logger.log(LoggingLevel.ERROR, "CheckLaunch()", "Riot Launcher not found");
                Thread.Sleep(5000);
                return CheckLaunch();
            }
        }

        public static bool LockFile()
        {
            Config.leagueClientLockFilePath = Config.leagueClientPath + "lockfile";
            if (File.Exists(Config.leagueClientLockFilePath))
            {
                string lockFileContent = FileManagerLocal.RestrictedAccess(Config.leagueClientLockFilePath);
                var splitLockFileContent = lockFileContent.Split(':');
                try
                {
                    Config.leagueClientLockFileProcessId = int.Parse(splitLockFileContent[1]);
                    Config.leagueClientLockFilePort = int.Parse(splitLockFileContent[2]);
                    Config.leagueClientLockFilePassword = splitLockFileContent[3];
                    _logger.log(LoggingLevel.INFO, "Check()", "Lock file found, process id: " + Config.leagueClientLockFileProcessId + ", port: " + Config.leagueClientLockFilePort + ", password: " + Config.leagueClientLockFilePassword);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.log(LoggingLevel.ERROR, "Check()", "Error parsing lock file: " + ex.Message);
                    return false;
                }
            }
            else
            {
                _logger.log(LoggingLevel.ERROR, "Check()", $"LockFile not found : {Config.leagueClientLockFilePath}");
                Thread.Sleep(5000);
                return LockFile();
            }
        }


        public static bool SetHostApi()
        {
            try
            {
                Config.leagueClientApiLocalHost = Config.localIpHttp + ":" + Config.leagueClientLockFilePort;
                Config.leagueClientApiPassword = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{Config.riotLogin}:{Config.leagueClientLockFilePassword}"));
                _logger.log(LoggingLevel.INFO, "HostPassGameClientApi()", "Host and password game client api set");
                return true;
            }
            catch
            {
                _logger.log(LoggingLevel.ERROR, "HostPassGameClientApi()", "Error host and password to game client api");
                return false;
            }
        }
    }
}
