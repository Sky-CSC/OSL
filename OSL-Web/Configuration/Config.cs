using OSL_Common.System.Logging;
using OSL_Web.Configuration.CDragon;
using OSL_Web.Configuration.Socket;
using OSL_Web.Configuration.WebApiRiot;
using System.Net;
using OSL_Web.Pages.ChampSelect;
using System.Net.Sockets;

namespace OSL_Web.Configuration
{
    public class Config
    {
        private static Logger _logger = new("Config");

        public static IPHostEntry? webHost;
        public static string? webHostName;
        public static int webHttpPort;
        public static int webHttpsPort;
        public static void LoadConfig()
        {
            LoadConfigWebHost();

            LoadConfigTimer();

            SocketConfig.LoadJsonConfig();
            CDragonConfig.LoadJsonConfig();
            CDragonConfig.LoadDirectoryConfig();
            WebApiRiotConfig.LoadJsonConfig();

            //Load configurations champ select
            Overlay.ChampSelect.View1.Config.LoadConfig();
            Overlay.ChampSelect.View2.Config.LoadConfig();
            Overlay.ChampSelect.View3.Config.LoadConfig();
            Overlay.ChampSelect.View4.Config.LoadConfig();

            //Load configurations in game
            Overlay.InGame.View1.Config.LoadConfig();
            Overlay.InGame.View1_1.Config.LoadConfig();
            Overlay.InGame.View2.Config.LoadConfig();
            //Overlay.InGame.View2_1.Config.LoadConfig();
            Overlay.InGame.View3.Config.LoadConfig();

            //Load configurations end game
            Overlay.EndGame.View1.Config.LoadConfig();
            Overlay.EndGame.View2.Config.LoadConfig();
            Overlay.EndGame.View3.Config.LoadConfig();

            //Load configurations runes
            Overlay.Rune.View1.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Adc.Config.LoadConfig();
            Overlay.Rune.View1.AdcSupp.Config.LoadConfig();
            Overlay.Rune.View1.All.Config.LoadConfig();
            Overlay.Rune.View1.Jungle.Config.LoadConfig();
            Overlay.Rune.View1.Mid.Config.LoadConfig();
            Overlay.Rune.View1.Supp.Config.LoadConfig();
            Overlay.Rune.View1.Top.Config.LoadConfig();

        }

        public static void LoadConfigWebHost()
        {
            webHost = Dns.Resolve("0.0.0.0");
            webHostName = webHost.HostName;
            foreach (var machin in webHost.AddressList)
            {
                if (machin.AddressFamily is AddressFamily.InterNetwork)
                {
                    webHostName = machin.ToString();
                }
            }
            webHttpPort = 4141;
            webHttpsPort = 4242;
        }

        /// <summary>
        /// Load timer for champ select view
        /// </summary>
        public static void LoadConfigTimer()
        {
            //Creation of timer for display him in champ select
            TimeControl.DecreasingTimerChapSelect(100);
            TimeControl.DecreasingTimerChapSelectFast(100, 50);
            TimeControl.DecreasingTimerChapSelectView3(100, 50);
        }

        public static void ReloadPagesView()
        {
            //Load configurations champ select
            Overlay.ChampSelect.View1.Config.LoadPatchRegionConfig();
            Overlay.ChampSelect.View2.Config.LoadPatchRegionConfig();
            Overlay.ChampSelect.View3.Config.LoadPatchRegionConfig();
            Overlay.ChampSelect.View4.Config.LoadPatchRegionConfig();

            //Load configurations in game
            Overlay.InGame.View1.Config.LoadPatchRegionConfig();
            Overlay.InGame.View1_1.Config.LoadPatchRegionConfig();
            Overlay.InGame.View2.Config.LoadPatchRegionConfig();
            Overlay.InGame.View3.Config.LoadPatchRegionConfig();

            //Load configurations end game
            Overlay.EndGame.View1.Config.LoadPatchRegionConfig();
            Overlay.EndGame.View2.Config.LoadPatchRegionConfig();
            Overlay.EndGame.View3.Config.LoadPatchRegionConfig();

            //Load configurations runes
            Overlay.Rune.View1.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Adc.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.AdcSupp.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.All.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Jungle.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Mid.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Supp.Config.LoadPatchRegionConfig();
            Overlay.Rune.View1.Top.Config.LoadPatchRegionConfig();
        }

        public static void LoadDefaultDataChampSelect()
        {

        }

        public static void LoadDefaultDataEndGame()
        {

        }
    }
}
