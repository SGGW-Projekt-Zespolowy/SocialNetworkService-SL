using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class HashtagRepository : IHashtagRepository
    {
        private readonly DatabaseContext _dbContext;

        public HashtagRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Hashtag hashtag)
        {
            _dbContext.Set<Hashtag>().Add(hashtag);
        }

        public void Remove(Hashtag hashtag)
        {
            _dbContext.Set<Hashtag>().Remove(hashtag);
        }

        public void Update(Hashtag hashtag)
        {
            _dbContext.Set<Hashtag>().Update(hashtag);
        }
    }
}
