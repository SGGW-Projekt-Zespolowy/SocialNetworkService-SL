using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Publications.Commands.CreatePublication
{
    public sealed record CreatePublicationCommand(
        Guid authorId, string title, string content,
        string link, string picture, string type) : ICommand;
}
