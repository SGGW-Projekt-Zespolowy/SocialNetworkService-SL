
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.ToTable("Reactions");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.ReactionType)
                .HasConversion(c => c.ToString(),c => 
                (ReactionTypeEnum)Enum.Parse(typeof(ReactionTypeEnum), c));
        }
    }
}
