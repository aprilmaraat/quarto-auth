using Microsoft.AspNetCore.Identity;
using Auth.Models.Entities;
using System.Threading.Tasks;

namespace Auth.Web.Services
{
    public class AuthService
    {
        private readonly AuthContext _authContext;
        public AuthService(AuthContext authContext)
        {
            _authContext = authContext;
        }

        private static string GetAuthHash(string password)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
            return password;
        }
    }
}
