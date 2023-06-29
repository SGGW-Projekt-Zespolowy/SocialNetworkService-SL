using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Specifications;
using Infrastructure.Specifications.Publication;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class PublicationRepository : IPublicationRepository
    {
        private readonly DatabaseContext _dbContext;

        public PublicationRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Publication publication, CancellationToken cancellationToken)
        {
            _dbContext.Set<Publication>().Add(publication);
        }

        public async Task<Publication?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await ApplySpecification(new PublicationByIdSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public async Task<Publication?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken)
            => await ApplySpecification(new PublicationByIdIncludeAllSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<Publication>> GetByUserIdWithAllAsync(Guid userId, CancellationToken cancellationToken)
            => await ApplySpecification(new PublicationByUseriIdSpecification(userId)).ToListAsync(cancellationToken);

        public IQueryable<Publication> ApplySpecification(Specification<Publication> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<Publication>(), specification);
        }

        public void Remove(Publication publication, CancellationToken cancellationToken)
        {
            _dbContext.Set<Publication>().Remove(publication);
        }

        public void Update(Publication publication, CancellationToken cancellationToken)
        {
            _dbContext.Set<Publication>().Update(publication);
        }
    }
}
