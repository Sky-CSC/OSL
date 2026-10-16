using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>Builds the rune catalog (perks and perk styles) and queues the icons.</summary>
internal static class Perks
{
    private static readonly Logger _logger = new("Perks");

    /// <summary>Perks that must not be exposed (unused or removed runes).</summary>
    private static readonly HashSet<int> _ignored =
    [
        7000, 8006, 8007, 8016, 8109, 8114, 8115, 8127, 8205, 8207, 8208, 8220, 8318, 8319, 8320, 8344, 8414, 8415, 8416, 8454,
    ];

    internal static async Task<List<Perk>> PlanAsync(SyncContext context)
    {
        Task<List<Dto.Perk>?> perksTask = context.GetJsonAsync<List<Dto.Perk>>(context.RegionalUrl("v1/perks.json"));
        Task<Dto.PerkStyle?> stylesTask = context.GetJsonValueAsync<Dto.PerkStyle>(context.RegionalUrl("v1/perkstyles.json"));
        await Task.WhenAll(perksTask, stylesTask).ConfigureAwait(false);

        var perks = new List<Perk>();

        if (perksTask.Result is { } sourcePerks)
        {
            foreach (Dto.Perk perk in sourcePerks.Where(perk => !_ignored.Contains(perk.Id)))
                perks.Add(PlanPerk(context, perk.Id, perk.Name, perk.IconPath));
        }
        else
        {
            _logger.Log(LoggingLevel.ERROR, nameof(PlanAsync), "Perk list not available");
        }

        if (stylesTask.Result?.Styles is { } styles)
        {
            foreach (Dto.Style style in styles)
                perks.Add(PlanPerk(context, style.Id, style.Name, style.IconPath));
        }
        else
        {
            _logger.Log(LoggingLevel.ERROR, nameof(PlanAsync), "Perk style list not available");
        }

        return perks;
    }

    private static Perk PlanPerk(SyncContext context, int id, string name, string iconPath)
    {
        string? relative = AssetPaths.AfterLast(iconPath, "/perk-images/");
        string destination = string.Empty;
        if (relative is not null)
        {
            destination = context.Queue(
                context.DefaultUrl($"v1/perk-images/{relative}"),
                $"{context.RegionDir}/perks/{id}.png");
        }

        return new Perk(id, name, destination);
    }

    internal static void VerifyFiles(IEnumerable<Perk> perks)
    {
        foreach (Perk perk in perks)
            perk.IconPath = AssetPaths.ExistingOrEmpty(perk.IconPath);
    }
}
