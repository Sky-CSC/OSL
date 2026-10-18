using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_Overlay.Services;

/// <summary>
/// Removes the old images of <c>wwwroot/temp</c>. An image chosen in a page is copied there first, and copied
/// again next to the team file when the team is saved: what stays in this folder is never used again.
/// </summary>
public sealed class TempCleanupService : BackgroundService
{
    private static readonly Logger _logger = new("TempCleanupService");

    private static readonly string _directory = Path.Combine("./wwwroot", "temp");

    /// <summary>A file this old is no longer needed.</summary>
    private static readonly TimeSpan _maxAge = TimeSpan.FromDays(7);

    private static readonly TimeSpan _period = TimeSpan.FromHours(24);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Never delay the start of the host.
        await Task.Yield();

        using var timer = new PeriodicTimer(_period);
        do
        {
            Cleanup();
        }
        while (await WaitNextAsync(timer, stoppingToken));
    }

    private static async Task<bool> WaitNextAsync(PeriodicTimer timer, CancellationToken stoppingToken)
    {
        try
        {
            return await timer.WaitForNextTickAsync(stoppingToken);
        }
        catch (OperationCanceledException)
        {
            return false;
        }
    }

    private static void Cleanup()
    {
        if (!Directory.Exists(_directory))
            return;

        int deleted = 0;
        foreach (string file in Directory.EnumerateFiles(_directory))
        {
            try
            {
                if (DateTime.UtcNow - File.GetLastWriteTimeUtc(file) < _maxAge)
                    continue;

                File.Delete(file);
                deleted++;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // In use or protected: it will be tried again at the next cleanup
                _logger.Log(LoggingLevel.WARN, nameof(Cleanup), $"{file} not deleted : {ex.Message}");
            }
        }

        if (deleted > 0)
            _logger.Log(LoggingLevel.INFO, nameof(Cleanup), $"{deleted} old temporary image(s) deleted");
    }
}
