using Microsoft.AspNetCore.Authentication;

namespace Quarto.Auth.Security
{
    public class QuartoAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "Quarto";
        public const string SchemeDisplayName = "Quarto Scheme";
    }
}
