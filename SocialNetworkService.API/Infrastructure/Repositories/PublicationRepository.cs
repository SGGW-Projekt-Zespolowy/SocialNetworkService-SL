using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class PublicationRepository : IPublicationRepository
    {
        private readonly DatabaseContext _dbContext;

        public PublicationRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Publication publication)
        {
            _dbContext.Set<Publication>().Add(publication);
        }

        public async Task<Publication?> GetByIdWithAllAsync(Guid id)
        {
            return await _dbContext.Set<Publication>()
                .Include(x => x.CoAuthors)
                .Include(x => x.Hashtags)
                .Include(x => x.Reactions)
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Publication publication)
        {
            _dbContext.Set<Publication>().Remove(publication);
        }

        public void Update(Publication publication)
        {
            _dbContext.Set<Publication>().Update(publication);
        }
    }
}
