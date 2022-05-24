
namespace OSL_Server
{
    /// <summary>
    /// Logger
    /// </summary>
    public class OSLLogger
    {
        private static Mutex mut = new Mutex();

        public LoggingLevel LogLevel;
        public string contextPrefix;
        private static IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .Build();
        public static LoggingLevel DefaultLoggingLevel = DefaultInit();

        /// <summary>
        /// DefaultInit - Initialize the default logging level from the appsettings.json file
        /// </summary>
        /// <returns> default logging level </returns>
        private static LoggingLevel DefaultInit()
        {
            LoggingLevel? loggingLevel = GetLogLevFromConf("Default");
            if (loggingLevel.HasValue)
            {
                Console.WriteLine($"Default logging level is {loggingLevel}");
                return loggingLevel.Value;
            }
            else
            {
                Console.WriteLine("The default logging level is not defined by user, using \"INFO\" as default");
                return LoggingLevel.INFO;
            }
        }

        private static LoggingLevel? GetLogLevFromConf(string prefix)
        {
            if (Configuration.GetSection("Logging").GetChildren().Count() == 0 ||
                Configuration.GetSection($"Logging:LogLevel:{prefix}").Exists() == false)
            {
                //Console.WriteLine($"No logging level for {prefix}");
                return null;
            }

            try
            {
                return (LoggingLevel)Enum.Parse(typeof(LoggingLevel), Configuration[$"Logging:LogLevel:{prefix}"]);
            }
            catch (Exception)
            {
                switch (Configuration[$"Logging:LogLevel:{prefix}"].ToLower())
                {
                    case "debug":
                    case "debugging":
                        return LoggingLevel.DEBUG;
                    case "information":
                    case "info":
                        return LoggingLevel.INFO;
                    case "warning":
                    case "warn":
                        return LoggingLevel.WARN;
                    case "error":
                    case "fatal":
                    case "critical":
                        return LoggingLevel.ERROR;
                    default:
                        //Console.WriteLine($"No logging level for {prefix}");
                        return null;
                }
            }
            //return null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OSLLogger"/> class.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="contextPrefix"></param>
        public OSLLogger(string contextPrefix = "", LoggingLevel? logLevel = null)
        {
            if (logLevel == null && contextPrefix != "")
            {
                try
                {
                    LogLevel = GetLogLevFromConf(contextPrefix) ?? DefaultLoggingLevel;
                }
                catch (Exception)
                {
                    LogLevel = DefaultLoggingLevel;
                }
            }
            else
            {
                LogLevel = logLevel ?? DefaultLoggingLevel;
            }

            this.contextPrefix = contextPrefix + ".";
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public void log(LoggingLevel level, string context, object message)
        {
            if (level <= LogLevel && level != LoggingLevel.OFF)
            {
                mut.WaitOne();
                if (Console.Out != null) Console.Out.Flush();
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
