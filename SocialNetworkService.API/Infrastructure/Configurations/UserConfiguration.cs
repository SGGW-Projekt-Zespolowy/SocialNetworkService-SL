
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.ValueObjects;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Email).HasConversion(user => user.Value, value => Email.Create(value).Value);
            builder.Property(x => x.FirstName).HasConversion(user => user.Value, value => FirstName.Create(value).Value);
            builder.Property(x => x.LastName).HasConversion(user => user.Value, value => LastName.Create(value).Value);
            builder.Property(x => x.Degree).HasConversion(user => user.Value, value => Degree.Create(value).Value);            
        }
    }
}