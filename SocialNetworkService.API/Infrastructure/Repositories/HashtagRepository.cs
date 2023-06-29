using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.Hashtag;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class HashtagRepository : IHashtagRepository
    {
        private readonly DatabaseContext _dbContext;

        public HashtagRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Hashtag hashtag, CancellationToken cancellationToken)
        {
            _dbContext.Set<Hashtag>().Add(hashtag);
        }

        public void Remove(Hashtag hashtag, CancellationToken cancellationToken)
        {
            _dbContext.Set<Hashtag>().Remove(hashtag);
        }

        public void Update(Hashtag hashtag, CancellationToken cancellationToken)
        {
            _dbContext.Set<Hashtag>().Update(hashtag);
        }

        public async Task<List<Hashtag>> GetAllByIdsAsync(List<Guid> postIds, CancellationToken cancellationToken)
        => await ApplySpecification(new HashtagByPostIdSpecification(postIds)).ToListAsync(cancellationToken);

        public IQueryable<Hashtag> ApplySpecification(Specification<Hashtag> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Hashtag>(), specification);
        }
    }
}
