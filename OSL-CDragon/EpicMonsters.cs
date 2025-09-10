using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.CDragon;

namespace OSL_CDragon
{
    /// <summary>
    /// Download epic monsters assets such as dragons, baron, herald, voidgrub and atakhan.
    /// </summary>
    internal class EpicMonsters
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("EpicMonsters");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// All epic monsters assets, including dragons, baron, herald, voidgrub and atakhan.
        /// </summary>
        private readonly EpicMonster _epicMonsters = new();

        /// <summary>
        /// Download epic monsters data.
        /// </summary>
        /// <returns></returns>
        internal EpicMonster Download()
        {
            // Download dragons assets from OSL server
            Uri url = new("https://osl.sky-csc.fr/epicmonsters/epicmonsters.json");
            string? epicMonsterOnServer = _download.StringAsync(url).Result;
            string? epicMonsterOnLocal = OSL_Utils.File.Read("./EndpointsJson/epicmonster.json");
            if (epicMonsterOnServer != null && epicMonsterOnLocal != null)
            {
                try
                {
                    List<Asset>? epicMonsterSummaryServer = JsonConvert.DeserializeObject<List<Asset>>(epicMonsterOnServer);
                    List<Asset>? epicMonsterSummaryLocal = JsonConvert.DeserializeObject<List<Asset>>(epicMonsterOnLocal);
                    if (epicMonsterSummaryServer == null || epicMonsterSummaryLocal == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Dragons not downloaded");
                        return _epicMonsters;
                    }
                    List<Asset>? epicMonsterSummary = [];
                    epicMonsterSummary.AddRange(epicMonsterSummaryServer);
                    epicMonsterSummary.AddRange(epicMonsterSummaryLocal);

                    // Process each epic monster
                    foreach (Asset epicMonster in epicMonsterSummary)
                    {
                        if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("chemtech"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Chemtech.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("cloud"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Cloud.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("hextech"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Hextech.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("infernal"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Infernal.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("mountain"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Mountain.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("ocean"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Ocean.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("elder"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Dragons.Elder.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("herald"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Heralds.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("voidgrub"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.VoidGrubs.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("baron"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Barons.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(epicMonster.Path).Contains("atakhan"))
                        {
                            CreateAssetInfo(new($"{epicMonster.Url}"), epicMonster.Id, epicMonster.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(epicMonster.Path)}", epicMonster.Description, System.IO.Path.GetExtension(epicMonster.Path), epicMonster.Type, (asset) => _epicMonsters.Atakhans.Add(asset));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Dragons not downloaded : {ex.Message}");
                    return _epicMonsters;
                }
            }
            return _epicMonsters;
        }
    }
}
