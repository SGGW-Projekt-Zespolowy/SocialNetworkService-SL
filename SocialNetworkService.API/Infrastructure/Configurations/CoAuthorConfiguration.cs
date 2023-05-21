
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
            builder.HasIndex(a => new { a.AuthorId, a.PublicationId }).IsUnique();
        }
    }
}
