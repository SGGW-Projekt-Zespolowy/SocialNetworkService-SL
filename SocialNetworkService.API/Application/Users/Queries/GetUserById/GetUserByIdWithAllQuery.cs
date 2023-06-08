using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetUserById
{
    public record GetUserByIdWithAllQuery(Guid userId) : IQuery<GetUserByIdWithAllResponse>;
}
