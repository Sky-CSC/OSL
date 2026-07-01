using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OSL_Lcu;
using OSL_Lcu.Schema.Lcu;
using OSL_RGDP;
using OSL_RGDP.Schema.Riot;
using OSL_Server.Phases;
using OSL_Server.Schema;
using OSL_Server.WebSocketServer;
using OSL_Utils;
using System.Diagnostics;

namespace OSL_Server.Services
{

    public enum RiotApiKeyStatus
    {
        Valid,
        Invalid,
        NotTested
    }
    /// <summary>
    /// League Client service to monitor and interact with the League of Legends client.
    /// </summary>
    public class LeagueClient : BackgroundService
    {
        private static readonly Logger _logger = new("LeagueClient");

        private readonly LeagueClientConfig _leagueClientConfig;
        private RiotGameDevelopementPortalConfig _riotDevelopementPortalConfig;
        private readonly WebSocketServer.WebSocketServer _wsServer;
        private readonly string _riotDevelopementPortalConfigPath;
        private CancellationTokenSource? _restartCts;
        public RiotApiKeyStatus RiotApiKeyValid { get; private set; } = RiotApiKeyStatus.NotTested;
        public PlatformDataDto? Status { get; private set; }

        public RiotGameDeveloperPortal rgdp;
        private bool _isRunning;

        public event Action? OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();
        public bool IsRunning => _isRunning;

        /// <summary>
        /// League Client service constructor.
        /// </summary>
        /// <param name="config">League client config</param>
        /// <param name="wsServer">Web socket server</param>
        public LeagueClient(IOptions<LeagueClientConfig> leagueClientConfig, IOptions<RiotGameDevelopementPortalConfig> riotDevelopementPortalConfig, WebSocketServer.WebSocketServer wsServer)
        {
            _leagueClientConfig = leagueClientConfig.Value;
            _riotDevelopementPortalConfig = riotDevelopementPortalConfig.Value;
            _wsServer = wsServer;
            _riotDevelopementPortalConfigPath = "./Services/RiotGameDevelopementPortalConfig.json";
        }

        /// <summary>
        /// Execute the background service to monitor the League Client.
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _restartCts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);

                try
                {
                    await RunAsync(_restartCts.Token);
                    await Task.Delay(2000, _restartCts.Token);
                }
                catch (OperationCanceledException)
                {
                }
                finally
                {
                    _restartCts.Dispose();
                    _restartCts = null;
                }
            }
        }

        private async Task RunAsync(CancellationToken token)
        {
            try
            {
                // Read Riot Api Key
                ReadApiKey();

                // Check if the League Client process is running
                bool running = LeagueClientStatus();

                // If the running state has changed, update and notify
                if (running != _isRunning)
                {
                    _isRunning = running;
                    NotifyStateChanged();
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
                        await Task.Delay(2000, token);
                    }

                    // Initialize OSL-RGDP
                    NotifyStateChanged();
                    OSL_RGDP.Schema.RiotGameDeveloperPortalConfig info = new(_riotDevelopementPortalConfig.ApiKey, regionLocaleData.AppContext.UserRegion.ToLower());
                    rgdp = new RiotGameDeveloperPortal(info);
                    // Get status of riot api, check if key is valid if noot set bool to false for display it on razor page
                    Status = rgdp.Status.GetStatus();
                    if (Status == null)
                        RiotApiKeyValid = RiotApiKeyStatus.Invalid;
                    else
                        RiotApiKeyValid = RiotApiKeyStatus.Valid;

                    NotifyStateChanged();

                    // Sync Gameflow Phase
                    var gameFlowPhase = new GameFlow(lcuEndpoints, _wsServer);
                    var champSelect = new ChampSelect(lcuEndpoints, _wsServer);
                    var endGame = new EndGame(lcuEndpoints, _wsServer, rgdp);
                    LolGameflowGameflowPhase? phase;
                    while ((phase = gameFlowPhase.SyncGameflowPhaseAsync().GetAwaiter().GetResult()) != null)
                    {
                        gameFlowPhase.InPhase(phase, champSelect, endGame);
                        // If we are in spécific game flow phase make one thing by phase 
                        await Task.Delay(1000, token); // Attente pour éviter une boucle trop rapide (ajuste si besoin)
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.Log(LoggingLevel.INFO, "ExecuteAsync()", "Service stopped");
            }
        }

        public async Task RestartAsync()
        {
            _logger.Log(LoggingLevel.INFO, nameof(RestartAsync), "Restart requested (Api key changed)");

            _restartCts?.Cancel();

            while (_restartCts != null)
            {
                await Task.Delay(100);
            }
        }

        /// <summary>
        /// Check if the League Client process is running.
        /// </summary>
        /// <returns>True if is running</returns>
        private bool LeagueClientStatus()
        {
            Process[] processes = Process.GetProcessesByName(_leagueClientConfig.LeagueClientProcess);
            if (processes.Length > 0)
                return true;

            _logger.Log(LoggingLevel.WARN, "LeagueClientUp()", $"Process : {_leagueClientConfig.LeagueClientProcess} not running");
            return false;
        }

        public async Task UpdateApiKey(string apiKey)
        {
            Console.WriteLine(_riotDevelopementPortalConfig.ApiKey);
            Console.WriteLine(apiKey);
            if (_riotDevelopementPortalConfig.ApiKey != apiKey)
            {
                _riotDevelopementPortalConfig.ApiKey = apiKey;
                await WriteApiKey();
            }
            NotifyStateChanged();
        }

        private async Task WriteApiKey()
        {
            string json = JsonConvert.SerializeObject(_riotDevelopementPortalConfig);
            OSL_Utils.File.Write(_riotDevelopementPortalConfigPath, json);
            _logger.Log(LoggingLevel.INFO, nameof(ReadApiKey), $"Riot Game Development Portal Api key write {_riotDevelopementPortalConfig.ApiKey}");
            // restart the service to apply the new API key
            await RestartAsync();
        }

        private void ReadApiKey()
        {
            // Read file _riotDevelopementPortalConfigPath
            if (OSL_Utils.File.Exist(_riotDevelopementPortalConfigPath))
            {
                string? json = OSL_Utils.File.Read(_riotDevelopementPortalConfigPath);
                if (json != null)
                {
                    try
                    {
                        var config = JsonConvert.DeserializeObject<RiotGameDevelopementPortalConfig>(json);
                        if (config != null)
                        {
                            _riotDevelopementPortalConfig = config;
                            _logger.Log(LoggingLevel.DEBUG, nameof(ReadApiKey), $"Riot Game Development Portal Api key is {_riotDevelopementPortalConfig.ApiKey}");
                            return;
                        }
                    }
                    catch (JsonException ex)
                    {
                        _logger.Log(LoggingLevel.ERROR, nameof(ReadApiKey), $"Error deserializing {_riotDevelopementPortalConfigPath}: {ex.Message}");
                    }
                }

                _riotDevelopementPortalConfig = new RiotGameDevelopementPortalConfig
                {
                    ApiKey = ""
                };
                WriteApiKey();
            }
            NotifyStateChanged();
        }

        public string GetApiKey()
        {
            return new string(_riotDevelopementPortalConfig.ApiKey);
        }
    }
}
