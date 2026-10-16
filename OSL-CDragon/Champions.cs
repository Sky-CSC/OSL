using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>
/// Builds the champion catalog: reads the champion list and each champion detail, and queues the files to download
/// (square portrait, optional voice-overs, skin images).
/// </summary>
internal static class Champions
{
    private static readonly Logger _logger = new("Champions");

    internal static async Task<List<Champion>> PlanAsync(SyncContext context)
    {
        var summaries = await context.GetJsonAsync<List<Dto.ChampionSummary>>(context.RegionalUrl("v1/champion-summary.json")).ConfigureAwait(false);
        if (summaries is null || summaries.Count == 0)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(PlanAsync), "Champion list not available");
            return [];
        }

        var champions = new Champion[summaries.Count];
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = context.MaxParallelism,
            CancellationToken = context.CancellationToken,
        };

        await Parallel.ForEachAsync(Enumerable.Range(0, summaries.Count), options, async (index, _) =>
        {
            champions[index] = await PlanChampionAsync(context, summaries[index].Id).ConfigureAwait(false);
        }).ConfigureAwait(false);

        return [.. champions];
    }

    private static async Task<Champion> PlanChampionAsync(SyncContext context, int id)
    {
        var champion = new Champion(id);
        string championDir = $"{context.RegionDir}/champions/{id}";

        champion.SquarePortraitPath = context.Queue(
            context.DefaultUrl($"v1/champion-icons/{id}.png"),
            $"{championDir}/default-square.png");

        // The "none" champion (-1) has no voice-over and no skin.
        if (id != -1 && context.DownloadSounds)
        {
            string soundDir = $"{context.RegionDir}/champions/{id}/sounds";
            champion.Sounds = new Sound
            {
                ChoosePath = context.Queue(context.RegionalUrl($"v1/champion-choose-vo/{id}.ogg"), $"{soundDir}/choose.ogg"),
                BanPath = context.Queue(context.RegionalUrl($"v1/champion-ban-vo/{id}.ogg"), $"{soundDir}/ban.ogg"),
                SfxPath = context.Queue(context.DefaultUrl($"v1/champion-sfx-audios/{id}.ogg"), $"{championDir}/sounds/sfx.ogg"),
            };
        }

        Dto.Champion? maybeDetails = await context.GetJsonValueAsync<Dto.Champion>(context.RegionalUrl($"v1/champions/{id}.json")).ConfigureAwait(false);
        if (maybeDetails is not { } details)
        {
            _logger.Log(LoggingLevel.WARN, nameof(PlanChampionAsync), $"Details of champion {id} not available");
            return champion;
        }

        champion.Name = details.Name;
        champion.Alias = details.Alias;
        champion.Roles = details.Roles;

        if (id != -1 && details.Skins is { Count: > 0 })
        {
            int skinCount = context.DownloadAllSkins ? details.Skins.Count : 1;
            for (int index = 0; index < skinCount; index++)
                champion.Skins.Add(PlanSkin(context, championDir, details.Skins[index]));
        }

        return champion;
    }

    private static Skin PlanSkin(SyncContext context, string championDir, Dto.Skin source)
    {
        string skinDir = $"{championDir}/skins/{source.Id}";
        return new Skin(source.Id, source.IsBase)
        {
            Splashe = QueueSkinImage(context, source.SplashPath, $"{skinDir}/splashe.png"),
            SplasheUncentered = QueueSkinImage(context, source.UncenteredSplashPath, $"{skinDir}/splashe-uncentered.png"),
            Tile = QueueSkinImage(context, source.TilePath, $"{skinDir}/tile.png"),
            LoadScreen = QueueSkinImage(context, source.LoadScreenPath, $"{skinDir}/loadscreen.png"),
        };
    }

    private static string QueueSkinImage(SyncContext context, string? sourcePath, string destination)
    {
        const string marker = "/ASSETS/";
        if (string.IsNullOrEmpty(sourcePath))
            return string.Empty;

        int index = sourcePath.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
        if (index < 0)
            return string.Empty;

        string relative = sourcePath[(index + marker.Length)..].ToLowerInvariant();
        return context.Queue(context.DefaultUrl($"{relative}"), destination);
    }

    /// <summary>Replaces by an empty string every path whose file is not on disk (not found or failed download).</summary>
    internal static void VerifyFiles(IEnumerable<Champion> champions)
    {
        foreach (Champion champion in champions)
        {
            champion.SquarePortraitPath = AssetPaths.ExistingOrEmpty(champion.SquarePortraitPath);
            champion.Sounds.ChoosePath = AssetPaths.ExistingOrEmpty(champion.Sounds.ChoosePath);
            champion.Sounds.BanPath = AssetPaths.ExistingOrEmpty(champion.Sounds.BanPath);
            champion.Sounds.SfxPath = AssetPaths.ExistingOrEmpty(champion.Sounds.SfxPath);

            foreach (Skin skin in champion.Skins)
            {
                skin.Splashe = AssetPaths.ExistingOrEmpty(skin.Splashe);
                skin.SplasheUncentered = AssetPaths.ExistingOrEmpty(skin.SplasheUncentered);
                skin.Tile = AssetPaths.ExistingOrEmpty(skin.Tile);
                skin.LoadScreen = AssetPaths.ExistingOrEmpty(skin.LoadScreen);
            }
        }
    }
}
