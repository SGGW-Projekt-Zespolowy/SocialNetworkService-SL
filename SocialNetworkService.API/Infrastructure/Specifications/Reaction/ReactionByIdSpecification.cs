namespace Infrastructure.Specifications
{
    public class ReactionByIdSpecification : Specification<Domain.Entities.Reaction>
    {
        public ReactionByIdSpecification(Guid id)
            : base(reaction => reaction.Id == id) { }
    }
}