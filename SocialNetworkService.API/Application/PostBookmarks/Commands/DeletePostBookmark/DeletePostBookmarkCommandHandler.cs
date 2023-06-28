using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.PostBookmarks.Commands.DeletePostBookmark
{
    public sealed class DeletePostBookmarkCommandHandler : ICommandHandler<DeletePostBookmarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostBookmarkRepository _postBookmarkRepository;

        public DeletePostBookmarkCommandHandler(IUnitOfWork unitOfWork, IPostBookmarkRepository postBookmarkRepository)
        {
            _unitOfWork = unitOfWork;
            _postBookmarkRepository = postBookmarkRepository;
        }

        public async Task<Result> Handle(DeletePostBookmarkCommand request, CancellationToken cancellationToken)
        {
            var postBookmark = await _postBookmarkRepository.GetById(request.postBookmarkId, cancellationToken);
            if (postBookmark is null)
                return Result.Failure(Domain.Errors.ApplicationErrors.PostBookmark.BookmarkNotFound);

            await _postBookmarkRepository.Remove(postBookmark,cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
