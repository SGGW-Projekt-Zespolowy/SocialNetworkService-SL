using Application.Abstractions.Messaging;

namespace Application.Credentials.Login
{
    public record LoginCommand(string email, string password) : ICommand<string>;
}
