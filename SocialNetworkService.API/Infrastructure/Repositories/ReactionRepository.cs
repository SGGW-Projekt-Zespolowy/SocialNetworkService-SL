using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.Reaction;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ReactionRepository : IReactionRepository
    {
        private readonly DatabaseContext _dbContext;

        public ReactionRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Reaction reaction, CancellationToken cancellationToken)
        {
            _dbContext.Set<Reaction>().Add(reaction);    
        }

        public async Task<Reaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await ApplySpecification(new ReactionByIdSpecification(id)).FirstOrDefaultAsync(cancellationToken);
        public async Task<List<Reaction>?> GetByPostIdsAsync(List<Guid> postIds, CancellationToken cancellationToken)
            => await ApplySpecification(new ReactionByPostIdsSpecification(postIds)).ToListAsync(cancellationToken);
        public async Task<Reaction?> GetByPostIdAndAuthorIdAsync(Guid postId, Guid authorId, CancellationToken cancellationToken)
            => await ApplySpecification(new ReactionByRelatedItemAndAuthoerIdSpecification(postId, authorId)).
            FirstOrDefaultAsync(cancellationToken);
        public IQueryable<Reaction> ApplySpecification(Specification<Reaction> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Reaction>(), specification);
        }
        public void Remove(Reaction reaction, CancellationToken cancellationToken)
        {
            _dbContext.Set<Reaction>().Remove(reaction);
        }

        public void Update(Reaction reaction, CancellationToken cancellationToken)
        {
            _dbContext.Set<Reaction>().Update(reaction);
        }

        public async Task<List<Reaction>> GetByRelatedItemId(Guid relatedItemId, CancellationToken cancellationToken)
        {
            IQueryable<Reaction> reactionsQuery = _dbContext.Set<Reaction>();
            var reactions = await reactionsQuery
                .Where(r => r.RelatedItemId == relatedItemId)
                .ToListAsync(cancellationToken);

            return reactions;
        }
    }
}
