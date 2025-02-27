using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.CDragon;

namespace OSL_CDragon
{
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

        private readonly List<Asset> _fonts = [];

        internal List<Asset> Download()
        {
            Uri url = new("https://osl.sky-csc.fr/fonts/fonts.json");
            string? fonts = _download.StringAsync(url).Result;
            if (fonts != null)
            {
                try
                {
                    List<Asset>? fontSummary = JsonConvert.DeserializeObject<List<Asset>>(fonts);
                    if (fontSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Fonts not downloaded");
                        return _fonts;
                    }
                    string server = "https://osl.sky-csc.fr/";
                    foreach (Asset font in fontSummary)
                    {
                        CreateAssetInfo(new($"{server}{font.Path}"), font.Id, font.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(font.Path)}", font.Description, System.IO.Path.GetExtension(font.Path), font.Type, (asset) => _fonts.Add(asset));
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
