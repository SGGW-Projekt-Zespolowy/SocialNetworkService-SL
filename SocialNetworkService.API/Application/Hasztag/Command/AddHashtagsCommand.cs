using Application.Abstractions.Messaging;

namespace Application.Hasztag.Command
{
    public record AddHashtagsCommand(List<string> names, Guid relatedItemId): ICommand;
}
