
using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetUserByFullName
{
    public record GetUserByFullNameQuery (string fullName) : IQuery<GetUserByFullNameResponse>;
}
