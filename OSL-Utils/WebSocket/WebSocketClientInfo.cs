using System.Net.WebSockets;

namespace OSL_Utils.WebSocket
{
    public class WebSocketClientInfo
    {
        public Guid Id { get; init; }

        public DateTime ConnectedAt { get; init; } = DateTime.UtcNow;

        public DateTime LastActivity { get; set; } = DateTime.UtcNow;

        public string? IpAddress { get; set; }

        public bool Authenticated { get; set; }

        public WebSocketState State { get; set; }

        public System.Net.WebSockets.WebSocket Socket { get; init; } = null!;
        public SemaphoreSlim SendLock { get; } = new(1, 1);
    }
}
