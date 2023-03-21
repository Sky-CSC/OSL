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
        /// Receive
        /// </summary>
        /// <param name="client">Socket client</param>
        public static void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Receive()", "Error Client Recive : " + e.Message);
            }
        }

        public static void Receive()
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = oslServerSocket;

                // Begin receiving the data from the remote device.  
                oslServerSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Receive()", "Error Client Recive : " + e.Message);
            }
        }

        /// <summary>
        /// ReceiveCallback
        /// </summary>
        /// <param name="ar"></param>
        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                        _logger.log(LoggingLevel.INFO, "ReceiveCallback()", "Response : " + response);
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "ReceiveCallback()", "Error Client Recive : " + e.Message);
            }
        }
    }
}
