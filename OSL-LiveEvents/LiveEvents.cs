using OSL_Common.System.Logging;
using System.Net.Sockets;
using System.Text;

namespace OSL_LiveEvents
{
    public class LiveEvents
    {
        private static Logger _logger = new("LiveEvents");
        private static Socket socketLiveEvents = null;
        public static bool Connect(string localIpHttp, int leagueClientLiveEventsPort)
        {
            try
            {
                socketLiveEvents = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketLiveEvents.ReceiveBufferSize = int.MaxValue;
                socketLiveEvents.Connect(localIpHttp, leagueClientLiveEventsPort);
                _logger.log(LoggingLevel.INFO, "Connect()", "Connexion to LiveEvents successfull");
                return true;
            }
            catch (Exception e)
            {
                Close();
                _logger.log(LoggingLevel.ERROR, "Connect()", "Connexion to LiveEvents failed : " + e.Message);
                return false;
            }
        }

        public static void Close()
        {
            try
            {
                //socketLiveEvents.Disconnect(false); //true if this socket can be reused after the current connection is closed
                //socketLiveEventsAPI.Disconnect(false); //otherwise
                socketLiveEvents.Shutdown(SocketShutdown.Receive);
                socketLiveEvents.Close();
                _logger.log(LoggingLevel.INFO, "Close()", "Disconnect to LiveEvents successfull");
            }
            catch (Exception e)
            {
                socketLiveEvents.Close();
                _logger.log(LoggingLevel.ERROR, "Close()", "Disconnect to LiveEvents failed : " + e.Message);
            }
        }

        public static string Read()
        {
            try
            {
                if (socketLiveEvents.Available > 0)
                {
                    int size = socketLiveEvents.Available;
                    byte[] bytes = new byte[size];
                    if (bytes.Length > 0)
                    {
                        socketLiveEvents.Receive(bytes, 0, size, SocketFlags.None);
                        string content = Encoding.UTF8.GetString(bytes);
                        _logger.log(LoggingLevel.INFO, "Read()", "Receive from LiveEvents successfull : " + content);
                        return content;
                    }
                    else
                    {
                        _logger.log(LoggingLevel.ERROR, "Read()", "Receive from LiveEvents null");
                        return null;
                    }
                }
                else
                {
                    _logger.log(LoggingLevel.WARN, "Read()", "Receive from LiveEvents not Available");
                    //Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                //Close();
                _logger.log(LoggingLevel.ERROR, "Read()", "GetLiveEvents failed : " + e.Message);
                return null;
            }
        }

    }
}