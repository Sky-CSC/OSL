using System.Runtime.InteropServices;
using OSL_Common.System.Logging;

namespace OSL_Client
{
    /// <summary>
    /// Get close events
    /// </summary>
    internal class CloseEvent
    {
        private static Logger _logger = new("CloseEvent");

        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(SetConsoleCtrlEventHandler handler, bool add);
        public delegate bool SetConsoleCtrlEventHandler(CtrlType sig);
        public enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                    _logger.log(LoggingLevel.WARN, "Handler()", "ctrl+c event");
                    //Close socket
                    //Close api connexion
                    Environment.Exit(0);
                    return false;
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    _logger.log(LoggingLevel.WARN, "Handler()", "ctrl close event");
                    //Close socket
                    //Close api connexion
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
