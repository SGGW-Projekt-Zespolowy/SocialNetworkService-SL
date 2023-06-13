using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Posts.Commands.CreatePost
{
    public sealed record CreatePostCommand(
        Guid authorId, string content, MedicalSpecialization type, Title title
        ) : ICommand;
}
