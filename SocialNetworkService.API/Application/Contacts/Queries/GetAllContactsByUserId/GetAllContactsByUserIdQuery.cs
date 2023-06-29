using Application.Abstractions.Messaging;
using Application.Contacts.Queries.GetAllContactsByUserId;

namespace Application.Posts.Queries.Get
{
    public sealed record GetAllContactsByUserIdQuery(Guid userId, int Page, int PageSize) : IQuery<GetAllContactsByUserIdResponse>;
}
