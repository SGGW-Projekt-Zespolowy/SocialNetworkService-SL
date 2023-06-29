using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Contacts.Queries.GetAllContactsByUserId;
using Domain.Repositories;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Followers.Queries.GetAllFollowersByUserId
{
    public class GetAllFollowersByFollowerIdQueryHandler : IQueryHandler<GetAllFollowersByFollowerIdQuery, GetAllFollowersByFollowerIdResponse>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFollowersByFollowerIdQueryHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetAllFollowersByFollowerIdResponse>> Handle(GetAllFollowersByFollowerIdQuery request, CancellationToken cancellationToken)
        {
            var followers = await _followerRepository.GetAll(request.followerId, request.page, request.pageSize, cancellationToken);

            if (followers.Count == 0)
            {
                return Result.Failure<GetAllFollowersByFollowerIdResponse>(Domain.Errors.ApplicationErrors.Follower.FollowedUsersNotFound(request.followerId));
            }

            var response = new GetAllFollowersByFollowerIdResponse();

            foreach (var follower in followers)
            {
                response.Followers.Add(new FollowerResponse(
                    follower.Id,
                    follower.FollowedUser.FirstName.Value,
                    follower.FollowedUser.LastName.Value,
                    follower.FollowedUser.Degree.Value,
                    follower.FollowedUser.ProfilePicture));
            }

            return Result.Success(response);
        }
    }
}
