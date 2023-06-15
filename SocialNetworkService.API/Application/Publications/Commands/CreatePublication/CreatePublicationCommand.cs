using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Publications.Commands.CreatePublication
{
    public sealed record CreatePublicationCommand(
        Guid authorId, Title title, string content,
        Link link, string picture, MedicalSpecialization type) : ICommand;
}
