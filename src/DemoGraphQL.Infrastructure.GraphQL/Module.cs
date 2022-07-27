using DemoGraphQL.Infrastructure.GraphQL.DataLoaders;
using DemoGraphQL.Infrastructure.GraphQL.Mutations;
using DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor;
using DemoGraphQL.Infrastructure.GraphQL.Queries;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBookById;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBooks;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions.AddAuthor;
using DemoGraphQL.Infrastructure.GraphQL.Types;
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

                .AddType<BookType>()
                .AddTypeExtension<GetBooksQueryExtensions>()
                .AddTypeExtension<GetBookQueryExtension>()

                .AddMutationType<Mutation>()
                .AddType<AddAuthorMutationExtension>()

                .AddSubscriptionType<Subscription>()
                .AddTypeExtension<AddAuthorSubscriptionType>()

                .AddDataLoader<GetBookDataLoader>()

                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddProjections()
                .AddDefaultTransactionScopeHandler()
                .AddMutationConventions(true);

            return services;
        }
    }
}
