using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFollowerRepository
    {
        Task<Follower> GetByIdsAsync(Guid followerId, Guid followedUserId, CancellationToken cancellationToken);
        Task<List<Follower>> GetAllFollowedUsers(Guid followerId, int page, int pageSize, CancellationToken cancellationToken);
        Task<List<Follower>> GetAllFollowers(Guid followedUserId, int page, int pageSize, CancellationToken cancellationToken);
        void Add(Follower follower, CancellationToken cancellationToken);
        void Remove(Follower follower, CancellationToken cancellationToken);
    }
}
