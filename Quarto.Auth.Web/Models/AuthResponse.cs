using Quarto.Auth.Models;
using Newtonsoft.Json;

namespace Quarto.Auth.Web.Models
{
    public class AuthResponse
    {
        [JsonProperty("user")]
        public LoginUser User { get; set; }
    }

    public class LoginUser
    {
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("userID")]
        public int UserID { get; set; }
        public UserData UserData { get; set; }
    }
}
