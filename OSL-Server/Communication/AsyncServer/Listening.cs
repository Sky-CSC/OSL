using System.Net.Sockets;
using System.Net;
using OSL_Server.DataReciveClient;
using System.Text;

namespace OSL_Server.Communication
{
    /// <summary>
    /// Async Server
    /// </summary>
    public partial class AsyncServer
    {
        /// <summary>
        /// Launch a listening session 
        /// </summary>
        private static void StartListening()
        {
            byte[] bytes = new byte[1024];

            // Reservation of the listening port according to the IP of the server.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //nimporte quelle ip
            IPAddress ipAddress = IPAddress.Any;
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            _logger.log(LoggingLevel.INFO, "StartListening()", $"Host address : {ipAddress} Port : {portSocketOSLServer}");

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portSocketOSLServer);
            Socket listener = new Socket(AddressFamily.InterNetworkV6,
                SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            //Socket listener = new Socket(AddressFamily.InterNetwork,
            //SocketType.Stream, ProtocolType.Tcp);
            //listener.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IPOptions, false);
            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "StartListening()", "Error while listening: " + e.Message);
            }

            while (true)
            {
                try
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    _logger.log(LoggingLevel.DEBUG, "StartListening()", $"Waiting for a connection... {portSocketOSLServer}");


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
                        ServerHub.IsServerRunning = false;
                        break;
                    }
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "StartListening()", "Error while waiting for a connection: " + e.Message);
                }
            }

            listener.Close();
            _logger.log(LoggingLevel.DEBUG, "AsyncServer.StartListening()", $"Listen is over.");

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
                        // There  might be more data, so store the data received so far.
                        //client.sb.Append(Encoding.UTF8.GetString(
                        //    client.buffer, 0, bytesRead));

                        // Check for end-of-file tag. If it is not there, read 
                        // more data.
                        //content = client.sb.ToString();
                        content = Encoding.UTF8.GetString(client.buffer, 0, bytesRead);
                        //_logger.log(LoggingLevel.INFO, "ReadCallback()", $"Content recived {content}");

                        string returnContent = ReciveFromClient.ReadData(content);

                        //Send(handler, returnContent);
                    }
                    //handler.BeginReceive(client.buffer, 0, Client.BufferSize, 0,
                    //    ReadCallback, client);
                    //Socket never close, system wait interruption kernel to close it
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "AcceptCallback()", "Error while accepting a connection: " + e.Message);
            }
        }
    }
}
