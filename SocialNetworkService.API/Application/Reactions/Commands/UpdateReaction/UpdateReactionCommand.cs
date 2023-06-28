using Application.Abstractions.Messaging;

namespace Application.Reactions.Commands.UpdateReaction
{
    public sealed record UpdateReactionCommand(Guid id, string reactionType) : ICommand;
}
