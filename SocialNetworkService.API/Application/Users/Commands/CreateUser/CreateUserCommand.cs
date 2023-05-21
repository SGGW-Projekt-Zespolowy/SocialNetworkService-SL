using Application.Abstractions.Messaging;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(        
        string email,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string degree,
        string profilePicture
        ): ICommand;
}
