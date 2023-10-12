using System.Security.Cryptography;
using System.Text;

namespace BlogAnimalApi.Helper
{
    public class Util
    {
        public string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string newlyHashedPassword = hashPassword(password);
            return newlyHashedPassword == hashedPassword;
        }
    }
}
