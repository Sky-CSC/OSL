using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_CDragon.Schema.CDragon;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Download champions data from the CommunityDragon API.
    /// </summary>
    /// <param name="info"></param>
    internal class Champions(Info info)
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger _logger = new("Champions");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();
        /// <summary>
        /// The information for download the assets.
        /// </summary>
        private Info _info = info;
        /// <summary>
        /// The list of champions.
        /// </summary>
        private readonly List<Schema.Champion> _champions = [];
        /// <summary>
        /// The champion.
        /// </summary>
        private Schema.Champion _champion = new();

        /// <summary>
        /// Download the champions data.
        /// </summary>
        /// <returns>List of champion</returns>
        internal List<Schema.Champion> Download()
        {
            Uri urlChampions = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/champion-summary.json");
            string? champions = _download.StringAsync(urlChampions).Result;
            if (champions != null)
            {
                try
                {
                    List<ChampionSummary>? championSummary = JsonConvert.DeserializeObject<List<ChampionSummary>>(champions);
                    if (championSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, nameof(Download), "Champions not downloaded");
                        return [];
                    }
                    foreach (ChampionSummary champion in championSummary)
                    {
                        _champion = new(champion.Id);
                        // Process each champion
                        CreateDirectory();
                        ChampionAssets();
                        _champions.Add(_champion);
                    }
                    return _champions;
                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Download), $"Champions not downloaded : {e.Message}");
                    return [];
                }
            }
            else
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Download), "Champions not downloaded");
                return [];
            }
        }

        /// <summary>
        /// Create the directory for the champion.
        /// </summary>
        private void CreateDirectory()
        {
            string championDir = OSL_Utils.Path.Combine(_info.AssetsDir, "champions", _champion.Id.ToString());
            OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(championDir));
            OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(championDir, "sounds"));
            OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(championDir, "skins"));
            OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(championDir, "abilitys"));
        }

        /// <summary>
        /// Download square portrait, sound, skin assets.
        /// </summary>
        private void ChampionAssets()
        {
            //Download square portrait
            SquarePortrait();
            //Download songs
            if (_champion.Id != -1)
            {
                Sound();
            }

            Uri urlChampion = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/champions/{_champion.Id}.json");
            string? champ = _download.StringAsync(urlChampion).Result;
            if (champ != null)
            {
                try
                {
                    Schema.CDragon.Champion champCD = JsonConvert.DeserializeObject<Schema.CDragon.Champion>(champ);
                    _champion.Name = champCD.Name;
                    _champion.Alias = champCD.Alias;
                    _champion.Roles = champCD.Roles;
                    if (_champion.Id != -1 && champCD.Skins.Count > 0)
                    {
                        int nbSkinToDownload = _info.DownloadAllSkin ? champCD.Skins.Count : 1;
                        for (int index = 0; index < nbSkinToDownload; index++)
                        {
                            //Dowload skins
                            Skin(champCD.Skins[index]);
                        }
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(ChampionAssets), $"Champion {_champion.Id} not downloaded : {e.Message}");
                }
            }
        }

        /// <summary>
        /// Download the square portrait of the champion.
        /// </summary>
        private void SquarePortrait()
        {
            Uri squarePortrait = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{_champion.Id}.png");
            _champion.SquarePortraitPath = DownloadFile(squarePortrait, _champion.Id, $"champions/{_champion.Id}", "default-square.png");
        }

        /// <summary>
        /// Download the sounds of the champion.
        /// </summary>
        private void Sound()
        {
            Uri soundChoose = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/champion-choose-vo/{_champion.Id}.ogg");
            Uri soundBan = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/champion-ban-vo/{_champion.Id}.ogg");
            Uri soundSfx = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-sfx-audios/{_champion.Id}.ogg");

            Sound sound = new();
            try
            {
                sound.ChoosePath = DownloadFile(soundChoose, _champion.Id, $"champions/{_champion.Id}/sounds", "choose.ogg");
                sound.BanPath = DownloadFile(soundBan, _champion.Id, $"champions/{_champion.Id}/sounds", "ban.ogg");
                sound.SfxPath = DownloadFile(soundSfx, _champion.Id, $"champions/{_champion.Id}/sounds", "sfx.ogg");
                _logger.Log(LoggingLevel.INFO, nameof(Sound), $"Sounds of champion {_champion.Id} downloaded");
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Sound), $"Sounds of champion {_champion.Id} not downloaded");
            }
            _champion.Sounds = sound;
        }

        /// <summary>
        /// Download the skins of the champion.
        /// </summary>
        /// <param name="skinCD">CDragon information of skin</param>
        private void Skin(Schema.CDragon.Skin skinCD)
        {
            Uri splashe = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/assets/{SplitAssetsToLower(skinCD.SplashPath)}");
            Uri splasheUncentered = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/assets/{SplitAssetsToLower(skinCD.UncenteredSplashPath)}");
            Uri tile = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/assets/{SplitAssetsToLower(skinCD.TilePath)}");
            Uri loadScreen = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/assets/{SplitAssetsToLower(skinCD.LoadScreenPath)}");

            Schema.Skin skin = new(skinCD.Id, skinCD.IsBase);
            try
            {
                skin.Splashe = DownloadFile(splashe, skin.Id, $"champions/{_champion.Id}/skins/{skin.Id}", "splashe.png");
                skin.SplasheUncentered = DownloadFile(splasheUncentered, skin.Id, $"champions/{_champion.Id}/skins/{skin.Id}", "splashe-uncentered.png");
                skin.Tile = DownloadFile(tile, skin.Id, $"champions/{_champion.Id}/skins/{skin.Id}", "tile.png");
                skin.LoadScreen = DownloadFile(loadScreen, skin.Id, $"champions/{_champion.Id}/skins/{skin.Id}", "loadscreen.png");
            }
            catch
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Skin), $"Skin {skin.Id} not downloaded");
            }
            _champion.Skins.Add(skin);
        }

        /// <summary>
        /// Download a file from a URL.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="id">champion id</param>
        /// <param name="directory">directory to save file</param>
        /// <param name="fileName">name of file</param>
        /// <returns></returns>
        private string DownloadFile(Uri url, int id, string directory, string fileName)
        {
            byte[]? data = _download.FileAsync(url).Result;
            if (data != null)
            {
                try
                {
                    string path = OSL_Utils.Path.Combine(_info.AssetsDir, directory);
                    string filePath = OSL_Utils.Path.Combine(path, fileName);
                    if (OSL_Utils.Directory.Create(path))
                    {
                        OSL_Utils.File.Write(filePath, data);
                        _logger.Log(LoggingLevel.INFO, "DownloadFile()", $"File {id} downloaded");
                        return filePath;
                    }
                }
                catch (Exception e)
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(DownloadFile), $"File {id} not downloaded : {e.Message}");
                }
            }
            _logger.Log(LoggingLevel.ERROR, nameof(DownloadFile), $"File {id} not downloaded");
            return "";
        }

        /// <summary>
        /// Split the assets path to lower.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string SplitAssetsToLower(string path)
        {
            return path.Split("/ASSETS/")[1].ToLower();
        }
    }
}
