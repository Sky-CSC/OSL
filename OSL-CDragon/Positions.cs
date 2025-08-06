using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using System.IO;
using static OSL_CDragon.CDragon;
using static OSL_CDragon.Schema.Asset;

namespace OSL_CDragon
{
    internal class Positions()
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Positions");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// All positions assets, Top, Jungle, Mid, Adc, Support
        /// </summary>
        private readonly Position _positions = new();

        internal Position Download()
        {
            //gérer des customs, on regarde si certains sont en local et on récupérer les infos
            Uri url = new("https://osl.sky-csc.fr/positions/positions.json");
            string? positionsOnServer = _download.StringAsync(url).Result;
            string? positionsOnLocal = OSL_Utils.File.Read("./EndpointsJson/position.json");
            if (positionsOnServer != null && positionsOnLocal != null)
            {
                try
                {
                    List<Asset>? positionSummaryServer = JsonConvert.DeserializeObject<List<Asset>>(positionsOnServer);
                    List<Asset>? positionSummaryLocal = JsonConvert.DeserializeObject<List<Asset>>(positionsOnLocal);
                    if (positionSummaryServer == null || positionSummaryLocal == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Positions not downloaded");
                        return _positions;
                    }
                    List<Asset>? positionSummary = [];
                    positionSummary.AddRange(positionSummaryServer);
                    positionSummary.AddRange(positionSummaryLocal);

                    foreach (Asset position in positionSummary)
                    {
                        _logger.Log(LoggingLevel.WARN, "positionSummary()", position.Path);
                        // Process each position
                        if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("top"))
                        {
                            CreateAssetInfo(new($"{position.Url}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.TopPath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("jungle"))
                        {
                            CreateAssetInfo(new($"{position.Url}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.JunglePath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("mid"))
                        {
                            CreateAssetInfo(new($"{position.Url}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.MiddlePath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("adc"))
                        {
                            CreateAssetInfo(new($"{position.Url}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.AdcPath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("support"))
                        {
                            CreateAssetInfo(new($"{position.Url}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.SupportPath.Add(asset));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Positions not downloaded : {ex.Message}");
                    return _positions;
                }
            }

            return _positions;
        }
    }
}
