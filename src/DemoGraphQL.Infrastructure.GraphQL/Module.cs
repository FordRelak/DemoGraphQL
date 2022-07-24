using DemoGraphQL.Infrastructure.GraphQL.DataLoaders;
using DemoGraphQL.Infrastructure.GraphQL.Mutations;
using DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor;
using DemoGraphQL.Infrastructure.GraphQL.Queries;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBookById;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBooks;
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
                .AddMutationType<Mutation>()
                //.AddSubscriptionType<Subscription>()

                .AddType<BookType>()
                .AddTypeExtension<GetBooksQueryExtensions>()
                .AddTypeExtension<GetBookQueryExtension>()

                .AddType<AddAuthorMutationExtension>()

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
