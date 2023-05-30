
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
            builder.HasOne(x => x.ParentPost).WithMany(y => y.Comments).HasForeignKey(z => z.ParentPostId);
            builder.HasOne(x => x.ParentComment).WithMany(y => y.Comments).HasForeignKey(z => z.ParentCommentId);
        }
    }
}
