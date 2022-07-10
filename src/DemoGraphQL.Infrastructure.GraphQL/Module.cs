using DemoGraphQL.Infrastructure.GraphQL.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.GraphQL
{
    public static class Module
    {
        public static IServiceCollection ConfigureHotChocolateGraphQL(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>();

            return services;
        }
    }
}
