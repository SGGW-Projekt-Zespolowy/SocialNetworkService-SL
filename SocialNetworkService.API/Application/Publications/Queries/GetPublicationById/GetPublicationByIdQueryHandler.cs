using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Publications.Queries.GetPublicationById
{
    public class GetPublicationByIdQueryHandler : IQueryHandler<GetPublicationByIdQuery, GetPublicationByIdResponse>
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPublicationByIdQueryHandler(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetPublicationByIdResponse>> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.publicationId, cancellationToken);

            if (publication == null)
            {
                return Result.Failure<GetPublicationByIdResponse>(Domain.Errors.ApplicationErrors.Publication.PublicationNotFound(request.publicationId));
            }

            var response = new GetPublicationByIdResponse(
                publication.Id, publication.AuthorId, publication.Title, publication.Content, publication.Link, publication.Picture, publication.Type);
            return Result.Success(response);
        }
    }
}
