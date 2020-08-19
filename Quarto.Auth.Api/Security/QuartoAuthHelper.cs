using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Quarto.Auth.Security
{
    public static class QuartoAuthHelper
    {
        private static void AddClaim(ClaimsIdentity identity, string type, string value)
        {
            if (value != null)
            {
                identity.AddClaim(new Claim(type, value));
            }
        }

        //public static ClaimsPrincipal CreateIdentity()
    }
}
