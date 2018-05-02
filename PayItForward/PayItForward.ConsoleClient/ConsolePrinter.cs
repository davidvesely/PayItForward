namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class ConsolePrinter
    {
        public void Print(Logger someLogger)
        {
            Console.WriteLine(someLogger.LoggerName());
            ConsoleColor previousColor = Console.ForegroundColor;

            foreach (var logger in someLogger.UsersInfo())
            {
                if (someLogger.GetType() == typeof(ColorfulLoggerPrint))
                {
                    Console.WriteLine(previousColor);
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine(logger);
            }

            Console.ForegroundColor = previousColor;
        }
    }
}
