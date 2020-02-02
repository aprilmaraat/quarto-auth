using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models.Entities
{
    public enum UserType : byte
    {
        LandOwner = 1,
        Tenant = 2
    }

    public class EnumUserType
    {
        public UserType ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Navigation property: To UserCred
        /// </summary>
        public virtual UserCred UserCred { get; set; }
    }
}
