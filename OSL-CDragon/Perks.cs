using Newtonsoft.Json;
using OSL_CDragon.Schema;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Donwload perks data.
    /// </summary>
    /// <param name="info"></param>
    internal class Perks(Info info)
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly Logger _logger = new("Perks");

        /// <summary>
        /// The download manager.
        /// </summary>
        private static readonly Download _download = new();
        /// <summary>
        /// The information fort download assets.
        /// </summary>
        private Info _info = info;
        /// <summary>
        /// The list of Perks.
        /// </summary>
        private readonly List<Perk> _perks = [];

        /// <summary>
        /// Download perks data.
        /// </summary>
        /// <returns>List of perks</returns>
        internal List<Perk> Download()
        {
            Perk();
            PerkStyle();
            return _perks;
        }

        /// <summary>
        /// Download the perks data.
        /// </summary>
        private void Perk()
        {
            Uri urlPerks = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/perks.json");
            string? perks = _download.StringAsync(urlPerks).Result;
            if (perks != null)
            {
                try
                {
                    List<Schema.CDragon.Perk>? perkSummary = JsonConvert.DeserializeObject<List<Schema.CDragon.Perk>>(perks);
                    if (perkSummary == null)
                    {
                        _logger.Log(LoggingLevel.ERROR, "Download()", "Perks not downloaded");
                        return;
                    }
                    // Perks to ignore
                    int[] perksToIgnore = { 7000, 8006, 8007, 8016, 8109, 8114, 8115, 8127, 8205, 8207, 8208, 8220, 8318, 8319, 8320, 8344, 8414, 8415, 8416, 8454 };
                    foreach (Schema.CDragon.Perk perk in perkSummary)
                    {
                        // Process each perk
                        if (!perksToIgnore.Contains(perk.Id))
                        {
                            _perks.Add(PerkAssets(perk));
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"Perks not downloaded : {ex.Message}");
                    return;
                }
            }
        }

        /// <summary>
        /// Download the perk sytles data.
        /// </summary>
        private void PerkStyle()
        {
            Uri urlPerksStyle = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/{_info.Region}/v1/perkstyles.json");
            string? perksStyle = _download.StringAsync(urlPerksStyle).Result;
            if (perksStyle != null)
            {
                try
                {
                    Schema.CDragon.PerkStyle perkStyleSummary = JsonConvert.DeserializeObject<Schema.CDragon.PerkStyle>(perksStyle);
                    foreach (Schema.CDragon.Style perkStyle in perkStyleSummary.Styles)
                    {
                        // Process each perk style
                        _perks.Add(PerkAssets(perkStyle));
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LoggingLevel.ERROR, "Download()", $"PerksStyle not downloaded : {ex.Message}");
                    return;
                }
            }
        }

        /// <summary>
        /// Download the perk or perk sytles images assets.
        /// </summary>
        /// <param name="perkCDragon">CDragon perk or perk style info</param>
        /// <returns>perk</returns>
        private Perk PerkAssets(dynamic perkCDragon)
        {
            string perkPathName = perkCDragon.IconPath;
            perkPathName = perkPathName.Split("/perk-images/")[^1].ToLower();
            Uri urlPerk = new($"https://raw.communitydragon.org/{_info.ShortPatch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{perkPathName}");

            string dir = OSL_Utils.Path.GetDirectoryName($"perks/{perkPathName}");
            //Folder to concerve, remove last folder if not in the list
            string[] lastFolders = { "inspiration", "precision", "resolve", "sorcery", "domination", "statmods" };
            if (!lastFolders.Contains(dir.Split("/")[^1]))
            {
                dir = dir.Replace(dir.Split("/")[^1], "");
            }

            string fullPerkDir = OSL_Utils.Path.Combine(_info.AssetsDir, dir);
            OSL_Utils.Directory.Create(fullPerkDir);

            Perk perk = new(perkCDragon.Id, perkCDragon.Name, _download.DownloadFile(urlPerk, fullPerkDir, $"{perkCDragon.Id}.png"));
            return perk;
        }
    }
}
