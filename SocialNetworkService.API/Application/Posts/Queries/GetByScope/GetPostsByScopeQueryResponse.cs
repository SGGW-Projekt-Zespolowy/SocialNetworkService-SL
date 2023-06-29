using Domain.Entities;

namespace Application.Posts.Queries.GetByScope
{
    public sealed class GetPostsByScopeQueryResponse
    {
        public GetPostsByScopeQueryResponse()
        {
            Posts = new List<PostResponse>();
        }
        public List<PostResponse> Posts { get; set; }
    }

    public class PostResponse
    {
        public PostResponse(Guid id, Guid authorId, string content, DateTime creationDate, string type,
            string title, List<Comment> comments, List<Hashtag> hashtags, bool isUp, bool isDown,
            bool isBookmarked, int reactionsCount, List<Image> images)
        {
            Id = id;
            AuthorId = authorId;
            CreationDate = creationDate;
            Content = content;
            Type = type;
            Title = title;
            Comments = comments;
            Hashtags = hashtags;
            IsUp = isUp;
            IsDown = isDown;
            IsBookmarked = isBookmarked;
            ReactionsCount = reactionsCount;
            Images = images;
        }
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; }
        public string Title { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();
        public List<Hashtag> Hashtags { get; private set; }
        public List<Image> Images { get; private set; }
        public bool IsUp { get; private set; }
        public bool IsDown { get; private set; }
        public bool IsBookmarked { get; private set; }
        public int ReactionsCount { get; private set; } 
    }
}
