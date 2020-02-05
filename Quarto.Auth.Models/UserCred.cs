using System;

namespace Quarto.Auth.Models
{
    public class UserCred
    {
        public int UserID { get; set; }
        public UserType UserType { get; set; }
        public string AuthenticationHash { get; set; }
        public DateTime LastUsedDT { get; set; }
        /// <summary>
        /// Navigation Property: UserData
        /// </summary>
        public virtual UserData User { get; set; }
        public virtual EnumUserType EnumUserType { get; set; }
    }
}
