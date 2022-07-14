using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.Persistence.EF;

namespace DemoGraphQL.Infrastructure.GraphQL.Subscriptions.Books
{
    [ExtendObjectType(typeof(Subscription))]
    public class UpdateBookSubscription
    {
        [Subscribe]
        [UseDbContext(typeof(GQDbContext))]
        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Book> BookUpdated(
            [Topic] Guid bookId,
            [EventMessage] Book book,
            [ScopedService] GQDbContext context)
        {
            return context.Books.Where(book => book.Id == bookId);
        }
    }
}
