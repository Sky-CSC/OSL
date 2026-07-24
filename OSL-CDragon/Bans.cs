using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.CDragon;

namespace OSL_CDragon
{
    /// <summary>
    /// Download and manage fonts assets.
    /// </summary>
    internal class Bans
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Bans");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// Bans assets list.
        /// </summary>
        private readonly List<Asset> _bans = [];

        /// <summary>
        /// Download bans data from the server and local files.
        /// </summary>
        /// <returns></returns>
        internal List<Asset> Download()
        {
            Uri url = new("https://asset.osl.sky-csc.fr/bans/bans.json");
            string? bansOnServer = _download.StringAsync(url).Result;
            string? bansOnLocal = OSL_Utils.File.Read("./EndpointsJson/ban.json");
            if (bansOnServer != null && bansOnLocal != null)
            {
                try
                {
                    List<Asset>? banSummaryServer = JsonConvert.DeserializeObject<List<Asset>>(bansOnServer);
                    List<Asset>? banSummaryLocal = JsonConvert.DeserializeObject<List<Asset>>(bansOnLocal);
                    if (banSummaryServer == null || banSummaryLocal == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, nameof(Download), "Bans not downloaded");
                        return _bans;
                    }
                    List<Asset>? banSummary = [];
                    banSummary.AddRange(banSummaryServer);
                    banSummary.AddRange(banSummaryLocal);
                    foreach (Asset ban in banSummary)
                    {
                        CreateAssetInfo(new($"{ban.Url}"), ban.Id, ban.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(ban.Path)}", ban.Description, System.IO.Path.GetExtension(ban.Path), ban.Type, (asset) => _bans.Add(asset));
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Download), $"Bans not downloaded : {e.Message}");
                    return _bans;
                }
            }
            return _bans;
        }
    }
}
