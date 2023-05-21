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
            builder.HasMany<Hashtag>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(hashtag => hashtag.RelatedItemId).IsRequired();
            builder.HasMany<Reaction>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
            builder.HasMany<Comment>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(comment => comment.ParentPostId).IsRequired();
            builder.OwnsOne(x => x.Type);
        }
    }
}
