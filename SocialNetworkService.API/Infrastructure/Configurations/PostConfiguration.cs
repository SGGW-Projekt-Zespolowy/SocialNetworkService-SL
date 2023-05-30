using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(k => k.Id);
            builder.OwnsOne(x => x.Type);
            builder.HasOne(x => x.Author).WithMany(y => y.Posts).HasForeignKey(z => z.AuthorId);
        }
    }
}
