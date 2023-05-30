
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.ToTable("Publications");
            builder.HasKey(k => k.Id);
            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Link);
            builder.OwnsOne(x => x.Type);
            builder.HasOne(x => x.Author).WithMany(y => y.Publications).OnDelete(DeleteBehavior.Cascade).HasForeignKey(z => z.AuthorId);
        }
    }
}
