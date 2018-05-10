namespace PayItForward.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class PayItForwardContextFactory : IDesignTimeDbContextFactory<PayItForwardDbContext>
    {
        private static string connectionString;

        public PayItForwardDbContext CreateDbContext()
        {
            return new PayItForwardDbContext(null);
        }

        public PayItForwardDbContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<PayItForwardDbContext>();
            builder.UseSqlServer(connectionString);

            return new PayItForwardDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new System.ArgumentException();
            }
        }
    }
}
