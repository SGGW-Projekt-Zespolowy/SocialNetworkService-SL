using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICoAuthorRepository
    {
        void Add(CoAuthor coAuthor);
        void Remove(CoAuthor coAuthor);
        void Update(CoAuthor coAuthor);
    }
}
