using System.Security.Cryptography;
using System.Text;
using Report.Application.Interfaces;

namespace Report.Application.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            return BitConverter.ToString(bytes);
        }

        public bool IsCorrect(string password, string hashPassword)
        {
            var hashedPassword = HashPassword(password);

            if (hashedPassword == hashPassword)
                return true;

            return false;
        }

    }
}