using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries.GetCommentById
{
    public record GetCommentByIdWithAllResponse(
        Guid id, Guid authorId, string content, 
        DateTime creationDate, DateTime modificationDate,
        Guid parentPostId, Guid parentCommentId, bool relatedToComment,
        List<Comment> comments, List<Reaction> reactions);
}
