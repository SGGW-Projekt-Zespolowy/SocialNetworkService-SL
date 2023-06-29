using Application.Abstractions.Messaging;

namespace Application.Publications.Commands.DeletePublication
{
    public sealed record DeletePublicationByIdCommand(Guid publicationId) : ICommand;
}
