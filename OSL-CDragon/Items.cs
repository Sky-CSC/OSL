using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>Builds the item catalog and queues the 2D icons.</summary>
internal static class Items
{
    private static readonly Logger _logger = new("Items");

    internal static async Task<List<Item>> PlanAsync(SyncContext context)
    {
        var source = await context.GetJsonAsync<List<Dto.Item>>(context.RegionalUrl("v1/items.json")).ConfigureAwait(false);
        if (source is null)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(PlanAsync), "Item list not available");
            return [];
        }

        var items = new List<Item>(source.Count);
        foreach (Dto.Item item in source)
        {
            string iconPath = string.Empty;
            string? relative = AssetPaths.AfterLast(item.IconPath, "/Icons2D/");
            if (relative is not null)
            {
                iconPath = context.Queue(
                    context.DefaultUrl($"assets/items/icons2d/{relative}"),
                    $"{context.RegionDir}/items/{item.Id}.png");
            }

            items.Add(new Item(item.Id, item.Name, iconPath, item.From, item.To));
        }

        return items;
    }

    internal static void VerifyFiles(IEnumerable<Item> items)
    {
        foreach (Item item in items)
            item.IconPath = AssetPaths.ExistingOrEmpty(item.IconPath);
    }
}
