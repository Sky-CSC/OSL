using System.Net.WebSockets;

namespace OSL_Utils.WebSocket;

/// <summary>
/// Information about a client connected to the WebSocket server (read by the administration UI).
/// The socket itself stays private to the server.
/// </summary>
public class WebSocketClientInfo
{
    public Guid Id { get; init; }
    public DateTime ConnectedAt { get; init; } = DateTime.UtcNow;
    public DateTime LastActivity { get; set; } = DateTime.UtcNow;
    public string? IpAddress { get; set; }
    public bool Authenticated { get; set; }
    public WebSocketState State { get; set; }

    /// <summary>
    /// Number of messages dropped because this client was too slow to read them (only the newest ones are kept).
    /// </summary>
    public int DroppedMessages { get; set; }
}
