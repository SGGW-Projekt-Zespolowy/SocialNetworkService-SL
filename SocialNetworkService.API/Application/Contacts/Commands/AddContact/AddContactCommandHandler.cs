using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Contacts.Commands.AddContact
{
    internal class AddContactCommandHandler : ICommandHandler<AddContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var userId = request.userId;
            var contactId = request.contactId;

            List<Contact> contacts = new List<Contact>()
            {
                new Contact(id, userId, contactId),
                new Contact(id, contactId, userId)
            };


            _contactRepository.Add(contacts, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
