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
    }
}
