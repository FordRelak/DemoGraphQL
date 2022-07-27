using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.DataLoaders;
using DemoGraphQL.Infrastructure.GraphQL.Types;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries.Books.GetBookById
{
    public class GetBookQueryExtension : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(nameof(Resolver.GetBookAsync).ToGqlName())
                .Type<BookType>()
                .Argument("id", a => a.Type<IdType>())
                .ResolveWith<Resolver>(resolver => resolver.GetBookAsync(default!, default, default))
                .UseProjection()
                .UseDataloader<GetBookDataLoader>()
                .Description("Получение книги по идентификатору.");
        }

        private class Resolver
        {
            public async Task<Book> GetBookAsync(
                Guid id,
                GetBookDataLoader getBookDataLoader,
                CancellationToken cancellationToken)
            {
                return await getBookDataLoader.LoadAsync(id, cancellationToken);
            }
        }
    }
}
