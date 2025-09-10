using Newtonsoft.Json.Linq;

namespace OSL_Utils.WebSocket
{
    /// <summary>
    /// WebSocket message structure
    /// </summary>
    public class WebSocketMessage
    {
        /// <summary>
        /// The type of the message
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// The data of the message
        /// </summary>
        public JToken? Data { get; set; }
    }
}
