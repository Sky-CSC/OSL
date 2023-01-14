using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Server.Communication
{
    /// <summary>
    /// AsyncServer
    /// </summary>
    public partial class AsyncServer
    {
        /// <summary>
        /// Encodes the specified string data in ASCII format and sends it asynchronously 
        /// to the network device represented by the specified socket
        /// </summary>
        /// <param name="handler">Client</param>
        /// <param name="data">Information to send</param>
        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        /// <summary>
        /// It sends the data when the network device is ready to receive
        /// </summary>
        /// <param name="ar"><see cref="IAsyncResult"/></param>
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                _logger.log(LoggingLevel.INFO, "SendCallback()", $"Sent {bytesSent} bytes to client.");

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "SendCallback()", e.ToString());
            }
        }
    }
}
