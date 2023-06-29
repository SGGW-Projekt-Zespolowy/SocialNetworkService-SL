using Application.Abstractions.Messaging;

namespace Application.Contacts.Commands.DeleteContact
{
    public sealed record DeleteContactByIdsCommand(Guid userId, Guid contactId) : ICommand;
}
