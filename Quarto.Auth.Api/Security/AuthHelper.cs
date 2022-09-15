using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Quarto.Auth.Security
{
    public static class AuthHelper
    {
        private static void AddClaim(ClaimsIdentity identity, string type, string value)
        {
            if (value != null)
            {
                identity.AddClaim(new Claim(type, value));
            }
        }
        private static void AddClaim<T>(ClaimsIdentity identity, string type, T value)
            where T : struct
        {
            AddClaim(identity, type, value.ToString());
        }
        private static string ReadClaim(ClaimsIdentity identity, string claimName, string defaultValue)
        {
            Claim claim = identity.Claims.FirstOrDefault(t => t.Type == claimName);

            if (claim == null)
                return defaultValue;

            return claim.Value;
        }
        private static T ReadClaim<T>(ClaimsIdentity identity, string claimName, T defaultValue)
            where T : struct
        {
            Claim claim = identity.Claims.FirstOrDefault(t => t.Type == claimName);

            if (claim == null)
                return defaultValue;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, claim.Value);
        }
    }
}
