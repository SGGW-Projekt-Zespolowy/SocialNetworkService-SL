using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Posts.Queries.GetPostById
{
    public record GetPostByIdWithAllResponse(
        Guid id, Guid authorId, string content, MedicalSpecialization type, 
        Title title, DateTime modificationDate, List<Comment> comments);
}
