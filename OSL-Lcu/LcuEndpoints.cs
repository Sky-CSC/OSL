using Newtonsoft.Json;
using OSL_Lcu.Schema.Lcu;
using OSL_Utils;

namespace OSL_Lcu
{
    /// <summary>
    /// Get endpoints data
    /// </summary>
    /// <param name="lcu">League Client</param>
    public class LcuEndpoints(LeagueClientUpdate lcu)
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("LeagueClientEndpoints");

        /// <summary>
        /// League client
        /// </summary>
        private readonly LeagueClientUpdate _lcu = lcu;

        /// <summary>
        /// Get the current region and locale configuration.
        /// </summary>
        /// <returns>Region locales data</returns>
        public async Task<LolPublishingContentPubHubConfig?> GetRegionLocaleAsync()
        {
            try
            {
                string? json = await _lcu.RequestAsync("/lol-publishing-content/v1/listeners/pubhub-config");

                if (string.IsNullOrEmpty(json))
                    return null;

                return JsonConvert.DeserializeObject<LolPublishingContentPubHubConfig>(json);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "GetRegionLocaleAsync()", $"❌ {ex.Message}");
                return null;
            }
        }

        /// <summary>
        ///  Get the current game flow phase.
        /// </summary>
        /// <returns>Game flow phase</returns>
        public async Task<LolGameflowGameflowPhase?> GetGameflowPhaseAsync()
        {
            try
            {
                string? json = await _lcu.RequestAsync("/lol-gameflow/v1/gameflow-phase");

                if (string.IsNullOrEmpty(json))
                    return null;

                return JsonConvert.DeserializeObject<LolGameflowGameflowPhase>(json);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "GetGameflowPhaseAsync()", $"❌ {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get the current champ select session details.
        /// </summary>
        /// <returns>Champ select data</returns>
        public async Task<ChampSelectSession?> GetChampSelectAsync()
        {
            try
            {
                string? json = await _lcu.RequestAsync("/lol-champ-select/v1/session");

                if (string.IsNullOrEmpty(json))
                    return null;

                return JsonConvert.DeserializeObject<ChampSelectSession>(json);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "GetChampSelectAsync()", $"❌ {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get the current champ select session details.
        /// </summary>
        /// <returns>End of game data</returns>
        public async Task<LolEndOfGameEndOfGameStats?> GetEndGameAsync()
        {
            try
            {
                string? json = await _lcu.RequestAsync("/lol-end-of-game/v1/eog-stats-block");

                if (string.IsNullOrEmpty(json))
                    return null;

                return JsonConvert.DeserializeObject<LolEndOfGameEndOfGameStats>(json);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, "GetEndGameAsync()", $"❌ {ex.Message}");
                return null;
            }
        }
    }
}
