using System.Net.Sockets;
using System.Net;
using System.Text;
using OSL_Common.System.Logging;

namespace OSL_Web.Sockets
{
    public partial class AsyncServer
    {
        private static void StartListening()
        {
            // Reservation of the listening port according to the IP of the server.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;
            _logger.log(LoggingLevel.INFO, "StartListening()", $"Host address : {ipAddress} Port : {port}");

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            Socket listener = new Socket(AddressFamily.InterNetworkV6,
                SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                Listening(listener);
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "StartListening()", "Error while listening: " + e.Message);
            }

            listener.Close();
            _logger.log(LoggingLevel.DEBUG, "AsyncServer.StartListening()", $"Listen is over.");
        }

        private static void Listening(Socket listener)
        {
            while (true)
            {
                try
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    _logger.log(LoggingLevel.INFO, "StartListening()", $"Waiting for a connection... {port}");


                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    if (_stop) throw new ThreadInterruptedException();
                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }
                catch (ThreadInterruptedException e)
                {
                    if (_StoppingIfRequested(listener))
                    {
                        _logger.log(LoggingLevel.WARN, "StartListening()", $"Server interrupted {e.Message}");
                        break;
                    }
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "StartListening()", "Error while waiting for a connection: " + e.Message);
                }
            }
        }

        /// <summary>
        /// Here we treat if the new client already exists or not, 
        /// then create a new one or update the existing one
        /// </summary>
        /// <param name="ar"></param>
        private static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            if (_StoppingIfRequested(ar.AsyncState as Socket))
            {
                return;
            }

            try
            {
                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                Client client = new Client();
                client.Handler = handler;

                while (true)
                {
                    int bytesRead = handler.Receive(client.buffer);
                    //while if dig data
                    String content = String.Empty;
                    // Serialisation
                    if (bytesRead > 0)
                    {
                        content = Encoding.UTF8.GetString(client.buffer, 0, bytesRead);
                        DataProcessing.DataRedirection.RedirectData(content);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "AcceptCallback()", "Error while accepting a connection: " + e.Message);
            }
        }
    }
}
