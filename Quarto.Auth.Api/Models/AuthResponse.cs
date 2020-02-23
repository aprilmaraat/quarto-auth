using Quarto.Auth.Models;
using Newtonsoft.Json;
using System;

namespace Quarto.Auth.Api.Models
{
    public class AuthResponse
    {
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}
