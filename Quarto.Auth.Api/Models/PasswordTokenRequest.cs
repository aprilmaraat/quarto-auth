using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Models
{
    public class PasswordTokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
