
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("Specializations");
            builder.HasKey(k => k.Id);
            builder.HasIndex(i => new { i.MedicalSpecialization, i.AuthorId }).IsUnique();
            builder.Property(x => x.MedicalSpecialization).HasConversion(c => c.ToString(),
                c => (MedicalSpecializationEnum)Enum.Parse(typeof(MedicalSpecializationEnum), c));
            builder.HasOne(x => x.User).WithMany(y => y.Specializations).HasForeignKey(z => z.AuthorId);
        }
    }
}
