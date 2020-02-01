using Microsoft.EntityFrameworkCore;

namespace Auth.Models.Entities
{
    public partial class AuthContext : DbContext
    {
        public virtual DbSet<UserData> UserData { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
