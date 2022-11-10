using Newtonsoft.Json;
using OSL_Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using OSL_Server.DataReciveClient;

namespace OSL_Server.Communication
{
    public partial class AsyncServer
    {
        /// <summary>
        /// Processing the information received by the client
        /// </summary>
        /// <param name="ar"></param>
        private static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            Client client = (Client)ar.AsyncState;
            Socket handler = client.Handler;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);
            //while if dig data

            // Serialisation
            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                client.sb.Append(Encoding.ASCII.GetString(
                    client.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = client.sb.ToString();
                _logger.log(LoggingLevel.INFO, "ReadCallback()", $"Content recived {content}");

                string returnContent = ReciveFromClient.ReadData(content);

                Send(handler, returnContent);
            }
        }
    }
}

