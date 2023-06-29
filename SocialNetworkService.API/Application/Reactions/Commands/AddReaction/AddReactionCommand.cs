using Application.Abstractions.Messaging;

namespace Application.Reactions.Commands.AddReaction
{
    public sealed record AddReactionCommand(string reactionType, Guid relatedItemId, Guid authorId) : ICommand;
}
