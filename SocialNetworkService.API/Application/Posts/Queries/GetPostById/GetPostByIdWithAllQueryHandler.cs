using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Posts.Queries.GetPostById
{
    public class GetPostByIdWithAllQueryHandler : IQueryHandler<GetPostByIdWithAllQuery, GetPostByIdWithAllResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostByIdWithAllQueryHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetPostByIdWithAllResponse>> Handle(GetPostByIdWithAllQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdWithAllAsync(request.postId, cancellationToken);
            if (post == null)
            {
                return Result.Failure<GetPostByIdWithAllResponse>(Domain.Errors.ApplicationErrors.Post.PostNotFound(request.postId));
            }

            var response = new GetPostByIdWithAllResponse(
                post.Id, post.AuthorId, post.Content, post.Type, post.Title, post.ModificationDate, post.Comments);
            return Result.Success(response);
        }
    }
}
