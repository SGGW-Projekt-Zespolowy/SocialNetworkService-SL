using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.ToTable("Badges");
            builder.HasKey(k => k.Id);
            builder.HasIndex(b => new { b.AuthorId, b.Name }).IsUnique();
            builder.Property(x => x.Name).HasConversion(
                c => c.ToString(), c => (BadgeEnum)Enum.Parse(typeof(BadgeEnum),c));
        }
    }
}
