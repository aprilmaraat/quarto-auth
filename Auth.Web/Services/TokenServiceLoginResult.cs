using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Web.Services
{
    public class TokenServiceLoginResult
    {
        public AuthResponse TokenLoginResponse { get; internal set; }
        public bool Success { get; set; }
    }
}
