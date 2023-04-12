using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OSL_Common.System.Logging;
using OSL_Client.Configuration;

namespace OSL_Client.Sockets
{
    public partial class AsyncClient
    {
        private static Logger _logger = new("AsyncClient");

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

                IPHostEntry hostEntry = Dns.GetHostEntry(Config.serverSocketIp);

                foreach (IPAddress address in hostEntry.AddressList)
                {
                    Console.WriteLine(address);
                    if (address.AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString())
                    {
                        ipe = new IPEndPoint(address, Config.serverSocketPort);
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
}
