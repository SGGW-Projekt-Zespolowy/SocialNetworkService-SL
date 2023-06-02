using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    internal class ReactionRepository : IReactionRepository
    {
        private readonly DatabaseContext _dbContext;

        public ReactionRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Reaction reaction)
        {
            _dbContext.Set<Reaction>().Add(reaction);    
        }

        public void Remove(Reaction reaction)
        {
            _dbContext.Set<Reaction>().Remove(reaction);
        }

        public void Update(Reaction reaction)
        {
            _dbContext.Set<Reaction>().Update(reaction);
        }
    }
}
