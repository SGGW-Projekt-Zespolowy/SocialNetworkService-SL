using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.PostBookmarks.Commands.AddPostBookmark
{
    public sealed class AddPostBookmarkCommandHandler : ICommandHandler<AddPostBookmarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostBookmarkRepository _postBookmarkRepository;

        public AddPostBookmarkCommandHandler(IUnitOfWork unitOfWork, IPostBookmarkRepository postBookmarkRepository)
        {
            _unitOfWork = unitOfWork;
            _postBookmarkRepository = postBookmarkRepository;
        }

        public async Task<Result> Handle(AddPostBookmarkCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return Result.Failure(Domain.Errors.ApplicationErrors.General.NullRequest);
            if (request.userId == Guid.Empty) 
                return Result.Failure(Domain.Errors.ApplicationErrors.PostBookmark.EmptyUserId);
            if (request.postId == Guid.Empty)
                return Result.Failure(Domain.Errors.ApplicationErrors.PostBookmark.EmptyPostId);

            var postBookmark = new PostBookmark(Guid.NewGuid(),request.postId, request.userId);
            _postBookmarkRepository.Add(postBookmark, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
