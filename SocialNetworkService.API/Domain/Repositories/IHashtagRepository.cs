using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHashtagRepository
    {
        void Add(Hashtag hashtag);
        void Remove(Hashtag hashtag);
        void Update(Hashtag hashtag);
    }
}
