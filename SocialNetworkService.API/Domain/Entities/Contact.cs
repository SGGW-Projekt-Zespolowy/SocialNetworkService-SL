using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Contact : Entity
    {
        public Contact(Guid id, Guid userId, Guid contactId) : base(id)
        {
            UserId = userId;
            ContactId = contactId;
        }

        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
    }
}
