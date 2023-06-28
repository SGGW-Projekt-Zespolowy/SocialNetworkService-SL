using Application.Abstractions.Messaging;

namespace Application.Contacts.Commands.AddContact
{
    public sealed record AddContactCommand(Guid userId, Guid contactId) : ICommand;
}
