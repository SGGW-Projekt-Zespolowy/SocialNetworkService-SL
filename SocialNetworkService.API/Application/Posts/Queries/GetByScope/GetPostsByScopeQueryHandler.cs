using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Comments.Queries.GetCommentById;
using Application.Posts.Queries.GetByScope;
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
    public class GetPostsByScopeQueryHandler : IQueryHandler<GetPostsByScopeQuery,GetPostsByScopeQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostsByScopeQueryHandler(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetPostsByScopeQueryResponse>> Handle(GetPostsByScopeQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll(request.Page, request.PageSize, cancellationToken);

            if (posts.Count == 0)
            {
                return Result.Failure<GetPostsByScopeQueryResponse>(Domain.Errors.ApplicationErrors.Post.NoPostsFound());
            }

            var response = new GetPostsByScopeQueryResponse();
            
            foreach (var post in posts)
            {
                response.Posts.Add(new PostResponse(
                    post.Id, post.AuthorId, post.Content,
                    post.CreationDate, post.Type.Value, post.Title.Value, post.Comments));
            }

            return Result.Success(response);
        }
    }
}
