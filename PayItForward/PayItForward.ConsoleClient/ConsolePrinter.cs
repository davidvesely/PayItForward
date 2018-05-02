namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class ConsolePrinter
    {
        public void Print(Logger someLogger)
        {
            Console.Write(someLogger.LoggerName());
            ConsoleColor previousColor = Console.ForegroundColor;

            foreach (var logger in someLogger.UsersInfo())
            {
                if (someLogger is ColorfulLoggerInfo)
                {
                    Console.ForegroundColor = someLogger.GetConsoleColor;
                }

                Console.Write(logger);
            }

            Console.ForegroundColor = previousColor;
        }
    }
}
