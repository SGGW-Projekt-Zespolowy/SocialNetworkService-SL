using Domain.Primitives;
using System.Security.Cryptography;

namespace Domain.Entities
{
    public sealed class Credentials : Entity
    {
        private Credentials(Guid id, Guid userId, byte[] passwordHash, byte[] passwordSalt, string token) :
            base(id)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Token = token;
            UserId = userId;
        }

        public Guid UserId;
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public string Token { get; set; } 

        public static Credentials Create(Guid userId, string password)
        {
            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);

            var credentials = new Credentials(new Guid(), userId, passwordHash, passwordSalt, string.Empty);
            return credentials;
        }

        public bool ValidatePassword(string password)
        {
            using(var hmac =  new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(PasswordHash);
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
