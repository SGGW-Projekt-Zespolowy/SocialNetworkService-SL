
using Application.Abstractions.Messaging;

namespace Application.Credentials.CreateCredentials
{
    public sealed record CreateCredentialsCommand(Guid userId, string password): ICommand;
}
