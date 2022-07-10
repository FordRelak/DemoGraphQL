using DemoGraphQL.Application.Mapper;
using DemoGraphQL.Application.Repositories;
using DemoGraphQL.Infrastructure.GraphQL;
using DemoGraphQL.Infrastructure.Persistence.EF;
using DemoGraphQL.Infrastructure.Persistence.EF.Migrations;
using DemoGraphQL.Infrastructure.Persistence.EF.Seedings;
using DemoGraphQL.Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.WebApi
{
    public class Program
    {
        private static ConfigurationManager _configuration;

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            _configuration = builder.Configuration;

            ConfigureServices(builder.Services);

            var app = builder.Build();

            Configure(app);

            await ApplyMigrationIfNeed(app);
            await SeedIfNeed(app);
            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureNpgsql(_configuration.GetConnectionString("DemoGraphQL"));
            services.ConfigureRepositories();
            services.ConfigureMapper();
            services.ConfigureSeeder();
            services.ConfigureMigration();
            services.ConfigureHotChocolateGraphQL();
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }

        private static async Task SeedIfNeed(WebApplication app)
        {
            var seeder = app.Services.GetRequiredService<Seeder>();
            await seeder.SeedIfNeed();
        }
        
        private static async Task ApplyMigrationIfNeed(WebApplication app)
        {
            var migrator = app.Services.GetRequiredService<MigrationService>();
            await migrator.ApplyMigrationIfNeed();
        }
    }
}
