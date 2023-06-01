using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DatabaseContext _dbContext;

        public SpecializationRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Specialization specialization)
        {
            _dbContext.Set<Specialization>().Add(specialization);
        }

        public void Remove(Specialization specialization)
        {
            _dbContext.Set<Specialization>().Remove(specialization);
        }

        public void Update(Specialization specialization)
        {
            _dbContext.Set<Specialization>().Update(specialization);
        }
    }
}
