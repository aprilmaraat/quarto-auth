using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Models.Entities
{
    public class UserCred
    {
        public int UserID { get; set; }
        public string AuthenticationHash { get; set; }
        public DateTime LastUsedDT { get; set; }
        /// <summary>
        /// Navigation Property: UserData
        /// </summary>
        //public UserData User { get; set; }
    }
}
