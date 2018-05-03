namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();

            List<Logger> loggers = new List<Logger>()
            {
                new BasicLoggerInfo("I am BasicLoggerInfo", consoleWrapper),
                new ColorfulLoggerInfo("ColorfulLoggerPrint", ConsoleColor.Blue, consoleWrapper),
                new DetailedLoggerInfo("DetailedLoggerInfo", consoleWrapper)
            };

            foreach (var logger in loggers)
            {
                logger.PrintUsersInfo();
            }
        }
    }
}
