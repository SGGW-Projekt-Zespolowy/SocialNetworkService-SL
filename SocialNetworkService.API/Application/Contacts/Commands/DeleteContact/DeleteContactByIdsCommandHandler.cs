using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactByIdsCommandHandler : ICommandHandler<DeleteContactByIdsCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactByIdsCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteContactByIdsCommand request, CancellationToken cancellationToken)
        {
            if (request.userId == Guid.Empty || request.contactId == Guid.Empty)
                return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var firstUserContact = await _contactRepository.GetByIdsAsync(request.userId, request.contactId, cancellationToken);
            if (firstUserContact is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Contact.ContactNotFound(request.userId, request.contactId));
            }

            var secondUserContact = await _contactRepository.GetByIdsAsync(request.contactId, request.userId, cancellationToken);            

            var contacts = new List<Contact>() { firstUserContact, secondUserContact };

            _contactRepository.Remove(contacts, cancellationToken);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
