using System.Text.RegularExpressions;
using Newtonsoft.Json;
using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>Result of a manual operation (download, deletion), with a message that can be shown to the user.</summary>
public readonly record struct AssetOperationResult(bool Success, string Message);

/// <summary>
/// Manual management of the patches on disk: list what CommunityDragon offers, download an older patch, delete a patch / region.
/// </summary>
public partial class CDragon
{
    /// <summary>Oldest patch that can be downloaded by hand.</summary>
    public const string MinimumPatch = "16.18";

    /// <summary>CommunityDragon folder (and local folder) of the American English assets, used as a region named "default".</summary>
    private const string SharedRegion = "default";

    private static readonly System.Version MinimumPatchVersion = System.Version.Parse(MinimumPatch);
    private static readonly Regex _patchPattern = new(@"^\d{1,3}\.\d{1,3}$", RegexOptions.Compiled);
    private static readonly Regex _folderLink = new("href=\"([^\"/?#]+)/\"", RegexOptions.Compiled);

    /// <summary>Name shown to the user for a region ("default" is the English one).</summary>
    public static string DisplayRegion(string region) =>
        string.Equals(region, SharedRegion, StringComparison.Ordinal) ? "default (en)" : region;

    /// <summary>Patches offered by CommunityDragon from <see cref="MinimumPatch"/>, latest first. Empty when it cannot be reached.</summary>
    public async Task<IReadOnlyList<string>> GetAvailablePatchesAsync(CancellationToken cancellationToken = default)
    {
        FetchedText fetched = await _downloader
            .GetStringAsync(new Uri("https://raw.communitydragon.org/"), cancellationToken)
            .ConfigureAwait(false);
        if (fetched.Content is null)
            return [];

        return ListFolders(fetched.Content)
            .Where(name => _patchPattern.IsMatch(name) && ParsePatch(name) >= MinimumPatchVersion)
            .OrderByDescending(ParsePatch)
            .ToArray();
    }

    /// <summary>Regions (language folders) CommunityDragon has for a patch. Empty when the patch is unusable or unreachable.</summary>
    public async Task<IReadOnlyList<string>> GetAvailableRegionsAsync(string? shortPatch, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(shortPatch) || !_patchPattern.IsMatch(shortPatch))
            return [];

        var url = new Uri($"https://raw.communitydragon.org/{shortPatch}/plugins/rcp-be-lol-game-data/global/");
        FetchedText fetched = await _downloader.GetStringAsync(url, cancellationToken).ConfigureAwait(false);
        if (fetched.Content is null)
            return [];

        return ListFolders(fetched.Content)
            .Select(name => name.ToLowerInvariant())
            .Where(name => name == SharedRegion || _localePattern.IsMatch(name))
            .OrderBy(name => name == SharedRegion ? 0 : 1)
            .ThenBy(name => name, StringComparer.Ordinal)
            .ToArray();
    }

    /// <summary>
    /// Downloads a patch / region by hand. The assets are not served automatically (use <see cref="Select"/>);
    /// an older patch is kept until the user deletes it.
    /// </summary>
    public async Task<AssetOperationResult> DownloadAsync(string? shortPatch, string? locale, CancellationToken cancellationToken = default)
    {
        string? region = NormalizeRegion(locale);
        if (string.IsNullOrWhiteSpace(shortPatch) || !_patchPattern.IsMatch(shortPatch) || region is null)
            return new AssetOperationResult(false, "Unusable patch or region.");
        if (ParsePatch(shortPatch) < MinimumPatchVersion)
            return new AssetOperationResult(false, $"Patches older than {MinimumPatch} cannot be downloaded.");

        await _updateLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_current is null && _data.Patchs.Count == 0)
                LoadFromDisk();

            Report(AssetSyncState.Checking, $"Checking patch {shortPatch}...", force: true);
            string patch = await ResolvePatchNumberAsync(shortPatch, cancellationToken).ConfigureAwait(false) ?? shortPatch;

            bool complete = await SyncRegionAsync(patch, shortPatch, cancellationToken, region).ConfigureAwait(false);
            bool stored = FindIndex(_data, shortPatch, region) is not null;

            // An older patch downloaded by hand must not be removed by the automatic cleanup.
            string? latest = LatestInstalledPatch();
            if (stored && latest is not null && ParsePatch(shortPatch) < ParsePatch(latest))
                _info.ManualPatches.Add(shortPatch);
            SaveAll();
            RaiseUpdated();

            string message = complete ? $"Patch {shortPatch} ({DisplayRegion(region)}) downloaded."
                : stored ? $"Patch {shortPatch} ({DisplayRegion(region)}) is incomplete: start the download again to resume it."
                : $"Patch {shortPatch} ({DisplayRegion(region)}) is not available (or CommunityDragon cannot be reached).";
            Report(complete ? AssetSyncState.Ready : AssetSyncState.Failed, message, force: true);
            return new AssetOperationResult(complete, message);
        }
        catch (OperationCanceledException)
        {
            Report(AssetSyncState.Idle, "Download cancelled", force: true);
            throw;
        }
        catch (Exception ex)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(DownloadAsync), $"Download of patch {shortPatch} ({region}) failed : {ex}");
            Report(AssetSyncState.Failed, ex.Message, force: true);
            return new AssetOperationResult(false, ex.Message);
        }
        finally
        {
            _updateLock.Release();
        }
    }

    /// <summary>
    /// Deletes a patch / region from disk. The assets in use cannot be deleted. The images of a patch are shared by
    /// its regions, so they are only removed with the last region.
    /// </summary>
    public AssetOperationResult Delete(string? shortPatch, string? locale)
    {
        string? region = NormalizeRegion(locale);
        if (string.IsNullOrWhiteSpace(shortPatch) || !_safeDirectoryName.IsMatch(shortPatch) || shortPatch is "." or ".." || region is null)
            return new AssetOperationResult(false, "Unusable patch or region.");

        if (!_updateLock.Wait(0))
            return new AssetOperationResult(false, "A download is in progress: try again when it is finished.");
        try
        {
            Patch? entry = _data.Patchs.FirstOrDefault(patch => patch.ShortNumber == shortPatch);
            Region? target = entry?.Regions.FirstOrDefault(r => r.Name == region);
            if (entry is null || target is null)
                return new AssetOperationResult(false, $"Patch {shortPatch} ({DisplayRegion(region)}) is not installed.");
            if (shortPatch == ServedPatch && region == ServedRegion)
                return new AssetOperationResult(false, "These assets are in use: select another version first.");

            bool lastRegion = entry.Regions.All(r => r.Name == region);
            string patchDirectory = $"{AssetPaths.Root}/{shortPatch}";
            try
            {
                if (lastRegion)
                {
                    if (Directory.Exists(patchDirectory))
                        Directory.Delete(patchDirectory, recursive: true);
                }
                else if (region != SharedRegion && Directory.Exists($"{patchDirectory}/{region}"))
                {
                    // Never the shared folder: the images of the other regions are in it.
                    Directory.Delete($"{patchDirectory}/{region}", recursive: true);
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _logger.Log(LoggingLevel.WARN, nameof(Delete), $"Patch {shortPatch} ({region}) not deleted : {ex.Message}");
                return new AssetOperationResult(false, $"Files could not be deleted: {ex.Message}");
            }

            entry.Regions.Remove(target);
            if (lastRegion)
            {
                _data.Patchs.Remove(entry);
                _info.ManualPatches.Remove(shortPatch);
                if (_info.PinnedShortPatch == shortPatch)
                    _info.PinnedShortPatch = null;
            }

            _logger.Log(LoggingLevel.INFO, nameof(Delete), $"Patch {shortPatch} ({region}) deleted");
            TrySaveAll(nameof(Delete));
            RaiseUpdated();
            return new AssetOperationResult(true, $"Patch {shortPatch} ({DisplayRegion(region)}) deleted.");
        }
        finally
        {
            _updateLock.Release();
        }
    }

    /// <summary>Full number of a patch (e.g. "16.19.123+branch...") read from CommunityDragon, null when unknown.</summary>
    private async Task<string?> ResolvePatchNumberAsync(string shortPatch, CancellationToken cancellationToken)
    {
        FetchedText fetched = await _downloader
            .GetStringAsync(new Uri($"https://raw.communitydragon.org/{shortPatch}/content-metadata.json"), cancellationToken)
            .ConfigureAwait(false);
        if (fetched.Content is null)
            return null;

        try
        {
            return JsonConvert.DeserializeObject<Dto.ContentMetadata>(fetched.Content).Version;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static IEnumerable<string> ListFolders(string directoryListing) =>
        _folderLink.Matches(directoryListing).Select(match => match.Groups[1].Value).Distinct(StringComparer.Ordinal);
}
