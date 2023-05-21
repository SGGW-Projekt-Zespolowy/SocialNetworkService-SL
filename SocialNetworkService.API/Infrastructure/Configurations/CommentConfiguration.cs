
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(k => k.Id);
            builder.HasMany<Reaction>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
            builder.HasMany<Comment>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(comment => comment.ParentCommentId).IsRequired()
            .HasForeignKey(comment => comment.ParentPostId).IsRequired();
        }
    }
}
