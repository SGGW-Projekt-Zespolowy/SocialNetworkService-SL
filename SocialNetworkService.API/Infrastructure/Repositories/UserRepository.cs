using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Specifications;
using Infrastructure.Specifications.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user, CancellationToken cancellationToken)
        {
            _dbContext.Set<User>().Add(user);
        }

        public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
        => await ApplySpecification(new UserByEmailSpecification(email)).FirstOrDefaultAsync(cancellationToken);

        public async Task<User?> GetByFullNameAsync(string fullName, CancellationToken cancellationToken)
        => await ApplySpecification(new UserByFullNameSpecification(fullName)).FirstOrDefaultAsync(cancellationToken);

        public async Task<User?> GetByIdWithAllAsync(Guid id, CancellationToken cancellationToken)
        => await ApplySpecification(new UserByIdIncludeAllSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await ApplySpecification(new UserByIdSpecification(id)).FirstOrDefaultAsync(cancellationToken);

        public IQueryable<User> ApplySpecification(Specification<User> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<User>(), specification);
        }

        public void Remove(User user, CancellationToken cancellationToken)
        {
            _dbContext.Set<User>().Remove(user);
        }

        public void Update(User user, CancellationToken cancellationToken)
        {
            _dbContext.Set<User>().Update(user);
        }
    }
}
