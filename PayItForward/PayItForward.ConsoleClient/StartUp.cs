namespace PayItForward.ConsoleClient
{
    using PayItForward.Data;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();
            List<ILoggable> users = new List<ILoggable>()
             {
                new User("Viki", "Penkova", 21),
                new User("Aleks", "Stoycheva", 24),
                new User("Peter", "Petkov", 25)
             };

            List<Logger> loggers = new List<Logger>()
            {
                new BasicLoggerInfo("I am BasicLoggerInfo", consoleWrapper),
                new ColorfulLoggerInfo("ColorfulLoggerPrint", ConsoleColor.Blue, consoleWrapper),
                new DetailedLoggerInfo("DetailedLoggerInfo", consoleWrapper)
            };

            foreach (var logger in loggers)
            {
                logger.PrintInfoList(users);
            }

            // Seeding data from database part
            using (var context = new PayItForwardContextFactory().CreateDbContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
