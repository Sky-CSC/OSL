using OSL_Utils;

namespace OSL_Server.WebSocketServer.Handlers
{
    /// <summary>
    /// Example handler for the "skynet" message type.
    /// </summary>
    /// <remarks>
    /// When a client sends a message of type <c>skynet</c>, 
    /// this handler responds with a broadcast to all clients.
    /// </remarks>
    public class TerminatorHandler : IMessageHandler
    {
        private static readonly Logger _logger = new("TerminatorHandler");

        /// <inheritdoc />
        public string Type => "skynet";

        /// <inheritdoc />
        public async Task HandleAsync(WebSocketServer server, System.Net.WebSockets.WebSocket client, object? rawData)
        {
            try
            {
                var json = rawData?.ToString();
                _logger.Log(LoggingLevel.INFO, nameof(HandleAsync), $"🌍 Terminator received: {json}");

                await server.BroadcastAsync("skynet", "Application created by Sky-csc");
            }
            catch (Exception ex)
            {
                _logger.Log(LoggingLevel.ERROR, nameof(HandleAsync), $"❌ Error: {ex.Message}");
            }
        }
    }
}
