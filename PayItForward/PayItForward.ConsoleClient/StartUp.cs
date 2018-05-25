namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddIdentity<PayItForward.Data.Models.User, IdentityRole>();

            // Seeding data from database
            InitializeData(services);

            // Log dbusers info
            PrintData();
        }

        private static void InitializeData(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            using (var context = new PayItForwardContextFactory().CreateDbContext())
            {
                DbInitializer initializer = new DbInitializer();

                initializer.Initialize(context, serviceProvider);
            }
        }

        private static void PrintData()
        {
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();

            List<Logger> loggers = new List<Logger>()
             {
                new BasicLoggerInfo("I am BasicLoggerInfo", consoleWrapper),
                new ColorfulLoggerInfo("ColorfulLoggerInfo", ConsoleColor.Blue, consoleWrapper),
                new DetailedLoggerInfo("DetailedLoggerInfo", consoleWrapper)
             };

            // Logging data from database
            using (var payItForwardDbContext = new PayItForwardContextFactory().CreateDbContext())
            {
                var usersFromdb = payItForwardDbContext.Users.ToList();
                List<ILoggable> localUsers = new List<ILoggable>();

                if (payItForwardDbContext.Users.Any())
                {
                    foreach (var user in usersFromdb)
                    {
                        localUsers.Add(new User(
                                user.FirstName,
                                user.LastName,
                                user.Id));
                        if (localUsers.Count == 3)
                        {
                            break;
                        }
                    }

                    foreach (var logger in loggers)
                    {
                        logger.PrintInfoList(localUsers);
                    }
                }
            }
        }
    }
}
