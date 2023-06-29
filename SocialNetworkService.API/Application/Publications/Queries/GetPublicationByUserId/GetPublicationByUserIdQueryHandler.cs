using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Publications.Queries.GetPublicationByUserId
{
    public sealed class GetPublicationByUserIdQueryHandler : IQueryHandler<GetPublicationByUserIdQuery, List<GetPublicationByUserIdResponse>>
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserRepository _userRepository;

        public GetPublicationByUserIdQueryHandler(IPublicationRepository publicationRepository, IUserRepository userRepository)
        {
            _publicationRepository = publicationRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<List<GetPublicationByUserIdResponse>>> Handle(GetPublicationByUserIdQuery request, 
                                                                    CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId,cancellationToken);
            if (user is null)
                return Result.Failure<List<GetPublicationByUserIdResponse>>
                    (Domain.Errors.ApplicationErrors.User.UserNotFound(request.userId));

            var publications = await _publicationRepository.GetByUserIdWithAllAsync(request.userId, cancellationToken);
            var publicationsResponse = publications.Select(x => new GetPublicationByUserIdResponse(
                x.Id, x.AuthorId, x.Title, x.Content, x.Link, x.Type, x.CreationDate, x.CoAuthors)).ToList();

            if (publicationsResponse.Count == 0) return new List<GetPublicationByUserIdResponse>();

            return publicationsResponse;
        }
    }
}
