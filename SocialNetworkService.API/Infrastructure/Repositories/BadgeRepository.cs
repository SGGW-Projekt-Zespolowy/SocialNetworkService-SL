using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class BadgeRepository : IBadgeRepository
    {
        private readonly DatabaseContext _dbContext;

        public BadgeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Badge badge)
        {
            _dbContext.Set<Badge>().Add(badge);
        }

        public void Remove(Badge badge)
        {
            _dbContext.Set<Badge>().Remove(badge);
        }

        public void Update(Badge badge)
        {
            _dbContext.Set<Badge>().Update(badge);
        }
    }
}
