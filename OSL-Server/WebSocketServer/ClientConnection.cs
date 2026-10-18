using OSL_Utils.WebSocket;
using System.Net.WebSockets;
using System.Threading.Channels;

namespace OSL_Server.WebSocketServer;

/// <summary>
/// One connected client. Messages are never sent directly: they are queued (<see cref="TryEnqueue"/>, never blocks) and
/// written to the socket by a dedicated loop (<see cref="RunSendLoopAsync"/>). A slow client therefore only delays itself.
/// </summary>
internal sealed class ClientConnection
{
    /// <summary>Maximum number of messages waiting for a client. When full, the oldest messages are dropped.</summary>
    private const int OutboundCapacity = 64;

    private readonly Channel<ReadOnlyMemory<byte>> _outbound;
    private int _dropped;

    public ClientConnection(WebSocket socket, string? ipAddress)
    {
        Socket = socket;
        Info = new WebSocketClientInfo
        {
            Id = Guid.NewGuid(),
            IpAddress = ipAddress,
            State = socket.State,
        };

        _outbound = Channel.CreateBounded<ReadOnlyMemory<byte>>(
            new BoundedChannelOptions(OutboundCapacity)
            {
                FullMode = BoundedChannelFullMode.DropOldest,
                SingleReader = true,
            },
            _ => Info.DroppedMessages = Interlocked.Increment(ref _dropped));
    }

    public WebSocket Socket { get; }

    public WebSocketClientInfo Info { get; }

    /// <summary>Close status requested by the receive loop, applied once the send loop has stopped.</summary>
    public WebSocketCloseStatus? CloseStatus { get; set; }

    public string? CloseDescription { get; set; }

    private readonly object _authenticationLock = new();
    private bool _timedOut;

    /// <summary>Marks the client as authenticated, unless the authentication timeout has already been triggered.</summary>
    public bool TryMarkAuthenticated()
    {
        lock (_authenticationLock)
        {
            if (_timedOut)
                return false;

            Info.Authenticated = true;
            return true;
        }
    }

    /// <summary>Marks the authentication timeout as triggered, unless the client has just authenticated.</summary>
    public bool TryMarkTimedOut()
    {
        lock (_authenticationLock)
        {
            if (Info.Authenticated)
                return false;

            _timedOut = true;
            return true;
        }
    }

    public bool TryEnqueue(ReadOnlyMemory<byte> payload) => _outbound.Writer.TryWrite(payload);

    public void CompleteOutbound() => _outbound.Writer.TryComplete();

    public void RefreshState() => Info.State = Socket.State;

    /// <summary>Writes the queued messages to the socket until the connection ends. Never throws.</summary>
    public async Task RunSendLoopAsync(CancellationToken cancellationToken)
    {
        try
        {
            await foreach (ReadOnlyMemory<byte> payload in _outbound.Reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            {
                if (Socket.State != WebSocketState.Open)
                    break;

                await Socket.SendAsync(payload, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            // Connection is ending.
        }
        catch (WebSocketException)
        {
            // The client is gone: the receive loop notices it too.
        }
        catch (ObjectDisposedException)
        {
        }
    }
}
