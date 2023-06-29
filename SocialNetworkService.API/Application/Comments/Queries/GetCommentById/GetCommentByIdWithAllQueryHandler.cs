using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdWithAllQueryHandler : IQueryHandler<GetCommentByIdWithAllQuery, GetCommentByIdWithAllResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentByIdWithAllQueryHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCommentByIdWithAllResponse>> Handle(GetCommentByIdWithAllQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdWithAllAsync(request.commentId, cancellationToken);

            if (comment == null)
            {
                return Result.Failure<GetCommentByIdWithAllResponse>(Domain.Errors.ApplicationErrors.Comment.CommentNotFound(request.commentId));
            }

            var response = new GetCommentByIdWithAllResponse(
                comment.Id, comment.AuthorId, comment.Content,
                comment.CreationDate, comment.ModificationDate,
                comment.ParentPostId, comment.ParentCommentId,
                comment.RelatedToComment);

            return Result.Success(response);
        }
    }
}
