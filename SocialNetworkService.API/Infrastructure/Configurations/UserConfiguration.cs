
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);
            builder.HasMany<Specialization>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(specialization => specialization.AuthorId).IsRequired();
            builder.HasMany<Contact>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(contact => contact.UserId).IsRequired();
            builder.HasMany<Follower>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(follower => follower.FollowerId).IsRequired();
            builder.HasMany<Publication>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(publication => publication.AuthorId).IsRequired();
            builder.HasMany<Post>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(post => post.AuthorId).IsRequired();
            builder.HasMany<Badge>()
            .WithOne().OnDelete(DeleteBehavior.Cascade)
            .HasForeignKey(badge => badge.AuthorId).IsRequired();
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
            builder.OwnsOne(x => x.Degree);
        }
    }
}
