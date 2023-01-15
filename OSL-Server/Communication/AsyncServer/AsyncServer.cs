using System.Net.Sockets;

namespace OSL_Server.Communication
{
    /// <summary>
    /// Async Server
    /// </summary>
    public partial class AsyncServer
    {
        private static OSLLogger _logger = new OSLLogger("AsyncServer");
        private static Thread? thread = null;
        public static int portSocketOSLServer { get; set; } = 45678;
        private static bool _stop = false;
        // Semaphore
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        /// <summary>
        /// Check if the server is running
        /// </summary>
        /// <returns>True if server is running</returns>
        public static bool IsRunning()
        {
            if (thread == null)
                return false;
            return thread.IsAlive;//|| thread != null;
        }
        /// <summary>
        /// Start the server
        /// </summary>
        public static void Run()
        {
            try
            {
                if (thread is not null)
                {
                    _logger.log(LoggingLevel.DEBUG, "Run()", $"Thread already exists and is in state {thread.ThreadState}");
                    if (thread.IsAlive)
                    {
                        _logger.log(LoggingLevel.ERROR, "Run()", "Server already running");
                        return;
                    }
                }
                _stop = false;
                thread = new Thread(new ThreadStart(StartListening));
                ServerHub.IsServerRunning = true;
                thread.Start();
                _logger.log(LoggingLevel.INFO, "Run()", "Starting server");
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Run()", "Error while starting server: " + e.Message);
            }
        }
        /// <summary>
        /// Stop the server
        /// </summary>
        public static void Stop()
        {
            try
            {
                if (thread is null || !thread.IsAlive)
                {
                    _logger.log(LoggingLevel.WARN, "Stop()", "Server is not running");
                    return;
                }
                _stop = true;
                thread.Interrupt();
                _logger.log(LoggingLevel.WARN, "Stop()", "Stopping server ...");
                while (thread.IsAlive)
                {
                    Thread.Sleep(500);
                }
                _logger.log(LoggingLevel.INFO, "Stop()", "Assuming the server is stopped");
            }

            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "Stop()", "Error stopping server: " + e.Message);
            }
        }
        /// <summary>
        /// If a closure request is made 
        /// </summary>
        /// <param name="s">Socket we whant closing</param>
        /// <returns>True if closure request is made</returns>
        private static bool _StoppingIfRequested(Socket? s)
        {
            if (_stop)
            {
                if (s is not null)
                {
                    _logger.log(LoggingLevel.WARN, "StartListening()", $"Closing a socket");
                    //s.Shutdown(SocketShutdown.Both);
                    s.Close();
                }
            }
            return _stop;
        }
    }
}
