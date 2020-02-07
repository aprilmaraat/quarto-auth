using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quarto.Auth.Api.Models;

namespace Quarto.Auth.Api.Services
{
    public class TokenServiceLoginResult
    {
        public AuthResponse TokenLoginResponse { get; internal set; }
        public bool Success { get; set; }
    }
}
