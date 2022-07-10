using DemoGraphQL.Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.Persistence.EF.Migrations.App
{
    internal class Program : IDesignTimeDbContextFactory<DbContext>
    {
        private static void Main(string[] args)
        {
        }

        public DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.ConfigureNpgsql(configuration.GetConnectionString("DemoGraphQL"));

            var _serviceProvider = services.BuildServiceProvider();

            return _serviceProvider.GetService<DbContext>();
        }
    }
}
