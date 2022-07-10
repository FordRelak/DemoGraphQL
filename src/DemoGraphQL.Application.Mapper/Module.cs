using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoGraphQL.Application.Mapper
{
    public static class Module
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            return services
                .AddAutoMapper(config => config.AddMaps(Assembly.GetExecutingAssembly()));
        }
    }
}
