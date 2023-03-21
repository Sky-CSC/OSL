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

    /// <summary>
    /// State object for receiving data from remote device.
    /// </summary>
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

    /// <summary>
    /// Asynchrone client
    /// </summary>
    public partial class AsyncClient
    {
        private static OSLLogger _logger = new OSLLogger("AsyncClient");

        // The port number for the remote device.
        //private const int port = 11000;
        public static Socket oslServerSocket = null;

        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;



        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool StartClient(String data)
        {
            try
            {
                Socket client = null;
                IPEndPoint ipe = null;

                IPHostEntry hostEntry = Dns.GetHostEntry(Config.serverIPSocketOSLServer);

                foreach (IPAddress address in hostEntry.AddressList)
                {
                    Console.WriteLine(address);
                    if (address.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                    {
                        ipe = new IPEndPoint(address, Config.serverPortSocketOSLServer);
                        Socket tempSocket =
                            new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            tempSocket.Connect(ipe);

                            if (tempSocket.Connected)
                            {
                                client = tempSocket;
                                _logger.log(LoggingLevel.INFO, "StartClient()", "Socket connected");
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.log(LoggingLevel.ERROR, "StartClient()", "Error tempSocket.Connect(ipe) : " + e.Message);
                        }
                    }
                }

                Send(client, data);
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                //Receive(client);
                //receiveDone.WaitOne();

                oslServerSocket = client;

                return true;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "StartClient()", "Error Client : " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CloseClient()
        {
            try
            {
                oslServerSocket.Shutdown(SocketShutdown.Both);
                oslServerSocket.Close();
                return true;
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "CloseClient()", "Error Client : " + e.Message);
                return false;
            }
        }
    }















    /// <summary>
    /// Run connexion for connect to server
    /// </summary>
    /// <param name="data">data recive</param>
    /// <returns>Connexion are enabled</returns>
    //public static bool StartClient(String data)
    //{
    //    // Connect to a remote device.  
    //    try
    //    {
    //        // Establish the remote endpoint for the socket.  
    //        // The name of the
    //        // remote device is "host.contoso.com".  
    //        //IPHostEntry ipHostInfo = Dns.Resolve(Config.serverIPSocketOSLServer);
    //        //IPAddress ipAddress = ipHostInfo.AddressList[0];
    //        //foreach (IPAddress address in ipHostInfo.AddressList){
    //        //    Console.WriteLine(address);
    //        //    if (address.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
    //        //    {

    //        //    }
    //        //    else if (address.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
    //        //    {
    //        //        ipAddress = address;
    //        //    }
    //        //}

    //        Socket client = null;
    //        IPEndPoint ipe = null;

    //        IPHostEntry hostEntry = Dns.GetHostEntry(Config.serverIPSocketOSLServer);

    //        foreach (IPAddress address in hostEntry.AddressList)
    //        {
    //            Console.WriteLine(address);
    //            ipe = new IPEndPoint(address, Config.serverPortSocketOSLServer);
    //            Socket tempSocket =
    //                new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    //            try
    //            {
    //                tempSocket.Connect(ipe);

    //                if (tempSocket.Connected)
    //                {
    //                    client = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    //                    break;
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //            }
    //            catch (Exception e)
    //            {
    //                _logger.log(LoggingLevel.ERROR, "StartClient()", "Error tempSocket.Connect(ipe) : " + e.Message);
    //            }
    //        }

    //        //_logger.log(LoggingLevel.INFO, "StartClient()", "ipAddress : " + ipAddress);

    //        //IPEndPoint remoteEP = new IPEndPoint(ipAddress, Config.serverPortSocketOSLServer);

    //        // Create a TCP/IP socket.  
    //        //client = new Socket(ipAddress.AddressFamily,
    //        //    SocketType.Stream, ProtocolType.Tcp);

    //        // Connect to the remote endpoint.  
    //        client.BeginConnect(ipe, new AsyncCallback(ConnectCallback), client);
    //        //Console.WriteLine(client.Connected);
    //        connectDone.WaitOne();

    //        //_logger.log(LoggingLevel.INFO, "StartClient()", "Data : " + data);
    //        Send(client, data);
    //        //Send(client, "This is a test<EOF>");
    //        sendDone.WaitOne();

    //        // Receive the response from the remote device.  
    //        Receive(client);
    //        receiveDone.WaitOne();

    //        _logger.log(LoggingLevel.INFO, "StartClient()", "Response received : " + response);

    //        // Release the socket.  
    //        //client.Shutdown(SocketShutdown.Both);
    //        //client.Close();
    //    }
    //    catch (Exception e)
    //    {
    //        _logger.log(LoggingLevel.ERROR, "StartClient()", "Error Client : " + e.Message);
    //        return false;
    //    }
    //    return true;
    //}
    //}
}
