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
            });
        }
    }
}
