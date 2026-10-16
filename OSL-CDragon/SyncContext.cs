using System.Collections.Concurrent;
using Newtonsoft.Json;
using OSL_CDragon.Schema;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>
/// State shared by the catalog builders (champions, items, perks, summoner spells) during one region synchronisation.
/// Builders only describe WHAT must be downloaded (<see cref="Queue"/>); the download itself is done once, in parallel.
/// </summary>
internal sealed class SyncContext(
    AssetDownloader downloader,
    Info info,
    string shortPatch,
    string region,
    CancellationToken cancellationToken)
{
    private static readonly Logger _logger = new("SyncContext");

    private readonly ConcurrentDictionary<string, AssetJob> _jobs = new(StringComparer.Ordinal);
    private int _transientFailures;

    public AssetDownloader Downloader { get; } = downloader;
    public string ShortPatch { get; } = shortPatch;
    public string Region { get; } = region;
    public bool DownloadAllSkins { get; } = info.DownloadAllSkin;
    public bool DownloadSounds { get; } = info.DownloadSounds;
    public int MaxParallelism { get; } = Math.Clamp(info.MaxParallelDownloads, 1, 32);
    public CancellationToken CancellationToken { get; } = cancellationToken;

    /// <summary>Directory for assets that do not depend on the region (icons, splash arts...). Shared by all regions of a patch.</summary>
    public string SharedDir { get; } = $"{AssetPaths.Root}/{shortPatch}/default";

    /// <summary>Directory for assets that depend on the region (voice-overs).</summary>
    public string RegionDir { get; } = $"{AssetPaths.Root}/{shortPatch}/{region}";

    /// <summary>Number of metadata requests that failed for a reason other than "not found".</summary>
    public int TransientFailures => Volatile.Read(ref _transientFailures);

    public IReadOnlyCollection<AssetJob> Jobs => _jobs.Values.ToArray();

    private string BaseUrl => $"https://raw.communitydragon.org/{ShortPatch}/plugins/rcp-be-lol-game-data";

    public Uri RegionalUrl(string relativePath) => new($"{BaseUrl}/global/{Region}/{relativePath}");

    public Uri DefaultUrl(string relativePath) => new($"{BaseUrl}/global/default/{relativePath}");

    /// <summary>Registers a file to download and returns its destination (the same destination is only queued once).</summary>
    public string Queue(Uri url, string destination)
    {
        _jobs.TryAdd(destination, new AssetJob(url, destination));
        return destination;
    }

    /// <summary>Reads a JSON reference type (list...). Returns null when the file is missing, unreachable or invalid.</summary>
    public async Task<T?> GetJsonAsync<T>(Uri url) where T : class
    {
        string? content = await GetTextAsync(url).ConfigureAwait(false);
        return content is null ? null : Deserialize<T>(url, content);
    }

    /// <summary>Same as <see cref="GetJsonAsync{T}"/> for the (struct) DTOs of the CommunityDragon schema.</summary>
    public async Task<T?> GetJsonValueAsync<T>(Uri url) where T : struct
    {
        string? content = await GetTextAsync(url).ConfigureAwait(false);
        return content is null ? null : Deserialize<T?>(url, content);
    }

    private async Task<string?> GetTextAsync(Uri url)
    {
        FetchedText fetched = await Downloader.GetStringAsync(url, CancellationToken).ConfigureAwait(false);
        if (fetched.Content is null && fetched.Result == DownloadResult.Failed)
            Interlocked.Increment(ref _transientFailures);
        return fetched.Content;
    }

    private static T? Deserialize<T>(Uri url, string content)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (JsonException ex)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(Deserialize), $"{url} is not valid JSON : {ex.Message}");
            return default;
        }
    }
}
