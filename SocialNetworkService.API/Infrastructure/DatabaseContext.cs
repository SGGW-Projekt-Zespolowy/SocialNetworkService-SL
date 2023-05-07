using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users");   
                builder.HasKey(k=>k.Id);
                builder.HasMany<Specialization>()
                .WithOne()
                .HasForeignKey(specialization => specialization.AuthorId).IsRequired();
                builder.HasMany<Contact>()
                .WithOne()
                .HasForeignKey(contact => contact.UserId).IsRequired();
                builder.HasMany<Follower>()
                .WithOne()
                .HasForeignKey(follower => follower.FollowerId).IsRequired();
                builder.HasMany<Publication>()
                .WithOne()
                .HasForeignKey(publication => publication.AuthorId).IsRequired();
                builder.HasMany<Post>()
                .WithOne()
                .HasForeignKey(post => post.AuthorId).IsRequired();
                builder.HasMany<Badge>()
                .WithOne()
                .HasForeignKey(badge => badge.AuthorId).IsRequired();
            });

            modelBuilder.Entity<Specialization>(builder =>
            {
                builder.ToTable("Specializations");
                builder.HasKey(k => k.Id);
                builder.HasIndex(i => new { i.MedicalSpecialization, i.AuthorId }).IsUnique();
            });

            modelBuilder.Entity<Reaction>(builder =>
            {
                builder.ToTable("Reactions");
                builder.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Publication>(builder =>
            {
                builder.ToTable("Publications");
                builder.HasKey(k => k.Id);
                builder.HasMany<CoAuthor>()
                .WithOne()
                .HasForeignKey(coAuthor => coAuthor.PublicationId).IsRequired();
                builder.HasMany<Hashtag>()
                .WithOne()
                .HasForeignKey(hashtag => hashtag.RelatedItemId).IsRequired();
                builder.HasMany<Reaction>()
                .WithOne()
                .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
                builder.HasMany<Comment>()
                .WithOne()
                .HasForeignKey(comment => comment.ParentPostId).IsRequired();
            });

            modelBuilder.Entity<Post>(builder =>
            {
                builder.ToTable("Posts");
                builder.HasKey(k => k.Id);
                builder.HasMany<Hashtag>()
                .WithOne()
                .HasForeignKey(hashtag => hashtag.RelatedItemId).IsRequired();
                builder.HasMany<Reaction>()
                .WithOne()
                .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
                builder.HasMany<Comment>()
                .WithOne()
                .HasForeignKey(comment => comment.ParentPostId).IsRequired();
            });

            modelBuilder.Entity<Hashtag>(builder =>
            {
                builder.ToTable("Hashtags");
                builder.HasKey(k => k.Id);
                builder.HasIndex(h => new { h.Name, h.RelatedItemId }).IsUnique();
            });

            modelBuilder.Entity<Follower>(builder =>
            {
                builder.ToTable("Followers");
                builder.HasKey(k => k.Id);
                builder.HasIndex(f => new { f.FollowerId , f.FollowedUserId}).IsUnique();
            });

            modelBuilder.Entity<Credentials>(builder => 
            {
                builder.ToTable("Credentials");
                builder.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Contact>(builder =>
            {
                builder.ToTable("Contacts");
                builder.HasKey(k => k.Id);
                builder.HasIndex(c => new { c.UserId, c.ContactId }).IsUnique();
            });

            modelBuilder.Entity<Comment>(builder =>
            {
                builder.ToTable("Comments");
                builder.HasKey(k => k.Id);
                builder.HasMany<Reaction>()
                .WithOne()
                .HasForeignKey(reaction => reaction.RelatedItemId).IsRequired();
                builder.HasMany<Comment>()
                .WithOne()
                .HasForeignKey(comment => comment.ParentCommentId).IsRequired()
                .HasForeignKey(comment => comment.ParentPostId).IsRequired();
            });

            modelBuilder.Entity<CoAuthor>(builder =>
            {
                builder.ToTable("CoAuthors");
                builder.HasKey(k => k.Id);
                builder.HasIndex(a => new {a.AuthorId, a.PublicationId}).IsUnique();
            });

            modelBuilder.Entity<Badge>(builder =>
            {
                builder.ToTable("Badges");
                builder.HasKey(k => k.Id);
                builder.HasIndex(b => new {b.AuthorId, b.Name}).IsUnique();
            });
        }
    }
}
