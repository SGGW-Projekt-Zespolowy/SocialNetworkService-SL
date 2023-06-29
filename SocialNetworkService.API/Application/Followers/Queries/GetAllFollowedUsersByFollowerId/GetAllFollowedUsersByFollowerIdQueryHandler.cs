using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Followers.Queries.GetAllFollowedUsersByFollowerId
{
    public class GetAllFollowedUsersByFollowerIdQueryHandler : IQueryHandler<GetAllFollowedUsersByFollowerIdQuery, GetAllFollowedUsersByFollowerIdResponse>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFollowedUsersByFollowerIdQueryHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetAllFollowedUsersByFollowerIdResponse>> Handle(GetAllFollowedUsersByFollowerIdQuery request, CancellationToken cancellationToken)
        {
            var followedUsers = await _followerRepository.GetAllFollowedUsers(request.followerId, request.page, request.pageSize, cancellationToken);

            if (followedUsers.Count == 0)
            {
                return Result.Failure<GetAllFollowedUsersByFollowerIdResponse>(Domain.Errors.ApplicationErrors.Follower.FollowedUsersNotFound(request.followerId));
            }

            var response = new GetAllFollowedUsersByFollowerIdResponse();

            foreach (var followedUser in followedUsers)
            {
                response.FollowedUsers.Add(new FollowedUserResponse(
                    followedUser.FollowedUser.Id,
                    followedUser.FollowedUser.FirstName.Value,
                    followedUser.FollowedUser.LastName.Value,
                    followedUser.FollowedUser.Degree.Value,
                    followedUser.FollowedUser.ProfilePicture));
            }

            return Result.Success(response);
        }
    }
}
