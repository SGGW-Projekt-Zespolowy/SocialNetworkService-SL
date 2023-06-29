using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Followers.Queries.GetAllFollowedUsersByFollowerId;
using Domain.Repositories;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Followers.Queries.GetAllFollowersByFollowedUserId
{
    public class GetAllFollowersByFollowedUserIdQueryHandler : IQueryHandler<GetAllFollowersByFollowedUserIdQuery, GetAllFollowersByFollowedUserIdResponse>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFollowersByFollowedUserIdQueryHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetAllFollowersByFollowedUserIdResponse>> Handle(GetAllFollowersByFollowedUserIdQuery request, CancellationToken cancellationToken)
        {
            var followers = await _followerRepository.GetAllFollowers(request.followedUserId, request.page, request.pageSize, cancellationToken);

            if (followers.Count == 0)
            {
                return Result.Failure<GetAllFollowersByFollowedUserIdResponse>(Domain.Errors.ApplicationErrors.Follower.FollowersOfUserNotFound(request.followedUserId));
            }

            var response = new GetAllFollowersByFollowedUserIdResponse();

            foreach (var follower in followers)
            {
                response.Followers.Add(new FollowerResponse(
                    follower.FollowerUser.Id,
                    follower.FollowerUser.FirstName.Value,
                    follower.FollowerUser.LastName.Value,
                    follower.FollowerUser.Degree.Value,
                    follower.FollowerUser.ProfilePicture));
            }

            return Result.Success(response);
        }
    }
}
