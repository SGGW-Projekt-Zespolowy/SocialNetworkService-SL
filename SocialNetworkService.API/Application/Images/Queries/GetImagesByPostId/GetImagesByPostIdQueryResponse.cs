namespace Application.Images.Queries.GetImagesByPostId
{
    public sealed class GetImagesByPostIdQueryResponse
    {
        public List<ImageResponse> images { get; private set; }

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
