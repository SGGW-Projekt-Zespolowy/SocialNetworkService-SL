using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class CredentialsRepository : ICredentialsRepository
    {
        private readonly DatabaseContext _dbContext;

        public CredentialsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Credentials credentials)
        {
            _dbContext.Set<Credentials>().Add(credentials);
        }

        public void Remove(Credentials credentials)
        {
            _dbContext.Set<Credentials>().Remove(credentials);
        }

        public void Update(Credentials credentials)
        {
            _dbContext.Set<Credentials>().Update(credentials);
        }
    }
}
