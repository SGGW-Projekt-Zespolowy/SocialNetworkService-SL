using Domain.Entities;
using Domain.ValueObjects;
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
            builder.Property(p => p.Type).HasConversion(c => c.Value, value => MedicalSpecialization.Create(value).Value);
            builder.Property(p => p.Title).HasConversion(c => c.Value, value => Title.Create(value).Value);
            builder.HasOne(x => x.Author).WithMany(y => y.Posts).OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.AuthorId);
        }
    }
}
