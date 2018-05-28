namespace PayItForward.Common
{
    using Microsoft.Extensions.Configuration;

    public class ConnectionStringResolver
    {
        public static string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);
            var configuration = configBuilder.Build();

            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
