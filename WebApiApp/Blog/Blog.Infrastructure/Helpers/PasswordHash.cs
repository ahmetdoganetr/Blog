using System;
using System.Text;

namespace Blog.Infrastructure.Helpers
{
    public static class PasswordHash
    {
        public static void Create(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            try
            {
                if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();

                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException();

                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public  static bool Verify(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            try
            {
                if (string.IsNullOrEmpty(password)) throw new ArgumentNullException();

                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException();

                if (passwordHash.Length != 64) throw new ArgumentException();

                if (passwordSalt.Length != 128) throw new ArgumentException();

                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != passwordHash[i]) return false;
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
