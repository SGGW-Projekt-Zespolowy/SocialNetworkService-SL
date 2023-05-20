using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateMemberCommand(        
        string email,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string degree,
        string profilePicture
        ): ICommand;
}
