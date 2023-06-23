namespace Infrastructure.Specifications.Comment
{
    public class CommentByIdSpecification : Specification<Domain.Entities.Comment>
    {
        public CommentByIdSpecification(Guid id) : base(comment => comment.Id == id) { }
    }
}
