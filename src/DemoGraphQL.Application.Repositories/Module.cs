using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Application.Repositories
{
    public static class Module
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
