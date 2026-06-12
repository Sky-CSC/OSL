using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.CDragon;

namespace OSL_CDragon
{
    /// <summary>
    /// Download and manage fonts assets.
    /// </summary>
    internal class Fonts
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Fonts");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();

        /// <summary>
        /// Fonts assets list.
        /// </summary>
        private readonly List<Asset> _fonts = [];

        /// <summary>
        /// Download fonts data from the server and local files.
        /// </summary>
        /// <returns></returns>
        internal List<Asset> Download()
        {
            Uri url = new("https://asset.osl.sky-csc.fr/fonts/fonts.json");
            string? fontsOnServer = _download.StringAsync(url).Result;
            string? fontsOnLocal = OSL_Utils.File.Read("./EndpointsJson/font.json");
            if (fontsOnServer != null && fontsOnLocal != null)
            {
                try
                {
                    List<Asset>? fontSummaryServer = JsonConvert.DeserializeObject<List<Asset>>(fontsOnServer);
                    List<Asset>? fontSummaryLocal = JsonConvert.DeserializeObject<List<Asset>>(fontsOnLocal);
                    if (fontSummaryServer == null || fontSummaryLocal == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Fonts not downloaded");
                        return _fonts;
                    }
                    List<Asset>? fontSummary = [];
                    fontSummary.AddRange(fontSummaryServer);
                    fontSummary.AddRange(fontSummaryLocal);
                    foreach (Asset font in fontSummary)
                    {
                        CreateAssetInfo(new($"{font.Url}"), font.Id, font.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(font.Path)}", font.Description, System.IO.Path.GetExtension(font.Path), font.Type, (asset) => _fonts.Add(asset));
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Fonts not downloaded : {e.Message}");
                    return _fonts;
                }
            }
            return _fonts;
        }
    }
}
