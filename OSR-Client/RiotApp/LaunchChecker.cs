using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OSR_Client.Configuration;

namespace OSR_Client.RiotApp
{
    /// <summary>
    /// Check all programm or what is launch in relation of RIOT
    /// </summary>
    public class LaunchChecker
    {
        private static OSRLogger _logger = new OSRLogger("LaunchChecker");
        /// <summary>
        /// Check if League Of Legends client is launch
        /// </summary>
        /// <returns></returns>
        public static void LoLLauncherCheck()
        {
            Process[] localAll = ProcessInfo.NameProcessInfo(Config.LeagueClientProcess);
            if (localAll.Length > 0)
            {
                try
                {
                    Config.LeagueClientFullFilePath = localAll[0].MainModule.FileName;
                    string[] splitPath = Config.LeagueClientFullFilePath.Split(localAll[0].MainModule.ModuleName);
                    Config.LeagueClientFilePath = splitPath[0];
                    _logger.log(LoggingLevel.INFO, "LaunchChecker()", "Riot Launcher Path : " + Config.LeagueClientFilePath);
                }
                catch (Exception)
                {
                    _logger.log(LoggingLevel.ERROR, "LaunchChecker()", "Riot Launcher Path not found");
                }
            }
            else
            {
                Thread.Sleep(5000);
                LoLLauncherCheck();
            }
        }
    }
}
