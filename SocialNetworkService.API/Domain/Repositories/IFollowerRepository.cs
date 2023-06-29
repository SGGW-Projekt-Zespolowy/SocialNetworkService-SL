using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<Follower> GetByIdsAsync(Guid followerId, Guid followedUserId, CancellationToken cancellationToken);
        Task<List<Follower>> GetAll(Guid followerId, int page, int pageSize, CancellationToken cancellationToken);
        void Add(Follower follower, CancellationToken cancellationToken);
        void Remove(Follower follower, CancellationToken cancellationToken);
    }
}
