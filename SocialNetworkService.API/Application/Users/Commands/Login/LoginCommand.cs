using Application.Abstractions.Messaging;

namespace Application.Users.Commands.Login
{
    public record LoginCommand(string email,string password): ICommand<string>;
}
