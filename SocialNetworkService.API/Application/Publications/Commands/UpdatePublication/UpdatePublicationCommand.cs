using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Publications.Commands.UpdatePublication
{
    public record class UpdatePublicationCommand(
        Guid id, string title, string content, string link, 
        string picture, string type) : ICommand;
}
