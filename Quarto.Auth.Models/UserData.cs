using System;
using Newtonsoft.Json;

namespace Quarto.Auth.Models
{
    public partial class UserData
    {
        public int ID { get; set; }
        public string EmailAddress { get; set; }
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
        [JsonIgnore]
        public virtual UserCred UserCred { get; set; }
    }
}
