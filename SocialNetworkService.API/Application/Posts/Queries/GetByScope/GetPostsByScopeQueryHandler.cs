using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Comments.Queries.GetCommentById;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Posts.Queries.Get
{
    public class GetPostsByScopeQueryHandler : IQueryHandler<GetPostsByScopeQuery,List<Post>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsByScopeQueryHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Post>>> Handle(GetPostsByScopeQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll(request.Page, request.PageSize, cancellationToken);

            if (posts.Count == 0)
            {
                return Result.Failure<List<Post>>(Domain.Errors.ApplicationErrors.Post.NoPostsFound());
            }

            return Result.Success(posts);
        }
    }
}
