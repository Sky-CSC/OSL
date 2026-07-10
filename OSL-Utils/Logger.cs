namespace OSL_Utils
{
    /// <summary>
    /// Logger class for logging messages, supports automatic emojis
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Mutex
        /// </summary>
        private static readonly Mutex mut = new();

        /// <summary>
        /// Log level
        /// </summary>
        public static LoggingLevel LogLevel { get; set; }

        /// <summary>
        /// Prefix context
        /// </summary>
        public string ContextPrefix { get; set; }

        /// <summary>
        /// Default logging level
        /// </summary>
        public static LoggingLevel DefaultLoggingLevel { get; } = LoggingLevel.DEBUG;

        /// <summary>
        /// Static constructor for configurer UTF-8
        /// </summary>
        static Logger()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contextPrefix">Prefixe context</param>
        /// <param name="logLevel">Log level</param>
        public Logger(string contextPrefix = "")
        {
            ContextPrefix = string.IsNullOrEmpty(contextPrefix) ? "" : contextPrefix + ".";
        }

        /// <summary>
        /// Logs a message with level and context.
        /// </summary>
        public void Log(LoggingLevel level, string context, object message)
        {
            if (level <= LogLevel && level != LoggingLevel.OFF)
            {
                mut.WaitOne();
                try
                {
                    Console.Out?.Flush();
                    Console.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ");
                    WriteLevel(level);          // Emoji + level
                    WriteCaller($"{ContextPrefix}{context}");
                    Console.Write(": ");

                    string msg = message?.ToString() ?? "null";
                    Console.WriteLine(msg);
                    Console.ResetColor();
                }
                finally
                {
                    mut.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// Get emoji for each log level
        /// </summary>
        /// <param name="level">log level</param>
        /// <returns>emoji</returns>
        private static string GetEmojiForLevel(LoggingLevel level) => level switch
        {
            LoggingLevel.DEBUG => "🐛",
            LoggingLevel.INFO => "ℹ️",
            LoggingLevel.WARN => "⚠️",
            LoggingLevel.ERROR => "❌",
            _ => ""
        };

        /// <summary>
        /// Write data
        /// </summary>
        /// <param name="caller"></param>
        private static void WriteCaller(string caller)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            int n = Align(caller);
            string aligned = caller + new string(' ', n);
            Console.Write($"[{aligned}] ");
            Console.ResetColor();
        }

        /// <summary>
        /// Align text
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>Number for align</returns>
        private static int Align(string text)
        {
            if (text.Length <= 24) return 25 - text.Length;
            if (text.Length <= 32) return 32 - text.Length;
            if (text.Length <= 40) return 45 - text.Length;
            return 0;
        }

        /// <summary>
        /// Write level log
        /// </summary>
        /// <param name="level"></param>
        private static void WriteLevel(LoggingLevel level)
        {
            string emoji = GetEmojiForLevel(level);
            Console.ForegroundColor = level switch
            {
                LoggingLevel.DEBUG => ConsoleColor.Blue,
                LoggingLevel.INFO => ConsoleColor.Green,
                LoggingLevel.WARN => ConsoleColor.Yellow,
                LoggingLevel.ERROR => ConsoleColor.Red,
                _ => Console.ForegroundColor
            };

            Console.Write($"[{level,-5}] "); // Emoji devant le niveau
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Loggings levels
    /// </summary>
    public enum LoggingLevel
    {
        OFF = 0,
        ERROR = 1,
        WARN = 2,
        INFO = 3,
        DEBUG = 4
    }
}
