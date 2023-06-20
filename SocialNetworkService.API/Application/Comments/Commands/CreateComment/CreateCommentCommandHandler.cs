using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Posts.Commands.CreatePost;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var authorId = request.authorId;
            var content = Content.Create(request.content);
            var parentPostId = request.parentPostId;
            var parentCommentId = request.parentCommentId;
            var relatedToComment = request.relatedToComment;

            var comment = new Comment(id, authorId, content.Value, parentPostId, parentCommentId, relatedToComment);

            _commentRepository.Add(comment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
