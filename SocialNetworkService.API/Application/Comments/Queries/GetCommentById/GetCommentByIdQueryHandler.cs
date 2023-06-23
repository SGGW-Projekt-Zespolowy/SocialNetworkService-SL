using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Users.Queries.GetUserById;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, GetCommentByIdResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentByIdQueryHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetCommentByIdResponse>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.commentId, cancellationToken);

            if (comment == null) 
                return Result.Failure<GetCommentByIdResponse>(Domain.Errors.ApplicationErrors.Comment.CommentNotFound(request.commentId));

            var response = new GetCommentByIdResponse(
                comment.Id, comment.AuthorId, comment.Content, 
                comment.CreationDate, comment.ModificationDate, 
                comment.ParentPostId, comment.ParentCommentId, comment.RelatedToComment);

            return Result.Success(response);
        }
    }
}
