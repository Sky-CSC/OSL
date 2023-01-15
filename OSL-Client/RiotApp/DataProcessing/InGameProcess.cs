using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using OSL_Client.Configuration;
using OSL_Client.FileManager;

namespace OSL_Client.RiotApp.DataProcessing
{
    /// <summary>
    /// In Game Process
    /// </summary>
    internal class InGameProcess
    {
        private static OSLLogger _logger = new OSLLogger("InGameProcess");
        private static Socket socketLiveEventsAPI = null;
        /// <summary>
        /// Initializes in game components
        /// </summary>
        public static void InGame()
        {
            ConnectLiveEventsAPI();
            while (true)
            {
                //if (ConnectLiveEventsAPI())
                //{

                //time stamp
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //Console.WriteLine();
                string content = GetLiveEventsAPI();
                if (content != null) {
                    //write in file
                    //FileManagerLocal.WriteInFile(@"E:\Overlay-found-riot\info.json", date);
                    FileManagerLocal.WriteInFile(@"E:\Overlay-found-riot\info.json", date + "\n" + content);
                }
                //DisconnectLiveEventsAPI();
                //}
            }


            //Init all fonction of this game

            //Retrieve information, not in game information flow :
            //     - Ban (Champion Banned, statistiques of bann)
            //     - Pick (Champion Pick, name champ, name player, champ skin, statistiques of win)
            //     - Perks (Perks by champion)

            //Retrieve information in game flow :
            //     - Minion kill
            //     - Monster kill
            //     - Herald kill (Buff timer, Launched ?, Next ?, Gold win while it was launched)
            //     - Dragon kill (Next ?, which, timer, Soul) 
            //     - Nash kill (Buff timer, Gold win while buff, Damage inflicted while buff, Who has the buff, If all team dead buff off, Next ?)
            //     - Helder dragon kill (Buff timer, Gold win while buff, Damage inflicted while buff, Who has the buff, If all team dead buff off, Next ?)
            //     - Turret kill
            //     - Inib kill (Timer reaspon)
            //     - Champion kill
            //     - Items buy
            //     - Level up
            //     - Gold win
            //     - Damage inflicted

            //Send this information to server API
        }

        /// <summary>
        /// Connection from the live events API
        /// </summary>
        /// <returns>True if connexion is successfull</returns>
        public static bool ConnectLiveEventsAPI()
        {
            try
            {
                socketLiveEventsAPI = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketLiveEventsAPI.ReceiveBufferSize = int.MaxValue;
                socketLiveEventsAPI.Connect(Config.localIpHttp, Config.LiveEventsAPIPort);
                _logger.log(LoggingLevel.INFO, "ConnectLiveEventsAPI()", "Connexion to LiveEventsAPI successfull");
                return true;
            }
            catch (Exception e)
            {
                DisconnectLiveEventsAPI();
                _logger.log(LoggingLevel.ERROR, "ConnectLiveEventsAPI()", "Connexion to LiveEventsAPI failed : " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Disconnect from the live events API
        /// </summary>
        public static void DisconnectLiveEventsAPI()
        {
            try
            {
                socketLiveEventsAPI.Disconnect(false); //true if this socket can be reused after the current connection is closed
                //socketLiveEventsAPI.Disconnect(false); //otherwise
                _logger.log(LoggingLevel.INFO, "DisconnectLiveEventsAPI()", "Disconnect to LiveEventsAPI successfull");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "DisconnectLiveEventsAPI()", "Disconnect to LiveEventsAPI failed : " + e.Message);
            }
        }

        /// <summary>
        /// Get the data from the live events API
        /// </summary>
        /// <returns>null if data not valid or error, else string like Json</returns>
        public static string GetLiveEventsAPI()
        {
            try
            {
                if (socketLiveEventsAPI.Available > 0)
                {
                    int size = socketLiveEventsAPI.Available;
                    byte[] bytes = new byte[size];
                    if (bytes.Length > 0)
                    {
                        socketLiveEventsAPI.Receive(bytes, 0, size, SocketFlags.None);
                        string content = Encoding.UTF8.GetString(bytes);
                        _logger.log(LoggingLevel.INFO, "GetLiveEventsAPI()", "Receive from LiveEventsAPI successfull : "/* + content*/);
                        return content;
                    }
                    else
                    {
                        _logger.log(LoggingLevel.WARN, "GetLiveEventsAPI()", "Receive from LiveEventsAPI null");
                        return null;
                    }
                }
                else
                {
                    _logger.log(LoggingLevel.ERROR, "GetLiveEventsAPI()", "Receive from LiveEventsAPI not Available");
                    //DisconnectLiveEventsAPI();
                    return null;
                }
            }
            catch (Exception e)
            {
                //DisconnectLiveEventsAPI();
                _logger.log(LoggingLevel.ERROR, "GetLiveEventsAPI()", "GetLiveEventsAPI failed : " + e.Message);
                return null;
            }
        }
    }
}
