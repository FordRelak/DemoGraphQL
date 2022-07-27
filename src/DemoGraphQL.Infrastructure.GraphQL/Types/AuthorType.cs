using DemoGraphQL.Domain;

namespace DemoGraphQL.Infrastructure.GraphQL.Types
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor
                .Description("Автор");

            descriptor
                .Field(author => author.Id)
                .Description("Идентификатор автора");

            descriptor
                .Field(author => author.Name)
                .Description("Имя автора");

            descriptor
                .Field(author => author.Books)
                .Description("Книги автора")
                .Type<BookType>()
                .ResolveWith<BookResolver>(resolver => resolver.GetBooks(default!))
                .UseDbContext<GQDbContext>()
                .UseProjection();

        }

        private class BookResolver
        {
            public IQueryable<Book> GetBooks([ScopedService] GQDbContext context)
            {
                return context.Books;
            }
        }
    }
}
