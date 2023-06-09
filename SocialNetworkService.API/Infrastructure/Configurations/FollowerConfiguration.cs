
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FollowerConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder.ToTable("Followers");
            builder.HasKey(k => k.Id);
            builder.HasIndex(f => new { f.FollowerId, f.FollowedUserId }).IsUnique();
            builder.HasOne(x => x.FollowedUser).WithMany(y => y.Followers).OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.FollowedUserId);
            builder.HasOne(x => x.FollowerUser).WithMany(y => y.FollowedByMeUsers).OnDelete(DeleteBehavior.NoAction).HasForeignKey(z => z.FollowerId);
        }
    }
}
