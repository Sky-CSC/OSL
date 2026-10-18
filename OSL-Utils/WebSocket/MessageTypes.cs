namespace OSL_Utils.WebSocket;

/// <summary>
/// Types of the messages exchanged between OSL-Server and OSL-Overlay (the "type" field of <see cref="WebSocketMessage"/>).
/// Server and client must use these constants instead of string literals.
/// </summary>
public static class MessageTypes
{
    // Protocol
    public const string Auth = "auth";
    public const string AuthOk = "auth_ok";
    public const string Skynet = "skynet";

    // Server => clients (state of the League client, replayed to a client when it connects)
    public const string RegionLocale = "regionLocale";
    public const string GameFlowPhase = "gameFlowPhase";
    public const string ChampSelect = "champSelect";
    public const string EndGame = "endGame";

    // Client => server (request), then server => clients (response)
    public const string EndGameMatch = "endGameMatch";
    public const string EndGameTimeline = "endGameTimeline";
    public const string FearlessGameMatch = "fearlessGameMatch";
    public const string SpectatorCurentGameInfoByRiotId = "spectatorCurentGameInfoByRiotId";
}
