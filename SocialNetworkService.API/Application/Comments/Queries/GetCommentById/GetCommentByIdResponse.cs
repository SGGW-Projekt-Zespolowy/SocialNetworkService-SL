using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries.GetCommentById
{
    public record GetCommentByIdResponse(
        Guid id, Guid authorId, string content,
        DateTime creationDate, DateTime modificationDate,
        Guid parentPostId, Guid parentCommentId, bool relatedToComment);
}
