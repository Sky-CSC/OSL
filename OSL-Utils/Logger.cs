namespace OSL_Utils
{
    /// <summary>
    /// Logger class for logging messages
    /// </summary>
    public class Logger
    {
        private static readonly Mutex mut = new();

        public LoggingLevel LogLevel;
        public string contextPrefix;

        public static LoggingLevel DefaultLoggingLevel = DefaultInit();

        /// <summary>
        /// DefaultInit - Initialize the default logging level from the appsettings.json file
        /// </summary>
        /// <returns> default logging level </returns>
        private static LoggingLevel DefaultInit()
        {
            return LoggingLevel.INFO;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="contextPrefix"></param>
        public Logger(string contextPrefix = "", LoggingLevel? logLevel = null)
        {
            LogLevel = logLevel ?? DefaultLoggingLevel;
            this.contextPrefix = contextPrefix + ".";
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public void Log(LoggingLevel level, string context, object message)
        {
            if (level <= LogLevel && level != LoggingLevel.OFF)
            {
                mut.WaitOne();
                Console.Out?.Flush();
                Console.Write(String.Format("{0,-16} | ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                WriteLevel(level);
                WriteCaller($"{contextPrefix}{context}");
                Console.Write(": ");
                Console.WriteLine(String.Format("{1}", context, message));
                Console.ResetColor();
                mut.ReleaseMutex();
            }
        }

        /// <summary>
        /// Formatting for writing in the console
        /// </summary>
        /// <param name="caller"></param>
        private static void WriteCaller(string caller)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int n = Allign(caller);
            string allign = caller + (new string(' ', n));
            Console.Write(String.Format($"[{allign}] "));
            Console.ResetColor();
        }

        /// <summary>
        /// Formatting alignement for writing in the console
        /// </summary>
        /// <param name="text">Text to format</param>
        /// <returns></returns>
        private static int Allign(string text)
        {
            if (text.Length <= 24)
            {
                return 25 - text.Length;
            }
            else if (text.Length <= 32)
            {
                return 32 - text.Length;
            }
            else if (text.Length <= 40)
            {
                return 45 - text.Length;
            }
            return 0;
        }

        /// <summary>
        /// Level formatting for writing in the console
        /// </summary>
        /// <param name="level"></param>
        private static void WriteLevel(LoggingLevel level)
        {
            switch (level)
            {
                case LoggingLevel.DEBUG:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LoggingLevel.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LoggingLevel.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LoggingLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.Write(String.Format("[{0,-5}] ", level.ToString()));
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Level of logging
    /// </summary>
    public enum LoggingLevel
    {
        OFF = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        DEBUG = 4,
    }
}
