using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OSR_Client.RiotApp.API;
using OSR_Client.RiotApp.API.LCU;

namespace OSR_Client.RiotApp.DataProcessing
{
    internal class ChampionSelect
    {
        private static OSRLogger _logger = new OSRLogger("ChampionSelect");
        public static void ManageChampionSelect()
        {
            //string champSelectContent = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectv1session);
            //string champSelectContentLegacy = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectlegacyv1session);
            string test = ApiRequest.RequestGameClientAPI(UrlRequest.lolchampselectv1currentchampion);
            //if (champSelectContent == null)
            if (test == null)
            {
                _logger.log(LoggingLevel.ERROR, "ManageChampionSelect()", "ChampSelectContent is null");
            }
            else
            {
                //_logger.log(LoggingLevel.INFO, "ManageChampionSelect()", $"ChampSelectContent is {champSelectContent}");
                _logger.log(LoggingLevel.INFO, "ManageChampionSelect()", $"ChampSelectContent is {test}");
                //send post att server
                
            }
        }
    }
}
