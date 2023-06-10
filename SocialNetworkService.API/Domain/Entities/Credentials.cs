using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Credentials : Entity
    {
        public Credentials(Guid id, Guid userId, string passwordHash, string passwordSalt, string token) :
            base(id)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Token = token;
            UserId = userId;
        }

        public Guid UserId;
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Token { get; set; } 
    }
}
