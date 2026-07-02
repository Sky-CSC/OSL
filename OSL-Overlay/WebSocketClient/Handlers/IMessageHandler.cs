using Newtonsoft.Json.Linq;

namespace OSL_Overlay.WebSocketClient.Handlers
{
    /// <summary>
    /// Interface for handling messages received from the WebSocket server
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// Type of message this handler processes
        /// </summary>
        string Type { get; }

        /// <summary>
        /// JSON schema for validating incoming messages (optional)
        /// </summary>
        /// <param name="jsonData">Json data to validate</param>
        /// <returns>Task</returns>
        Task HandleAsync(JToken jsonData);
    }
}
