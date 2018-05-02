namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ConsolePrinter printer = new ConsolePrinter();

            List<Logger> loggers = new List<Logger>()
            {
                new BasicLoggerInfo("I am BasicLoggerInfo"),
                new ColorfulLoggerPrint("ColorfulLoggerPrint", ConsoleColor.Blue),
                new DetailedLoggerInfo("DetailedLoggerInfo")
            };

            foreach (var logger in loggers)
            {
                printer.Print(logger);
            }
        }
    }
}
