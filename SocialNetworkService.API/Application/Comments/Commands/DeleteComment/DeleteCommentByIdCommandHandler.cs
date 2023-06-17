using Application.Abstractions;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentByIdCommandHandler
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentByIdCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.commentId == Guid.Empty) return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var comment = await _commentRepository.GetByIdAsync(request.commentId, cancellationToken);

            if (comment is not null)
            {
                _commentRepository.Remove(comment, cancellationToken);
            }
            else
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Comment.CommentNotFound(request.commentId));
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
