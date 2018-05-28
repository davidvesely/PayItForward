using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayItForward.Common
{
    public class ConnectionStringResolver
    {
        public string GetConnectionString()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false);
            var configuration = configBuilder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;

        }
    }
}
