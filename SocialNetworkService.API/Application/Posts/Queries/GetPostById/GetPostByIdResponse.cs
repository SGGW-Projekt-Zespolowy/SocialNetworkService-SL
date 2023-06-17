using Domain.ValueObjects;

namespace Application.Posts.Queries.GetPostById
{
    public record GetPostByIdResponse(
        Guid id, 
        Guid authorId, 
        DateTime creationDate,
        string content, 
        MedicalSpecialization type, 
        Title title, 
        DateTime modificationDate);
}
