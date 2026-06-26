using Microsoft.Extensions.Options;
using OSL_Lcu;
using OSL_Lcu.Schema.Lcu;
using OSL_RGDP;
using OSL_Server.Phases;
using OSL_Server.Schema;
using OSL_Server.WebSocketServer;
using OSL_Utils;
using System.Diagnostics;

namespace OSL_Server.Services
{
    /// <summary>
    /// League Client service to monitor and interact with the League of Legends client.
    /// </summary>
    public class LeagueClient : BackgroundService
    {
        private static readonly Logger _logger = new("LeagueClient");

        private readonly LeagueClientConfig _leagueClientConfig;
        private readonly RiotDevelopementPortalConfig _riotDevelopementPortalConfig;
        private readonly WebSocketServer.WebSocketServer _wsServer;
        public RiotGameDeveloperPortal rgdp;
        private bool _isRunning;

        public event Action? OnChanged;
        public bool IsRunning => _isRunning;

        /// <summary>
        /// League Client service constructor.
        /// </summary>
        /// <param name="config">League client config</param>
        /// <param name="wsServer">Web socket server</param>
        public LeagueClient(IOptions<LeagueClientConfig> leagueClientConfig, IOptions<RiotDevelopementPortalConfig> riotDevelopementPortalConfig, WebSocketServer.WebSocketServer wsServer)
        {
            _leagueClientConfig = leagueClientConfig.Value;
            _riotDevelopementPortalConfig = riotDevelopementPortalConfig.Value;
            _wsServer = wsServer;
        }

        /// <summary>
        /// Execute the background service to monitor the League Client.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(2));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    // Check if the League Client process is running
                    bool running = LeagueClientUp();

                    // If the running state has changed, update and notify
                    if (running != _isRunning)
                    {
                        _isRunning = running;
                        OnChanged?.Invoke();
                        if (running)
                        {
                            _logger.Log(LoggingLevel.INFO, "ExecuteAsync()", "League Client is running");
                        }
                    }

                    // If the League Client is running, proceed with initialization and syncing
                    if (running)
                    {
                        // Initialize LeagueClientUpdate
                        var lcu = new LeagueClientUpdate(_leagueClientConfig.LeagueClientProcess);
                        // Initialize LcuEndpoints
                        var lcuEndpoints = new LcuEndpoints(lcu);
                        
                        // Sync RegionLocale
                        var regionLocale = new RegionLocale(lcuEndpoints, _wsServer);
                        LolPublishingContentPubHubConfig regionLocaleData;
                        while ((regionLocaleData = regionLocale.SyncRegionLocaleAsync().GetAwaiter().GetResult()) == null)
                        {
                            _logger.Log(LoggingLevel.WARN, "ExecuteAsync()", "Waiting for LCU API to start");
                            await Task.Delay(2000, stoppingToken);
                        }

                        // Initialize OSL-RGDP
                        OSL_RGDP.Schema.RiotGameDeveloperPortalConfig info = new(_riotDevelopementPortalConfig.ApiKey, regionLocaleData.AppContext.UserRegion.ToLower());
                        rgdp = new RiotGameDeveloperPortal(info);

                        // Sync Gameflow Phase
                        var gameFlowPhase = new GameFlow(lcuEndpoints, _wsServer);
                        var champSelect = new ChampSelect(lcuEndpoints, _wsServer);
                        var endGame = new EndGame(lcuEndpoints, _wsServer, rgdp);
                        LolGameflowGameflowPhase? phase;
                        while ((phase = gameFlowPhase.SyncGameflowPhaseAsync().GetAwaiter().GetResult()) != null)
                        {
                            gameFlowPhase.InPhase(phase, champSelect, endGame);
                            // If we are in spécific game flow phase make one thing by phase 
                            await Task.Delay(1000, stoppingToken); // Attente pour éviter une boucle trop rapide (ajuste si besoin)
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.INFO, "ExecuteAsync()", "Service stopped");
            }
            finally
            {
                timer.Dispose();
            }
        }

        /// <summary>
        /// Check if the League Client process is running.
        /// </summary>
        /// <returns>True if is running</returns>
        private bool LeagueClientUp()
        {
            Process[] processes = Process.GetProcessesByName(_leagueClientConfig.LeagueClientProcess);
            if (processes.Length > 0)
                return true;

            _logger.Log(LoggingLevel.WARN, "LeagueClientUp()", $"Process : {_leagueClientConfig.LeagueClientProcess} not running");
            return false;
        }
    }
}
