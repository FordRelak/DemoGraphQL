using DemoGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoGraphQL.Infrastructure.Persistence.EF.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books);

            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books);
        }
    }
}