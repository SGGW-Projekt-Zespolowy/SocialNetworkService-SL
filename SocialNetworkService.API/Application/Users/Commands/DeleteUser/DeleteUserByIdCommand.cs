using Application.Abstractions.Messaging;

namespace Application.Users.Commands.DeleteUser
{
    public sealed record DeleteUserByIdCommand(Guid userId) : ICommand;
}
