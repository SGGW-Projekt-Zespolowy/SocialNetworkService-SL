using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Contacts.Commands.AddContact;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Followers.Commands.AddFollower
{
    internal class AddFollowerCommandHandler : ICommandHandler<AddFollowerCommand>
    {
        private readonly IFollowerRepository _followerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddFollowerCommandHandler(IFollowerRepository followerRepository, IUnitOfWork unitOfWork)
        {
            _followerRepository = followerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(AddFollowerCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var followerId = request.followerId;
            var followedUserId = request.followedUserId;

            var follower = new Follower(id, followerId, followedUserId);


            _followerRepository.Add(follower, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
