using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Image: Entity
    {
        public Image(Guid id, string data, Guid postId) : base(id)
        {
            Data = data;
            PostId = postId;
        }
        public string Data { get; set; }
        public Guid PostId { get; set; }        
    }
}
