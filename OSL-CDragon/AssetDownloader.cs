using System.Net;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_CDragon;

internal readonly record struct AssetJob(Uri Url, string Destination);

internal enum DownloadResult
{
    /// <summary>The file was already on disk, nothing was done.</summary>
    Existing,
    /// <summary>The file has been downloaded.</summary>
    Downloaded,
    /// <summary>The server answered 404/403/410: retrying is pointless.</summary>
    NotFound,
    /// <summary>Network or server failure after all retries: the next run should try again.</summary>
    Failed,
}

internal readonly record struct FetchedText(string? Content, DownloadResult Result);

internal sealed class DownloadSummary(int total)
{
    private int _existing;
    private int _downloaded;
    private int _notFound;
    private int _failed;

    public int Total { get; } = total;
    public int Existing => _existing;
    public int Downloaded => _downloaded;
    public int NotFound => _notFound;
    public int Failed => _failed;

    internal void Add(DownloadResult result)
    {
        switch (result)
        {
            case DownloadResult.Existing: Interlocked.Increment(ref _existing); break;
            case DownloadResult.Downloaded: Interlocked.Increment(ref _downloaded); break;
            case DownloadResult.NotFound: Interlocked.Increment(ref _notFound); break;
            default: Interlocked.Increment(ref _failed); break;
        }
    }

    public override string ToString() =>
        $"{Total} files: {Downloaded} downloaded, {Existing} already present, {NotFound} not found, {Failed} failed";
}

/// <summary>
/// Downloads text and files with retries, atomic writes and bounded parallelism.
/// One shared <see cref="HttpClient"/> is used for the whole application (no socket exhaustion).
/// </summary>
internal sealed class AssetDownloader(HttpClient http)
{
    private static readonly Logger _logger = new("AssetDownloader");

    private const int MaxAttempts = 3;
    private static readonly TimeSpan MaxRetryAfter = TimeSpan.FromSeconds(10);

    private static readonly Lazy<AssetDownloader> _shared = new(() => new AssetDownloader(CreateHttpClient()));

    public static AssetDownloader Shared => _shared.Value;

    public static HttpClient CreateHttpClient()
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5),
            AutomaticDecompression = DecompressionMethods.All,
            ConnectTimeout = TimeSpan.FromSeconds(10),
            MaxConnectionsPerServer = 16,
        };

        var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(60) };
        client.DefaultRequestHeaders.UserAgent.ParseAdd("OSL-CDragon/1.0");
        return client;
    }

    public async Task<FetchedText> GetStringAsync(Uri url, CancellationToken cancellationToken)
    {
        var (response, failure) = await SendAsync(url, cancellationToken).ConfigureAwait(false);
        if (response is null)
            return new FetchedText(null, failure);

        using (response)
        {
            try
            {
                string content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                return new FetchedText(content, DownloadResult.Downloaded);
            }
            catch (Exception ex) when (IsNetworkError(ex, cancellationToken))
            {
                _logger.Log(LoggingLevel.WARN, nameof(GetStringAsync), $"{url} could not be read : {ex.Message}");
                return new FetchedText(null, DownloadResult.Failed);
            }
        }
    }

    /// <summary>Downloads <paramref name="url"/> to <paramref name="destination"/> unless a non-empty file is already there.</summary>
    public async Task<DownloadResult> EnsureFileAsync(Uri url, string destination, CancellationToken cancellationToken)
    {
        if (AssetPaths.IsValidFile(destination))
            return DownloadResult.Existing;

        var (response, failure) = await SendAsync(url, cancellationToken).ConfigureAwait(false);
        if (response is null)
            return failure;

        string temporaryPath = destination + ".part";
        try
        {
            using (response)
            {
                string? directory = Path.GetDirectoryName(destination);
                if (!string.IsNullOrEmpty(directory))
                    Directory.CreateDirectory(directory);

                await using Stream source = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                await using var target = new FileStream(temporaryPath, FileMode.Create, FileAccess.Write, FileShare.None, 81920, useAsync: true);
                await source.CopyToAsync(target, cancellationToken).ConfigureAwait(false);
            }

            if (new FileInfo(temporaryPath).Length == 0)
            {
                File.Delete(temporaryPath);
                _logger.Log(LoggingLevel.WARN, nameof(EnsureFileAsync), $"{url} returned an empty file");
                return DownloadResult.Failed;
            }

            File.Move(temporaryPath, destination, overwrite: true);
            return DownloadResult.Downloaded;
        }
        catch (Exception ex) when (IsNetworkError(ex, cancellationToken) || ex is UnauthorizedAccessException)
        {
            TryDelete(temporaryPath);
            _logger.Log(LoggingLevel.WARN, nameof(EnsureFileAsync), $"{url} not saved to {destination} : {ex.Message}");
            return DownloadResult.Failed;
        }
    }

    /// <summary>Runs all jobs with at most <paramref name="maxParallelism"/> concurrent downloads.</summary>
    public async Task<DownloadSummary> DownloadAllAsync(
        IReadOnlyCollection<AssetJob> jobs,
        int maxParallelism,
        Action<int, int>? onProgress,
        CancellationToken cancellationToken)
    {
        var summary = new DownloadSummary(jobs.Count);
        int completed = 0;

        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = Math.Clamp(maxParallelism, 1, 32),
            CancellationToken = cancellationToken,
        };

        await Parallel.ForEachAsync(jobs, options, async (job, token) =>
        {
            DownloadResult result = await EnsureFileAsync(job.Url, job.Destination, token).ConfigureAwait(false);
            summary.Add(result);
            onProgress?.Invoke(Interlocked.Increment(ref completed), jobs.Count);
        }).ConfigureAwait(false);

        _logger.Log(LoggingLevel.INFO, nameof(DownloadAllAsync), summary.ToString());
        return summary;
    }

    /// <summary>Sends a GET and returns the successful response (to dispose by the caller) or the kind of failure.</summary>
    private async Task<(HttpResponseMessage? Response, DownloadResult Failure)> SendAsync(Uri url, CancellationToken cancellationToken)
    {
        for (int attempt = 1; ; attempt++)
        {
            TimeSpan? retryAfter = null;
            try
            {
                HttpResponseMessage response = await http
                    .GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                    return (response, DownloadResult.Downloaded);

                HttpStatusCode status = response.StatusCode;
                retryAfter = response.Headers.RetryAfter?.Delta;
                response.Dispose();

                if (status is HttpStatusCode.NotFound or HttpStatusCode.Forbidden or HttpStatusCode.Gone)
                {
                    _logger.Log(LoggingLevel.DEBUG, nameof(SendAsync), $"{url} not found ({(int)status})");
                    return (null, DownloadResult.NotFound);
                }

                if (!IsTransient(status) || attempt >= MaxAttempts)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(SendAsync), $"{url} failed with {(int)status}");
                    return (null, DownloadResult.Failed);
                }
            }
            catch (Exception ex) when (IsNetworkError(ex, cancellationToken))
            {
                if (attempt >= MaxAttempts)
                {
                    _logger.Log(LoggingLevel.WARN, nameof(SendAsync), $"{url} failed after {attempt} attempts : {ex.Message}");
                    return (null, DownloadResult.Failed);
                }
            }

            TimeSpan delay = retryAfter is { } wanted && wanted > TimeSpan.Zero
                ? (wanted < MaxRetryAfter ? wanted : MaxRetryAfter)
                : Backoff(attempt);
            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
    }

    private static bool IsTransient(HttpStatusCode status) =>
        status is HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests || (int)status >= 500;

    /// <summary>
    /// True for failures worth a retry/handling (network, timeout, disk), false for a cancellation requested by the caller.
    /// A timeout surfaces as TaskCanceledException while the caller's token is NOT cancelled.
    /// </summary>
    private static bool IsNetworkError(Exception ex, CancellationToken cancellationToken) =>
        !cancellationToken.IsCancellationRequested
        && ex is HttpRequestException or IOException or TaskCanceledException;

    private static TimeSpan Backoff(int attempt) =>
        TimeSpan.FromMilliseconds(500 * Math.Pow(3, attempt - 1) + Random.Shared.Next(0, 250));

    private static void TryDelete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (IOException)
        {
            // Best effort cleanup of a temporary file.
        }
    }
}
