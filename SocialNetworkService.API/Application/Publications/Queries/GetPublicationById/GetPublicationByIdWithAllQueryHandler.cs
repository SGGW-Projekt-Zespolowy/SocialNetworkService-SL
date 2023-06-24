using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Publications.Queries.GetPublicationById
{
    public class GetPublicationByIdWithAllQueryHandler : IQueryHandler<GetPublicationByIdWithAllQuery, GetPublicationByIdWithAllResponse>
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPublicationByIdWithAllQueryHandler(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetPublicationByIdWithAllResponse>> Handle(GetPublicationByIdWithAllQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdWithAllAsync(request.publicationId, cancellationToken);

            if (publication is null)
            {
                return Result.Failure<GetPublicationByIdWithAllResponse>(Domain.Errors.ApplicationErrors.Publication.PublicationNotFound(request.publicationId));
            }

            var response = new GetPublicationByIdWithAllResponse(
                publication.Id, publication.AuthorId, publication.Title,
                publication.Content, publication.Link, publication.Picture, 
                publication.Type, publication.CreationDate, publication.ModificationDate, publication.CoAuthors);

            return Result.Success(response);
        }
    }
}
