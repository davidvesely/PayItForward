namespace PayItForward.ConsoleClient
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PayItForward.Common;
    using PayItForward.ConsoleClient.DataPrint;
    using PayItForward.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            var connectionString = ConnectionStringResolver.GetConnectionString();

            services.AddDbContext<PayItForwardDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddIdentity<PayItForward.Data.Models.User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<PayItForwardDbContext>()
                .AddDefaultTokenProviders();

            var serviceProvider = services.BuildServiceProvider();

            // Seeding data from database
            InitializeData(serviceProvider);

            // Print dbusers info
            Printer.PrintData();
        }

        private static void InitializeData(ServiceProvider serviceProvider)
        {
            DbInitializer initializer = new DbInitializer(serviceProvider);
            initializer.Initialize();
        }
    }
}
