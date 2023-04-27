using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Credentials : Entity
    {
        public Credentials(Guid id, string passwordHash, string passwordSalt, string token) :
            base(id)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Token = token;
        }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Token { get; set; }
    }
}
