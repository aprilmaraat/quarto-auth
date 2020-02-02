using System;
using System.Collections.Generic;
using System.Text;

namespace Quarto.Auth.Models.Entities
{
    public class UserCred
    {
        public int UserID { get; set; }
        public string AuthenticationHash { get; set; }
        public DateTime LastUsedDT { get; set; }
        /// <summary>
        /// Navigation Property: UserData
        /// </summary>
        public virtual UserData User { get; set; }
        public virtual EnumUserType EnumUserType { get; set; }
    }
}
