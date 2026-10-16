using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using OSL_CDragon.Schema;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

/// <summary>Result of a static assets synchronisation. A null member means "no usable definition: keep the previous data".</summary>
internal sealed record StaticAssetsResult(
    Position? Positions,
    EpicMonster? EpicMonsters,
    List<Asset>? Fonts,
    List<Asset>? Bans,
    bool HasFailures);

/// <summary>
/// Downloads the assets that do not depend on a patch or a region (position icons, epic monsters, fonts, bans).
/// Definitions come from the OSL server AND from the local EndpointsJson files; either source alone is enough.
/// </summary>
internal static class StaticAssets
{
    private static readonly Logger _logger = new("StaticAssets");

    private const string ServerBaseUrl = "https://asset.osl.sky-csc.fr";

    internal static async Task<StaticAssetsResult> SyncAsync(
        AssetDownloader downloader,
        Data previous,
        int maxParallelism,
        Action<int, int>? onProgress,
        CancellationToken cancellationToken)
    {
        // 1. Definitions (4 small JSON files, in parallel).
        var positionsTask = LoadDefinitionsAsync(downloader, "positions/positions.json", "position.json", cancellationToken);
        var epicTask = LoadDefinitionsAsync(downloader, "epicmonsters/epicmonsters.json", "epicmonster.json", cancellationToken);
        var fontsTask = LoadDefinitionsAsync(downloader, "fonts/fonts.json", "font.json", cancellationToken);
        var bansTask = LoadDefinitionsAsync(downloader, "bans/bans.json", "ban.json", cancellationToken);
        await Task.WhenAll(positionsTask, epicTask, fontsTask, bansTask).ConfigureAwait(false);

        // 2. Plan: a stable id per destination (never regenerated at each run).
        Dictionary<string, string> knownIds = CollectKnownIds(previous);
        var jobs = new Dictionary<string, AssetJob>(StringComparer.Ordinal);

        List<Asset>? positions = Plan(positionsTask.Result, knownIds, jobs);
        List<Asset>? epicMonsters = Plan(epicTask.Result, knownIds, jobs);
        List<Asset>? fonts = Plan(fontsTask.Result, knownIds, jobs);
        List<Asset>? bans = Plan(bansTask.Result, knownIds, jobs);

        // 3. Download.
        DownloadSummary summary = await downloader
            .DownloadAllAsync(jobs.Values.ToArray(), maxParallelism, onProgress, cancellationToken)
            .ConfigureAwait(false);

        // 4. Keep only what is on disk, then classify.
        return new StaticAssetsResult(
            positions is null ? null : ClassifyPositions(OnDisk(positions)),
            epicMonsters is null ? null : ClassifyEpicMonsters(OnDisk(epicMonsters)),
            fonts is null ? null : OnDisk(fonts),
            bans is null ? null : OnDisk(bans),
            summary.Failed > 0);
    }

    private static async Task<List<Asset>?> LoadDefinitionsAsync(
        AssetDownloader downloader, string serverPath, string localFileName, CancellationToken cancellationToken)
    {
        var definitions = new List<Asset>();
        bool found = false;

        FetchedText server = await downloader.GetStringAsync(new Uri($"{ServerBaseUrl}/{serverPath}"), cancellationToken).ConfigureAwait(false);
        if (Parse(server.Content, serverPath) is { } fromServer)
        {
            definitions.AddRange(fromServer);
            found = true;
        }
        else
        {
            _logger.Log(LoggingLevel.WARN, nameof(LoadDefinitionsAsync), $"{serverPath} not available on the server, using local definitions only");
        }

        string localPath = $"{AssetPaths.EndpointsDirectory}/{localFileName}";
        if (Parse(AssetPaths.ReadTextOrNull(localPath), localPath) is { } fromLocal)
        {
            definitions.AddRange(fromLocal);
            found = true;
        }

        return found && definitions.Count > 0 ? definitions : null;
    }

    private static List<Asset>? Parse(string? json, string source)
    {
        if (string.IsNullOrWhiteSpace(json))
            return null;

        try
        {
            return JsonConvert.DeserializeObject<List<Asset>>(json);
        }
        catch (JsonException ex)
        {
            _logger.Log(LoggingLevel.ERROR, nameof(Parse), $"{source} is not valid : {ex.Message}");
            return null;
        }
    }

    /// <summary>Turns definitions into assets with a final destination, and registers the downloads (a local definition overrides a server one).</summary>
    private static List<Asset>? Plan(List<Asset>? definitions, Dictionary<string, string> knownIds, Dictionary<string, AssetJob> jobs)
    {
        if (definitions is null)
            return null;

        var byDestination = new Dictionary<string, Asset>(StringComparer.Ordinal);
        foreach (Asset definition in definitions)
        {
            if (string.IsNullOrWhiteSpace(definition.Path) || definition.Url is null)
            {
                _logger.Log(LoggingLevel.WARN, nameof(Plan), $"Asset '{definition.Name}' ignored: Path or Url missing");
                continue;
            }

            string destination = $"{AssetPaths.Root}/{AssetPaths.DirectoryOf(definition.Path)}/{definition.Name}{Path.GetExtension(definition.Path)}";
            string id = !string.IsNullOrEmpty(definition.Id)
                ? definition.Id
                : knownIds.TryGetValue(destination, out string? known) ? known : StableId(destination);

            byDestination[destination] = new Asset(id, definition.Name, definition.Description, definition.Url, destination, definition.Type ?? []);
            jobs[destination] = new AssetJob(definition.Url, destination);
        }

        return [.. byDestination.Values];
    }

    private static List<Asset> OnDisk(List<Asset> assets) => assets.Where(asset => AssetPaths.IsValidFile(asset.Path)).ToList();

    private static Position ClassifyPositions(List<Asset> assets)
    {
        var positions = new Position();
        var targets = new Dictionary<string, List<Asset>>(StringComparer.OrdinalIgnoreCase)
        {
            ["top"] = positions.TopPath,
            ["jungle"] = positions.JunglePath,
            ["mid"] = positions.MiddlePath,
            ["adc"] = positions.AdcPath,
            ["support"] = positions.SupportPath,
        };
        Distribute(assets, targets);
        return positions;
    }

    private static EpicMonster ClassifyEpicMonsters(List<Asset> assets)
    {
        var monsters = new EpicMonster();
        var dragons = monsters.Dragons;
        var targets = new Dictionary<string, List<Asset>>(StringComparer.OrdinalIgnoreCase)
        {
            ["chemtech"] = dragons.Chemtech,
            ["cloud"] = dragons.Cloud,
            ["hextech"] = dragons.Hextech,
            ["infernal"] = dragons.Infernal,
            ["mountain"] = dragons.Mountain,
            ["ocean"] = dragons.Ocean,
            ["elder"] = dragons.Elder,
            ["herald"] = monsters.Heralds,
            ["voidgrub"] = monsters.VoidGrubs,
            ["baron"] = monsters.Barons,
            ["atakhan"] = monsters.Atakhans,
        };
        Distribute(assets, targets);
        return monsters;
    }

    /// <summary>Puts each asset in the list matching one of its directory names ("epicmonsters/dragons/cloud" => cloud).</summary>
    private static void Distribute(List<Asset> assets, Dictionary<string, List<Asset>> targets)
    {
        foreach (Asset asset in assets)
        {
            string[] segments = AssetPaths.DirectoryOf(asset.Path).Split('/');
            List<Asset>? target = segments.Reverse().Select(segment => targets.GetValueOrDefault(segment)).FirstOrDefault(list => list is not null);

            if (target is null)
                _logger.Log(LoggingLevel.WARN, nameof(Distribute), $"Asset {asset.Path} does not match any known category");
            else
                target.Add(asset);
        }
    }

    private static Dictionary<string, string> CollectKnownIds(Data data)
    {
        IEnumerable<Asset> all = data.Positions.TopPath
            .Concat(data.Positions.JunglePath).Concat(data.Positions.MiddlePath)
            .Concat(data.Positions.AdcPath).Concat(data.Positions.SupportPath)
            .Concat(data.EpicMonsters.Barons).Concat(data.EpicMonsters.Heralds)
            .Concat(data.EpicMonsters.VoidGrubs).Concat(data.EpicMonsters.Atakhans)
            .Concat(data.EpicMonsters.Dragons.Chemtech).Concat(data.EpicMonsters.Dragons.Cloud)
            .Concat(data.EpicMonsters.Dragons.Elder).Concat(data.EpicMonsters.Dragons.Hextech)
            .Concat(data.EpicMonsters.Dragons.Infernal).Concat(data.EpicMonsters.Dragons.Mountain)
            .Concat(data.EpicMonsters.Dragons.Ocean)
            .Concat(data.Fonts).Concat(data.Bans);

        var ids = new Dictionary<string, string>(StringComparer.Ordinal);
        foreach (Asset asset in all.Where(asset => !string.IsNullOrEmpty(asset.Path) && !string.IsNullOrEmpty(asset.Id)))
            ids.TryAdd(asset.Path, asset.Id);
        return ids;
    }

    private static string StableId(string destination) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(destination)))[..10].ToLowerInvariant();
}
