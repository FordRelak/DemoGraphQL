using DemoGraphQL.Domain;
using DemoGraphQL.Infrastructure.Persistence.EF;
using HotChocolate.Language;
using HotChocolate.Resolvers;

namespace DemoGraphQL.Infrastructure.GraphQL.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class DbContextQuery
    {
        [UseDbContext(typeof(GQDbContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Book> GetBooksDbContext(IResolverContext context,[ScopedService] GQDbContext dbContext, CancellationToken cancellationToken)
        {
            var a =  context.ArgumentLiteral<ObjectValueNode>("where");
            return dbContext.Books;
        }
    }
}
