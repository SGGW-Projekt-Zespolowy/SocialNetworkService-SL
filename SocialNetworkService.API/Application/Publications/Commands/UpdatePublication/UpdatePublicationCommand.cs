using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Publications.Commands.UpdatePublication
{
    public sealed record UpdatePublicationCommand(
        Guid id, Title title, string content, Link link, 
        string picture, MedicalSpecialization type) : ICommand;
}
