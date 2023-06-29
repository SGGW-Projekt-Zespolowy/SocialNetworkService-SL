using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class FollowerRepository : IFollowerRepository
    {
        private readonly DatabaseContext _dbContext;

        public FollowerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Follower follower, CancellationToken cancellationToken)
        {
            _dbContext.Set<Follower>().Add(follower);
        }

        public async Task<Follower> GetByIdsAsync(Guid followerId, Guid followedUserId, CancellationToken cancellationToken)
            => await ApplySpecification(new GetFollowerByIdSpecification(followerId, followedUserId)).FirstOrDefaultAsync(cancellationToken);
        public IQueryable<Follower> ApplySpecification(Specification<Follower> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Follower>(), specification);
        }

        public async Task<List<Follower>> GetAll(Guid followerId, int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Follower> followersQuery = _dbContext.Set<Follower>();
            var followers = await followersQuery
                .Where(f => f.FollowerId == followerId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(f => f.FollowedUser)
                .ToListAsync(cancellationToken);

            return followers;
        }

        public void Remove(Follower follower, CancellationToken cancellationToken)
        {
            _dbContext.Set<Follower>().Remove(follower);
        }
    }
}
