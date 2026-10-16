using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>Builds the summoner spell catalog and queues the 2D icons.</summary>
internal static class SummonerSpells
{
    private static readonly Logger _logger = new("SummonerSpells");

    internal static async Task<List<SummonerSpell>> PlanAsync(SyncContext context)
    {
        var source = await context.GetJsonAsync<List<Dto.SummonerSpell>>(context.RegionalUrl("v1/summoner-spells.json")).ConfigureAwait(false);
        if (source is null)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(PlanAsync), "Summoner spell list not available");
            return [];
        }

        var spells = new List<SummonerSpell>();
        foreach (Dto.SummonerSpell spell in source)
        {
            // Only spells with a 2D icon are kept.
            string? relative = AssetPaths.AfterLast(spell.IconPath, "/Icons2D/");
            if (relative is null)
                continue;

            string iconPath = context.Queue(
                context.DefaultUrl($"data/spells/icons2d/{relative}"),
                $"{context.RegionDir}/summonerspells/{spell.Id}.png");
            spells.Add(new SummonerSpell(spell.Id, spell.Name, iconPath));
        }

        return spells;
    }

    internal static void VerifyFiles(IEnumerable<SummonerSpell> spells)
    {
        foreach (SummonerSpell spell in spells)
            spell.IconPath = AssetPaths.ExistingOrEmpty(spell.IconPath);
    }
}
