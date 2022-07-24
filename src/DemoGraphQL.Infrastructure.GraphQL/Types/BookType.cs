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
                .ResolveWith<PublisherResolver>(resolver => resolver.GetPublishers(default!))
                .UseDbContext<GQDbContext>()
                .UseProjection()
                .Description("Публикатор");
        }

        private class PublisherResolver
        {
            public IQueryable<Publisher> GetPublishers([ScopedService] GQDbContext context)
            {
                return context.Publishers;
            }
        }
    }
}
