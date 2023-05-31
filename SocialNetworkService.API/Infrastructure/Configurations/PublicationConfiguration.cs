
using Domain.Entities;
using Domain.ValueObjects;
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
            builder.Property(p => p.Title).HasConversion(c => c.Value, value => Title.Create(value).Value);
            builder.Property(p => p.Link).HasConversion(c => c.Value, value => Link.Create(value).Value);
            builder.Property(p => p.Type).HasConversion(c => c.Value, value => MedicalSpecialization.Create(value).Value);
            builder.HasOne(x => x.Author).WithMany(y => y.Publications).OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.AuthorId);
        }
    }
}
