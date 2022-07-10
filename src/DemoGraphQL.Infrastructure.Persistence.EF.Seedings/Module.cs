using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.Persistence.EF.Seedings
{
    public static class Module
    {
        public static IServiceCollection ConfigureSeeder(this IServiceCollection services)
        {
            return services
                .AddTransient<Seeder>();
        }
    }
}
