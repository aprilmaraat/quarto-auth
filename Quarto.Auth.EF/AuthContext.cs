using Microsoft.EntityFrameworkCore;
using Quarto.Auth.Models;

namespace Quarto.Auth.EF
{
    public partial class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
        }
        public virtual DbSet<EnumUserType> EnumUserType { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<UserCred> UserCred { get; set; }
        public virtual DbSet<LoggingData> LoggingData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }

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

                entity.Property(e => e.ID);

                entity.Property(e => e.EmailAddress)
                    .HasColumnType("varchar(255)");
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_User.Data_EmailAddress")
                    .IsUnique();

                entity.Property(e => e.PasswordChangeDT)
                    .HasColumnType("datetime2(0)");
                entity.Property(e => e.ResetPassword)
                    .HasDefaultValueSql("0");
            });
            modelBuilder.Entity<UserCred>(entity => 
            {
                entity.ToTable("User.Cred");

                entity.HasKey(e => e.UserID);

                entity.Property(e => e.UserID);
                entity.Property(e => e.UserType).HasColumnType("tinyint");
                entity.Property(e => e.AuthenticationHash);
                entity.Property(e => e.LastUsedDT);

                entity.HasOne(e => e.User)
                    .WithOne(e => e.UserCred)
                    .HasForeignKey<UserCred>(e => e.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User.Cred_User.Data");

                entity.HasOne(e => e.EnumUserType)
                    .WithOne(e => e.UserCred)
                    .HasForeignKey<UserCred>(e => e.UserType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_User.Cred_enum.User.Type");
            });
            modelBuilder.Entity<LoggingData>(entity => 
            {
                entity.ToTable("Logging.Data");
                entity.Property(e => e.ID);
                entity.Property(e => e.ErrorType).HasColumnType("varchar(255)");
                entity.Property(e => e.Description).HasColumnType("varchar(max)");
                entity.HasKey(e => e.ID);
            });
        }
    }
}
