namespace Application.Images.Queries.GetImagesByPostId
{
    public sealed class GetImagesByPostIdQueryResponse
    {
        public List<ImageResponse> Images { get; private set; }

        public GetImagesByPostIdQueryResponse(List<ImageResponse> images)
        {
            this.images = images;
        }
        public void Add(ImageResponse image)
        {
            images.Add(image);
        }
    }
}
