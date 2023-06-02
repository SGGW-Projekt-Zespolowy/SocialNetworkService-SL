using Domain.Entities;
using Domain.Repositories;
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

        public void Add(User user)
        {
            _dbContext.Set<User>().Add(user);
        }

        public async Task<User?> GetByIdWithAllAsync(Guid id)
        {
            return await _dbContext.Set<User>()
                .Include(x => x.Specializations)
                .Include(x => x.Contacts)
                .Include(x => x.Followers)
                .Include(x => x.Publications)
                .Include(x => x.Posts)
                .Include(x => x.Badges)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(User user)
        {
            _dbContext.Set<User>().Remove(user);
        }

        public void Update(User user)
        {
            _dbContext.Set<User>().Update(user);
        }
    }
}
