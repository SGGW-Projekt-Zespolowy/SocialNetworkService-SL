
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CoAuthorConfiguration : IEntityTypeConfiguration<CoAuthor>
    {
        public void Configure(EntityTypeBuilder<CoAuthor> builder)
        {
            builder.ToTable("CoAuthors");
            builder.HasKey(k => k.Id);
            builder.HasIndex(a => new { a.UserId, a.PublicationId }).IsUnique();
            builder.HasOne(x => x.Publication).WithMany(y => y.CoAuthors).HasForeignKey(z => z.PublicationId);            
            builder.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.UserId);
        }
    }
}
