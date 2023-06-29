using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Comments.Commands.MarkCommentUsefull
{
    public sealed class MarkCommentUsefullCommandHandler : ICommandHandler<MarkCommentUsefullCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _commentRepository;

        public MarkCommentUsefullCommandHandler(IUnitOfWork unitOfWork, ICommentRepository commentRepository)
        {
            _unitOfWork = unitOfWork;
            _commentRepository = commentRepository;
        }

        public async Task<Result> Handle(MarkCommentUsefullCommand command, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(command.commentId, cancellationToken);
            if (comment is null)
                return Result.Failure(Domain.Errors.ApplicationErrors.Comment.CommentNotFound(command.commentId));

            comment.Update(null, command.isUsefull);
            _commentRepository.Update(comment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
