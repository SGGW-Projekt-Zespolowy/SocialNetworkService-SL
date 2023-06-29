using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(        
        string email,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string degree
        ): ICommand<User>;
}
