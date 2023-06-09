using Application.Abstractions.Messaging;

namespace Application.Users.Commands.UpdateUser
{
    public record class UpdateUserCommand(Guid userId,
        string email,string firstName, string lastName, string degree, string profilePicture): ICommand;
}
