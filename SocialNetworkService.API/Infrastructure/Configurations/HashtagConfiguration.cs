
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class HashtagConfiguration : IEntityTypeConfiguration<Hashtag>
    {
        public void Configure(EntityTypeBuilder<Hashtag> builder)
        {
            builder.ToTable("Hashtags");
            builder.HasKey(k => k.Id);
            builder.HasIndex(h => new { h.Name, h.RelatedItemId }).IsUnique();
        }
    }
}
