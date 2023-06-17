using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetUserByEmail
{
    public record GetUserByEmailQuery(string email): IQuery<bool>;
}
