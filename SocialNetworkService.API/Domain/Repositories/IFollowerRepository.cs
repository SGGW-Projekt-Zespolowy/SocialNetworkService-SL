using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFollowerRepository
    {
        void Add(Follower follower);
        void Remove(Follower follower);
        void Update(Follower follower);
    }
}
