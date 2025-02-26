using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;
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
            Uri url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-bottom-blue-hover.png");
            CreateAssetInfo(url, "1000", "adc-blue-hover", "./wwwroot/assets/positions/adc", "", ".png", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-bottom-blue.png");
            CreateAssetInfo(url, "1001", "adc-blue", "./wwwroot/assets/positions/adc", "", ".png", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-bottom-disabled.png");
            CreateAssetInfo(url, "1002", "adc-disabled", "./wwwroot/assets/positions/adc", "", ".png", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-bottom-hover.png");
            CreateAssetInfo(url, "1003", "adc-hover", "./wwwroot/assets/positions/adc", "", ".png", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-bottom.png");
            CreateAssetInfo(url, "1004", "adc", "./wwwroot/assets/positions/adc", "", ".png", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-jungle-blue-hover.png");
            CreateAssetInfo(url, "1005", "jungle-blue-hover", "./wwwroot/assets/positions/jungle", "", ".png", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-jungle-blue.png");
            CreateAssetInfo(url, "1006", "jungle-blue", "./wwwroot/assets/positions/jungle", "", ".png", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-jungle-disabled.png");
            CreateAssetInfo(url, "1007", "jungle-disabled", "./wwwroot/assets/positions/jungle", "", ".png", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-jungle-hover.png");
            CreateAssetInfo(url, "1008", "jungle-hover", "./wwwroot/assets/positions/jungle", "", ".png", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-jungle.png");
            CreateAssetInfo(url, "1009", "jungle", "./wwwroot/assets/positions/jungle", "", ".png", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-middle-blue-hover.png");
            CreateAssetInfo(url, "1010", "mid-blue-hover", "./wwwroot/assets/positions/mid", "", ".png", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-middle-blue.png");
            CreateAssetInfo(url, "1011", "mid-blue", "./wwwroot/assets/positions/mid", "", ".png", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-middle-disabled.png");
            CreateAssetInfo(url, "1012", "mid-disabled", "./wwwroot/assets/positions/mid", "", ".png", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-middle-hover.png");
            CreateAssetInfo(url, "1013", "mid-hover", "./wwwroot/assets/positions/mid", "", ".png", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-middle.png");
            CreateAssetInfo(url, "1014", "mid", "./wwwroot/assets/positions/mid", "", ".png", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-top-blue-hover.png");
            CreateAssetInfo(url, "1015", "top-blue-hover", "./wwwroot/assets/positions/top", "", ".png", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-top-blue.png");
            CreateAssetInfo(url, "1016", "top-blue", "./wwwroot/assets/positions/top", "", ".png", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-top-disabled.png");
            CreateAssetInfo(url, "1017", "top-disabled", "./wwwroot/assets/positions/top", "", ".png", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-top-hover.png");
            CreateAssetInfo(url, "1018", "top-hover", "./wwwroot/assets/positions/top", "", ".png", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-top.png");
            CreateAssetInfo(url, "1019", "top", "./wwwroot/assets/positions/top", "", ".png", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-utility-blue-hover.png");
            CreateAssetInfo(url, "1020", "supp-blue-hover", "./wwwroot/assets/positions/support", "", ".png", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-utility-blue.png");
            CreateAssetInfo(url, "1021", "supp-blue", "./wwwroot/assets/positions/support", "", ".png", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-utility-disabled.png");
            CreateAssetInfo(url, "1022", "supp-disabled", "./wwwroot/assets/positions/support", "", ".png", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-utility-hover.png");
            CreateAssetInfo(url, "1023", "supp-hover", "./wwwroot/assets/positions/support", "", ".png", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-clash/global/default/assets/images/position-selector/positions/icon-position-utility.png");
            CreateAssetInfo(url, "1024", "supp", "./wwwroot/assets/positions/support", "", ".png", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-bottom-light.svg");
            CreateAssetInfo(url, "1025", "adc-blue-hover", "./wwwroot/assets/positions/adc", "", ".svg", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-bottom-red.svg");
            CreateAssetInfo(url, "1026", "adc-blue-hover", "./wwwroot/assets/positions/adc", "", ".svg", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-bottom.svg");
            CreateAssetInfo(url, "1027", "adc-blue-hover", "./wwwroot/assets/positions/adc", "", ".svg", [AssetType.NotSet], (asset) => _positions.AdcPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-jungle-light.svg");
            CreateAssetInfo(url, "1028", "jungle-blue-hover", "./wwwroot/assets/positions/jungle", "", ".svg", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-jungle-red.svg");
            CreateAssetInfo(url, "1029", "jungle-blue-hover", "./wwwroot/assets/positions/jungle", "", ".svg", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-jungle.svg");
            CreateAssetInfo(url, "1030", "jungle-blue-hover", "./wwwroot/assets/positions/jungle", "", ".svg", [AssetType.NotSet], (asset) => _positions.JunglePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-middle-light.svg");
            CreateAssetInfo(url, "1031", "mid-blue-hover", "./wwwroot/assets/positions/mid", "", ".svg", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-middle-red.svg");
            CreateAssetInfo(url, "1032", "mid-blue-hover", "./wwwroot/assets/positions/mid", "", ".svg", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-middle.svg");
            CreateAssetInfo(url, "1033", "mid-blue-hover", "./wwwroot/assets/positions/mid", "", ".svg", [AssetType.NotSet], (asset) => _positions.MiddlePath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-top-light.svg");
            CreateAssetInfo(url, "1034", "top-blue-hover", "./wwwroot/assets/positions/top", "", ".svg", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-top-red.svg");
            CreateAssetInfo(url, "1035", "top-blue-hover", "./wwwroot/assets/positions/top", "", ".svg", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-top.svg");
            CreateAssetInfo(url, "1036", "top-blue-hover", "./wwwroot/assets/positions/top", "", ".svg", [AssetType.NotSet], (asset) => _positions.TopPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-utility-light.svg");
            CreateAssetInfo(url, "1037", "supp-blue-hover", "./wwwroot/assets/positions/support", "", ".svg", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-utility-red.svg");
            CreateAssetInfo(url, "1038", "supp-blue-hover", "./wwwroot/assets/positions/support", "", ".svg", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));
            url = new("https://raw.communitydragon.org/pbe/plugins/rcp-fe-lol-static-assets/global/default/svg/position-utility.svg");
            CreateAssetInfo(url, "1039", "supp-blue-hover", "./wwwroot/assets/positions/support", "", ".svg", [AssetType.NotSet], (asset) => _positions.SupportPath.Add(asset));

            //gérer des customs, on regarde si certains sont en local et on récupérer les infos
            url = new("https://osl.sky-csc.fr/positions/positions.json");
            string? positions = _download.StringAsync(url).Result;
            if (positions != null)
            {
                try
                {
                    List<Asset>? positionSummary = JsonConvert.DeserializeObject<List<Asset>>(positions);
                    if (positionSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Positions not downloaded");
                        return _positions;
                    }
                    string server = "https://osl.sky-csc.fr/";
                    foreach (Asset position in positionSummary)
                    {
                        // Process each position
                        if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("top"))
                        {
                            CreateAssetInfo(new($"{server}{position.Path}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.TopPath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("jungle"))
                        {
                            CreateAssetInfo(new($"{server}{position.Path}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.JunglePath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("mid"))
                        {
                            CreateAssetInfo(new($"{server}{position.Path}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.MiddlePath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("adc"))
                        {
                            CreateAssetInfo(new($"{server}{position.Path}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.AdcPath.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(position.Path).Contains("support"))
                        {
                            CreateAssetInfo(new($"{server}{position.Path}"), position.Id, position.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(position.Path)}", position.Description, System.IO.Path.GetExtension(position.Path), position.Type, (asset) => _positions.SupportPath.Add(asset));
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
