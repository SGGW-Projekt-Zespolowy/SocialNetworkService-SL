using Application.Abstractions.Messaging;

namespace Application.Reactions.Commands.DeleteReaction
{
    public sealed record DeleteReactionByIdCommand(Guid reactionId) : ICommand;
}
