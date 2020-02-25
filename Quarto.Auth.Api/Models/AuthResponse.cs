using Quarto.Auth.Models;
using Newtonsoft.Json;
using System;

namespace Quarto.Auth.Api.Models
{
    public class AuthResponse
    {
        public string EmailAddress { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
