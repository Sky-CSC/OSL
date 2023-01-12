using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Server.Communication
{
    public class ServerHub : Hub
    {
        private static OSLLogger _logger = new OSLLogger("ServerHub");


        public static bool IsServerRunning { set; get; } = false;

        /// <summary>
        /// Update status of the server
        /// </summary>
        /// <returns></returns>
        public async Task UpdateStatus()
        {

            while (true)
            {
                if (Clients is not null && Clients.All is not null)
                {
                    await Clients.All.SendAsync("ServerStatusUpdate", IsServerRunning);
                    _logger.log(LoggingLevel.DEBUG, "BoatTypesListHub", $"Server send isServerRunning: {IsServerRunning}");

                }
                await Task.Delay(2000);
            }
        }

        /// <summary>
        /// Send the list of all BoatTypes to the client
        /// </summary>
        /// <param name="port">port</param>
        /// <returns></returns>
        public async Task SendPort(int port)
        {
            _logger.log(LoggingLevel.INFO, "SendPort()", "A client ask to change the port");
            AsyncServer.Stop();
            AsyncServer.portSocketOSLServer = port;
            _logger.log(LoggingLevel.INFO, "SendPort()", $"Server port changed to : {port}");
            AsyncServer.Run();
        }


        /// <summary>
        /// Ask the server to start the socket
        /// </summary>
        /// <returns></returns>
        public async Task TurnOn()
        {
            _logger.log(LoggingLevel.INFO, "TurnOn()", $"A client ask to turn on the server");
            AsyncServer.Run();
        }

        /// <summary>
        /// Ask the server to turn off the socket
        /// </summary>
        /// <returns></returns>
        public async Task TurnOff()
        {
            _logger.log(LoggingLevel.INFO, "TurnOff()", $"A client ask to turn off the server");
            AsyncServer.Stop();
        }

        /// <summary>
        /// Called when a new connection is established with the hub.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            _logger.log(LoggingLevel.DEBUG, "OnConnectedAsync()", $"New connection {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        /// <summary>
        /// Called when a connection with the hub is terminated.
        /// </summary>
        /// <param name="e">exeption type</param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception e)
        {
            _logger.log(LoggingLevel.DEBUG, "OnDisconnectedAsync()", $"Disconnection of {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

        /// <summary>
        /// Check the status of the port
        /// </summary>
        /// <param name="port"></param>
        /// <returns>True if is busy</returns>
        public static bool IsPortBusy(int port)
        {
            try
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

                foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
                {
                    if (tcpi.LocalEndPoint.Port == port)
                    {
                        return false;
                    }
                }

                Socket listener = new Socket(AddressFamily.InterNetworkV6,
                    SocketType.Stream, ProtocolType.Tcp);
                listener.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                listener.Bind(new IPEndPoint(ipAddress, port));
                listener.Close();
                _logger.log(LoggingLevel.DEBUG, "IsPortBusy()", $"Port available: {port}");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.DEBUG, "IsPortBusy()", $"Port busy: {port}: \"{e}\"");
                return false;
            }

            return true;
        }
    }
}
