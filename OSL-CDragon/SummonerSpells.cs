using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Donwload summoner spells data.
    /// </summary>
    /// <param name="info"></param>
    internal class SummonerSpells(Info info)
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Items");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();
        /// <summary>
        /// The information fort download assets.
        /// </summary>
        private Info _info = info;
        /// <summary>
        /// The list of items.
        /// </summary>
        private readonly List<SummonerSpell> _summonerSpell = [];

        /// <summary>
        /// Download summoner spells data.
        /// </summary>
        /// <returns>List of summoner spells</returns>
        internal List<SummonerSpell> Download()
        {
            Uri urlSummonersSpells = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/summoner-spells.json");
            string? summonerSpells = _download.StringAsync(urlSummonersSpells).Result;
            if (summonerSpells != null)
            {
                try
                {
                    List<Schema.CDragon.SummonerSpell>? summonerSpellSummary = JsonConvert.DeserializeObject<List<Schema.CDragon.SummonerSpell>>(summonerSpells);
                    if (summonerSpellSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Summoner Spells not downloaded");
                        return _summonerSpell;
                    }
                    foreach (Schema.CDragon.SummonerSpell summonerSpell in summonerSpellSummary)
                    {
                        // Process each item 
                        _summonerSpell.Add(SummonerSpellAssets(summonerSpell));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Summoner Spells not downloaded : {ex.Message}");
                    return _summonerSpell;
                }
            }
            return _summonerSpell;
        }

        /// <summary>
        /// Download summoner spell icon2d assets.
        /// </summary>
        /// <param name="summonerSpellCDragon">CDragon summoner spell infos</param>
        /// <returns>Summoner spell</returns>
        private SummonerSpell SummonerSpellAssets(Schema.CDragon.SummonerSpell summonerSpellCDragon)
        {
            string summonerSpellName = summonerSpellCDragon.IconPath.Split("/Icons2D/")[^1].ToLower();
            Uri urlSummonerSpell = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/data/spells/icons2d/{summonerSpellName}");
            SummonerSpell summonerSpell = new(summonerSpellCDragon.Id, summonerSpellCDragon.Name, DownloadFile(urlSummonerSpell, summonerSpellCDragon.Id, "summonerspells"));
            return summonerSpell;
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="id">summoner spell id</param>
        /// <param name="path">directory how to save files</param>
        /// <returns>Summoner file path</returns>
        private string DownloadFile(Uri url, uint id, string path)
        {
            byte[]? file = _download.FileAsync(url).Result;
            if (file != null)
            {
                try
                {
                    string filePath = OSL_Utils.Path.Combine(_info.AssetsDir, path, $"{id}.png");
                    OSL_Utils.File.Write(filePath, file);
                    return filePath;
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "DownloadFile()", $"File not downloaded : {ex.Message}");
                }
            }
            return "";
        }
    }
}
