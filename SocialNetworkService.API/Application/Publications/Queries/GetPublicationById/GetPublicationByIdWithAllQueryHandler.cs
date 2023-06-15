using Application.Abstractions;
using Domain.Repositories;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Publications.Queries.GetPublicationById
{
    public class GetPublicationByIdWithAllQueryHandler
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPublicationByIdWithAllQueryHandler(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetPublicationByIdWithAllResponse>> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdWithAllAsync(request.publicationId, cancellationToken);

            if (publication == null)
            {
                return Result.Failure<GetPublicationByIdWithAllResponse>(Domain.Errors.ApplicationErrors.Publication.PublicationNotFound(request.publicationId));
            }

            var response = new GetPublicationByIdWithAllResponse(
                publication.Id, publication.AuthorId, publication.Title,
                publication.Content, publication.Link, publication.Picture, 
                publication.Type, publication.CoAuthors, publication.Comments
                );

            return Result.Success(response);
        }
    }
}
