using System;
using System.Collections.Generic;

namespace PayItForward.ConsoleClient
{
    public class ConsolePrinter
    {
        public void Print(Logger someLogger, ConsoleColor? color)
        {
            if (someLogger.GetType() == typeof(ColorfulLoggerPrint))
            {
                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = (someLogger as ColorfulLoggerPrint).GetConsoleColor;
            }

            foreach (var logger in someLogger.UserInfo())
            {
                Console.WriteLine(logger);
            }
        }
    }
}
