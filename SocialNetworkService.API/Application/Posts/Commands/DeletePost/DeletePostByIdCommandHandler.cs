using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Posts.Commands.DeletePost
{
    public class DeletePostByIdCommandHandler : ICommandHandler<DeletePostByIdCommand>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostByIdCommandHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeletePostByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.postId == Guid.Empty) return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var post = await _postRepository.GetByIdAsync(request.postId, cancellationToken);

            if (post is not null)
            {
                _postRepository.Remove(post, cancellationToken);
            }
            else
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Post.PostNotFound(request.postId));
            }
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
