namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PayItForward.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IConsoleWrapper consoleWrapper = new ConsoleWrapper();

            // var serviceProvider = new ServiceCollection().BuildServiceProvider();
            IServiceCollection services = new ServiceCollection();

            var serviceProvider = services.BuildServiceProvider();

            services.AddIdentity<PayItForward.Data.Models.User, IdentityRole>();

            // List<ILoggable> users = new List<ILoggable>()
            // {
            //    new User("Viki", "Penkova", new Guid("viki")),
            //    new User("Aleks", "Stoycheva", new Guid("aleks")),
            //    new User("Peter", "Petkov", new Guid("peter"))
            // };

            // List<Logger> loggers = new List<Logger>()
            // {
            //    new BasicLoggerInfo("I am BasicLoggerInfo", consoleWrapper),
            //    new ColorfulLoggerInfo("ColorfulLoggerInfo", ConsoleColor.Blue, consoleWrapper),
            //    new DetailedLoggerInfo("DetailedLoggerInfo", consoleWrapper)
            // };

            // foreach (var logger in loggers)
            // {
            //    logger.PrintInfoList(users);
            // }

            // Seeding data from database
            using (var context = new PayItForwardContextFactory().CreateDbContext())
            {
                DbInitializer initializer = new DbInitializer();

                initializer.Initialize(context, serviceProvider);
            }

            // Logging data from database
            Logger colorfulLogger = new ColorfulLoggerInfo("DbUserColorfulLogger", ConsoleColor.Blue, consoleWrapper);

            var optionsBuilder = new DbContextOptionsBuilder<PayItForwardDbContext>();

            colorfulLogger.LoggerName();

            using (var payItForwardDbContext = new PayItForwardDbContext(optionsBuilder.Options))
            {
                var dbusersTolist = payItForwardDbContext.Users.ToList();
                List<ILoggable> dbusers = new List<ILoggable>();

                if (payItForwardDbContext.Users.Any())
                {
                    foreach (var user in dbusersTolist)
                    {
                        dbusers = new List<ILoggable>()
                         {
                            new User(
                                payItForwardDbContext.Users.FirstOrDefault(u => u.FirstName == "Aleksandra").FirstName,
                                dbusersTolist.FirstOrDefault(u => u.LastName == "Stoicheva").LastName,
                                dbusersTolist.FirstOrDefault(u => u.FirstName == "Aleksandra").Id),
                             new User(
                                dbusersTolist.FirstOrDefault(u => u.FirstName == "Peter").FirstName,
                                dbusersTolist.FirstOrDefault(u => u.LastName == "Petkov").LastName,
                                dbusersTolist.FirstOrDefault(u => u.FirstName == "Peter").Id),
                            new User(
                                payItForwardDbContext.Users.FirstOrDefault(u => u.FirstName == "Viktoria").FirstName,
                                dbusersTolist.FirstOrDefault(u => u.LastName == "Penkova").LastName,
                                dbusersTolist.FirstOrDefault(u => u.FirstName == "Viktoria").Id)
                        };
                    }

                    colorfulLogger.PrintInfoList(dbusers);
                }
            }
        }
    }
}
