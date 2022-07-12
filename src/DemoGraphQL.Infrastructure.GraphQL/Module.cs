using DemoGraphQL.Infrastructure.GraphQL.Mutations;
using DemoGraphQL.Infrastructure.GraphQL.Queries;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.Infrastructure.GraphQL
{
    public static class Module
    {
        public static IServiceCollection ConfigureHotChocolateGraphQL(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()

                .AddQueryType<Query>()
                .AddMutationType<Mutation>()

                .AddTypeExtension<SimpleQuery>()
                .AddTypeExtension<DbContextQuery>()

                .AddTypeExtension<AddBookMutation>()
                .AddTypeExtension<UpdateBookMutation>()
                
                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddProjections();

            return services;
        }
    }
}
