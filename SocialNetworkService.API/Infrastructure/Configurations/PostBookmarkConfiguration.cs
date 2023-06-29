using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public sealed class PostBookmarkConfiguration : IEntityTypeConfiguration<PostBookmark>
    {
        public void Configure(EntityTypeBuilder<PostBookmark> builder)
        {
            builder.ToTable("PostBookmarks");
            builder.HasKey(p => p.Id);
            builder.HasIndex(b => new { b.UserId,b.PostId }).IsUnique();
        }
    }
}
