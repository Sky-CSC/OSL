using OSL_CDragon.Schema;
using OSL_Utils;

namespace OSL_CDragon
{
    /// <summary>
    /// Check data for champion, items, runes, and summoner spells.
    /// </summary>
    public partial class CDragon
    {

        /// <summary>
        /// Check if all assets are downloaded
        /// </summary>
        /// <returns>True if all data are downloaded</returns>
        internal void Patchs()
        {
            //Save current info
            Info info = _info;

            foreach (var patch in _data.Patchs)
            {
                // Check patch directory
                string patchShortNumber = $"./wwwroot/assets/{patch.ShortNumber}";
                if (!OSL_Utils.Directory.Exist(patchShortNumber))
                {
                    _logger.Log(LoggingLevel.WARN, nameof(Patchs), $"Patch {patchShortNumber} not downloaded");
                }
                _logger.Log(LoggingLevel.INFO, nameof(Patchs), $"Patch {patchShortNumber} are already downloaded");

                // Check all regions
                List<string> regionsError = Regions(patchShortNumber, patch.Regions);
                //Error in regions
                if (regionsError.Count != 0)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(Patchs), $"Patch {patch.Number} have regions not downloaded");

                    //Set patch info with the current value
                    _info.Patch = patch.Number;
                    _info.ShortPatch = patch.ShortNumber;

                    // For each region in error
                    foreach (var regionError in regionsError)
                    {
                        _logger.Log(LoggingLevel.WARN, nameof(Patchs), $"Region {regionError} not correctly downloaded");
                        //Set region with current value used
                        _info.Region = regionError;
                        //Set index of patch and region current used
                        FindIndexPatch();
                        FindIndexRegion();

                        //Download all assets of the patch in regionsError list
                        DownloadAllData();
                        _logger.Log(LoggingLevel.INFO, nameof(Patchs), $"Region {regionError} are downloaded");
                    }
                }
                else
                {
                    _logger.Log(LoggingLevel.INFO, nameof(Patchs), $"Latest patch {patch.Number} are already downloaded");
                }
            }

            //Set patch and region info with the previous value
            _info = info;
            //Set index of patch and region current used
            FindIndexPatch();
            FindIndexRegion();
        }

        /// <summary>
        /// Check if all assets are downloaded
        /// </summary>
        /// <param name="pathPatch">Patch</param>
        /// <param name="regions">List of region in the patch</param>
        /// <returns>List of region not correctly downloaded</returns>
        private static List<string> Regions(string pathPatch, List<Region> regions)
        {
            List<string> regionsError = [];
            //Check all regions in patch, if one region is not correctly downloaded, add it in regionsError list
            foreach (var region in regions)
            {
                //Check region directory
                string pathRegionName = $"{pathPatch}/{region.Name}";
                if (!OSL_Utils.Directory.Exist(pathRegionName))
                {
                    regionsError.Add(region.Name);
                    continue;
                }
                _logger.Log(LoggingLevel.INFO, nameof(Regions), $"Region {pathRegionName} are already downloaded");

                // Check all champions directories
                if (!Champions(region.Champions))
                {
                    regionsError.Add(region.Name);
                    continue;
                }

                // Check all items directories
                if (!Items(region.Items))
                {
                    regionsError.Add(region.Name);
                    continue;
                }

                // Check all perks directories
                if (!Perks(region.Perks))
                {
                    regionsError.Add(region.Name);
                    continue;
                }

                // Check all summoner spells directories
                if (!SummonerSpells(region.SummonerSpells))
                {
                    regionsError.Add(region.Name);
                    continue;
                }
            }
            return regionsError;
        }

        /// <summary>
        /// Check if all champion asset are downloaded
        /// </summary>
        /// <param name="champions">List of champion</param>
        /// <returns>True if all data are downloaded</returns>
        private static bool Champions(List<Champion> champions)
        {
            if (champions.Count == 0)
            {
                return false;
            }
            foreach (var champion in champions)
            {
                if (champion.Id != -1)
                {
                    // Check champion directory
                    if (!Champion(champion))
                    {
                        return false;
                    }
                    // Check sound assets
                    if (!Sound(champion.Sounds))
                    {
                        return false;
                    }
                    // Check skin assets
                    foreach (var skin in champion.Skins)
                    {
                        if (!Skin(skin))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the champion assets are downloaded
        /// </summary>
        /// <param name="champion"></param>
        /// <returns>True if champion assets are present</returns>
        private static bool Champion(Champion champion)
        {
            if (!OSL_Utils.File.Exist(champion.SquarePortraitPath))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Champion), $"Champion {champion.SquarePortraitPath} portrait not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Champion), $"Champion {champion.SquarePortraitPath} portrait exist");
            return true;
        }

        /// <summary>
        /// Check if the sound assets are downloaded
        /// </summary>
        /// <param name="sound">Sound information</param>
        /// <returns>True if all assets of sound are present</returns>
        private static bool Sound(Sound sound)
        {
            if (!OSL_Utils.File.Exist(sound.ChoosePath) && sound.ChoosePath != "")
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Sound), $"Sound {sound.ChoosePath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Sound), $"Sound {sound.ChoosePath} exist");
            if (!OSL_Utils.File.Exist(sound.BanPath) && sound.BanPath != "")
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Sound), $"Sound {sound.BanPath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Sound), $"Sound {sound.BanPath} exist");
            if (!OSL_Utils.File.Exist(sound.SfxPath) && sound.SfxPath != "")
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Sound), $"Sound {sound.SfxPath} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Sound), $"Sound {sound.SfxPath} exist");
            return true;
        }

        /// <summary>
        /// Check if the skin assets are downloaded
        /// </summary>
        /// <param name="skin">Skin information</param>
        /// <returns>True if all assets of skin are present</returns>
        private static bool Skin(Skin skin)
        {
            if (!OSL_Utils.File.Exist(skin.Splashe))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Skin), $"Skin {skin.Splashe} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Skin), $"Skin {skin.Splashe} exist");
            if (!OSL_Utils.File.Exist(skin.SplasheUncentered))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Skin), $"Skin {skin.SplasheUncentered} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Skin), $"Skin {skin.SplasheUncentered} exist");
            if (!OSL_Utils.File.Exist(skin.Tile))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Skin), $"Skin {skin.Tile} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Skin), $"Skin {skin.Tile} exist");
            if (!OSL_Utils.File.Exist(skin.LoadScreen))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Skin), $"Skin {skin.LoadScreen} not exist");
                return false;
            }
            _logger.Log(LoggingLevel.INFO, nameof(Skin), $"Skin {skin.LoadScreen} exist");
            return true;
        }

        /// <summary>
        /// Check if all items assets are downloaded
        /// </summary>
        /// <param name="items">List of item</param>
        /// <returns>True if all data are downloaded</returns>
        private static bool Items(List<Item> items)
        {
            if (items.Count == 0)
            {
                return false;
            }
            foreach (var item in items)
            {
                if (!OSL_Utils.File.Exist(item.IconPath))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Items), $"Item {item.IconPath} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(Items), $"Item {item.IconPath} exist");
            }
            return true;
        }

        /// <summary>
        /// Check if all perks assets are downloaded
        /// </summary>
        /// <param name="perks">List of perk</param>
        /// <returns>True if all data are downloaded</returns>
        private static bool Perks(List<Perk> perks)
        {
            if (perks.Count == 0)
            {
                return false;
            }
            foreach (var perk in perks)
            {
                if (!OSL_Utils.File.Exist(perk.IconPath))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Perks), $"Perk {perk.IconPath} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(Perks), $"Perk {perk.IconPath} exist");
            }
            return true;
        }

        /// <summary>
        /// Check if all summoner spells assets are downloaded
        /// </summary>
        /// <param name="summonerSpells">List of summoner spell</param>
        /// <returns>True if all data are downloaded</returns>
        private static bool SummonerSpells(List<SummonerSpell> summonerSpells)
        {
            if (summonerSpells.Count == 0)
            {
                return false;
            }
            foreach (var summonerSpell in summonerSpells)
            {
                if (!OSL_Utils.File.Exist(summonerSpell.IconPath))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(SummonerSpells), $"Summoner spell {summonerSpell.IconPath} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(SummonerSpells), $"Summoner spell {summonerSpell.IconPath} exist");
            }
            return true;
        }

        /// <summary>
        /// Check if all positions assets are downloaded
        /// </summary>
        /// <returns>True if all data are downloaded</returns>
        internal static bool Position(Position position)
        {
            var allPaths = position.TopPath.Select(position => position.Path);
            allPaths = allPaths.Concat(position.JunglePath.Select(position => position.Path));
            allPaths = allPaths.Concat(position.MiddlePath.Select(position => position.Path));
            allPaths = allPaths.Concat(position.AdcPath.Select(position => position.Path));
            allPaths = allPaths.Concat(position.SupportPath.Select(position => position.Path));

            if (!allPaths.Any())
            {
                return false;
            }

            foreach (var path in allPaths)
            {
                if (!OSL_Utils.File.Exist(path))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Position), $"Position {path} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(Position), $"Position {path} exist");
            }
            return true;
        }

        /// <summary>
        /// Check if all epic monster assets are downloaded
        /// </summary>
        /// <param name="epicMonster"></param>
        /// <returns></returns>
        internal static bool EpicMonster(EpicMonster epicMonster)
        {
            var allPaths = epicMonster.Dragons.Chemtech.Select(epicMonster => epicMonster.Path);
            allPaths = allPaths.Concat(epicMonster.Dragons.Cloud.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Dragons.Elder.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Dragons.Hextech.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Dragons.Infernal.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Dragons.Mountain.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Dragons.Ocean.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Heralds.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.VoidGrubs.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Atakhans.Select(epicMonster => epicMonster.Path));
            allPaths = allPaths.Concat(epicMonster.Barons.Select(epicMonster => epicMonster.Path));

            if (!allPaths.Any())
            {
                return false;
            }

            foreach (var path in allPaths)
            {
                if (!OSL_Utils.File.Exist(path))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(EpicMonster), $"Epic monster {path} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(EpicMonster), $"Epic monster {path} exist");

            }
            return true;
        }

        /// <summary>
        /// Check if all fonts assets are downloaded
        /// </summary>
        /// <param name="fonts"></param>
        /// <returns></returns>
        internal static bool Font(List<Asset> fonts)
        {
            if (fonts.Count == 0)
            {
                return false;
            }

            var fontPaths = fonts.Select(font => font.Path);

            foreach (string path in fontPaths)
            {
                if (!OSL_Utils.File.Exist(path))
                {
                    _logger.Log(LoggingLevel.ERROR, nameof(Font), $"Font {path} not exist");
                    return false;
                }
                _logger.Log(LoggingLevel.INFO, nameof(Font), $"Font {path} exist");
            }
            return true;
        }
    }
}
