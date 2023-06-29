using Domain.Entities;
using Domain.Shared;

namespace Application.Images.Queries.GetImagesByPostId
{
    public class ImageResponse
    {
        public ImageResponse(string image, Guid postId, Guid id)
        {
            Image = image;
            PostId = postId;
            Id = id;
        }
        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public string Image { get; private set; }    
        
        public static Result<ImageResponse> Decode(Image image)
        {
            if (image is null)
                return Result.Failure<ImageResponse>(Domain.Errors.ApplicationErrors.General.NullObject);

            var imageData = string.Format("data:image/png;base64,{0}", image.Data);
            var readableData = new ImageResponse(imageData, image.PostId, image.Id);

            return readableData;
        }
    }
}
