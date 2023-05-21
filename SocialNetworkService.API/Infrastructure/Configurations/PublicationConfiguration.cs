
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
            builder.HasMany<CoAuthor>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(coAuthor => coAuthor.PublicationId).IsRequired();
            builder.HasMany<Hashtag>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(hashtag => hashtag.RelatedItemId).IsRequired();
            builder.HasMany<Reaction>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
            builder.HasMany<Comment>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(comment => comment.ParentPostId).IsRequired();
            builder.OwnsOne(x => x.Title);
            builder.OwnsOne(x => x.Link);
            builder.OwnsOne(x => x.Type);
        }
    }
}
