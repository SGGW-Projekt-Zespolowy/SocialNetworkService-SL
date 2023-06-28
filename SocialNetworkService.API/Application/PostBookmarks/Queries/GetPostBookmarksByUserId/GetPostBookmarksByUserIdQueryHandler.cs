using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.PostBookmarks.Queries.GetPostBookmarksByUserId
{
    public sealed class GetPostBookmarksByUserIdQueryHandler : IQueryHandler<GetPostBookmarksByUserIdQuery, List<PostBookmarkResponse>>
    {
        private readonly IPostBookmarkRepository _repository;

        public GetPostBookmarksByUserIdQueryHandler(IPostBookmarkRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<PostBookmarkResponse>>> Handle(GetPostBookmarksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var postBookmarks = await _repository.GetAll(request.userId, cancellationToken);
            if (postBookmarks is null)
                return Result.Failure<List<PostBookmarkResponse>>
                    (Domain.Errors.ApplicationErrors.PostBookmark.BookmarkNotFound);

            var postBookmarksResponse = new List<PostBookmarkResponse>();
            foreach ( var postBookmark in postBookmarks)
            {
                postBookmarksResponse.Add(
                    new PostBookmarkResponse(postBookmark.Id, postBookmark.PostId, postBookmark.UserId));
            }

            return postBookmarksResponse;
        }
    }
}
