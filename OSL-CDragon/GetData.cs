using OSL_CDragon.Schema;

namespace OSL_CDragon
{
    /// <summary>
    /// Return scpécific data from CDragon
    /// </summary>
    public partial class CDragon
    {
        /// <summary>
        /// Get a champion by its ID.
        /// </summary>
        /// <param name="id">Champion id</param>
        /// <returns>A <see cref="Schema.Champion"/> object if found; otherwise, null.</returns>
        public Champion? GetChampion(Int64 id)
        {
            return _data.Patchs[_indexPatch].Regions[_indexRegion].Champions.FirstOrDefault(champ => champ.Id == id) ?? null;
        }

        public string GetChampionSplash(Int64 championId)
        {
            if (championId == 0)
                return string.Empty;

            var champion = GetChampion(championId);
            if (champion == null)
                return string.Empty;

            var skin = champion.Skins.FirstOrDefault(skin => skin.IsBase);
            if (skin == null)
                return string.Empty;

            string[] path = skin.Splashe.Split("/wwwroot");
            string filePath = path[0] + path[1];
            return filePath;
        }

        public string GetChampionSquare(int championId)
        {
            if (championId == 0)
                return string.Empty;
            var champion = GetChampion(championId);
            if (champion == null)
                return string.Empty;

            string[] path = champion.SquarePortraitPath.Split("/wwwroot");
            string filePath = path[0] + path[1];
            return filePath;
        }

        public List<Champion> GetAllChampions()
        {
            return _data.Patchs[_indexPatch].Regions[_indexRegion].Champions;
        }

        public string GetDefaultImage()
        {
            SummonerSpell? item = GetSummonerSpell(54);
            if (item == null)
            {
                return "";
            }
            return item.IconPath;
        }

        public string GetPatchVersion()
        {
            return _data.Patchs[_indexPatch].ShortNumber;
        }

        /// <summary>
        /// Get a item by its ID.
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>A <see cref="Item"/> object if found; otherwise, null.</returns>
        public Item? GetItem(int id)
        {
            return _data.Patchs[_indexPatch].Regions[_indexRegion].Items.FirstOrDefault(item => item.Id == id) ?? null;
        }

        /// <summary>
        /// Get a summoner spell by its ID.
        /// </summary>
        /// <param name="id">Summoner Spell id</param>
        /// <returns>A <see cref="SummonerSpell"/> object if found; otherwise, null.</returns>
        public SummonerSpell? GetSummonerSpell(int id)
        {
            return _data.Patchs[_indexPatch].Regions[_indexRegion].SummonerSpells.FirstOrDefault(spell => spell.Id == id) ?? null;
        }

        /// <summary>
        /// Get a perk by its ID.
        /// </summary>
        /// <param name="id">Perk id</param>
        /// <returns>A <see cref="Perk"/> object if found; otherwise, null.</returns>
        public Perk? GetPerk(int id)
        {
            return _data.Patchs[_indexPatch].Regions[_indexRegion].Perks.FirstOrDefault(perk => perk.Id == id) ?? null;
        }

        public List<Asset> GetPositionTop()
        {
            return _data.Positions.TopPath;
        }

        public List<Asset> GetPositionJungle()
        {
            return _data.Positions.JunglePath;
        }

        public List<Asset> GetPositionMid()
        {
            return _data.Positions.MiddlePath;
        }

        public List<Asset> GetPositionAdc()
        {
            return _data.Positions.AdcPath;
        }

        public List<Asset> GetPositionSupport()
        {
            return _data.Positions.SupportPath;
        }
    }
}
