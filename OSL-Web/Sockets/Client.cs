using System.Net.Sockets;
using System.Net;
using System.Text;

namespace OSL_Web.Sockets
{
    /// <summary>
    /// Async Server
    /// </summary>
    public partial class AsyncServer
    {
        /// <summary>
        /// This class is used to store the state of the connection of client
        /// </summary>
        private class Client // : IObservable<Client>
        {
            public IPAddress IpAddress { set; get; }
            public int Port { set; get; }
            public string Nickname { set; get; }
            public Socket Handler { set; get; }
            public Socket Listener { set; get; }

            public const int BufferSize = 1048576;
            //public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string. 
            public StringBuilder sb = new StringBuilder();

        }
    }
}
