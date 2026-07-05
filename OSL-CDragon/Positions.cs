using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.CDragon;

namespace OSL_CDragon
{
    /// <summary>
    /// Represents a collection of position-related assets and provides functionality to download and manage them.
    /// </summary>
    /// <remarks>The <see cref="Positions"/> class is responsible for handling position assets such as Top,
    /// Jungle, Mid, ADC, and Support. It provides a method to download position data from a remote server and merge it
    /// with local data.</remarks>
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

        /// <summary>
        /// Downloads and processes position data from a remote server and local storage.
        /// </summary>
        /// <remarks>This method retrieves position data from a predefined remote server and a local file,
        /// deserializes the data, and processes it to populate categorized position paths. If an error occurs during
        /// the download or processing, the method logs the error and returns the current state of the
        /// positions.</remarks>
        /// <returns>A <see cref="Position"/> object containing the categorized position data. The returned object reflects the
        /// current state of the positions, including any successfully processed data.</returns>
        internal Position Download()
        {
            //gérer des customs, on regarde si certains sont en local et on récupérer les infos
            Uri url = new("https://asset.osl.sky-csc.fr/positions/positions.json");
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
                        _logger.Log(LoggingLevel.ERROR, nameof(Download), "Positions not downloaded");
                        return _positions;
                    }
                    List<Asset>? positionSummary = [];
                    positionSummary.AddRange(positionSummaryServer);
                    positionSummary.AddRange(positionSummaryLocal);

                    foreach (Asset position in positionSummary)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(Download), position.Path);
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
                    _logger.Log(LoggingLevel.ERROR, nameof(Download), $"Positions not downloaded : {ex.Message}");
                    return _positions;
                }
            }

            return _positions;
        }
    }
}
