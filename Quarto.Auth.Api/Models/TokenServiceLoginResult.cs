using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarto.Auth.Models
{
    public class TokenServiceLoginResult
    {
        public AuthResponse LoginResponse { get; set; }
        public bool Success { get; set; }
    }
}
