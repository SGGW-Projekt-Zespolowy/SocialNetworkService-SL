using Application.Abstractions.Messaging;

namespace Application.Images.Commands.DeletePictures
{
    public record DeletePicturesCommand(List<Guid> imageIds): ICommand;
        
}
