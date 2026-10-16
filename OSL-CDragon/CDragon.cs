using System.Text.RegularExpressions;
using Newtonsoft.Json;
using OSL_CDragon.Schema;
using Dto = OSL_CDragon.Schema.CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>
/// Keeps the CommunityDragon assets (champions, items, runes, summoner spells...) up to date on disk and exposes them.
/// <para>
/// Usage: call <see cref="LoadFromDisk"/> at startup (instant, serves the assets already downloaded), then run
/// <see cref="UpdateAsync"/> in the background. The data served to readers is replaced atomically once a new patch is
/// completely downloaded, so the overlay never sees a half-downloaded patch.
/// </para>
/// </summary>
public partial class CDragon
{
    private static readonly Logger _logger = new("CDragon");
    private static readonly Regex _safeDirectoryName = new("^[0-9A-Za-z_.-]+$", RegexOptions.Compiled);
    private static readonly Regex _localePattern = new("^[a-z]{2}[_-][a-z]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>CommunityDragon folder holding the default language, used when a region does not exist.</summary>
    private const string DefaultRegion = "fr_fr";

    private readonly AssetDownloader _downloader;
    private readonly SemaphoreSlim _updateLock = new(1, 1);

    private Info _info = new();
    private Data _data = new();
    private volatile RegionIndex? _current;
    private AssetSyncStatus _status = AssetSyncStatus.Idle;
    private long _lastStatusRaise;
    private readonly object _saveLock = new();

    public CDragon() : this(AssetDownloader.Shared)
    {
    }

    internal CDragon(AssetDownloader downloader)
    {
        _downloader = downloader;
    }

    /// <summary>Raised (from a background thread) when new data is served: new patch, new static assets.</summary>
    public event Action? Updated;

    /// <summary>Raised (from a background thread) when the progress changes. Throttled to about 5 events per second.</summary>
    public event Action<AssetSyncStatus>? StatusChanged;
    /// <summary>Raised when something asks for a synchronisation (region changed). The background service listens to it.</summary>
    public event Action? UpdateRequested;

    /// <summary>Region (CommunityDragon locale folder, e.g. "fr_fr") currently requested.</summary>
    public string Region => _info.Region;

    public AssetSyncStatus Status => _status;

    /// <summary>True once champion/item data is available (from disk or after the first download).</summary>
    public bool IsReady => _current is not null;

    /// <summary>
    /// Changes the region (language of the names). Accepts "fr_FR", "fr-FR" or "fr_fr".
    /// Images are shared by all regions, so they keep working immediately; only the catalogs of the new region are
    /// read in the background (<see cref="UpdateRequested"/>).
    /// </summary>
    /// <returns>True when the region really changed.</returns>
    public bool SetRegion(string? locale)
    {
        string? region = NormalizeRegion(locale);
        if (region is null)
        {
            _logger.Log(LoggingLevel.WARN, nameof(SetRegion), $"Unusable region '{locale}', ignored");
            return false;
        }
        // Same region again (the server sends it at every reconnection): a manual choice must not be cancelled.
        if (string.Equals(region, _info.Region, StringComparison.Ordinal))
            return false;
        _logger.Log(LoggingLevel.INFO, nameof(SetRegion), $"Region changed from {_info.Region} to {region}");
        _info.Region = region;
        // A new region is the new default: follow the latest patch again.
        _info.PinnedShortPatch = null;
        // Instant switch when this region is already complete for the latest patch on disk.
        string? servedPatch = LatestInstalledPatch() ?? _current?.Patch.ShortNumber;
        RegionIndex? known = servedPatch is null ? null : FindIndex(_data, servedPatch, region);
        if (known is { Region.IsComplete: true })
        {
            _current = known;
            RaiseUpdated();
        }
        try
        {
            SaveAll();
        }
        catch (IOException ex)
        {
            _logger.Log(LoggingLevel.WARN, nameof(SetRegion), $"Region not saved : {ex.Message}");
        }
        RaiseUpdateRequested();
        return true;
    }
    private static string? NormalizeRegion(string? locale)
    {
        if (string.IsNullOrWhiteSpace(locale))
            return null;
        string value = locale.Trim();
        if (string.Equals(value, DefaultRegion, StringComparison.OrdinalIgnoreCase))
            return DefaultRegion;
        // The "default" folder of CommunityDragon holds the English names: it is the folder of "en_us".
        if (value.Equals(SharedRegion, StringComparison.OrdinalIgnoreCase)
            || value.Equals("en_us", StringComparison.OrdinalIgnoreCase)
            || value.Equals("en-us", StringComparison.OrdinalIgnoreCase))
            return SharedRegion;
        return _localePattern.IsMatch(value) ? value.Replace('-', '_').ToLowerInvariant() : null;
    }

    /// <summary>Loads the data of the last synchronisation from disk. Fast, no network.</summary>
    public void LoadFromDisk()
    {
        _data = ReadJson<Data>(AssetPaths.DataFile) ?? new Data();
        _info = ReadJson<Info>(AssetPaths.InfoFile) ?? new Info();
        _info.Region = NormalizeRegion(_info.Region) ?? DefaultRegion;
        _info.ManualPatches ??= [];
        MergeDuplicatedPatches(_data);

        _current = FindIndex(_data, _info.PinnedShortPatch ?? _info.ShortPatch, _info.Region)
                   ?? _data.Patchs.AsEnumerable().Reverse()
                       .Select(patch => FindIndex(_data, patch.ShortNumber, _info.Region))
                       .FirstOrDefault(index => index is not null);

        // The patch chosen by the user no longer exists on disk: back to the automatic mode.
        if (_info.PinnedShortPatch is not null && _current?.Patch.ShortNumber != _info.PinnedShortPatch)
            _info.PinnedShortPatch = null;
        RefreshInstalled();

        _logger.Log(LoggingLevel.INFO, nameof(LoadFromDisk),
            _current is null ? "No asset available on disk yet" : $"Assets of patch {_current.Patch.ShortNumber} ({_info.Region}) loaded");
    }

    /// <summary>
    /// Synchronous version kept for compatibility. Blocks until everything is downloaded: prefer
    /// <see cref="LoadFromDisk"/> + <see cref="UpdateAsync"/> in a background service.
    /// </summary>
    [Obsolete("Use LoadFromDisk() and UpdateAsync() in a background service.")]
    public void DownloadLatestAssets()
    {
        LoadFromDisk();
        UpdateAsync().GetAwaiter().GetResult();
    }

    /// <summary>
    /// Checks the latest patch and downloads what is missing. Safe to call several times (calls are serialised),
    /// resumable (files already on disk are skipped) and never throws, except when cancelled.
    /// </summary>
    public async Task UpdateAsync(CancellationToken cancellationToken = default)
    {
        await _updateLock.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_current is null && _data.Patchs.Count == 0)
                LoadFromDisk();

            Report(AssetSyncState.Checking, "Checking the latest patch...", force: true);

            (string Patch, string ShortPatch)? target = await ResolveTargetPatchAsync(cancellationToken).ConfigureAwait(false);
            if (target is null)
            {
                Report(_current is null ? AssetSyncState.Failed : AssetSyncState.Ready,
                    _current is null ? "No patch information available and no asset on disk" : "Offline: using the assets already on disk",
                    force: true);
                return;
            }

            await SyncStaticAssetsAsync(cancellationToken).ConfigureAwait(false);
            bool regionOk = await SyncRegionAsync(target.Value.Patch, target.Value.ShortPatch, cancellationToken).ConfigureAwait(false);

            SaveAll();
            PurgeOldPatches(target.Value.ShortPatch);
            SaveAll();

            Report(regionOk ? AssetSyncState.Ready : AssetSyncState.Failed,
                regionOk ? "Assets are up to date" : "Some assets could not be downloaded, they will be retried at the next start",
                force: true);
        }
        catch (OperationCanceledException)
        {
            Report(AssetSyncState.Idle, "Synchronisation cancelled", force: true);
            throw;
        }
        catch (Exception ex)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(UpdateAsync), $"Synchronisation failed : {ex}");
            Report(AssetSyncState.Failed, ex.Message, force: true);
        }
        finally
        {
            _updateLock.Release();
        }
    }

    /// <summary>
    /// Finds the patch to serve: the latest one when CommunityDragon answers, otherwise (offline)
    /// the patch already served, so the overlay keeps working without Internet.
    /// </summary>
    private async Task<(string Patch, string ShortPatch)?> ResolveTargetPatchAsync(CancellationToken cancellationToken)
    {
        FetchedText fetched = await _downloader
            .GetStringAsync(new Uri("https://raw.communitydragon.org/latest/content-metadata.json"), cancellationToken)
            .ConfigureAwait(false);

        if (fetched.Content is not null)
        {
            try
            {
                string? version = JsonConvert.DeserializeObject<Dto.ContentMetadata>(fetched.Content).Version;
                string[]? parts = version?.Split('.');
                if (version is not null && parts is { Length: >= 2 })
                {
                    _logger.Log(LoggingLevel.INFO, nameof(ResolveTargetPatchAsync), $"Latest patch is {version}");
                    return (version, $"{parts[0]}.{parts[1]}");
                }

                _logger.Log(LoggingLevel.ERROR, nameof(ResolveTargetPatchAsync), $"Unexpected content-metadata : {fetched.Content}");
            }
            catch (JsonException ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(ResolveTargetPatchAsync), $"content-metadata is not valid : {ex.Message}");
            }
        }

        if (_current is { } current)
        {
            _logger.Log(LoggingLevel.WARN, nameof(ResolveTargetPatchAsync), $"Latest patch unknown, keeping patch {current.Patch.ShortNumber}");
            return null;
        }

        return null;
    }

    private async Task SyncStaticAssetsAsync(CancellationToken cancellationToken)
    {
        Report(AssetSyncState.Downloading, "Downloading positions, epic monsters, fonts and bans...");

        StaticAssetsResult result = await StaticAssets
            .SyncAsync(_downloader, _data, _info.MaxParallelDownloads, (done, total) => Report(AssetSyncState.Downloading, "Downloading static assets...", done, total), cancellationToken)
            .ConfigureAwait(false);

        // A null member means "no usable definition": the previous data is kept.
        _data.Positions = result.Positions ?? _data.Positions;
        _data.EpicMonsters = result.EpicMonsters ?? _data.EpicMonsters;
        _data.Fonts = result.Fonts ?? _data.Fonts;
        _data.Bans = result.Bans ?? _data.Bans;

        SaveAll();
        RaiseUpdated();
    }

    /// <returns>True when the region is complete (nothing failed for a transient reason).</returns>
    private async Task<bool> SyncRegionAsync(string patch, string shortPatch, CancellationToken cancellationToken, string? requestedRegion = null)
    {
        // A region asked by hand (download of an older patch) is never replaced by a fallback and never becomes the latest patch.
        bool manual = requestedRegion is not null;
        string region = requestedRegion ?? _info.Region;
        Region? existing = _data.Patchs.FirstOrDefault(p => p.ShortNumber == shortPatch)?.Regions.FirstOrDefault(r => r.Name == region);

        if (existing is { IsComplete: true } && Directory.Exists($"{AssetPaths.Root}/{shortPatch}"))
        {
            _logger.Log(LoggingLevel.INFO, nameof(SyncRegionAsync), $"Patch {shortPatch} ({region}) already complete");
            SwitchTo(patch, shortPatch, existing, isLatest: !manual);
            return true;
        }

        _logger.Log(LoggingLevel.INFO, nameof(SyncRegionAsync), $"Synchronising patch {shortPatch} ({region})");
        Report(AssetSyncState.Downloading, $"Reading the catalogs of patch {shortPatch}...", force: true);

        var context = new SyncContext(_downloader, _info, shortPatch, region, cancellationToken);

        // The four catalogs are independent: read them at the same time.
        Task<List<Champion>> championsTask = Champions.PlanAsync(context);
        Task<List<Item>> itemsTask = Items.PlanAsync(context);
        Task<List<Perk>> perksTask = Perks.PlanAsync(context);
        Task<List<SummonerSpell>> spellsTask = SummonerSpells.PlanAsync(context);
        await Task.WhenAll(championsTask, itemsTask, perksTask, spellsTask).ConfigureAwait(false);

        var newRegion = new Region(region)
        {
            Champions = championsTask.Result,
            Items = itemsTask.Result,
            Perks = perksTask.Result,
            SummonerSpells = spellsTask.Result,
        };

        IReadOnlyCollection<AssetJob> jobs = context.Jobs;
        _logger.Log(LoggingLevel.INFO, nameof(SyncRegionAsync), $"{jobs.Count} files to check");

        DownloadSummary summary = await _downloader
            .DownloadAllAsync(jobs, context.MaxParallelism, (done, total) => Report(AssetSyncState.Downloading, $"Downloading assets of patch {shortPatch}...", done, total), cancellationToken)
            .ConfigureAwait(false);

        // A file that does not exist on the server (404) is final; a network failure must be retried at the next start.
        Champions.VerifyFiles(newRegion.Champions);
        Items.VerifyFiles(newRegion.Items);
        Perks.VerifyFiles(newRegion.Perks);
        SummonerSpells.VerifyFiles(newRegion.SummonerSpells);
        newRegion.IsComplete = newRegion.Champions.Count > 0 && summary.Failed == 0 && context.TransientFailures == 0;

        // The region folder does not exist on CommunityDragon (not a network problem): fall back instead of failing forever.
        if (!manual && newRegion.Champions.Count == 0 && context.TransientFailures == 0)
        {
            string fallback = _current?.Region.Name ?? DefaultRegion;
            if (!string.Equals(fallback, region, StringComparison.Ordinal))
            {
                _logger.Log(LoggingLevel.WARN, nameof(SyncRegionAsync), $"Region {region} is not available for patch {shortPatch}, falling back to {fallback}");
                if (string.Equals(_info.Region, region, StringComparison.Ordinal))
                    _info.Region = fallback;
                return await SyncRegionAsync(patch, shortPatch, cancellationToken).ConfigureAwait(false);
            }
        }

        // Never replace a working data set by an empty one.
        if (newRegion.Champions.Count == 0 && (manual || _current is not null))
        {
            _logger.Log(LoggingLevel.ERROR, nameof(SyncRegionAsync), "No champion available for the new patch, previous data kept");
            return false;
        }

        SwitchTo(patch, shortPatch, newRegion, isLatest: !manual);
        return newRegion.IsComplete;
    }

    /// <summary>Stores the region in the data and makes it the one served to readers.</summary>
    private void SwitchTo(string patch, string shortPatch, Region region, bool isLatest = true)
    {
        Patch? entry = _data.Patchs.FirstOrDefault(p => p.ShortNumber == shortPatch);
        if (entry is null)
        {
            entry = new Patch(patch, shortPatch);
            _data.Patchs.Add(entry);
        }

        entry.Number = patch;
        entry.Regions.RemoveAll(r => r.Name == region.Name);
        entry.Regions.Add(region);

        // An older patch downloaded by hand must not look like the latest one.
        if (isLatest)
        {
            _info.Patch = patch;
            _info.ShortPatch = shortPatch;
            _info.IsLatest = true;
            _info.AssetsDir = $"{AssetPaths.Root}/{shortPatch}/{region.Name}";
            _info.Date = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
        }

        // The region may have been changed while this one was downloading: only serve it if it is still the requested one
        // (or if nothing is served yet: images are shared by all regions, so it is better than nothing).
        // A patch pinned by the user is never replaced by a newer one.
        bool followsLatest = isLatest && (_info.PinnedShortPatch is null || _info.PinnedShortPatch == shortPatch);
        bool reloadsServed = _current is { } served && served.Patch.ShortNumber == shortPatch && served.Region.Name == region.Name;
        if (_current is null || reloadsServed || (followsLatest && string.Equals(region.Name, _info.Region, StringComparison.Ordinal)))
            _current = new RegionIndex(entry, region);

        SaveAll();
        RaiseUpdated();
    }

    /// <summary>Deletes the oldest patches from disk, keeping <see cref="Info.RetainedPatches"/> (the served one included).</summary>
    private void PurgeOldPatches(string currentShortPatch)
    {
        int retained = _info.RetainedPatches;
        if (retained <= 0)
            return;

        // The most recent patches by version number (a patch downloaded by hand is not necessarily the last one added).
        var keep = _data.Patchs.OrderByDescending(patch => ParsePatch(patch.ShortNumber)).Take(retained).Select(patch => patch.ShortNumber).ToHashSet();
        keep.Add(currentShortPatch);
        keep.UnionWith(_info.ManualPatches);
        if (_info.PinnedShortPatch is not null)
            keep.Add(_info.PinnedShortPatch);

        foreach (Patch patch in _data.Patchs.Where(patch => !keep.Contains(patch.ShortNumber)).ToList())
        {
            // The name comes from a file: never trust it to build a path to delete.
            if (!_safeDirectoryName.IsMatch(patch.ShortNumber) || patch.ShortNumber is "." or "..")
            {
                _logger.Log(LoggingLevel.WARN, nameof(PurgeOldPatches), $"Patch '{patch.ShortNumber}' has an unsafe name, directory not deleted");
                _data.Patchs.Remove(patch);
                continue;
            }

            try
            {
                string directory = $"{AssetPaths.Root}/{patch.ShortNumber}";
                if (Directory.Exists(directory))
                    Directory.Delete(directory, recursive: true);

                _data.Patchs.Remove(patch);
                _logger.Log(LoggingLevel.INFO, nameof(PurgeOldPatches), $"Old patch {patch.ShortNumber} removed");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // Kept in the data: it will be retried at the next start.
                _logger.Log(LoggingLevel.WARN, nameof(PurgeOldPatches), $"Old patch {patch.ShortNumber} not removed : {ex.Message}");
            }
        }
    }

    private void SaveAll()
    {
        // SetRegion can be called while a synchronisation saves: never write the same temporary file twice at once.
        lock (_saveLock)
        {
            AssetPaths.WriteTextAtomic(AssetPaths.DataFile, JsonConvert.SerializeObject(_data, Formatting.Indented));
            AssetPaths.WriteTextAtomic(AssetPaths.InfoFile, JsonConvert.SerializeObject(_info, Formatting.Indented));
            RefreshInstalled();
        }
    }

    private static T? ReadJson<T>(string path) where T : class
    {
        string? json = AssetPaths.ReadTextOrNull(path);
        if (json is null)
            return null;

        try
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (JsonException ex)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(ReadJson), $"{path} is not valid and is ignored : {ex.Message}");
            return null;
        }
    }

    /// <summary>Older versions could create the same patch several times: merge them, keeping the fullest region.</summary>
    private static void MergeDuplicatedPatches(Data data)
    {
        if (data.Patchs.Select(patch => patch.ShortNumber).Distinct().Count() == data.Patchs.Count)
            return;

        var merged = new List<Patch>();
        foreach (Patch patch in data.Patchs)
        {
            Patch? target = merged.FirstOrDefault(p => p.ShortNumber == patch.ShortNumber);
            if (target is null)
            {
                merged.Add(patch);
                continue;
            }

            foreach (Region region in patch.Regions)
            {
                int index = target.Regions.FindIndex(r => r.Name == region.Name);
                if (index < 0)
                    target.Regions.Add(region);
                else if (region.Champions.Count > target.Regions[index].Champions.Count)
                    target.Regions[index] = region;
            }
        }

        data.Patchs = merged;
    }

    private static RegionIndex? FindIndex(Data data, string shortPatch, string region)
    {
        Patch? patch = data.Patchs.FirstOrDefault(p => p.ShortNumber == shortPatch);
        Region? found = patch?.Regions.FirstOrDefault(r => r.Name == region);
        return patch is null || found is null || found.Champions.Count == 0 ? null : new RegionIndex(patch, found);
    }

    private void Report(AssetSyncState state, string message, int completed = 0, int total = 0, bool force = false)
    {
        var status = new AssetSyncStatus(state, message, completed, total);
        _status = status;

        long now = Environment.TickCount64;
        long last = Volatile.Read(ref _lastStatusRaise);
        bool raise = force || (now - last >= 200 && Interlocked.CompareExchange(ref _lastStatusRaise, now, last) == last);
        if (!raise)
            return;

        if (force)
            Volatile.Write(ref _lastStatusRaise, now);

        Raise(StatusChanged, handler => handler(status), nameof(StatusChanged));
    }

    private void RaiseUpdated() => Raise(Updated, handler => handler(), nameof(Updated));

    private void RaiseUpdateRequested() => Raise(UpdateRequested, handler => handler(), nameof(UpdateRequested));

    /// <summary>Invokes every handler separately: a handler that throws must not prevent the next ones from running.</summary>
    private static void Raise<THandler>(THandler? multicast, Action<THandler> invoke, string eventName) where THandler : Delegate
    {
        if (multicast is null)
            return;
        foreach (Delegate delegateHandler in multicast.GetInvocationList())
        {
            try
            {
                invoke((THandler)delegateHandler);
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(Raise), $"A {eventName} handler failed : {ex}");
            }
        }
    }

    /// <summary>Immutable-by-convention view of the served region, indexed for O(1) lookups.</summary>
    private sealed class RegionIndex
    {
        public RegionIndex(Patch patch, Region region)
        {
            Patch = patch;
            Region = region;
            Champions = BuildMap(region.Champions, champion => champion.Id);
            Items = BuildMap(region.Items, item => item.Id);
            SummonerSpells = BuildMap(region.SummonerSpells, spell => spell.Id);
            Perks = BuildMap(region.Perks, perk => perk.Id);
        }

        public Patch Patch { get; }
        public Region Region { get; }
        public Dictionary<int, Champion> Champions { get; }
        public Dictionary<int, Item> Items { get; }
        public Dictionary<uint, SummonerSpell> SummonerSpells { get; }
        public Dictionary<int, Perk> Perks { get; }

        // First entry wins on duplicates, like the former FirstOrDefault.
        private static Dictionary<TKey, TValue> BuildMap<TKey, TValue>(IEnumerable<TValue> values, Func<TValue, TKey> key) where TKey : notnull
        {
            var map = new Dictionary<TKey, TValue>();
            foreach (TValue value in values)
                map.TryAdd(key(value), value);
            return map;
        }
    }
}
