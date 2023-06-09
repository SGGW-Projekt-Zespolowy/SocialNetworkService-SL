using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class CoAuthorRepository : ICoAuthorRepository
    {
        private readonly DatabaseContext _dbContext;

        public CoAuthorRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CoAuthor coAuthor)
        {
            _dbContext.Set<CoAuthor>().Add(coAuthor);
        }

        public void Remove(CoAuthor coAuthor)
        {
            _dbContext.Set<CoAuthor>().Remove(coAuthor);
        }

        public void Update(CoAuthor coAuthor)
        {
            _dbContext.Set<CoAuthor>().Update(coAuthor);
        }
    }
}
