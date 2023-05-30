
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
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
            builder.OwnsOne(x => x.Degree);
        }
    }
}
