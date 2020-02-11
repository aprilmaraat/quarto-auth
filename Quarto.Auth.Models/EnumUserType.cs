using Newtonsoft.Json;

namespace Quarto.Auth.Models
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
        /// Navigation property: UserCred
        /// </summary>
        [JsonIgnore]
        public virtual UserCred UserCred { get; set; }
    }
}
