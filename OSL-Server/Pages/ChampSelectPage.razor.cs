using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.Forms;
using OSL_Server.DataLoader.CDragon;
using OSL_Server.Download;
using OSL_Server.DataReciveClient.Processing.ChampSelect;

namespace OSL_Server.Pages
{
    public partial class ChampSelectPage
    {
        private static OSLLogger _logger = new OSLLogger("CDragonPage");
        public static string linkOverlayChampSelect = "";
        public static string champ = "./default-square.png";
        public static string champBan1;
        //private static void LinkGenerator()
        //{
            
        //    linkOverlayChampSelect = "tesmps";
        //}

        public static void DisplayInfo()
        {
            //Console.WriteLine(JsonConvert.SerializeObject(ChampSelectInfo.session, Formatting.Indented));
            //Console.WriteLine(ChampSelectInfo.session.Bans.MyTeamBans[0]);
            //if (ChampSelectInfo.session.Bans.MyTeamBans[0] == 432)
            //{
            //    Console.WriteLine(Directory.GetCurrentDirectory());
            //    champ = "../wwroot/assets/12.12/fr_fr/Champions/432/default-square.png";
            //    Console.WriteLine(File.Exists(champ));
            //}

            //foreach (var item in ChampSelectInfo.session.Bans.MyTeamBans)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach(var item in ChampSelectInfo.session.Bans.TheirTeamBans)
            //{
            //    Console.WriteLine(item);
            //}


            //foreach(var chamPick in ChampSelectInfo.session.MyTeam)
            //{

            //}
        }
    }
}
