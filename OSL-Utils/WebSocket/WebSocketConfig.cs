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
        public List<string> Token { get; set; }

        public bool Equals(WebSocketConfig? other)
        {
            if (other is null)
                return false;

            return Ip == other.Ip
                && Port == other.Port
                && Token.SequenceEqual(other.Token);
        }

        public WebSocketConfig Clone()
        {
            return new WebSocketConfig
            {
                Ip = this.Ip,
                Port = this.Port,
                Token = [.. Token]
            };
        }
    }
}
