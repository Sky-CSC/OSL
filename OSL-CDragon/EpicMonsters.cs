using OSL_CDragon.Schema;
using OSL_Utils;
using static OSL_CDragon.Schema.Asset;
using static OSL_CDragon.CDragon;
using Newtonsoft.Json;

namespace OSL_CDragon
{
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
            Uri url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/atakhan_r_circle.png");
            CreateAssetInfo(url, "1000", "atakhan_circle", "./wwwroot/assets/epicmonsters/atakhan", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Atakhans.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/baron_circle.png");
            CreateAssetInfo(url, "1001", "baron_circle", "./wwwroot/assets/epicmonsters/baron", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Barons.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_air.png");
            CreateAssetInfo(url, "1002", "cloud_circle", "./wwwroot/assets/epicmonsters/dragons/cloud", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Cloud.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_chemtech.png");
            CreateAssetInfo(url, "1003", "chemtech_circle", "./wwwroot/assets/epicmonsters/dragons/chemtech", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Chemtech.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_earth.png");
            CreateAssetInfo(url, "1004", "mountain_circle", "./wwwroot/assets/epicmonsters/dragons/mountain", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Mountain.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_fire.png");
            CreateAssetInfo(url, "1005", "infernal_circle", "./wwwroot/assets/epicmonsters/dragons/infernal", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Infernal.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_hextech.png");
            CreateAssetInfo(url, "1006", "hextech_circle", "./wwwroot/assets/epicmonsters/dragons/hextech", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Hextech.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/dragon_circle_water.png");
            CreateAssetInfo(url, "1007", "ocean_circle", "./wwwroot/assets/epicmonsters/dragons/ocean", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Dragons.Ocean.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/sru_voidgrub_circle.png");
            CreateAssetInfo(url, "1008", "voidgrub_circle", "./wwwroot/assets/epicmonsters/voidgrub", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.VoidGrubs.Add(asset));
            url = new("https://raw.communitydragon.org/15.3/game/assets/ux/announcements/sruriftherald_circle.png");
            CreateAssetInfo(url, "1009", "herald_circle", "./wwwroot/assets/epicmonsters/herald", "", ".png", [AssetType.NotSet], (asset) => _epicMonsters.Heralds.Add(asset));

            // Download dragons assets from OSL server
            url = new("https://osl.sky-csc.fr/epicmonsters/dragons/dragons.json");
            string? dragons = _download.StringAsync(url).Result;
            if (dragons != null)
            {
                try
                {
                    List<Asset>? dragonSummary = JsonConvert.DeserializeObject<List<Asset>>(dragons);
                    if (dragonSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Dragons not downloaded");
                        return _epicMonsters;
                    }
                    string server = "https://osl.sky-csc.fr/";
                    // Process each dragon
                    foreach (Asset dragon in dragonSummary)
                    {
                        if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("chemtech"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Chemtech.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("cloud"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Cloud.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("hextech"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Hextech.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("infernal"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Infernal.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("mountain"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Mountain.Add(asset));
                        }
                        else if (OSL_Utils.Path.GetDirectoryName(dragon.Path).Contains("ocean"))
                        {
                            CreateAssetInfo(new($"{server}{dragon.Path}"), dragon.Id, dragon.Name, $"./wwwroot/assets/{OSL_Utils.Path.GetDirectoryName(dragon.Path)}", dragon.Description, System.IO.Path.GetExtension(dragon.Path), dragon.Type, (asset) => _epicMonsters.Dragons.Ocean.Add(asset));
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
