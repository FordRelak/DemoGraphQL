using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.Persistence.EF;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class DbContextQuery
    {
        [UseDbContext(typeof(GQDbContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Book> GetBooksDbContext(
            [ScopedService] GQDbContext dbContext,
            CancellationToken cancellationToken)
        {
            return dbContext.Books;
        }
    }
}
