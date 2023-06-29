using Application.Abstractions.Messaging;

namespace Application.Followers.Commands.DeleteFollower
{
    public sealed record DeleteFollowerByIdsCommand(Guid followerId, Guid followedUserId) : ICommand;
}
