using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Client.Communication.OSLServer
{
    public partial class AsyncClient
    {
        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                _logger.log(LoggingLevel.INFO, "SendCallback()", "Sent " + bytesSent + " bytes to server");


                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "SendCallback()", "Error Client Send : " + e.Message);
            }
        }
    }
}
