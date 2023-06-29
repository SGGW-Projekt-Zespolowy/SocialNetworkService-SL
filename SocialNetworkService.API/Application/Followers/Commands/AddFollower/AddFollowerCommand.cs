using Application.Abstractions.Messaging;

namespace Application.Followers.Commands.AddFollower
{
    public sealed record AddFollowerCommand(Guid followerId, Guid followedUserId) : ICommand;
}
