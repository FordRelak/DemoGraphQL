using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBooks
{
    public class GetBooksQueryExtensions : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(nameof(Resolver.GetBooks).ToGqlName())
                .Type<ListType<BookType>>()
                .ResolveWith<Resolver>(resolver => resolver.GetBooks(default))
                .UseDbContext<GQDbContext>()
                .UseProjection()
                .Description("Получение всех книг.")
                ;
        }

        private class Resolver
        {
            public IQueryable<Book> GetBooks([ScopedService] GQDbContext context)
            {
                return context.Books;
            }
        }
    }
}
