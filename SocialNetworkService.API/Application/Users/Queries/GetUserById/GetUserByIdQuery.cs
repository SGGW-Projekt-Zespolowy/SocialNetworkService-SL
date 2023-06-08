
using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid userId): IQuery<GetUserByIdResponse>;
    
}
