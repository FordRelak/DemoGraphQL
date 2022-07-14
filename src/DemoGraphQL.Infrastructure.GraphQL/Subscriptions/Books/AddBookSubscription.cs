using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.GraphQL.Types.Books;
using DemoGraphQL.Infrastructure.Persistence.EF;

namespace DemoGraphQL.Infrastructure.GraphQL.Subscriptions.Books
{
    [ExtendObjectType(typeof(Subscription))]
    public class AddBookSubscription
    {
        [Subscribe]
        [UseDbContext(typeof(GQDbContext))]
        [UseFirstOrDefault]
        public IQueryable<Book> BookAdded(
            [Topic] Guid authorId,
            [EventMessage] BookType book,
            [ScopedService] GQDbContext context)
        {
            return context.Books.Where(book => book.AuthorId == authorId);
        }
    }
}
