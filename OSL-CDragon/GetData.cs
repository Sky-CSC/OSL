using OSL_CDragon.Schema;

namespace OSL_CDragon;

/// <summary>
/// Read access to the assets. Every method is safe to call at any time (even before the first download):
/// it returns null / an empty value when the data is not available yet.
/// </summary>
public partial class CDragon
{
    public Champion? GetChampion(long id)
    {
        if (id is < int.MinValue or > int.MaxValue)
            return null;

        return _current?.Champions.GetValueOrDefault((int)id);
    }

    public string GetChampionSplash(long championId)
    {
        if (championId == 0)
            return string.Empty;

        Skin? skin = GetChampion(championId)?.Skins.FirstOrDefault(skin => skin.IsBase);
        return AssetPaths.ToWebPath(skin?.Splashe);
    }

    public string GetChampionSquare(int championId)
    {
        if (championId == 0)
            return string.Empty;

        return AssetPaths.ToWebPath(GetChampion(championId)?.SquarePortraitPath);
    }

    public string GetChampionTile(int championId)
    {
        if (championId == 0)
            return string.Empty;

        Champion? champion = GetChampion(championId);
        return champion is null ? string.Empty : AssetPaths.ToWebPath(GetBaseSkin(champion).Tile);
    }

    public Skin GetBaseSkin(Champion champion)
    {
        return champion.Skins.FirstOrDefault(skin => skin.IsBase) ?? new Skin();
    }

    public List<Champion> GetAllChampions()
    {
        return _current?.Region.Champions ?? [];
    }

    public string GetDefaultImage()
    {
        return GetSummonerSpell(54)?.IconPath ?? string.Empty;
    }

    public string GetPatchVersion()
    {
        return _current?.Patch.ShortNumber ?? string.Empty;
    }

    public Item? GetItem(int id)
    {
        return _current?.Items.GetValueOrDefault(id);
    }

    public SummonerSpell? GetSummonerSpell(uint id)
    {
        return _current?.SummonerSpells.GetValueOrDefault(id);
    }

    public Perk? GetPerk(int id)
    {
        return _current?.Perks.GetValueOrDefault(id);
    }

    public string GetPerkIconPath(int id)
    {
        return AssetPaths.ToWebPath(GetPerk(id)?.IconPath);
    }

    public List<Asset> GetPositionTop() => _data.Positions.TopPath;

    public List<Asset> GetPositionJungle() => _data.Positions.JunglePath;

    public List<Asset> GetPositionMid() => _data.Positions.MiddlePath;

    public List<Asset> GetPositionAdc() => _data.Positions.AdcPath;

    public List<Asset> GetPositionSupport() => _data.Positions.SupportPath;
}
