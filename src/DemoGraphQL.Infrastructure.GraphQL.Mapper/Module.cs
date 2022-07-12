using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoGraphQL.Infrastructure.GraphQL.Mapper
{
    public static class Module
    {
        public static IServiceCollection ConfigureMapperGraphQL(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));
        }
    }
}
