using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.Persistence.EF.Migrations
{
    public static class Module
    {
        public static IServiceCollection ConfigureMigration(this IServiceCollection services)
        {
            return services.AddTransient<MigrationService>();
        }
    }
}
