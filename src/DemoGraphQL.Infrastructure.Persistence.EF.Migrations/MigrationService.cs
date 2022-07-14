using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.Infrastructure.Persistence.EF.Migrations
{
    public class MigrationService
    {
        private readonly DbContext _context;

        public MigrationService(DbContext context)
        {
            _context = context;
        }

        public async Task ApplyMigrationIfNeed()
        {
            IEnumerable<string> migrations = await _context.Database.GetPendingMigrationsAsync();
            if(migrations.Any())
            {
                await _context.Database.MigrateAsync();
            }
        }
    }
}
