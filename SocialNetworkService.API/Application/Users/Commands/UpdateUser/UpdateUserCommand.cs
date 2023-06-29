using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http;

namespace Application.Users.Commands.UpdateUser
{
    public record class UpdateUserCommand(Guid userId,
        string email,string firstName, string lastName, string degree, string profilePic): ICommand;
}
