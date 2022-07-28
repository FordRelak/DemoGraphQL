using DemoGraphQL.Domain;

namespace DemoGraphQL.Infrastructure.GraphQL.Types
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor
                .Description("Хнига");

            descriptor
                .Field(book => book.Publisher)
                .ResolveWith<PublisherResolver>(resolver => resolver.GetPublisher(default!, default!))
                .UseDbContext<GQDbContext>()
                .UseProjection()
                .Description("Публикатор");

            descriptor
                .Field(book => book.Author)
                .ResolveWith<AuthorResolver>(resolver => resolver.GetAuthor(default!, default!))
                .UseDbContext<GQDbContext>()
                .UseProjection()
                .Description("Автор");
        }

        private class PublisherResolver
        {
            public IQueryable<Publisher> GetPublisher(
                [Parent] Book book,
                [ScopedService] GQDbContext context)
            {
                return context.Publishers.Where(publisher => publisher.Id == book.PublisherId);
            }
        }

        private class AuthorResolver
        {
            public IQueryable<Author> GetAuthor(
                [Parent] Book book,
                [ScopedService] GQDbContext context)
            {
                return context.Authors.Where(author => author.Id == book.AuthorId);
            }
        }
    }
}
