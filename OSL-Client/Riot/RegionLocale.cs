using Newtonsoft.Json;
using OSL_Client.Configuration;
using OSL_Client.Sockets;
using OSL_LcuApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Riot
{
    public class RegionLocale
    {
        public static void SetRegionLocale()
        {
            var regionLocaleSettingStart = new GameFlow.GameFlow.PhaseStatus
            {
                Phase = "SetRegionLocale",
                Status = "Running",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string regionLocaleSettingStartSend = JsonConvert.SerializeObject(regionLocaleSettingStart);
            AsyncClient.Send(regionLocaleSettingStartSend);

            //Send region-locale information
            string regionLocaleInfo = LcuApi.Request(LcuApi.Url.lolpublishingcontentv1listenerspubhubconfig, Config.leagueClientLockFilePort, Config.leagueClientApiLocalHost, Config.leagueClientApiPassword);
            if (regionLocaleInfo != null)
            {
                AsyncClient.Send(regionLocaleInfo);
            }

            var regionLocaleSettingEnd = new GameFlow.GameFlow.PhaseStatus
            {
                Phase = "SetRegionLocale",
                Status = "End",
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            string regionLocaleSettingEndSend = JsonConvert.SerializeObject(regionLocaleSettingEnd);
            AsyncClient.Send(regionLocaleSettingEndSend);
        }
    }
}
