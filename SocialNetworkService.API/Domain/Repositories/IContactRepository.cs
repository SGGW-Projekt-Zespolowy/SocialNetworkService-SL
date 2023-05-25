using Domain.Entities;

namespace Domain.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Remove(Contact contact);
        void Update(Contact contact);
    }
}
