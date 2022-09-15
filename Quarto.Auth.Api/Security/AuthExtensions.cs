using System;
using Microsoft.AspNetCore.Authentication;

namespace Quarto.Auth.Security
{
    internal static class AuthExtensions
    {
        internal static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<AuthOptions> configureOptions)
        {
            return builder.AddScheme<AuthOptions, AuthHandler>(AuthOptions.DefaultScheme, AuthOptions.SchemeDisplayName, configureOptions);
        }
    }
}
