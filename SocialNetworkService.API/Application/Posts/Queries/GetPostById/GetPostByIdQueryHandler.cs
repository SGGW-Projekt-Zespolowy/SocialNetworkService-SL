using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Users.Queries.GetUserById;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, GetPostByIdResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostByIdQueryHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetPostByIdResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.postId, cancellationToken);

            if (post == null)
            {
                return Result.Failure<GetPostByIdResponse>(Domain.Errors.ApplicationErrors.Post.PostNotFound(request.postId));
            }

            var response = new GetPostByIdResponse
                (post.Id,post.AuthorId,post.CreationDate, post.Content,post.Type,post.Title,post.ModificationDate, post.CaseResolved);
            return Result.Success(response);
        }
    }
}
