using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Communication.OSLServer
{
    /// <summary>
    /// Asynchrone client
    /// </summary>
    public partial class AsyncClient
    {
        /// <summary>
        /// ConnectCallback
        /// </summary>
        /// <param name="ar"></param>
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                _logger.log(LoggingLevel.INFO, "ConnectCallback()", "Socket connected to : " + client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ConnectCallBack()", "Error Client Connect : " + e.Message);
            }
        }
    }
}
