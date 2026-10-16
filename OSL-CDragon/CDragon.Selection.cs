using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>A patch / region combination available on disk.</summary>
/// <param name="ShortPatch">Short patch number, e.g. "16.20".</param>
/// <param name="Region">CommunityDragon locale, e.g. "fr_fr".</param>
/// <param name="IsComplete">False when some files are still missing (the next synchronisation resumes the download).</param>
public sealed record AssetVersion(string ShortPatch, string Region, bool IsComplete);

/// <summary>
/// Choice of the patch and the region served to the overlay.
/// By default the latest patch of the requested region is served; <see cref="Select"/> pins another one.
/// </summary>
public partial class CDragon
{
    private volatile IReadOnlyList<AssetVersion> _installed = [];

    /// <summary>Short patch really served to the overlay (e.g. "16.20"), empty when nothing is available yet.</summary>
    public string ServedPatch => _current?.Patch.ShortNumber ?? string.Empty;

    /// <summary>Region really served to the overlay (e.g. "fr_fr"), empty when nothing is available yet.</summary>
    public string ServedRegion => _current?.Region.Name ?? string.Empty;

    /// <summary>True when the user chose an older patch: it is kept until the server sends another region or <see cref="FollowLatest"/> is called.</summary>
    public bool IsPinned => _info.PinnedShortPatch is not null;

    /// <summary>Patch / region combinations available on disk, latest patch first.</summary>
    public IReadOnlyList<AssetVersion> GetInstalled() => _installed;

    /// <summary>
    /// Serves another patch / region already on disk. Choosing the latest installed patch goes back to the automatic mode.
    /// </summary>
    /// <returns>False when this combination is not installed.</returns>
    public bool Select(string? shortPatch, string? locale)
    {
        string? region = NormalizeRegion(locale);
        if (string.IsNullOrWhiteSpace(shortPatch) || region is null)
            return false;

        RegionIndex? index = FindIndex(_data, shortPatch, region);
        if (index is null || !Directory.Exists($"{AssetPaths.Root}/{shortPatch}"))
        {
            _logger.Log(LoggingLevel.WARN, nameof(Select), $"Patch {shortPatch} ({region}) is not installed");
            return false;
        }

        _info.Region = region;
        _info.PinnedShortPatch = string.Equals(shortPatch, LatestInstalledPatch(), StringComparison.Ordinal) ? null : shortPatch;
        _current = index;
        _logger.Log(LoggingLevel.INFO, nameof(Select), $"Serving patch {shortPatch} ({region}){(IsPinned ? " (chosen by the user)" : string.Empty)}");

        TrySaveAll(nameof(Select));
        RaiseUpdated();
        return true;
    }

    /// <summary>Back to the automatic mode: serves the latest patch and checks whether a newer one can be downloaded.</summary>
    public void FollowLatest()
    {
        _info.PinnedShortPatch = null;

        string? latest = LatestInstalledPatch();
        RegionIndex? index = latest is null ? null : FindIndex(_data, latest, _info.Region);
        if (index is not null)
            _current = index;

        TrySaveAll(nameof(FollowLatest));
        RaiseUpdated();
        RaiseUpdateRequested();
    }

    private string? LatestInstalledPatch() =>
        _data.Patchs.Select(patch => patch.ShortNumber)
            .OrderByDescending(ParsePatch)
            .FirstOrDefault();

    /// <summary>Numeric order ("16.10" is after "16.9"); a name that is not a version goes last.</summary>
    private static System.Version ParsePatch(string shortPatch) =>
        System.Version.TryParse(shortPatch, out System.Version? version) ? version : new System.Version(0, 0);

    /// <summary>Rebuilds the list read by <see cref="GetInstalled"/>. Called after every change of the data.</summary>
    private void RefreshInstalled()
    {
        try
        {
            _installed = _data.Patchs.ToArray()
                .SelectMany(patch => patch.Regions.ToArray()
                    .Where(region => region.Champions.Count > 0)
                    .Select(region => new AssetVersion(patch.ShortNumber, region.Name, region.IsComplete)))
                .Where(version => Directory.Exists($"{AssetPaths.Root}/{version.ShortPatch}"))
                .OrderByDescending(version => ParsePatch(version.ShortPatch))
                .ThenBy(version => version.Region, StringComparer.Ordinal)
                .ToArray();
        }
        catch (InvalidOperationException)
        {
            // The data changed while it was read: the previous list is kept until the next save.
        }
    }

    private void TrySaveAll(string caller)
    {
        try
        {
            SaveAll();
        }
        catch (IOException ex)
        {
            _logger.Log(LoggingLevel.WARN, caller, $"Choice not saved : {ex.Message}");
        }
    }
}
