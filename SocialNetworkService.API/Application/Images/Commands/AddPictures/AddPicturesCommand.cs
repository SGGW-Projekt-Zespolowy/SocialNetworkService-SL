using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http;

namespace Application.Images.Commands.AddPicture
{
    public record AddPicturesCommand(List<IFormFile> images, Guid postId) : ICommand;
}
