using System;
using Newtonsoft.Json;

namespace Quarto.Auth.Models
{
    public class UserCred
    {
        public int UserID { get; set; }
        public UserType UserType { get; set; }
        public string AuthenticationHash { get; set; }
        public DateTime LastUsedDT { get; set; }
        /// <summary>
        /// Navigation property: UserData
        /// </summary>
        [JsonIgnore]
        public virtual UserData User { get; set; }
        /// <summary>
        /// Navigation property: EnumUserType
        /// </summary>
        [JsonIgnore]
        public virtual EnumUserType EnumUserType { get; set; }
    }
}
