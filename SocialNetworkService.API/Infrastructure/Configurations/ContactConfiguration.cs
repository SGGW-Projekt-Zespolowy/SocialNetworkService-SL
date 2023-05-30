
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
            builder.HasOne(x => x.User).WithMany(y => y.Contacts).HasForeignKey(z => z.UserId);            
        }
    }
}
