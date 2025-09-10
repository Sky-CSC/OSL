namespace OSL_Utils.WebSocket
{
    /// <summary>
    /// WebSocket configuration
    /// </summary>
    public class WebSocketConfig
    {
        /// <summary>
        /// IP address of the WebSocket server
        /// </summary>
        public string Ip { get; set; } = "localhost";
        /// <summary>
        /// Port of the WebSocket server
        /// </summary>
        public int Port { get; set; } = 5005;
        /// <summary>
        /// Token for authenticate clients
        /// </summary>
        public string Token { get; set; } = "tWnrMk5KXjOiJ29zGPlgeF6U5YCa2aIdDI2B1K+Jwdc=";
    }
}
