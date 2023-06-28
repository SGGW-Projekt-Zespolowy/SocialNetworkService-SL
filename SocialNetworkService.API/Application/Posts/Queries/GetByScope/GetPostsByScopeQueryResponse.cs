using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public PostResponse(Guid id, Guid authorId, string content, DateTime creationDate, string type, string title, List<Comment> comments)
        {
            Id = id;
            AuthorId = authorId;
            CreationDate = creationDate;
            Content = content;
            Type = type;
            Title = title;
            Comments = comments;
        }
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreationDate { get; init; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; }
        public string Title { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();
    }
}
