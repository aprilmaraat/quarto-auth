using Microsoft.EntityFrameworkCore;

namespace Auth.Models.Entities
{
    public partial class AuthContext : DbContext
    {
        public virtual DbSet<UserData> UserData { get; set; }
    }
}
