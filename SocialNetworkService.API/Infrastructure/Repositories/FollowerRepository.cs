using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class FollowerRepository : IFollowerRepository
    {
        private readonly DatabaseContext _dbContext;

        public FollowerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Follower follower)
        {
            _dbContext.Set<Follower>().Add(follower);
        }

        public void Remove(Follower follower)
        {
            _dbContext.Set<Follower>().Remove(follower);
        }

        public void Update(Follower follower)
        {
            _dbContext.Set<Follower>().Update(follower);
        }
    }
}
