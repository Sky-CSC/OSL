using OSL_CDragon;
using Logger = OSL_Utils.Logger;
using LoggingLevel = OSL_Utils.LoggingLevel;

namespace OSL_Overlay.Services;

/// <summary>
/// Keeps the CommunityDragon assets up to date in the background so the application starts immediately,
/// even on the first launch or when a new patch has to be downloaded.
/// It also runs again when the region changes (message received from the server).
/// </summary>
public sealed class AssetUpdateService(CDragon cdragon) : BackgroundService
{
    private static readonly Logger _logger = new("AssetUpdateService");

    /// <summary>Waits a little before synchronising so several requests in a row (reconnection replays) are merged.</summary>
    private static readonly TimeSpan _debounce = TimeSpan.FromMilliseconds(500);
    private readonly SemaphoreSlim _requests = new(0, 1);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Never delay the start of the host.
        await Task.Yield();

        cdragon.UpdateRequested += OnUpdateRequested;
        try
        {
            await RunUpdateAsync(stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                await _requests.WaitAsync(stoppingToken);
                await Task.Delay(_debounce, stoppingToken);
                // Requests received during the delay are covered by the update that starts now.
                _requests.Wait(0, CancellationToken.None);
                await RunUpdateAsync(stoppingToken);
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Application is stopping.
        }
        finally
        {
            cdragon.UpdateRequested -= OnUpdateRequested;
        }
    }
    private void OnUpdateRequested()
    {
        // The semaphore holds at most one pending request.
        try
        {
            _requests.Release();
        }
        catch (SemaphoreFullException)
        {
            // A request is already pending.
        }
    }
    private async Task RunUpdateAsync(CancellationToken cancellationToken)
    {
        try
        {
            await cdragon.UpdateAsync(cancellationToken);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception ex)
        {
            // An unhandled exception in a BackgroundService would stop the whole application.
            _logger.Log(LoggingLevel.ERROR, nameof(RunUpdateAsync), $"Asset update failed : {ex}");
        }
    }
}
