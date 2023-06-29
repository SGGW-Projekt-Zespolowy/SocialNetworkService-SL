using Domain.Primitives;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.AspNetCore.Http;
using static Domain.Errors.ApplicationErrors;
using System.Threading;

namespace Domain.Entities
{
    public sealed class Image: Entity
    {
        public Image(Guid id, string data, Guid postId) : base(id)
        {
            Data = data;
            PostId = postId;
        }
        public string Data { get; private set; }
        public Guid PostId { get; private set; }        

        public static Result<Image> Encode(IFormFile file, Guid postId)
        {
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var base64 = Convert.ToBase64String(fileBytes);

                    var image = new Image(Guid.NewGuid(), base64, postId);

                    return image;
                }
            }
            else return Result.Failure<Image>(Errors.DomainErrors.Image.InvalidImageData);
        }
    }
}
