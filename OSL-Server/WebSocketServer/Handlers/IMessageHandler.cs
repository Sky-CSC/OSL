namespace OSL_Server.WebSocket.Handlers
{
    /// <summary>
    /// Defines a contract for handling typed WebSocket messages.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface are responsible for processing
    /// messages that match their <see cref="Type"/> identifier.
    /// </remarks>
    public interface IMessageHandler
    {
        /// <summary>
        /// The unique type identifier for this handler (e.g. "regionLocale", "gameFlowPhase").
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Handles an incoming WebSocket message.
        /// </summary>
        /// <param name="server">The WebSocket server instance that received the message.</param>
        /// <param name="client">The client WebSocket that sent the message.</param>
        /// <param name="rawData">The raw deserialized payload data (typically a <c>JToken</c>).</param>

        Task HandleAsync(WebSocketServer server, System.Net.WebSockets.WebSocket client, object? rawData);
    }
}
