
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(k => k.Id);
            builder.HasIndex(c => new { c.UserId, c.ContactId }).IsUnique();
            builder.HasOne(x => x.User).WithMany(y => y.Contacts).OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.UserId);
            builder.HasOne(x => x.ContactUser).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.ContactId);
        }
    }
}
