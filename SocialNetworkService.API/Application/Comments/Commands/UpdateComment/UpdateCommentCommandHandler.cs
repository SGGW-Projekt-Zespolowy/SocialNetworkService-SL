using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : ICommandHandler<UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.commentId, cancellationToken);

            if (comment is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Comment.CommentNotFound(request.commentId));
            }

            var content = request.content != string.Empty ? Content.Create(request.content) : null;

            if (content is not null && content.IsFailure) return Result.Failure(ValueObjectErrors.ContentIsInvalid);

            var usefull = request.usefull is null ? null : request.usefull;

            comment.Update(content?.Value, usefull);
            _commentRepository.Update(comment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
