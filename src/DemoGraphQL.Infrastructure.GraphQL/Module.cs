using DemoGraphQL.Infrastructure.GraphQL.Mutations;
using DemoGraphQL.Infrastructure.GraphQL.Mutations.Books;
using DemoGraphQL.Infrastructure.GraphQL.Queries;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions.Books;
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
                .AddSubscriptionType<Subscription>()

                .AddTypeExtension<SimpleQuery>()
                .AddTypeExtension<DbContextQuery>()

                .AddTypeExtension<AddBookMutation>()
                .AddTypeExtension<UpdateBookMutation>()

                .AddTypeExtension<AddBookSubscription>()
                .AddTypeExtension<UpdateBookSubscription>()

                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddProjections();

            return services;
        }
    }
}
