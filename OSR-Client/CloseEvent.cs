using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSR_Client
{
    internal class CloseEvent
    {
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
        public static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    Console.WriteLine("Closing");
                    // TODO Cleanup resources
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }
    }
}
