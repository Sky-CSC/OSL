using Newtonsoft.Json;
using OSL_Client.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Communication.OSLServer
{

    // State object for receiving data from remote device.
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public partial class AsyncClient
    {
        private static OSLLogger _logger = new OSLLogger("AsyncClient");

        // The port number for the remote device.
        //private const int port = 11000;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;

        //IP
        //private static string ip = "127.0.0.1";
        //private static int port = 45879;

        public static bool StartClient(String data)
        {
            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // The name of the
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.Resolve(Config.serverIPSocketOSLServer);
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Config.serverPortSocketOSLServer);

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                //Console.WriteLine(client.Connected);
                connectDone.WaitOne();

                //_logger.log(LoggingLevel.INFO, "StartClient()", "Data : " + data);
                Send(client, data);
                //Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                Receive(client);
                receiveDone.WaitOne();

                _logger.log(LoggingLevel.INFO, "StartClient()", "Response received : " + response);

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "StartClient()", "Error Client : " + e.Message);
                return false;
            }
            return true;
        }
    }
}
