using AlohaAPIExample.Models;
using IdentotyExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentotyExample.Data
{
    public class DataContext : IdentityDbContext <User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=testbaza;user=root;password=Sa21sa21sa21!;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                    .Property(b => b.FirstName)
                    .HasDefaultValue("DefaultName");

            modelBuilder.Entity<User>()
                .Property(b => b.LastName)
                .HasDefaultValue("DefaultName");

            modelBuilder.Entity<User>()
                .HasMany(user => user.Addresses)
                .WithOne(address => address.User)
                .IsRequired();

            modelBuilder.Entity<MenuItemOverride>(entity =>
            {
                entity.HasKey(e => new { e.SiteId, e.MenuId, e.MenuItemId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("menu_item_override");

                entity.Property(e => e.Description).HasMaxLength(45);
                entity.Property(e => e.ImageName).HasMaxLength(45);
                entity.Property(e => e.Name).HasMaxLength(45);
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Address> Address { get; set; }
        public virtual DbSet<MenuItemOverride> MenuItemOverrides { get; set; }

    }
}
