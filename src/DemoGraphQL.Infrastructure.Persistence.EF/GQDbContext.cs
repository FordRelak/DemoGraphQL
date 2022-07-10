using DemoGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DemoGraphQL.Infrastructure.Persistence.EF
{
    public class GQDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public GQDbContext(DbContextOptions<GQDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}