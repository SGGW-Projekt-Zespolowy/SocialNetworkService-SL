using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Repositories;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Followers.Commands.DeleteFollower
{
    public class DeleteFollowerByIdsCommandHandler : ICommandHandler<DeleteFollowerByIdsCommand>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFollowerByIdsCommandHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteFollowerByIdsCommand request, CancellationToken cancellationToken)
        {
            if (request.followerId == Guid.Empty || request.followedUserId == Guid.Empty)
                return Result.Failure(Domain.Errors.ApplicationErrors.Request.EmptyRequest);

            var follower = await _followerRepository.GetByIdsAsync(request.followerId, request.followedUserId, cancellationToken);

            if (follower is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Follower.FollowedUserNotFound(request.followerId, request.followedUserId));
            }

            _followerRepository.Remove(follower, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
