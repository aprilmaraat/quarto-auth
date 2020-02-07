using Newtonsoft.Json;
using Quarto.Auth.Models;

namespace Quarto.Auth.Api.Models
{
    public interface IPasswordTokenRequest
    { 
        string Password { get; set; }
        string UserName { get; set; }
    }
    public class PasswordTokenRequest : IPasswordTokenRequest
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }

        public UserType UserType { get; set; }
    }

    public class PasswordTokenFormRequest : IPasswordTokenRequest
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
