using DemoGraphQL.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.Infrastructure.GraphQL.DataLoaders
{
    public class GetBookDataLoader : BatchDataLoader<Guid, Book>
    {
        private readonly IDbContextFactory<GQDbContext> _dbContextFactory;

        public GetBookDataLoader(
            IDbContextFactory<GQDbContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<Guid, Book>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            await using GQDbContext context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await context.Books
                .Where(book => keys.Contains(book.Id))
                .ToDictionaryAsync(book => book.Id, cancellationToken);
        }
    }
}
