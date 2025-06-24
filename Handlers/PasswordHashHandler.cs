using Microsoft.AspNetCore.Identity;
using WebAPI.Models.Entities;

namespace WebAPI.Handlers
{
    public static class PasswordHashHandler
    {
        private static readonly PasswordHasher<User> _hasher = new();

        public static string HashPassword(string rawPassword)
        {
            return _hasher.HashPassword(null!, rawPassword);
        }

        public static bool VerifyPassword(User user, string rawPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, user.Password, rawPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}