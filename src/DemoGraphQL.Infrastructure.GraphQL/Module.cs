using DemoGraphQL.Infrastructure.GraphQL.DataLoaders;
using DemoGraphQL.Infrastructure.GraphQL.Mutations;
using DemoGraphQL.Infrastructure.GraphQL.Mutations.AddAuthor;
using DemoGraphQL.Infrastructure.GraphQL.Mutations.AddBook;
using DemoGraphQL.Infrastructure.GraphQL.Queries;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBookById;
using DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBooks;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions.AddAuthor;
using DemoGraphQL.Infrastructure.GraphQL.Subscriptions.AddBookToAuthor;
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
                .AddTypeExtension<GetBooksQueryExtensions>()
                .AddTypeExtension<GetBookQueryExtension>()

                .AddMutationType<Mutation>()
                .AddTypeExtension<AddAuthorMutationExtension>()
                .AddTypeExtension<AddBookMutationExtension>()

                .AddSubscriptionType<Subscription>()
                .AddTypeExtension<AddAuthorSubscriptionType>()
                .AddTypeExtension<AddBookToAuthorSubscriptionType>()

                .AddDataLoader<GetBookDataLoader>()
                
                .AddType<BookType>()
                .AddType<AuthorType>()
                .AddType<AddBookInputType>()
                .AddType<AddAuthorInputType>()

                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddProjections()
                .AddDefaultTransactionScopeHandler()
                .RegisterDbContext<GQDbContext>(DbContextKind.Pooled)
                .AddMutationConventions(true);

            return services;
        }
    }
}
