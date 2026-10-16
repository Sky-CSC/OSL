namespace OSL_CDragon;

public enum AssetSyncState
{
    Idle,
    Checking,
    Downloading,
    Ready,
    Failed,
}

/// <summary>Immutable snapshot of the synchronisation progress, safe to read from any thread.</summary>
public sealed record AssetSyncStatus(AssetSyncState State, string Message, int Completed, int Total)
{
    public static AssetSyncStatus Idle { get; } = new(AssetSyncState.Idle, string.Empty, 0, 0);

    public bool IsBusy => State is AssetSyncState.Checking or AssetSyncState.Downloading;

    /// <summary>Progress between 0 and 100 (0 when the total is not known yet).</summary>
    public double Percent => Total > 0 ? Math.Round(100.0 * Completed / Total, 1) : 0;
}
