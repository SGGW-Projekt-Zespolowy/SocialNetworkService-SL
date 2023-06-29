using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Posts.Queries.Get;
using Application.Posts.Queries.GetByScope;
using Domain.Repositories;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contacts.Queries.GetAllContactsByUserId
{
    public class GetAllContactsByUserIdQueryHandler : IQueryHandler<GetAllContactsByUserIdQuery, GetAllContactsByUserIdResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllContactsByUserIdQueryHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetAllContactsByUserIdResponse>> Handle(GetAllContactsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.GetAll(request.userId, request.Page, request.PageSize, cancellationToken);

            if (contacts.Count == 0)
            {
                return Result.Failure<GetAllContactsByUserIdResponse>(Domain.Errors.ApplicationErrors.Contact.ContactsNotFound(request.userId));
            }

            var response = new GetAllContactsByUserIdResponse();

            foreach (var contact in contacts)
            {
                response.Contacts.Add(new ContactResponse(
                    contact.Id,
                    contact.ContactUser.FirstName.Value,
                    contact.ContactUser.LastName.Value,
                    contact.ContactUser.Degree.Value,
                    contact.ContactUser.ProfilePicture));
            }

            return Result.Success(response);
        }
    }
}
