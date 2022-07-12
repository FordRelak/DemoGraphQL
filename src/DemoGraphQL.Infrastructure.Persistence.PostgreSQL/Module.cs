using DemoGraphQL.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.Persistence.PostgreSQL
{
    public static class Module
    {
        public static IServiceCollection ConfigureNpgsql(this IServiceCollection services, string connectionString)
        {
            services.AddPooledDbContextFactory<GQDbContext>(options =>
            {
                options.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly("DemoGraphQL.Infrastructure.Persistence.EF.Migrations");
                })
                .LogTo(Console.WriteLine);

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }, poolSize: 32);

            services.AddTransient<DbContext>(s => s.GetRequiredService<IDbContextFactory<GQDbContext>>()
                                                .CreateDbContext());

            services.AddTransient<GQDbContext>(s => s.GetRequiredService<IDbContextFactory<GQDbContext>>()
                                                .CreateDbContext());

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
