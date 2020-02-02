using System;
using System.Collections.Generic;
using System.Text;

namespace Quarto.Auth.Models
{
    public partial class UserData
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string DisplayName { get; set; }
        /// <summary>
        /// Date and time of the last password change of user.
        /// </summary>
        public DateTime? PasswordChangeDT { get; set; }
        /// <summary>
        /// Set to true if this user needs to reset password
        /// </summary>
        public bool ResetPassword { get; set; }
        /// <summary>
        /// Navigation property: UserCred
        /// </summary>
        public virtual UserCred UserCred { get; set; }
    }
}
