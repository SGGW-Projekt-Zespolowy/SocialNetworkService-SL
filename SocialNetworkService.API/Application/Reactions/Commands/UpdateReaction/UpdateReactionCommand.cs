using Application.Abstractions.Messaging;

namespace Application.Reactions.Commands.UpdateReaction
{
    public sealed record UpdateReactionCommand(Guid relatedItemId, Guid authorId, string reactionType) : ICommand;
}
