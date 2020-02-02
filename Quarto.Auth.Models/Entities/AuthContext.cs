using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Quarto.Auth.Models.Entities
{
    public partial class AuthContext : DbContext
    {
        public virtual DbSet<EnumUserType> EnumUserType { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<UserCred> UserCred { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<EnumUserType>(entity =>
            {
                entity.ToTable("enum.User.Type");

                entity.Property(e => e.ID)
                    .HasColumnType("tinyint")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)");
            });
            modelBuilder.Entity<UserData>(entity => 
            {
                entity.ToTable("User.Data");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(255)")
                    .IsRequired();
                entity.HasIndex(e => e.UserName)
                    .HasName("IX_User.Data_UserName");

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(255)");
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_User.Data_EmailAddress");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DisplayName)
                    .HasColumnType("varchar(255)");


                entity.Property(e => e.PasswordChangeDT)
                    .HasColumnType("datetime2(0)");
                entity.Property(e => e.ResetPassword)
                    .HasDefaultValueSql("0");
            });
        }
    }
}
